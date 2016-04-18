using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Location
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string address_city_String {get; set;}                  
    public string address_country_String {get; set;}                  
    public string address_postalcode_String {get; set;}                  
    public string address_state_String {get; set;}                  
    public string address_use_Code {get; set;}                  
    public string address_use_System {get; set;}                
    public string name_String {get; set;}                  
    public string near_Code {get; set;}                  
    public string near_System {get; set;}                
    public string near_distance_Code {get; set;}                  
    public string near_distance_System {get; set;}                
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string partof_FhirId {get; set;}     
    public string partof_Type {get; set;}     
    public string partof_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                

    public ICollection<Res_Location_Index_address> address_List { get; set; }   
    public ICollection<Res_Location_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_Location_Index_type> type_List { get; set; }   

    public Res_Location()
    {
      this.address_List = new HashSet<Res_Location_Index_address>();
      this.identifier_List = new HashSet<Res_Location_Index_identifier>();
      this.type_List = new HashSet<Res_Location_Index_type>();
    }
  }
}