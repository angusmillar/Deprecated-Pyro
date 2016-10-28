using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.CodeGenerationSupport.SearchParameterInfoCodeGeneration
{
  public class ResourceSearchParamInfo
  {
    public string ResourceName { get; set; }
    public List<ResourceSearchParamInfoItem> ResourceSearchParamInfoItemList { get; set; }
  }
}
