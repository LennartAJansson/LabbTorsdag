namespace Workloads.Features.Customers.GetAll;

public sealed record GetAllWorkloadCustomersResponse(IReadOnlyList<WorkloadCustomerResponse> Customers);

public sealed record WorkloadCustomerResponse(Guid Id, string CompanyName);
