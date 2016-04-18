using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Condition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string asserter_FhirId {get; set;}     
    public string asserter_Type {get; set;}     
    public string asserter_Url {get; set;}     
    public string clinicalstatus_Code {get; set;}                  
    public string clinicalstatus_System {get; set;}                
    public DateTimeOffset? date_recorded_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public DateTimeOffset? onset_DateTimeOffset {get; set;}              
    public string onset_info_String {get; set;}                  
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     

    public ICollection<Res_Condition_Index_body_site> body_site_List { get; set; }   
    public ICollection<Res_Condition_Index_category> category_List { get; set; }   
    public ICollection<Res_Condition_Index_code> code_List { get; set; }   
    public ICollection<Res_Condition_Index_evidence> evidence_List { get; set; }   
    public ICollection<Res_Condition_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_Condition_Index_severity> severity_List { get; set; }   
    public ICollection<Res_Condition_Index_stage> stage_List { get; set; }   

    public Res_Condition()
    {
      this.body_site_List = new HashSet<Res_Condition_Index_body_site>();
      this.category_List = new HashSet<Res_Condition_Index_category>();
      this.code_List = new HashSet<Res_Condition_Index_code>();
      this.evidence_List = new HashSet<Res_Condition_Index_evidence>();
      this.identifier_List = new HashSet<Res_Condition_Index_identifier>();
      this.severity_List = new HashSet<Res_Condition_Index_severity>();
      this.stage_List = new HashSet<Res_Condition_Index_stage>();
    }
  }
}