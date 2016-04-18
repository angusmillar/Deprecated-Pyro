using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Conformance
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string description_String {get; set;}                  
    public string fhirversion_Code {get; set;}                  
    public string fhirversion_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string software_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_Code {get; set;}                  
    public string version_System {get; set;}                

    public ICollection<Res_Conformance_Index_event> event_List { get; set; }   
    public ICollection<Res_Conformance_Index_format> format_List { get; set; }   
    public ICollection<Res_Conformance_Index_mode> mode_List { get; set; }   
    public ICollection<Res_Conformance_Index_profile> profile_List { get; set; }   
    public ICollection<Res_Conformance_Index_resource> resource_List { get; set; }   
    public ICollection<Res_Conformance_Index_security> security_List { get; set; }   
    public ICollection<Res_Conformance_Index_supported_profile> supported_profile_List { get; set; }   

    public Res_Conformance()
    {
      this.event_List = new HashSet<Res_Conformance_Index_event>();
      this.format_List = new HashSet<Res_Conformance_Index_format>();
      this.mode_List = new HashSet<Res_Conformance_Index_mode>();
      this.profile_List = new HashSet<Res_Conformance_Index_profile>();
      this.resource_List = new HashSet<Res_Conformance_Index_resource>();
      this.security_List = new HashSet<Res_Conformance_Index_security>();
      this.supported_profile_List = new HashSet<Res_Conformance_Index_supported_profile>();
    }
  }
}