using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_EnrollmentRequest
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Res_EnrollmentRequest_Index_identifier> identifier_List { get; set; }   

    public Res_EnrollmentRequest()
    {
      this.identifier_List = new HashSet<Res_EnrollmentRequest_Index_identifier>();
    }
  }
}