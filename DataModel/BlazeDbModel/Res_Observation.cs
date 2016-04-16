using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Observation
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string device_FhirId {get; set;}     
    public string device_Type {get; set;}     
    public string device_Url {get; set;}     
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string specimen_FhirId {get; set;}     
    public string specimen_Type {get; set;}     
    public string specimen_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string value_concept_Code {get; set;}                  
    public string value_concept_System {get; set;}                
    public DateTimeOffset? value_date_DateTimeOffset {get; set;}              
    public decimal? value_quantity_Quantity {get; set;}     
    public string value_quantity_System {get; set;}     
    public string value_quantity_Code {get; set;}     
    public string value_string_String {get; set;}                  

    public ICollection<Res_Observation_Index_category> category_List { get; set; }   
    public ICollection<Res_Observation_Index_code> code_List { get; set; }   
    public ICollection<Res_Observation_Index_component_code> component_code_List { get; set; }   
    public ICollection<Res_Observation_Index_component_data_absent_reason> component_data_absent_reason_List { get; set; }   
    public ICollection<Res_Observation_Index_component_value_concept> component_value_concept_List { get; set; }   
    public ICollection<Res_Observation_Index_component_value_quantity> component_value_quantity_List { get; set; }   
    public ICollection<Res_Observation_Index_component_value_string> component_value_string_List { get; set; }   
    public ICollection<Res_Observation_Index_data_absent_reason> data_absent_reason_List { get; set; }   
    public ICollection<Res_Observation_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_Observation_Index_performer> performer_List { get; set; }   
    public ICollection<Res_Observation_Index_related_target> related_target_List { get; set; }   
    public ICollection<Res_Observation_Index_related_type> related_type_List { get; set; }   

    public Res_Observation()
    {
      this.category_List = new HashSet<Res_Observation_Index_category>();
      this.code_List = new HashSet<Res_Observation_Index_code>();
      this.component_code_List = new HashSet<Res_Observation_Index_component_code>();
      this.component_data_absent_reason_List = new HashSet<Res_Observation_Index_component_data_absent_reason>();
      this.component_value_concept_List = new HashSet<Res_Observation_Index_component_value_concept>();
      this.component_value_quantity_List = new HashSet<Res_Observation_Index_component_value_quantity>();
      this.component_value_string_List = new HashSet<Res_Observation_Index_component_value_string>();
      this.data_absent_reason_List = new HashSet<Res_Observation_Index_data_absent_reason>();
      this.identifier_List = new HashSet<Res_Observation_Index_identifier>();
      this.performer_List = new HashSet<Res_Observation_Index_performer>();
      this.related_target_List = new HashSet<Res_Observation_Index_related_target>();
      this.related_type_List = new HashSet<Res_Observation_Index_related_type>();
    }
  }
}