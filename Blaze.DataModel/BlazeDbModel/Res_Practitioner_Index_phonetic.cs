using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Practitioner_Index_phonetic
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Res_Practitioner Res_Practitioner { get; set; }                     
  }
}