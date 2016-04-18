using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Order_Index_when
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Res_Order Res_Order { get; set; }                     
  }
}