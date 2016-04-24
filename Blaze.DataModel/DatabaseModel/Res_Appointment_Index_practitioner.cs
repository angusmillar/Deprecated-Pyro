using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Appointment_Index_practitioner
  {
    public int Res_Appointment_Index_practitionerID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_Appointment Res_Appointment { get; set; }
   
    public Res_Appointment_Index_practitioner()
    {
    }
  }
}

