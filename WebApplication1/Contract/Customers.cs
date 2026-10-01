namespace WebApplication1.Contract;

public record CreateCustomerRequest(
  string CompanyName
);

public record CreateCustomerResponse(
  Guid Id,
  string CompanyName
);

public record UpdateCustomerRequest(
  Guid Id,
  string CompanyName
);

public record UpdateCustomerResponse(
  Guid Id,
  string CompanyName
);

public record DeleteCustomerResponse(
  Guid Id,
  string CompanyName
);

public record GetCustomerResponse(
  Guid Id,
  string CompanyName
);
