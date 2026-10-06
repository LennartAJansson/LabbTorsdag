namespace WebApplication1.Features.Customers.Core;

using WebApplication1.Core;

public interface IRequestHandler<TRequest, TResponse>
{
  Task<Result<TResponse>> HandleAsync(TRequest request);
}
