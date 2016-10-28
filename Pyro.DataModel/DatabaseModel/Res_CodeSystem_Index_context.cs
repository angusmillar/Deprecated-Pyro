using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_CodeSystem_Index_context : TokenIndex
  {
    public int Res_CodeSystem_Index_contextID {get; set;}
    public virtual Res_CodeSystem Res_CodeSystem { get; set; }
   
    public Res_CodeSystem_Index_context()
    {
    }
  }
}

