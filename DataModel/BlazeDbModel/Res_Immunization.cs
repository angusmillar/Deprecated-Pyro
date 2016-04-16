using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Immunization
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public string lot_number_String {get; set;}                  
    public string manufacturer_FhirId {get; set;}     
    public string manufacturer_Type {get; set;}     
    public string manufacturer_Url {get; set;}     
    public string notgiven_Code {get; set;}                  
    public string notgiven_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string performer_FhirId {get; set;}     
    public string performer_Type {get; set;}     
    public string performer_Url {get; set;}     
    public string requester_FhirId {get; set;}     
    public string requester_Type {get; set;}     
    public string requester_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Res_Immunization_Index_dose_sequence> dose_sequence_List { get; set; }   
    public ICollection<Res_Immunization_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_Immunization_Index_reaction> reaction_List { get; set; }   
    public ICollection<Res_Immunization_Index_reaction_date> reaction_date_List { get; set; }   
    public ICollection<Res_Immunization_Index_reason> reason_List { get; set; }   
    public ICollection<Res_Immunization_Index_reason_not_given> reason_not_given_List { get; set; }   
    public ICollection<Res_Immunization_Index_vaccine_code> vaccine_code_List { get; set; }   

    public Res_Immunization()
    {
      this.dose_sequence_List = new HashSet<Res_Immunization_Index_dose_sequence>();
      this.identifier_List = new HashSet<Res_Immunization_Index_identifier>();
      this.reaction_List = new HashSet<Res_Immunization_Index_reaction>();
      this.reaction_date_List = new HashSet<Res_Immunization_Index_reaction_date>();
      this.reason_List = new HashSet<Res_Immunization_Index_reason>();
      this.reason_not_given_List = new HashSet<Res_Immunization_Index_reason_not_given>();
      this.vaccine_code_List = new HashSet<Res_Immunization_Index_vaccine_code>();
    }
  }
}