using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_EnrollmentRequest : ResourceIndexBase
  {
    public int Res_EnrollmentRequestID {get; set;}
    public string patient_identifier_Code {get; set;}
    public string patient_identifier_System {get; set;}
    public string patient_reference_VersionId {get; set;}
    public string patient_reference_FhirId {get; set;}
    public string patient_reference_Type {get; set;}
    public virtual ServiceRootURL_Store patient_reference_Url { get; set; }
    public int? patient_reference_ServiceRootURL_StoreID { get; set; }
    public string subject_identifier_Code {get; set;}
    public string subject_identifier_System {get; set;}
    public string subject_reference_VersionId {get; set;}
    public string subject_reference_FhirId {get; set;}
    public string subject_reference_Type {get; set;}
    public virtual ServiceRootURL_Store subject_reference_Url { get; set; }
    public int? subject_reference_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_EnrollmentRequest_History> Res_EnrollmentRequest_History_List { get; set; }
    public ICollection<Res_EnrollmentRequest_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_EnrollmentRequest_Index__profile> _profile_List { get; set; }
    public ICollection<Res_EnrollmentRequest_Index__security> _security_List { get; set; }
    public ICollection<Res_EnrollmentRequest_Index__tag> _tag_List { get; set; }
   
    public Res_EnrollmentRequest()
    {
      this.identifier_List = new HashSet<Res_EnrollmentRequest_Index_identifier>();
      this._profile_List = new HashSet<Res_EnrollmentRequest_Index__profile>();
      this._security_List = new HashSet<Res_EnrollmentRequest_Index__security>();
      this._tag_List = new HashSet<Res_EnrollmentRequest_Index__tag>();
      this.Res_EnrollmentRequest_History_List = new HashSet<Res_EnrollmentRequest_History>();
    }
  }
}

