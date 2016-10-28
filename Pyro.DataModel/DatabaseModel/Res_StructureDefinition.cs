using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_StructureDefinition : ResourceIndexBase
  {
    public int Res_StructureDefinitionID {get; set;}
    public string abstract_Code {get; set;}
    public string abstract_System {get; set;}
    public string base_Uri {get; set;}
    public string context_type_Code {get; set;}
    public string context_type_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string derivation_Code {get; set;}
    public string derivation_System {get; set;}
    public string description_String {get; set;}
    public string display_String {get; set;}
    public string experimental_Code {get; set;}
    public string experimental_System {get; set;}
    public string kind_Code {get; set;}
    public string kind_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public string url_Uri {get; set;}
    public string version_Code {get; set;}
    public string version_System {get; set;}
    public ICollection<Res_StructureDefinition_History> Res_StructureDefinition_History_List { get; set; }
    public ICollection<Res_StructureDefinition_Index_base_path> base_path_List { get; set; }
    public ICollection<Res_StructureDefinition_Index_code> code_List { get; set; }
    public ICollection<Res_StructureDefinition_Index_context> context_List { get; set; }
    public ICollection<Res_StructureDefinition_Index_ext_context> ext_context_List { get; set; }
    public ICollection<Res_StructureDefinition_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_StructureDefinition_Index_path> path_List { get; set; }
    public ICollection<Res_StructureDefinition_Index_valueset> valueset_List { get; set; }
    public ICollection<Res_StructureDefinition_Index__profile> _profile_List { get; set; }
    public ICollection<Res_StructureDefinition_Index__security> _security_List { get; set; }
    public ICollection<Res_StructureDefinition_Index__tag> _tag_List { get; set; }
   
    public Res_StructureDefinition()
    {
      this.base_path_List = new HashSet<Res_StructureDefinition_Index_base_path>();
      this.code_List = new HashSet<Res_StructureDefinition_Index_code>();
      this.context_List = new HashSet<Res_StructureDefinition_Index_context>();
      this.ext_context_List = new HashSet<Res_StructureDefinition_Index_ext_context>();
      this.identifier_List = new HashSet<Res_StructureDefinition_Index_identifier>();
      this.path_List = new HashSet<Res_StructureDefinition_Index_path>();
      this.valueset_List = new HashSet<Res_StructureDefinition_Index_valueset>();
      this._profile_List = new HashSet<Res_StructureDefinition_Index__profile>();
      this._security_List = new HashSet<Res_StructureDefinition_Index__security>();
      this._tag_List = new HashSet<Res_StructureDefinition_Index__tag>();
      this.Res_StructureDefinition_History_List = new HashSet<Res_StructureDefinition_History>();
    }
  }
}

