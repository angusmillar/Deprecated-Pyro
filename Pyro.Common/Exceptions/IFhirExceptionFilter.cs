using System.Web.Http.Filters;

namespace Pyro.Common.Exceptions
{
  public interface IFhirExceptionFilter : IFilter
  {
    void OnException(HttpActionExecutedContext context);
  }
}