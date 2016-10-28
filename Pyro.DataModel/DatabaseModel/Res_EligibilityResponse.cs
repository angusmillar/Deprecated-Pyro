using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_EligibilityResponse : ResourceIndexBase
  {
    public int Res_EligibilityResponseID {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string disposition_String {get; set;}
    public string organization_identifier_Code {get; set;}
    public string organization_identifier_System {get; set;}
    public string organization_reference_VersionId {get; set;}
    public string organization_reference_FhirId {get; set;}
    public string organization_reference_Type {get; set;}
    public virtual ServiceRootURL_Store organization_reference_Url { get; set; }
    public int? organization_reference_ServiceRootURL_StoreID { get; set; }
    public string outcome_Code {get; set;}
    public string outcome_System {get; set;}
    public string request_identifier_Code {get; set;}
    public string request_identifier_System {get; set;}
    public string request_organization_identifier_Code {get; set;}
    public string request_organization_identifier_System {get; set;}
    public string request_organization_reference_VersionId {get; set;}
    public string request_organization_reference_FhirId {get; set;}
    public string request_organization_reference_Type {get; set;}
    public virtual ServiceRootURL_Store request_organization_reference_Url { get; set; }
    public int? request_organization_reference_ServiceRootURL_StoreID { get; set; }
    public string request_provider_identifier_Code {get; set;}
    public string request_provider_identifier_System {get; set;}
    public string request_provider_reference_VersionId {get; set;}
    public string request_provider_reference_FhirId {get; set;}
    public string request_provider_reference_Type {get; set;}
    public virtual ServiceRootURL_Store request_provider_reference_Url { get; set; }
    public int? request_provider_reference_ServiceRootURL_StoreID { get; set; }
    public string request_reference_VersionId {get; set;}
    public string request_reference_FhirId {get; set;}
    public string request_reference_Type {get; set;}
    public virtual ServiceRootURL_Store request_reference_Url { get; set; }
    public int? request_reference_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_EligibilityResponse_History> Res_EligibilityResponse_History_List { get; set; }
    public ICollection<Res_EligibilityResponse_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_EligibilityResponse_Index__profile> _profile_List { get; set; }
    public ICollection<Res_EligibilityResponse_Index__security> _security_List { get; set; }
    public ICollection<Res_EligibilityResponse_Index__tag> _tag_List { get; set; }
   
    public Res_EligibilityResponse()
    {
      this.identifier_List = new HashSet<Res_EligibilityResponse_Index_identifier>();
      this._profile_List = new HashSet<Res_EligibilityResponse_Index__profile>();
      this._security_List = new HashSet<Res_EligibilityResponse_Index__security>();
      this._tag_List = new HashSet<Res_EligibilityResponse_Index__tag>();
      this.Res_EligibilityResponse_History_List = new HashSet<Res_EligibilityResponse_History>();
    }
  }
}

