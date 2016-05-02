using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ReferralRequest_Index_basedon
  {
    public int Res_ReferralRequest_Index_basedonID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Blaze_RootUrlStore Url { get; set; }
    public int? Url_Blaze_RootUrlStoreID { get; set; }
    public virtual Res_ReferralRequest Res_ReferralRequest { get; set; }
   
    public Res_ReferralRequest_Index_basedon()
    {
    }
  }
}

