using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_ExplanationOfBenefit_Index__tag : TokenIndex
  {
    public int Res_ExplanationOfBenefit_Index__tagID {get; set;}
    public virtual Res_ExplanationOfBenefit Res_ExplanationOfBenefit { get; set; }
   
    public Res_ExplanationOfBenefit_Index__tag()
    {
    }
  }
}

