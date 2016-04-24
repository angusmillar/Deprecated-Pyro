using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Practitioner_Index_telecom
  {
    public int Res_Practitioner_Index_telecomID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Practitioner Res_Practitioner { get; set; }
   
    public Res_Practitioner_Index_telecom()
    {
    }
  }
}

