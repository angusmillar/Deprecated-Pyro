using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_DeviceUseRequest : ResourceIndexBase
  {
    public int Res_DeviceUseRequestID {get; set;}
    public DateTimeOffset? author_date_DateTimeOffset {get; set;}
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
    public DateTimeOffset? event_date_DateTimeOffsetLow {get; set;}
    public DateTimeOffset? event_date_DateTimeOffsetHigh {get; set;}
    public string filler_VersionId {get; set;}
    public string filler_FhirId {get; set;}
    public string filler_Type {get; set;}
    public virtual ServiceRootURL_Store filler_Url { get; set; }
    public int? filler_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string requester_VersionId {get; set;}
    public string requester_FhirId {get; set;}
    public string requester_Type {get; set;}
    public virtual ServiceRootURL_Store requester_Url { get; set; }
    public int? requester_ServiceRootURL_StoreID { get; set; }
    public string requisition_Code {get; set;}
    public string requisition_System {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_DeviceUseRequest_History> Res_DeviceUseRequest_History_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_based_on> based_on_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_code> code_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_definition> definition_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_replaces> replaces_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_stage> stage_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index__profile> _profile_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index__security> _security_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index__tag> _tag_List { get; set; }
   
    public Res_DeviceUseRequest()
    {
      this.based_on_List = new HashSet<Res_DeviceUseRequest_Index_based_on>();
      this.code_List = new HashSet<Res_DeviceUseRequest_Index_code>();
      this.definition_List = new HashSet<Res_DeviceUseRequest_Index_definition>();
      this.identifier_List = new HashSet<Res_DeviceUseRequest_Index_identifier>();
      this.replaces_List = new HashSet<Res_DeviceUseRequest_Index_replaces>();
      this.stage_List = new HashSet<Res_DeviceUseRequest_Index_stage>();
      this._profile_List = new HashSet<Res_DeviceUseRequest_Index__profile>();
      this._security_List = new HashSet<Res_DeviceUseRequest_Index__security>();
      this._tag_List = new HashSet<Res_DeviceUseRequest_Index__tag>();
      this.Res_DeviceUseRequest_History_List = new HashSet<Res_DeviceUseRequest_History>();
    }
  }
}

