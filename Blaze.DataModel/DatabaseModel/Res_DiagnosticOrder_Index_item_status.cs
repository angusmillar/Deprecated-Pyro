using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DiagnosticOrder_Index_item_status
  {
    public int Res_DiagnosticOrder_Index_item_statusID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_DiagnosticOrder Res_DiagnosticOrder { get; set; }
   
    public Res_DiagnosticOrder_Index_item_status()
    {
    }
  }
}

