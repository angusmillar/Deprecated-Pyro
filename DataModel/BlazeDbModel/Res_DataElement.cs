using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_DataElement
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string name_String {get; set;}                  
    public string publisher_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string stringency_Code {get; set;}                  
    public string stringency_System {get; set;}                
    public string url_Uri {get; set;}     
    public string version_String {get; set;}                  

    public ICollection<Res_DataElement_Index_code> code_List { get; set; }   
    public ICollection<Res_DataElement_Index_context> context_List { get; set; }   
    public ICollection<Res_DataElement_Index_description> description_List { get; set; }   
    public ICollection<Res_DataElement_Index_identifier> identifier_List { get; set; }   

    public Res_DataElement()
    {
      this.code_List = new HashSet<Res_DataElement_Index_code>();
      this.context_List = new HashSet<Res_DataElement_Index_context>();
      this.description_List = new HashSet<Res_DataElement_Index_description>();
      this.identifier_List = new HashSet<Res_DataElement_Index_identifier>();
    }
  }
}