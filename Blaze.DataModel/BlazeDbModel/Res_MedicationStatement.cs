using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_MedicationStatement
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public DateTimeOffset? effectivedate_DateTimeOffset {get; set;}              
    public string medication_FhirId {get; set;}     
    public string medication_Type {get; set;}     
    public string medication_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string source_FhirId {get; set;}     
    public string source_Type {get; set;}     
    public string source_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Res_MedicationStatement_Index_identifier> identifier_List { get; set; }   

    public Res_MedicationStatement()
    {
      this.identifier_List = new HashSet<Res_MedicationStatement_Index_identifier>();
    }
  }
}