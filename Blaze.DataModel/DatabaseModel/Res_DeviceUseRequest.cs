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
    public virtual ServiceRootURL_Store device_Url { get; set; }
    public int? device_ServiceRootURL_StoreID { get; set; }
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
    public ICollection<Res_DeviceUseRequest_History> Res_DeviceUseRequest_History_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index__profile> _profile_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index__security> _security_List { get; set; }
    public ICollection<Res_DeviceUseRequest_Index__tag> _tag_List { get; set; }
   
    public Res_DeviceUseRequest()
    {
      this._profile_List = new HashSet<Res_DeviceUseRequest_Index__profile>();
      this._security_List = new HashSet<Res_DeviceUseRequest_Index__security>();
      this._tag_List = new HashSet<Res_DeviceUseRequest_Index__tag>();
      this.Res_DeviceUseRequest_History_List = new HashSet<Res_DeviceUseRequest_History>();
    }
  }
}

