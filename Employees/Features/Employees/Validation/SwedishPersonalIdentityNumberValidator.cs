namespace Employees.Features.Employees.Validation;

using System.Globalization;

/// <summary>
/// Validates Swedish personal identity numbers (personnummer).
/// </summary>
/// <remarks>
/// Accepts the formats <c>YYYYMMDD-XXXX</c>, <c>YYMMDD-XXXX</c> and <c>YYMMDDXXXX</c>.
/// A <c>+</c> separator instead of <c>-</c> indicates the person is over 100 years old.
/// The last four digits consist of a birth number followed by a checksum digit validated
/// using the Luhn algorithm.
/// </remarks>
public static class SwedishPersonalIdentityNumberValidator
{
  public static bool IsValid(string? value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      return false;
    }

    var digitsOnly = NormalizeToTenOrTwelveDigits(value, out var isOverHundred);
    if (digitsOnly is null)
    {
      return false;
    }

    var datePart = digitsOnly.Length == 12 ? digitsOnly[..8] : $"19{digitsOnly[..6]}";
    var birthNumberAndChecksum = digitsOnly.Length == 12 ? digitsOnly[8..] : digitsOnly[6..];

    if (!DateTime.TryParseExact(datePart, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
    {
      return false;
    }

    var checksumInput = digitsOnly.Length == 12 ? digitsOnly[2..] : digitsOnly;

    return HasValidLuhnChecksum(checksumInput);
  }

  private static string? NormalizeToTenOrTwelveDigits(string value, out bool isOverHundred)
  {
    isOverHundred = value.Contains('+');
    var cleaned = value.Replace("-", string.Empty).Replace("+", string.Empty);

    if (cleaned.Length is not (10 or 12) || !cleaned.All(char.IsDigit))
    {
      return null;
    }

    return cleaned;
  }

  private static bool HasValidLuhnChecksum(string tenDigits)
  {
    if (tenDigits.Length != 10)
    {
      return false;
    }

    var sum = 0;
    for (var i = 0; i < tenDigits.Length; i++)
    {
      var digit = tenDigits[i] - '0';
      if (i % 2 == 0)
      {
        digit *= 2;
        if (digit > 9)
        {
          digit -= 9;
        }
      }

      sum += digit;
    }

    return sum % 10 == 0;
  }
}
