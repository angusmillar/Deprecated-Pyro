using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ReferralRequest_Index_specialty
  {
    public int Res_ReferralRequest_Index_specialtyID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_ReferralRequest Res_ReferralRequest { get; set; }
   
    public Res_ReferralRequest_Index_specialty()
    {
    }
  }
}

