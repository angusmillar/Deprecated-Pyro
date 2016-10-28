using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImmunizationRecommendation_Index_support : ReferenceIndex
  {
    public int Res_ImmunizationRecommendation_Index_supportID {get; set;}
    public virtual Res_ImmunizationRecommendation Res_ImmunizationRecommendation { get; set; }
   
    public Res_ImmunizationRecommendation_Index_support()
    {
    }
  }
}

