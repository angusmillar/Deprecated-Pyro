using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_ProcessResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     
    public string request_FhirId {get; set;}     
    public string request_Type {get; set;}     
    public string request_Url {get; set;}     
    public string requestorganization_FhirId {get; set;}     
    public string requestorganization_Type {get; set;}     
    public string requestorganization_Url {get; set;}     
    public string requestprovider_FhirId {get; set;}     
    public string requestprovider_Type {get; set;}     
    public string requestprovider_Url {get; set;}     

    public ICollection<Res_ProcessResponse_Index_identifier> identifier_List { get; set; }   

    public Res_ProcessResponse()
    {
      this.identifier_List = new HashSet<Res_ProcessResponse_Index_identifier>();
    }
  }
}