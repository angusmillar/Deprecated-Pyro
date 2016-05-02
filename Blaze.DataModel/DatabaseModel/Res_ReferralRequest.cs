using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ReferralRequest
  {
    public int Res_ReferralRequestID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string category_Code {get; set;}
    public string category_System {get; set;}
    public string context_FhirId {get; set;}
    public string context_Type {get; set;}
    public virtual Blaze_RootUrlStore context_Url { get; set; }
    public int? context_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string parent_Code {get; set;}
    public string parent_System {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string requester_FhirId {get; set;}
    public string requester_Type {get; set;}
    public virtual Blaze_RootUrlStore requester_Url { get; set; }
    public int? requester_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_ReferralRequest_Index_basedon> basedon_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_priority> priority_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_recipient> recipient_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_specialty> specialty_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_type> type_List { get; set; }
   
    public Res_ReferralRequest()
    {
      this.basedon_List = new HashSet<Res_ReferralRequest_Index_basedon>();
      this.priority_List = new HashSet<Res_ReferralRequest_Index_priority>();
      this.recipient_List = new HashSet<Res_ReferralRequest_Index_recipient>();
      this.specialty_List = new HashSet<Res_ReferralRequest_Index_specialty>();
      this.type_List = new HashSet<Res_ReferralRequest_Index_type>();
    }
  }
}

