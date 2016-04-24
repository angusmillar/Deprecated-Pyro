using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_AppointmentResponse
  {
    public int Res_AppointmentResponseID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public string actor_FhirId {get; set;}
    public string actor_Type {get; set;}
    public virtual Aux_RootUrlStore actor_Aux_RootUrlStoreID { get; set; }
    public string appointment_FhirId {get; set;}
    public string appointment_Type {get; set;}
    public virtual Aux_RootUrlStore appointment_Aux_RootUrlStoreID { get; set; }
    public string location_FhirId {get; set;}
    public string location_Type {get; set;}
    public virtual Aux_RootUrlStore location_Aux_RootUrlStoreID { get; set; }
    public string part_status_Code {get; set;}
    public string part_status_System {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string practitioner_FhirId {get; set;}
    public string practitioner_Type {get; set;}
    public virtual Aux_RootUrlStore practitioner_Aux_RootUrlStoreID { get; set; }
    public ICollection<Res_AppointmentResponse_Index_identifier> identifier_List { get; set; }
   
    public Res_AppointmentResponse()
    {
      this.identifier_List = new HashSet<Res_AppointmentResponse_Index_identifier>();
    }
  }
}

