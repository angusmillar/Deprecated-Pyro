using Pyro.Common.Service.SearchParameters;

namespace Pyro.Common.Search
{
  public class DtoServiceSearchParameter : DtoServiceSearchParameterLight
  {
    public string Description { get; set; }
    public string Url { get; set; }
    public string XPath { get; set; }
    public SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }
  }
}
