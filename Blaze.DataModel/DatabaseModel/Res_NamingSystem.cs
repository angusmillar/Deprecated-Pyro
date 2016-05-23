using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_NamingSystem : ResourceIndexBase
  {
    public int Res_NamingSystemID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string kind_Code {get; set;}
    public string kind_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string replaced_by_FhirId {get; set;}
    public string replaced_by_Type {get; set;}
    public virtual Blaze_RootUrlStore replaced_by_Url { get; set; }
    public int? replaced_by_Url_Blaze_RootUrlStoreID { get; set; }
    public string responsible_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_NamingSystem_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_NamingSystem_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_NamingSystem_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_NamingSystem_History> Res_NamingSystem_History_List { get; set; }
    public ICollection<Res_NamingSystem_Index_contact> contact_List { get; set; }
    public ICollection<Res_NamingSystem_Index_context> context_List { get; set; }
    public ICollection<Res_NamingSystem_Index_id_type> id_type_List { get; set; }
    public ICollection<Res_NamingSystem_Index_period> period_List { get; set; }
    public ICollection<Res_NamingSystem_Index_telecom> telecom_List { get; set; }
    public ICollection<Res_NamingSystem_Index_type> type_List { get; set; }
    public ICollection<Res_NamingSystem_Index_value> value_List { get; set; }
   
    public Res_NamingSystem()
    {
      this.contact_List = new HashSet<Res_NamingSystem_Index_contact>();
      this.context_List = new HashSet<Res_NamingSystem_Index_context>();
      this.id_type_List = new HashSet<Res_NamingSystem_Index_id_type>();
      this.period_List = new HashSet<Res_NamingSystem_Index_period>();
      this.telecom_List = new HashSet<Res_NamingSystem_Index_telecom>();
      this.type_List = new HashSet<Res_NamingSystem_Index_type>();
      this.value_List = new HashSet<Res_NamingSystem_Index_value>();
      this.meta_tag_List = new HashSet<Res_NamingSystem_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_NamingSystem_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_NamingSystem_Index_meta_profile>();
      this.Res_NamingSystem_History_List = new HashSet<Res_NamingSystem_History>();
    }
  }
}

