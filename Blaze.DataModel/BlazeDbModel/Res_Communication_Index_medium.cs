using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Communication_Index_medium
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Res_Communication Res_Communication { get; set; }                     
  }
}