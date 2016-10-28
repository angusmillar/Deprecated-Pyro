using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Appointment : ResourceIndexBase
  {
    public int Res_AppointmentID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Appointment_History> Res_Appointment_History_List { get; set; }
    public ICollection<Res_Appointment_Index_actor> actor_List { get; set; }
    public ICollection<Res_Appointment_Index_appointment_type> appointment_type_List { get; set; }
    public ICollection<Res_Appointment_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Appointment_Index_location> location_List { get; set; }
    public ICollection<Res_Appointment_Index_part_status> part_status_List { get; set; }
    public ICollection<Res_Appointment_Index_patient> patient_List { get; set; }
    public ICollection<Res_Appointment_Index_practitioner> practitioner_List { get; set; }
    public ICollection<Res_Appointment_Index_service_type> service_type_List { get; set; }
    public ICollection<Res_Appointment_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Appointment_Index__security> _security_List { get; set; }
    public ICollection<Res_Appointment_Index__tag> _tag_List { get; set; }
   
    public Res_Appointment()
    {
      this.actor_List = new HashSet<Res_Appointment_Index_actor>();
      this.appointment_type_List = new HashSet<Res_Appointment_Index_appointment_type>();
      this.identifier_List = new HashSet<Res_Appointment_Index_identifier>();
      this.location_List = new HashSet<Res_Appointment_Index_location>();
      this.part_status_List = new HashSet<Res_Appointment_Index_part_status>();
      this.patient_List = new HashSet<Res_Appointment_Index_patient>();
      this.practitioner_List = new HashSet<Res_Appointment_Index_practitioner>();
      this.service_type_List = new HashSet<Res_Appointment_Index_service_type>();
      this._profile_List = new HashSet<Res_Appointment_Index__profile>();
      this._security_List = new HashSet<Res_Appointment_Index__security>();
      this._tag_List = new HashSet<Res_Appointment_Index__tag>();
      this.Res_Appointment_History_List = new HashSet<Res_Appointment_History>();
    }
  }
}

