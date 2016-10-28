using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Device : ResourceIndexBase
  {
    public int Res_DeviceID {get; set;}
    public string location_VersionId {get; set;}
    public string location_FhirId {get; set;}
    public string location_Type {get; set;}
    public virtual ServiceRootURL_Store location_Url { get; set; }
    public int? location_ServiceRootURL_StoreID { get; set; }
    public string manufacturer_String {get; set;}
    public string model_String {get; set;}
    public string organization_VersionId {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual ServiceRootURL_Store organization_Url { get; set; }
    public int? organization_ServiceRootURL_StoreID { get; set; }
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string udicarrier_Code {get; set;}
    public string udicarrier_System {get; set;}
    public string url_Uri {get; set;}
    public ICollection<Res_Device_History> Res_Device_History_List { get; set; }
    public ICollection<Res_Device_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Device_Index_type> type_List { get; set; }
    public ICollection<Res_Device_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Device_Index__security> _security_List { get; set; }
    public ICollection<Res_Device_Index__tag> _tag_List { get; set; }
   
    public Res_Device()
    {
      this.identifier_List = new HashSet<Res_Device_Index_identifier>();
      this.type_List = new HashSet<Res_Device_Index_type>();
      this._profile_List = new HashSet<Res_Device_Index__profile>();
      this._security_List = new HashSet<Res_Device_Index__security>();
      this._tag_List = new HashSet<Res_Device_Index__tag>();
      this.Res_Device_History_List = new HashSet<Res_Device_History>();
    }
  }
}

