using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ReferralRequest : ResourceIndexBase
  {
    public int Res_ReferralRequestID {get; set;}
    public string category_Code {get; set;}
    public string category_System {get; set;}
    public string context_VersionId {get; set;}
    public string context_FhirId {get; set;}
    public string context_Type {get; set;}
    public virtual ServiceRootURL_Store context_Url { get; set; }
    public int? context_ServiceRootURL_StoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string parent_Code {get; set;}
    public string parent_System {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string requester_VersionId {get; set;}
    public string requester_FhirId {get; set;}
    public string requester_Type {get; set;}
    public virtual ServiceRootURL_Store requester_Url { get; set; }
    public int? requester_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_ReferralRequest_History> Res_ReferralRequest_History_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_basedon> basedon_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_priority> priority_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_recipient> recipient_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_specialty> specialty_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_type> type_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_profile> profile_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_security> security_List { get; set; }
    public ICollection<Res_ReferralRequest_Index_tag> tag_List { get; set; }
   
    public Res_ReferralRequest()
    {
      this.basedon_List = new HashSet<Res_ReferralRequest_Index_basedon>();
      this.priority_List = new HashSet<Res_ReferralRequest_Index_priority>();
      this.recipient_List = new HashSet<Res_ReferralRequest_Index_recipient>();
      this.specialty_List = new HashSet<Res_ReferralRequest_Index_specialty>();
      this.type_List = new HashSet<Res_ReferralRequest_Index_type>();
      this.profile_List = new HashSet<Res_ReferralRequest_Index_profile>();
      this.security_List = new HashSet<Res_ReferralRequest_Index_security>();
      this.tag_List = new HashSet<Res_ReferralRequest_Index_tag>();
      this.Res_ReferralRequest_History_List = new HashSet<Res_ReferralRequest_History>();
    }
  }
}

