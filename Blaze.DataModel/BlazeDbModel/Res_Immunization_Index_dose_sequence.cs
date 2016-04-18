using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Immunization_Index_dose_sequence
  {
    public int Id {get; set;}
    public decimal Number {get; set;}                  
    
    //Keyed
    public virtual Res_Immunization Res_Immunization { get; set; }                     
  }
}