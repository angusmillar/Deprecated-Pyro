using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Immunization_Index_dose_sequence : NumberIndex
  {
    public int Res_Immunization_Index_dose_sequenceID {get; set;}
    public virtual Res_Immunization Res_Immunization { get; set; }
   
    public Res_Immunization_Index_dose_sequence()
    {
    }
  }
}

