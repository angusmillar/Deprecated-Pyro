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
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_History> Res_ImmunizationRecommendation_History_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_date> date_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_dose_number> dose_number_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_dose_sequence> dose_sequence_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_information> information_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_status> status_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_support> support_List { get; set; }
    public ICollection<Res_ImmunizationRecommendation_Index_vaccine_type> vaccine_type_List { get; set; }
   
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
      this.meta_tag_List = new HashSet<Res_ImmunizationRecommendation_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_ImmunizationRecommendation_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_ImmunizationRecommendation_Index_meta_profile>();
      this.Res_ImmunizationRecommendation_History_List = new HashSet<Res_ImmunizationRecommendation_History>();
    }
  }
}

