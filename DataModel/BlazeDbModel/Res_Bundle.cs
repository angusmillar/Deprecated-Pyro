using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Bundle
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string composition_FhirId {get; set;}     
    public string composition_Type {get; set;}     
    public string composition_Url {get; set;}     
    public string message_FhirId {get; set;}     
    public string message_Type {get; set;}     
    public string message_Url {get; set;}     
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                


    public Res_Bundle()
    {
    }
  }
}