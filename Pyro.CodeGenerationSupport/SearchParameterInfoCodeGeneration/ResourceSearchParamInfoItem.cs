using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.CodeGenerationSupport.SearchParameterInfoCodeGeneration
{
  public class ResourceSearchParamInfoItem
  {
    public string SearchParameterNameType { get; set; }    
    public string ResourceType { get; set; }
    public string DbSearchParameterType { get; set; }
    public List<string> ModifierList { get; set; }
    public List<string> TypeModifierResourceList { get; set; }
    public List<string> PrefixList { get; set; }
    public string IsDbCollection { get; set; }
    public string DbBasePropertyName { get; set; }
  }
}
