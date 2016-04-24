using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_SearchParameter_Index_target
  {
    public int Res_SearchParameter_Index_targetID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_SearchParameter Res_SearchParameter { get; set; }
   
    public Res_SearchParameter_Index_target()
    {
    }
  }
}

