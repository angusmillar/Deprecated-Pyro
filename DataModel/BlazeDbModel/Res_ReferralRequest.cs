using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_ReferralRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string requester_FhirId {get; set;}     
    public string requester_Type {get; set;}     
    public string requester_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Res_ReferralRequest_Index_priority> priority_List { get; set; }   
    public ICollection<Res_ReferralRequest_Index_recipient> recipient_List { get; set; }   
    public ICollection<Res_ReferralRequest_Index_specialty> specialty_List { get; set; }   
    public ICollection<Res_ReferralRequest_Index_type> type_List { get; set; }   

    public Res_ReferralRequest()
    {
      this.priority_List = new HashSet<Res_ReferralRequest_Index_priority>();
      this.recipient_List = new HashSet<Res_ReferralRequest_Index_recipient>();
      this.specialty_List = new HashSet<Res_ReferralRequest_Index_specialty>();
      this.type_List = new HashSet<Res_ReferralRequest_Index_type>();
    }
  }
}