﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ExplanationOfBenefit : ResourceIndexBase
  {
    public int Res_ExplanationOfBenefitID {get; set;}
    public string claimindentifier_Code {get; set;}
    public string claimindentifier_System {get; set;}
    public string claimreference_FhirId {get; set;}
    public string claimreference_Type {get; set;}
    public virtual Blaze_RootUrlStore claimreference_Url { get; set; }
    public int? claimreference_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string disposition_String {get; set;}
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
    public ICollection<Res_ExplanationOfBenefit_History> Res_ExplanationOfBenefit_History_List { get; set; }
    public ICollection<Res_ExplanationOfBenefit_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_ExplanationOfBenefit_Index_profile> profile_List { get; set; }
    public ICollection<Res_ExplanationOfBenefit_Index_security> security_List { get; set; }
    public ICollection<Res_ExplanationOfBenefit_Index_tag> tag_List { get; set; }
   
    public Res_ExplanationOfBenefit()
    {
      this.identifier_List = new HashSet<Res_ExplanationOfBenefit_Index_identifier>();
      this.profile_List = new HashSet<Res_ExplanationOfBenefit_Index_profile>();
      this.security_List = new HashSet<Res_ExplanationOfBenefit_Index_security>();
      this.tag_List = new HashSet<Res_ExplanationOfBenefit_Index_tag>();
      this.Res_ExplanationOfBenefit_History_List = new HashSet<Res_ExplanationOfBenefit_History>();
    }
  }
}

