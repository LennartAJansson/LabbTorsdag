namespace Workloads.Features.Employees.GetAll;

public sealed record GetAllWorkloadEmployeesResponse(IReadOnlyList<WorkloadEmployeeResponse> Employees);

public sealed record WorkloadEmployeeResponse(Guid Id, string GivenName, string Surname);
