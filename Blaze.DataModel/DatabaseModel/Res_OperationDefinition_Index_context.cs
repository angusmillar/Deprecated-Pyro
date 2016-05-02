using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OperationDefinition_Index_context
  {
    public int Res_OperationDefinition_Index_contextID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_OperationDefinition Res_OperationDefinition { get; set; }
   
    public Res_OperationDefinition_Index_context()
    {
    }
  }
}

