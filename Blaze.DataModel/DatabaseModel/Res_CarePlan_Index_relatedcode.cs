using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_CarePlan_Index_relatedcode
  {
    public int Res_CarePlan_Index_relatedcodeID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_CarePlan Res_CarePlan { get; set; }
   
    public Res_CarePlan_Index_relatedcode()
    {
    }
  }
}

