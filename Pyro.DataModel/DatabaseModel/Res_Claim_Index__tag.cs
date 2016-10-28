using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Claim_Index__tag : TokenIndex
  {
    public int Res_Claim_Index__tagID {get; set;}
    public virtual Res_Claim Res_Claim { get; set; }
   
    public Res_Claim_Index__tag()
    {
    }
  }
}

