using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ClinicalImpression_Index_finding_code : TokenIndex
  {
    public int Res_ClinicalImpression_Index_finding_codeID {get; set;}
    public virtual Res_ClinicalImpression Res_ClinicalImpression { get; set; }
   
    public Res_ClinicalImpression_Index_finding_code()
    {
    }
  }
}

