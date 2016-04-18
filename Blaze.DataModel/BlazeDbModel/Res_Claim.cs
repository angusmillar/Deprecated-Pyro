using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Claim
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string priority_Code {get; set;}                  
    public string priority_System {get; set;}                
    public string provider_FhirId {get; set;}     
    public string provider_Type {get; set;}     
    public string provider_Url {get; set;}     
    public string use_Code {get; set;}                  
    public string use_System {get; set;}                

    public ICollection<Res_Claim_Index_identifier> identifier_List { get; set; }   

    public Res_Claim()
    {
      this.identifier_List = new HashSet<Res_Claim_Index_identifier>();
    }
  }
}