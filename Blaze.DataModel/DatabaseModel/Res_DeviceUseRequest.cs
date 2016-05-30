using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DeviceUseRequest : ResourceIndexBase
  {
    public int Res_DeviceUseRequestID {get; set;}
    public string device_VersionId {get; set;}
    public string device_FhirId {get; set;}
    public string device_Type {get; set;}
    public virtual Blaze_RootUrlStore device_Url { get; set; }
    public int? device_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_DeviceUseRequest_History> Res_DeviceUseRequest_History_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_profile> profile_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_security> security_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index_tag> tag_List { get; set; }
   
    public Res_DeviceUseRequest()
    {
      this.profile_List = new HashSet<Res_DeviceUseRequest_Index_profile>();
      this.security_List = new HashSet<Res_DeviceUseRequest_Index_security>();
      this.tag_List = new HashSet<Res_DeviceUseRequest_Index_tag>();
      this.Res_DeviceUseRequest_History_List = new HashSet<Res_DeviceUseRequest_History>();
    }
  }
}

