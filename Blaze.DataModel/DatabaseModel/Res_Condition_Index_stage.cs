using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Condition_Index_stage
  {
    public int Res_Condition_Index_stageID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Condition Res_Condition { get; set; }
   
    public Res_Condition_Index_stage()
    {
    }
  }
}

