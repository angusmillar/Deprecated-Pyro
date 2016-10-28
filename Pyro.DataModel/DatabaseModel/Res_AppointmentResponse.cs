using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_AppointmentResponse : ResourceIndexBase
  {
    public int Res_AppointmentResponseID {get; set;}
    public string actor_VersionId {get; set;}
    public string actor_FhirId {get; set;}
    public string actor_Type {get; set;}
    public virtual ServiceRootURL_Store actor_Url { get; set; }
    public int? actor_ServiceRootURL_StoreID { get; set; }
    public string appointment_VersionId {get; set;}
    public string appointment_FhirId {get; set;}
    public string appointment_Type {get; set;}
    public virtual ServiceRootURL_Store appointment_Url { get; set; }
    public int? appointment_ServiceRootURL_StoreID { get; set; }
    public string location_VersionId {get; set;}
    public string location_FhirId {get; set;}
    public string location_Type {get; set;}
    public virtual ServiceRootURL_Store location_Url { get; set; }
    public int? location_ServiceRootURL_StoreID { get; set; }
    public string part_status_Code {get; set;}
    public string part_status_System {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string practitioner_VersionId {get; set;}
    public string practitioner_FhirId {get; set;}
    public string practitioner_Type {get; set;}
    public virtual ServiceRootURL_Store practitioner_Url { get; set; }
    public int? practitioner_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_AppointmentResponse_History> Res_AppointmentResponse_History_List { get; set; }
    public ICollection<Res_AppointmentResponse_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_AppointmentResponse_Index__profile> _profile_List { get; set; }
    public ICollection<Res_AppointmentResponse_Index__security> _security_List { get; set; }
    public ICollection<Res_AppointmentResponse_Index__tag> _tag_List { get; set; }
   
    public Res_AppointmentResponse()
    {
      this.identifier_List = new HashSet<Res_AppointmentResponse_Index_identifier>();
      this._profile_List = new HashSet<Res_AppointmentResponse_Index__profile>();
      this._security_List = new HashSet<Res_AppointmentResponse_Index__security>();
      this._tag_List = new HashSet<Res_AppointmentResponse_Index__tag>();
      this.Res_AppointmentResponse_History_List = new HashSet<Res_AppointmentResponse_History>();
    }
  }
}

