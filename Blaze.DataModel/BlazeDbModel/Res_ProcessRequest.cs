using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_ProcessRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string action_Code {get; set;}                  
    public string action_System {get; set;}                
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string provider_FhirId {get; set;}     
    public string provider_Type {get; set;}     
    public string provider_Url {get; set;}     

    public ICollection<Res_ProcessRequest_Index_identifier> identifier_List { get; set; }   

    public Res_ProcessRequest()
    {
      this.identifier_List = new HashSet<Res_ProcessRequest_Index_identifier>();
    }
  }
}