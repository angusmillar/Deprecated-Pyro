using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Location : ResourceIndexBase
  {
    public int Res_LocationID {get; set;}
    public string address_city_String {get; set;}
    public string address_country_String {get; set;}
    public string address_postalcode_String {get; set;}
    public string address_state_String {get; set;}
    public string address_use_Code {get; set;}
    public string address_use_System {get; set;}
    public string name_String {get; set;}
    public string near_Code {get; set;}
    public string near_System {get; set;}
    public string near_distance_Code {get; set;}
    public string near_distance_System {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual Blaze_RootUrlStore organization_Url { get; set; }
    public int? organization_Url_Blaze_RootUrlStoreID { get; set; }
    public string partof_FhirId {get; set;}
    public string partof_Type {get; set;}
    public virtual Blaze_RootUrlStore partof_Url { get; set; }
    public int? partof_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Location_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_Location_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_Location_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_Location_History> Res_Location_History_List { get; set; }
    public ICollection<Res_Location_Index_address> address_List { get; set; }
    public ICollection<Res_Location_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Location_Index_type> type_List { get; set; }
   
    public Res_Location()
    {
      this.address_List = new HashSet<Res_Location_Index_address>();
      this.identifier_List = new HashSet<Res_Location_Index_identifier>();
      this.type_List = new HashSet<Res_Location_Index_type>();
      this.meta_tag_List = new HashSet<Res_Location_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_Location_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_Location_Index_meta_profile>();
      this.Res_Location_History_List = new HashSet<Res_Location_History>();
    }
  }
}

