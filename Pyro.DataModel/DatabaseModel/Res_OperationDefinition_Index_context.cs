using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_OperationDefinition_Index_context : TokenIndex
  {
    public int Res_OperationDefinition_Index_contextID {get; set;}
    public virtual Res_OperationDefinition Res_OperationDefinition { get; set; }
   
    public Res_OperationDefinition_Index_context()
    {
    }
  }
}

