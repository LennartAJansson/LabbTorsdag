<#
.SYNOPSIS
Creates ten test customers and ten test employees through the running API.
.DESCRIPTION
Verifies that all created IDs reach the Workloads projections via Channel events.
Each run creates new records; no existing data is modified or deleted.
Employee identity numbers are generated test values with valid dates and Luhn checksums,
not verified or reserved identities. Use only against a development database.
If a request fails, the script stops; records already created are not rolled back.
.EXAMPLE
.\scripts\Seed-TestData.ps1
.EXAMPLE
.\scripts\Seed-TestData.ps1 -BaseUrl https://localhost:7086 -ProjectionTimeoutSeconds 60
#>
[CmdletBinding()]
param(
  [ValidateScript({ $_.IsAbsoluteUri -and $_.Scheme -in @('http', 'https') -and -not $_.Query -and -not $_.Fragment })]
  [uri] $BaseUrl = 'https://localhost:7086',

  [ValidateRange(1, 300)]
  [int] $ProjectionTimeoutSeconds = 30
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$root = $BaseUrl.AbsoluteUri.TrimEnd('/')
$runId = [guid]::NewGuid().ToString('N').Substring(0, 8)
$created = [System.Collections.Generic.List[object]]::new()

function New-TestIdentityNumber {
  param([int] $Index)

  $date = ([datetime]::new(1990, 1, 1)).AddDays($Index - 1)
  $firstNine = $date.ToString('yyMMdd') + '001'
  $sum = 0
  for ($position = 0; $position -lt $firstNine.Length; $position++) {
    $digit = [int]::Parse($firstNine.Substring($position, 1))
    if ($position % 2 -eq 0) {
      $digit *= 2
      if ($digit -gt 9) { $digit -= 9 }
    }
    $sum += $digit
  }
  $checksum = (10 - ($sum % 10)) % 10
  return $date.ToString('yyyyMMdd') + '-001' + $checksum
}

function Add-SeedRecord {
  param([string] $Path, [string] $Type, [string] $Name, [hashtable] $Payload)

  $json = $Payload | ConvertTo-Json -Compress
  $response = Invoke-RestMethod -Uri "$root/$Path" -Method Post `
    -ContentType 'application/json; charset=utf-8' -Body ([System.Text.Encoding]::UTF8.GetBytes($json))
  $id = [guid]::Empty
  if (-not [guid]::TryParse([string] $response.id, [ref] $id) -or $id -eq [guid]::Empty) {
    throw "POST /$Path returned no valid ID for '$Name'. Seeding stopped."
  }

  $created.Add([pscustomobject]@{ Type = $Type; Id = $id; Name = $Name })
  Write-Host "Created $Type '$Name' ($id)"
}

Write-Host "Seeding development API at $root (run $runId). Each run adds 20 records."
for ($i = 1; $i -le 10; $i++) {
  $number = '{0:D2}' -f $i
  $companyName = "Seed $runId Company $number"
  Add-SeedRecord -Path 'customers/' -Type 'Customer' -Name $companyName -Payload @{
    companyName = $companyName
    organizationNumber = "TEST-$runId-$number"
    contactName = "Test Contact $number"
    street = "Testgatan $i"
    postalCode = '11122'
    city = 'Teststad'
    phone = "07000000$number"
  }
}

for ($i = 1; $i -le 10; $i++) {
  $number = '{0:D2}' -f $i
  $givenName = "Seed-$number"
  $surname = "Test-$runId"
  Add-SeedRecord -Path 'employee' -Type 'Employee' -Name "$givenName $surname" -Payload @{
    ssid = New-TestIdentityNumber -Index $i
    title = 'Test technician'
    givenName = $givenName
    surname = $surname
    street = "Testvagen $i"
    postalCode = '22233'
    city = 'Teststad'
    phone = "07000001$number"
  }
}

Write-Host 'Waiting for the Workloads projections...'
$timer = [System.Diagnostics.Stopwatch]::StartNew()
do {
  $customers = Invoke-RestMethod -Uri "$root/workloadcustomers" -Method Get
  $employees = Invoke-RestMethod -Uri "$root/workloademployees" -Method Get
  $customerIds = @($customers.customers | ForEach-Object { [guid] $_.id })
  $employeeIds = @($employees.employees | ForEach-Object { [guid] $_.id })
  $missing = @($created | Where-Object {
    if ($_.Type -eq 'Customer') { $_.Id -notin $customerIds }
    else { $_.Id -notin $employeeIds }
  })

  if ($missing.Count -eq 0) { break }
  if ($timer.Elapsed.TotalSeconds -ge $ProjectionTimeoutSeconds) {
    $details = ($missing | ForEach-Object { "$($_.Type) '$($_.Name)' ($($_.Id))" }) -join '; '
    throw "Workloads projection timed out after $ProjectionTimeoutSeconds seconds. Missing: $details. The created records have not been removed."
  }
  Start-Sleep -Milliseconds 250
} while ($true)

Write-Host 'Verified: all 10 customers and 10 employees are present in Workloads.'
$created
