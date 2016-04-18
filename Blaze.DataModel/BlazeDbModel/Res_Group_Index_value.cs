using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Group_Index_value
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Res_Group Res_Group { get; set; }                     
  }
}