using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_BodySite_Index_code
  {
    public int Res_BodySite_Index_codeID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_BodySite Res_BodySite { get; set; }
   
    public Res_BodySite_Index_code()
    {
    }
  }
}

