using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_SupplyRequest_Index_kind
  {
    public int Res_SupplyRequest_Index_kindID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_SupplyRequest Res_SupplyRequest { get; set; }
   
    public Res_SupplyRequest_Index_kind()
    {
    }
  }
}

