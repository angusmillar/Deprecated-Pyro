using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Appointment_Index_part_status : TokenIndex
  {
    public int Res_Appointment_Index_part_statusID {get; set;}
    public virtual Res_Appointment Res_Appointment { get; set; }
   
    public Res_Appointment_Index_part_status()
    {
    }
  }
}

