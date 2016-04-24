using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Appointment_Index_part_status
  {
    public int Res_Appointment_Index_part_statusID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Appointment Res_Appointment { get; set; }
   
    public Res_Appointment_Index_part_status()
    {
    }
  }
}

