using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_TestScript_Index__security : TokenIndex
  {
    public int Res_TestScript_Index__securityID {get; set;}
    public virtual Res_TestScript Res_TestScript { get; set; }
   
    public Res_TestScript_Index__security()
    {
    }
  }
}

