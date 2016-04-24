using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ClinicalImpression_Index_resolved
  {
    public int Res_ClinicalImpression_Index_resolvedID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_ClinicalImpression Res_ClinicalImpression { get; set; }
   
    public Res_ClinicalImpression_Index_resolved()
    {
    }
  }
}

