using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Medication_Index_container
  {
    public int Res_Medication_Index_containerID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Medication Res_Medication { get; set; }
   
    public Res_Medication_Index_container()
    {
    }
  }
}

