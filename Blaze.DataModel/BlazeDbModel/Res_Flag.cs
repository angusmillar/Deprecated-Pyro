using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Flag
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     


    public Res_Flag()
    {
    }
  }
}