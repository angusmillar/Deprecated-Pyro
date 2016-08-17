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
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_EnrollmentRequest_History> Res_EnrollmentRequest_History_List { get; set; }
    public ICollection<Res_EnrollmentRequest_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_EnrollmentRequest_Index_profile> profile_List { get; set; }
    public ICollection<Res_EnrollmentRequest_Index_security> security_List { get; set; }
    public ICollection<Res_EnrollmentRequest_Index_tag> tag_List { get; set; }
   
    public Res_EnrollmentRequest()
    {
      this.identifier_List = new HashSet<Res_EnrollmentRequest_Index_identifier>();
      this.profile_List = new HashSet<Res_EnrollmentRequest_Index_profile>();
      this.security_List = new HashSet<Res_EnrollmentRequest_Index_security>();
      this.tag_List = new HashSet<Res_EnrollmentRequest_Index_tag>();
      this.Res_EnrollmentRequest_History_List = new HashSet<Res_EnrollmentRequest_History>();
    }
  }
}

