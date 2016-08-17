using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ClaimResponse : ResourceIndexBase
  {
    public int Res_ClaimResponseID {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string disposition_String {get; set;}
    public string organizationidentifier_Code {get; set;}
    public string organizationidentifier_System {get; set;}
    public string organizationreference_VersionId {get; set;}
    public string organizationreference_FhirId {get; set;}
    public string organizationreference_Type {get; set;}
    public virtual ServiceRootURL_Store organizationreference_Url { get; set; }
    public int? organizationreference_ServiceRootURL_StoreID { get; set; }
    public string outcome_Code {get; set;}
    public string outcome_System {get; set;}
    public DateTimeOffset? paymentdate_DateTimeOffset {get; set;}
    public string requestidentifier_Code {get; set;}
    public string requestidentifier_System {get; set;}
    public string requestreference_VersionId {get; set;}
    public string requestreference_FhirId {get; set;}
    public string requestreference_Type {get; set;}
    public virtual ServiceRootURL_Store requestreference_Url { get; set; }
    public int? requestreference_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_ClaimResponse_History> Res_ClaimResponse_History_List { get; set; }
    public ICollection<Res_ClaimResponse_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_ClaimResponse_Index_profile> profile_List { get; set; }
    public ICollection<Res_ClaimResponse_Index_security> security_List { get; set; }
    public ICollection<Res_ClaimResponse_Index_tag> tag_List { get; set; }
   
    public Res_ClaimResponse()
    {
      this.identifier_List = new HashSet<Res_ClaimResponse_Index_identifier>();
      this.profile_List = new HashSet<Res_ClaimResponse_Index_profile>();
      this.security_List = new HashSet<Res_ClaimResponse_Index_security>();
      this.tag_List = new HashSet<Res_ClaimResponse_Index_tag>();
      this.Res_ClaimResponse_History_List = new HashSet<Res_ClaimResponse_History>();
    }
  }
}

