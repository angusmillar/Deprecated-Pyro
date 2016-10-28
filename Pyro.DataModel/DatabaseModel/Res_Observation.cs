using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Observation : ResourceIndexBase
  {
    public int Res_ObservationID {get; set;}
    public DateTimeOffset? date_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? date_DateTimeOffsetHigh {get; set;}
    public string device_VersionId {get; set;}
    public string device_FhirId {get; set;}
    public string device_Type {get; set;}
    public virtual ServiceRootURL_Store device_Url { get; set; }
    public int? device_ServiceRootURL_StoreID { get; set; }
    public string encounter_VersionId {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual ServiceRootURL_Store encounter_Url { get; set; }
    public int? encounter_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string specimen_VersionId {get; set;}
    public string specimen_FhirId {get; set;}
    public string specimen_Type {get; set;}
    public virtual ServiceRootURL_Store specimen_Url { get; set; }
    public int? specimen_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? value_date_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? value_date_DateTimeOffsetHigh {get; set;}
    public Hl7.Fhir.Model.Quantity.QuantityComparator? value_quantity_Comparator {get; set;}
    public decimal? value_quantity_Quantity {get; set;}
    public string value_quantity_System {get; set;}
    public string value_quantity_Code {get; set;}
    public string value_quantity_Unit {get; set;}
    public string value_string_String {get; set;}
    public ICollection<Res_Observation_History> Res_Observation_History_List { get; set; }
    public ICollection<Res_Observation_Index_category> category_List { get; set; }
    public ICollection<Res_Observation_Index_code> code_List { get; set; }
    public ICollection<Res_Observation_Index_data_absent_reason> data_absent_reason_List { get; set; }
    public ICollection<Res_Observation_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Observation_Index_method> method_List { get; set; }
    public ICollection<Res_Observation_Index_performer> performer_List { get; set; }
    public ICollection<Res_Observation_Index_related_target> related_target_List { get; set; }
    public ICollection<Res_Observation_Index_related_type> related_type_List { get; set; }
    public ICollection<Res_Observation_Index_value_concept> value_concept_List { get; set; }
    public ICollection<Res_Observation_Index_value_quantity> value_quantity_List { get; set; }
    public ICollection<Res_Observation_Index_value_string> value_string_List { get; set; }
    public ICollection<Res_Observation_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Observation_Index__security> _security_List { get; set; }
    public ICollection<Res_Observation_Index__tag> _tag_List { get; set; }
   
    public Res_Observation()
    {
      this.category_List = new HashSet<Res_Observation_Index_category>();
      this.code_List = new HashSet<Res_Observation_Index_code>();
      this.data_absent_reason_List = new HashSet<Res_Observation_Index_data_absent_reason>();
      this.identifier_List = new HashSet<Res_Observation_Index_identifier>();
      this.method_List = new HashSet<Res_Observation_Index_method>();
      this.performer_List = new HashSet<Res_Observation_Index_performer>();
      this.related_target_List = new HashSet<Res_Observation_Index_related_target>();
      this.related_type_List = new HashSet<Res_Observation_Index_related_type>();
      this.value_concept_List = new HashSet<Res_Observation_Index_value_concept>();
      this.value_quantity_List = new HashSet<Res_Observation_Index_value_quantity>();
      this.value_string_List = new HashSet<Res_Observation_Index_value_string>();
      this._profile_List = new HashSet<Res_Observation_Index__profile>();
      this._security_List = new HashSet<Res_Observation_Index__security>();
      this._tag_List = new HashSet<Res_Observation_Index__tag>();
      this.Res_Observation_History_List = new HashSet<Res_Observation_History>();
    }
  }
}

