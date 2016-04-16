using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_QuestionnaireResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public DateTimeOffset? authored_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string questionnaire_FhirId {get; set;}     
    public string questionnaire_Type {get; set;}     
    public string questionnaire_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     


    public Res_QuestionnaireResponse()
    {
    }
  }
}