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
    public string organizationreference_FhirId {get; set;}
    public string organizationreference_Type {get; set;}
    public virtual Blaze_RootUrlStore organizationreference_Url { get; set; }
    public int? organizationreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string outcome_Code {get; set;}
    public string outcome_System {get; set;}
    public DateTimeOffset? paymentdate_DateTimeOffset {get; set;}
    public string requestidentifier_Code {get; set;}
    public string requestidentifier_System {get; set;}
    public string requestreference_FhirId {get; set;}
    public string requestreference_Type {get; set;}
    public virtual Blaze_RootUrlStore requestreference_Url { get; set; }
    public int? requestreference_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_ClaimResponse_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_ClaimResponse_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_ClaimResponse_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_ClaimResponse_History> Res_ClaimResponse_History_List { get; set; }
    public ICollection<Res_ClaimResponse_Index_identifier> identifier_List { get; set; }
   
    public Res_ClaimResponse()
    {
      this.identifier_List = new HashSet<Res_ClaimResponse_Index_identifier>();
      this.meta_tag_List = new HashSet<Res_ClaimResponse_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_ClaimResponse_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_ClaimResponse_Index_meta_profile>();
      this.Res_ClaimResponse_History_List = new HashSet<Res_ClaimResponse_History>();
    }
  }
}

