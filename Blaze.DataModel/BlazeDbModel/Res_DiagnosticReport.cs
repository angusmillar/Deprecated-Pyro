using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_DiagnosticReport
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public DateTimeOffset? issued_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string performer_FhirId {get; set;}     
    public string performer_Type {get; set;}     
    public string performer_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Res_DiagnosticReport_Index_category> category_List { get; set; }   
    public ICollection<Res_DiagnosticReport_Index_code> code_List { get; set; }   
    public ICollection<Res_DiagnosticReport_Index_diagnosis> diagnosis_List { get; set; }   
    public ICollection<Res_DiagnosticReport_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_DiagnosticReport_Index_image> image_List { get; set; }   
    public ICollection<Res_DiagnosticReport_Index_request> request_List { get; set; }   
    public ICollection<Res_DiagnosticReport_Index_result> result_List { get; set; }   
    public ICollection<Res_DiagnosticReport_Index_specimen> specimen_List { get; set; }   

    public Res_DiagnosticReport()
    {
      this.category_List = new HashSet<Res_DiagnosticReport_Index_category>();
      this.code_List = new HashSet<Res_DiagnosticReport_Index_code>();
      this.diagnosis_List = new HashSet<Res_DiagnosticReport_Index_diagnosis>();
      this.identifier_List = new HashSet<Res_DiagnosticReport_Index_identifier>();
      this.image_List = new HashSet<Res_DiagnosticReport_Index_image>();
      this.request_List = new HashSet<Res_DiagnosticReport_Index_request>();
      this.result_List = new HashSet<Res_DiagnosticReport_Index_result>();
      this.specimen_List = new HashSet<Res_DiagnosticReport_Index_specimen>();
    }
  }
}