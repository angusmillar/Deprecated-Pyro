using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_CareTeam_Index_status
  {
    public int Res_CareTeam_Index_statusID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_CareTeam Res_CareTeam { get; set; }
   
    public Res_CareTeam_Index_status()
    {
    }
  }
}

