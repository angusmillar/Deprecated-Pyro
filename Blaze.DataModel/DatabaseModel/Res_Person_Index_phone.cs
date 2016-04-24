using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Person_Index_phone
  {
    public int Res_Person_Index_phoneID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Person Res_Person { get; set; }
   
    public Res_Person_Index_phone()
    {
    }
  }
}

