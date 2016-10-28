using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
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
    public Hl7.Fhir.Model.Quantity.QuantityComparator? near_distance_Comparator {get; set;}
    public decimal? near_distance_Quantity {get; set;}
    public string near_distance_System {get; set;}
    public string near_distance_Code {get; set;}
    public string near_distance_Unit {get; set;}
    public string organization_VersionId {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual ServiceRootURL_Store organization_Url { get; set; }
    public int? organization_ServiceRootURL_StoreID { get; set; }
    public string partof_VersionId {get; set;}
    public string partof_FhirId {get; set;}
    public string partof_Type {get; set;}
    public virtual ServiceRootURL_Store partof_Url { get; set; }
    public int? partof_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Location_History> Res_Location_History_List { get; set; }
    public ICollection<Res_Location_Index_address> address_List { get; set; }
    public ICollection<Res_Location_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Location_Index_name> name_List { get; set; }
    public ICollection<Res_Location_Index_type> type_List { get; set; }
    public ICollection<Res_Location_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Location_Index__security> _security_List { get; set; }
    public ICollection<Res_Location_Index__tag> _tag_List { get; set; }
   
    public Res_Location()
    {
      this.address_List = new HashSet<Res_Location_Index_address>();
      this.identifier_List = new HashSet<Res_Location_Index_identifier>();
      this.name_List = new HashSet<Res_Location_Index_name>();
      this.type_List = new HashSet<Res_Location_Index_type>();
      this._profile_List = new HashSet<Res_Location_Index__profile>();
      this._security_List = new HashSet<Res_Location_Index__security>();
      this._tag_List = new HashSet<Res_Location_Index__tag>();
      this.Res_Location_History_List = new HashSet<Res_Location_History>();
    }
  }
}

