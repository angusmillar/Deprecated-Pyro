using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Substance_Index_expiry
  {
    public int Res_Substance_Index_expiryID {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}
    public virtual Res_Substance Res_Substance { get; set; }
   
    public Res_Substance_Index_expiry()
    {
    }
  }
}

