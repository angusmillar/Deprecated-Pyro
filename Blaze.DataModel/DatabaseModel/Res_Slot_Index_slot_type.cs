using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Slot_Index_slot_type
  {
    public int Res_Slot_Index_slot_typeID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Slot Res_Slot { get; set; }
   
    public Res_Slot_Index_slot_type()
    {
    }
  }
}

