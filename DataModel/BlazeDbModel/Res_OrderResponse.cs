using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_OrderResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string request_FhirId {get; set;}     
    public string request_Type {get; set;}     
    public string request_Url {get; set;}     
    public string who_FhirId {get; set;}     
    public string who_Type {get; set;}     
    public string who_Url {get; set;}     

    public ICollection<Res_OrderResponse_Index_fulfillment> fulfillment_List { get; set; }   
    public ICollection<Res_OrderResponse_Index_identifier> identifier_List { get; set; }   

    public Res_OrderResponse()
    {
      this.fulfillment_List = new HashSet<Res_OrderResponse_Index_fulfillment>();
      this.identifier_List = new HashSet<Res_OrderResponse_Index_identifier>();
    }
  }
}