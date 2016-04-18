using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_VisionPrescription
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? datewritten_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string prescriber_FhirId {get; set;}     
    public string prescriber_Type {get; set;}     
    public string prescriber_Url {get; set;}     

    public ICollection<Res_VisionPrescription_Index_identifier> identifier_List { get; set; }   

    public Res_VisionPrescription()
    {
      this.identifier_List = new HashSet<Res_VisionPrescription_Index_identifier>();
    }
  }
}