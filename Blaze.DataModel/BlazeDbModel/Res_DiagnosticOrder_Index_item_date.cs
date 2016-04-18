using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_DiagnosticOrder_Index_item_date
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Res_DiagnosticOrder Res_DiagnosticOrder { get; set; }                     
  }
}