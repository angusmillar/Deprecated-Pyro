using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_ImplementationGuide
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string description_String {get; set;}                  
    public string experimental_Code {get; set;}                  
    public string experimental_System {get; set;}                
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_Code {get; set;}                  
    public string version_System {get; set;}                

    public ICollection<Res_ImplementationGuide_Index_context> context_List { get; set; }   
    public ICollection<Res_ImplementationGuide_Index_dependency> dependency_List { get; set; }   

    public Res_ImplementationGuide()
    {
      this.context_List = new HashSet<Res_ImplementationGuide_Index_context>();
      this.dependency_List = new HashSet<Res_ImplementationGuide_Index_dependency>();
    }
  }
}