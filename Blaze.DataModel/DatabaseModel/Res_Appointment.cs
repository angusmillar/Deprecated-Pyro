using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Appointment
  {
    public int Res_AppointmentID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Appointment_Index_actor> actor_List { get; set; }
    public ICollection<Res_Appointment_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Appointment_Index_location> location_List { get; set; }
    public ICollection<Res_Appointment_Index_part_status> part_status_List { get; set; }
    public ICollection<Res_Appointment_Index_patient> patient_List { get; set; }
    public ICollection<Res_Appointment_Index_practitioner> practitioner_List { get; set; }
   
    public Res_Appointment()
    {
      this.actor_List = new HashSet<Res_Appointment_Index_actor>();
      this.identifier_List = new HashSet<Res_Appointment_Index_identifier>();
      this.location_List = new HashSet<Res_Appointment_Index_location>();
      this.part_status_List = new HashSet<Res_Appointment_Index_part_status>();
      this.patient_List = new HashSet<Res_Appointment_Index_patient>();
      this.practitioner_List = new HashSet<Res_Appointment_Index_practitioner>();
    }
  }
}

