using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Sequence_Index_meta_security : TokenIndex
  {
    public int Res_Sequence_Index_meta_securityID {get; set;}
    public virtual Res_Sequence Res_Sequence { get; set; }
   
    public Res_Sequence_Index_meta_security()
    {
    }
  }
}

