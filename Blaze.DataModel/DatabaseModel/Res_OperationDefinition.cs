using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OperationDefinition : ResourceIndexBase
  {
    public int Res_OperationDefinitionID {get; set;}
    public string base_FhirId {get; set;}
    public string base_Type {get; set;}
    public virtual Blaze_RootUrlStore base_Url { get; set; }
    public int? base_Url_Blaze_RootUrlStoreID { get; set; }
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string instance_Code {get; set;}
    public string instance_System {get; set;}
    public string kind_Code {get; set;}
    public string kind_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string system_Code {get; set;}
    public string system_System {get; set;}
    public string url_Uri {get; set;}
    public string version_Code {get; set;}
    public string version_System {get; set;}
    public ICollection<Res_OperationDefinition_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_OperationDefinition_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_OperationDefinition_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_OperationDefinition_History> Res_OperationDefinition_History_List { get; set; }
    public ICollection<Res_OperationDefinition_Index_context> context_List { get; set; }
    public ICollection<Res_OperationDefinition_Index_paramprofile> paramprofile_List { get; set; }
    public ICollection<Res_OperationDefinition_Index_type> type_List { get; set; }
   
    public Res_OperationDefinition()
    {
      this.context_List = new HashSet<Res_OperationDefinition_Index_context>();
      this.paramprofile_List = new HashSet<Res_OperationDefinition_Index_paramprofile>();
      this.type_List = new HashSet<Res_OperationDefinition_Index_type>();
      this.meta_tag_List = new HashSet<Res_OperationDefinition_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_OperationDefinition_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_OperationDefinition_Index_meta_profile>();
      this.Res_OperationDefinition_History_List = new HashSet<Res_OperationDefinition_History>();
    }
  }
}

