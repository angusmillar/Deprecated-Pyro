using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Service;

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
