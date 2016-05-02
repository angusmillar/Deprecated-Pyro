using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_StructureMap
  {
    public int Res_StructureMapID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string description_String {get; set;}
    public string experimental_Code {get; set;}
    public string experimental_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string url_Uri {get; set;}
    public string version_Code {get; set;}
    public string version_System {get; set;}
    public ICollection<Res_StructureMap_Index_context> context_List { get; set; }
    public ICollection<Res_StructureMap_Index_identifier> identifier_List { get; set; }
   
    public Res_StructureMap()
    {
      this.context_List = new HashSet<Res_StructureMap_Index_context>();
      this.identifier_List = new HashSet<Res_StructureMap_Index_identifier>();
    }
  }
}

