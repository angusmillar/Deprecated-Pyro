using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_CompartmentDefinition
  {
    public int Res_CompartmentDefinitionID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string name_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string url_Uri {get; set;}
    public ICollection<Res_CompartmentDefinition_Index_resource> resource_List { get; set; }
   
    public Res_CompartmentDefinition()
    {
      this.resource_List = new HashSet<Res_CompartmentDefinition_Index_resource>();
    }
  }
}

