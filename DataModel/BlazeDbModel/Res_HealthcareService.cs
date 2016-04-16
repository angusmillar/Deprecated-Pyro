using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_HealthcareService
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public string name_String {get; set;}                  
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     

    public ICollection<Res_HealthcareService_Index_characteristic> characteristic_List { get; set; }   
    public ICollection<Res_HealthcareService_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_HealthcareService_Index_programname> programname_List { get; set; }   
    public ICollection<Res_HealthcareService_Index_servicecategory> servicecategory_List { get; set; }   
    public ICollection<Res_HealthcareService_Index_servicetype> servicetype_List { get; set; }   

    public Res_HealthcareService()
    {
      this.characteristic_List = new HashSet<Res_HealthcareService_Index_characteristic>();
      this.identifier_List = new HashSet<Res_HealthcareService_Index_identifier>();
      this.programname_List = new HashSet<Res_HealthcareService_Index_programname>();
      this.servicecategory_List = new HashSet<Res_HealthcareService_Index_servicecategory>();
      this.servicetype_List = new HashSet<Res_HealthcareService_Index_servicetype>();
    }
  }
}