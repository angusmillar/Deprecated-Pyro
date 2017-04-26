using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.CodeGeneration.Model
{
  public class MainModel
  {
    public List<string> GetResourceNameList()
    {      
      return ModelInfo.SupportedResources;
    }
  }
}
