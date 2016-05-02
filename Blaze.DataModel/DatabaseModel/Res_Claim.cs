using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Claim
  {
    public int Res_ClaimID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string priority_Code {get; set;}
    public string priority_System {get; set;}
    public string provider_FhirId {get; set;}
    public string provider_Type {get; set;}
    public virtual Blaze_RootUrlStore provider_Url { get; set; }
    public int? provider_Url_Blaze_RootUrlStoreID { get; set; }
    public string use_Code {get; set;}
    public string use_System {get; set;}
    public ICollection<Res_Claim_Index_identifier> identifier_List { get; set; }
   
    public Res_Claim()
    {
      this.identifier_List = new HashSet<Res_Claim_Index_identifier>();
    }
  }
}

