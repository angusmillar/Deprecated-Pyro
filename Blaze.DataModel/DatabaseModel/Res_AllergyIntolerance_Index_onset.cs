using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_AllergyIntolerance_Index_onset
  {
    public int Res_AllergyIntolerance_Index_onsetID {get; set;}
    public DateTimeOffset DateTimeOffset {get; set;}
    public virtual Res_AllergyIntolerance Res_AllergyIntolerance { get; set; }
   
    public Res_AllergyIntolerance_Index_onset()
    {
    }
  }
}

