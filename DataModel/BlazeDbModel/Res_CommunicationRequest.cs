using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_CommunicationRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public DateTimeOffset? requested_DateTimeOffset {get; set;}              
    public string requester_FhirId {get; set;}     
    public string requester_Type {get; set;}     
    public string requester_Url {get; set;}     
    public string sender_FhirId {get; set;}     
    public string sender_Type {get; set;}     
    public string sender_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public DateTimeOffset? time_DateTimeOffset {get; set;}              

    public ICollection<Res_CommunicationRequest_Index_category> category_List { get; set; }   
    public ICollection<Res_CommunicationRequest_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_CommunicationRequest_Index_medium> medium_List { get; set; }   
    public ICollection<Res_CommunicationRequest_Index_priority> priority_List { get; set; }   
    public ICollection<Res_CommunicationRequest_Index_recipient> recipient_List { get; set; }   

    public Res_CommunicationRequest()
    {
      this.category_List = new HashSet<Res_CommunicationRequest_Index_category>();
      this.identifier_List = new HashSet<Res_CommunicationRequest_Index_identifier>();
      this.medium_List = new HashSet<Res_CommunicationRequest_Index_medium>();
      this.priority_List = new HashSet<Res_CommunicationRequest_Index_priority>();
      this.recipient_List = new HashSet<Res_CommunicationRequest_Index_recipient>();
    }
  }
}