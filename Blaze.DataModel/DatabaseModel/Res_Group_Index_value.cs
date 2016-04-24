using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Group_Index_value
  {
    public int Res_Group_Index_valueID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Group Res_Group { get; set; }
   
    public Res_Group_Index_value()
    {
    }
  }
}

