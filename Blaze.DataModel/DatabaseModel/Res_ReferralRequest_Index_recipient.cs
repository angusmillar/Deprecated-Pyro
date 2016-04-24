using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ReferralRequest_Index_recipient
  {
    public int Res_ReferralRequest_Index_recipientID {get; set;}
    public string FhirId {get; set;}
    public string Type {get; set;}
    public virtual Aux_RootUrlStore Aux_RootUrlStoreID { get; set; }
    public virtual Res_ReferralRequest Res_ReferralRequest { get; set; }
   
    public Res_ReferralRequest_Index_recipient()
    {
    }
  }
}

