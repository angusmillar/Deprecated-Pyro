using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_StructureDefinition_History
  {
    public int Res_StructureDefinitionID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_StructureDefinition Res_StructureDefinition { get; set; }
   
    public Res_StructureDefinition_History()
    {
    }
  }
}

