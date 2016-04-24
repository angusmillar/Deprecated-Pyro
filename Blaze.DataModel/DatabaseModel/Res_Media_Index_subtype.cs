using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Media_Index_subtype
  {
    public int Res_Media_Index_subtypeID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Media Res_Media { get; set; }
   
    public Res_Media_Index_subtype()
    {
    }
  }
}

