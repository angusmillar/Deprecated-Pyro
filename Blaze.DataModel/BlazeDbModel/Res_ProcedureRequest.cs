using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_ProcedureRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string orderer_FhirId {get; set;}     
    public string orderer_Type {get; set;}     
    public string orderer_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string performer_FhirId {get; set;}     
    public string performer_Type {get; set;}     
    public string performer_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Res_ProcedureRequest_Index_identifier> identifier_List { get; set; }   

    public Res_ProcedureRequest()
    {
      this.identifier_List = new HashSet<Res_ProcedureRequest_Index_identifier>();
    }
  }
}