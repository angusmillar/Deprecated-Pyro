using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OperationDefinition_Index_type : TokenIndex
  {
    public int Res_OperationDefinition_Index_typeID {get; set;}
    public virtual Res_OperationDefinition Res_OperationDefinition { get; set; }
   
    public Res_OperationDefinition_Index_type()
    {
    }
  }
}

