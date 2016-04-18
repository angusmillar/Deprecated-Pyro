using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_MedicationOrder
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public DateTimeOffset? datewritten_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string medication_FhirId {get; set;}     
    public string medication_Type {get; set;}     
    public string medication_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string prescriber_FhirId {get; set;}     
    public string prescriber_Type {get; set;}     
    public string prescriber_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Res_MedicationOrder_Index_identifier> identifier_List { get; set; }   

    public Res_MedicationOrder()
    {
      this.identifier_List = new HashSet<Res_MedicationOrder_Index_identifier>();
    }
  }
}