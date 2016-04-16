using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_SupplyDelivery
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string supplier_FhirId {get; set;}     
    public string supplier_Type {get; set;}     
    public string supplier_Url {get; set;}     

    public ICollection<Res_SupplyDelivery_Index_receiver> receiver_List { get; set; }   

    public Res_SupplyDelivery()
    {
      this.receiver_List = new HashSet<Res_SupplyDelivery_Index_receiver>();
    }
  }
}