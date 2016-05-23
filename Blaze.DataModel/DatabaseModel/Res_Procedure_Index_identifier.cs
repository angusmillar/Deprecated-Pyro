using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Procedure_Index_identifier : TokenIndex
  {
    public int Res_Procedure_Index_identifierID {get; set;}
    public virtual Res_Procedure Res_Procedure { get; set; }
   
    public Res_Procedure_Index_identifier()
    {
    }
  }
}

