using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_RiskAssessment
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string condition_FhirId {get; set;}     
    public string condition_Type {get; set;}     
    public string condition_Url {get; set;}     
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string performer_FhirId {get; set;}     
    public string performer_Type {get; set;}     
    public string performer_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Res_RiskAssessment_Index_method> method_List { get; set; }   

    public Res_RiskAssessment()
    {
      this.method_List = new HashSet<Res_RiskAssessment_Index_method>();
    }
  }
}