namespace Customers.Features.Customers.Core;

using Common;

public interface IRequestHandler<TRequest, TResponse>
{
  Task<Result<TResponse>> HandleAsync(TRequest request);
}
