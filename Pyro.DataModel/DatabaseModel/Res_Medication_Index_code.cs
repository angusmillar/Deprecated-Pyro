using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Medication_Index_code : TokenIndex
  {
    public int Res_Medication_Index_codeID {get; set;}
    public virtual Res_Medication Res_Medication { get; set; }
   
    public Res_Medication_Index_code()
    {
    }
  }
}

