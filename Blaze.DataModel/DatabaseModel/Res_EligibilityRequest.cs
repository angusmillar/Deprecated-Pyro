using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_EligibilityRequest : ResourceIndexBase
  {
    public int Res_EligibilityRequestID {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string facilityidentifier_Code {get; set;}
    public string facilityidentifier_System {get; set;}
    public string facilityreference_FhirId {get; set;}
    public string facilityreference_Type {get; set;}
    public virtual Blaze_RootUrlStore facilityreference_Url { get; set; }
    public int? facilityreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string organizationidentifier_Code {get; set;}
    public string organizationidentifier_System {get; set;}
    public string organizationreference_FhirId {get; set;}
    public string organizationreference_Type {get; set;}
    public virtual Blaze_RootUrlStore organizationreference_Url { get; set; }
    public int? organizationreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string patientidentifier_Code {get; set;}
    public string patientidentifier_System {get; set;}
    public string patientreference_FhirId {get; set;}
    public string patientreference_Type {get; set;}
    public virtual Blaze_RootUrlStore patientreference_Url { get; set; }
    public int? patientreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string provideridentifier_Code {get; set;}
    public string provideridentifier_System {get; set;}
    public string providerreference_FhirId {get; set;}
    public string providerreference_Type {get; set;}
    public virtual Blaze_RootUrlStore providerreference_Url { get; set; }
    public int? providerreference_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_EligibilityRequest_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_EligibilityRequest_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_EligibilityRequest_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_EligibilityRequest_History> Res_EligibilityRequest_History_List { get; set; }
    public ICollection<Res_EligibilityRequest_Index_identifier> identifier_List { get; set; }
   
    public Res_EligibilityRequest()
    {
      this.identifier_List = new HashSet<Res_EligibilityRequest_Index_identifier>();
      this.meta_tag_List = new HashSet<Res_EligibilityRequest_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_EligibilityRequest_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_EligibilityRequest_Index_meta_profile>();
      this.Res_EligibilityRequest_History_List = new HashSet<Res_EligibilityRequest_History>();
    }
  }
}

