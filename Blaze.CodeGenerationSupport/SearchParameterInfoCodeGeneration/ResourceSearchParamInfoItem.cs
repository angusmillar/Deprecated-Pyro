using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration
{
  public class ResourceSearchParamInfoItem
  {
    public string SearchParameterNameType { get; set; }
    public string ResourceName { get; set; }
    public string DbSearchParameterType { get; set; }
    public List<string> ModifierList { get; set; }
    public List<string> TypeModifierResourceList { get; set; }
    public List<string> PrefixList { get; set; }
    public bool IsDbCollection { get; set; }
    public string DbPropertyName { get; set; }
  }
}
