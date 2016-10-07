using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_EligibilityRequest_Index__security : TokenIndex
  {
    public int Res_EligibilityRequest_Index__securityID {get; set;}
    public virtual Res_EligibilityRequest Res_EligibilityRequest { get; set; }
   
    public Res_EligibilityRequest_Index__security()
    {
    }
  }
}

