using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Composition_Index_period
  {
    public int Id {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}              
    
    //Keyed
    public virtual Res_Composition Res_Composition { get; set; }                     
  }
}