using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_MedicationDispense
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string destination_FhirId {get; set;}     
    public string destination_Type {get; set;}     
    public string destination_Url {get; set;}     
    public string dispenser_FhirId {get; set;}     
    public string dispenser_Type {get; set;}     
    public string dispenser_Url {get; set;}     
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string medication_FhirId {get; set;}     
    public string medication_Type {get; set;}     
    public string medication_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public DateTimeOffset? whenhandedover_DateTimeOffset {get; set;}              
    public DateTimeOffset? whenprepared_DateTimeOffset {get; set;}              

    public ICollection<Res_MedicationDispense_Index_prescription> prescription_List { get; set; }   
    public ICollection<Res_MedicationDispense_Index_receiver> receiver_List { get; set; }   
    public ICollection<Res_MedicationDispense_Index_responsibleparty> responsibleparty_List { get; set; }   
    public ICollection<Res_MedicationDispense_Index_type> type_List { get; set; }   

    public Res_MedicationDispense()
    {
      this.prescription_List = new HashSet<Res_MedicationDispense_Index_prescription>();
      this.receiver_List = new HashSet<Res_MedicationDispense_Index_receiver>();
      this.responsibleparty_List = new HashSet<Res_MedicationDispense_Index_responsibleparty>();
      this.type_List = new HashSet<Res_MedicationDispense_Index_type>();
    }
  }
}