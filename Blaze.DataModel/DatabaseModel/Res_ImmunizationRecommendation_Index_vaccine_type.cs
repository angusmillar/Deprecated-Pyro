using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImmunizationRecommendation_Index_vaccine_type
  {
    public int Res_ImmunizationRecommendation_Index_vaccine_typeID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_ImmunizationRecommendation Res_ImmunizationRecommendation { get; set; }
   
    public Res_ImmunizationRecommendation_Index_vaccine_type()
    {
    }
  }
}

