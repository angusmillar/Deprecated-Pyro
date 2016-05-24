using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_EligibilityResponse_Index_security : TokenIndex
  {
    public int Res_EligibilityResponse_Index_securityID {get; set;}
    public virtual Res_EligibilityResponse Res_EligibilityResponse { get; set; }
   
    public Res_EligibilityResponse_Index_security()
    {
    }
  }
}

