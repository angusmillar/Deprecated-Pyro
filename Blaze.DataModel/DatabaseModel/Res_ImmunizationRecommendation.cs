using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImmunizationRecommendation : ResourceIndexBase
  {
    public int Res_ImmunizationRecommendationID {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_ImmunizationRecommendation_History> Res_ImmunizationRecommendation_History_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_date> date_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_dose_number> dose_number_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_dose_sequence> dose_sequence_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_information> information_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_status> status_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_support> support_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_vaccine_type> vaccine_type_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index__profile> _profile_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index__security> _security_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index__tag> _tag_List { get; set; }
   
    public Res_ImmunizationRecommendation()
    {
      this.date_List = new HashSet<Res_ImmunizationRecommendation_Index_date>();
      this.dose_number_List = new HashSet<Res_ImmunizationRecommendation_Index_dose_number>();
      this.dose_sequence_List = new HashSet<Res_ImmunizationRecommendation_Index_dose_sequence>();
      this.identifier_List = new HashSet<Res_ImmunizationRecommendation_Index_identifier>();
      this.information_List = new HashSet<Res_ImmunizationRecommendation_Index_information>();
      this.status_List = new HashSet<Res_ImmunizationRecommendation_Index_status>();
      this.support_List = new HashSet<Res_ImmunizationRecommendation_Index_support>();
      this.vaccine_type_List = new HashSet<Res_ImmunizationRecommendation_Index_vaccine_type>();
      this._profile_List = new HashSet<Res_ImmunizationRecommendation_Index__profile>();
      this._security_List = new HashSet<Res_ImmunizationRecommendation_Index__security>();
      this._tag_List = new HashSet<Res_ImmunizationRecommendation_Index__tag>();
      this.Res_ImmunizationRecommendation_History_List = new HashSet<Res_ImmunizationRecommendation_History>();
    }
  }
}

