using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_PractitionerRole_Index_telecom
  {
    public int Res_PractitionerRole_Index_telecomID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_PractitionerRole Res_PractitionerRole { get; set; }
   
    public Res_PractitionerRole_Index_telecom()
    {
    }
  }
}

