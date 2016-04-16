using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_ImmunizationRecommendation
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     

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
    }
  }
}