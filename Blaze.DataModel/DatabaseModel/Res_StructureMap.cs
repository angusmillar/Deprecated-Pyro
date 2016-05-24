using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_StructureMap : ResourceIndexBase
  {
    public int Res_StructureMapID {get; set;}
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
    public ICollection<Res_StructureMap_History> Res_StructureMap_History_List { get; set; }
    public ICollection<Res_StructureMap_Index_context> context_List { get; set; }
    public ICollection<Res_StructureMap_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_StructureMap_Index_profile> profile_List { get; set; }
    public ICollection<Res_StructureMap_Index_security> security_List { get; set; }
    public ICollection<Res_StructureMap_Index_tag> tag_List { get; set; }
   
    public Res_StructureMap()
    {
      this.context_List = new HashSet<Res_StructureMap_Index_context>();
      this.identifier_List = new HashSet<Res_StructureMap_Index_identifier>();
      this.profile_List = new HashSet<Res_StructureMap_Index_profile>();
      this.security_List = new HashSet<Res_StructureMap_Index_security>();
      this.tag_List = new HashSet<Res_StructureMap_Index_tag>();
      this.Res_StructureMap_History_List = new HashSet<Res_StructureMap_History>();
    }
  }
}

