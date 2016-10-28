using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_DeviceMetric : ResourceIndexBase
  {
    public int Res_DeviceMetricID {get; set;}
    public string category_Code {get; set;}
    public string category_System {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string parent_VersionId {get; set;}
    public string parent_FhirId {get; set;}
    public string parent_Type {get; set;}
    public virtual ServiceRootURL_Store parent_Url { get; set; }
    public int? parent_ServiceRootURL_StoreID { get; set; }
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual ServiceRootURL_Store source_Url { get; set; }
    public int? source_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_DeviceMetric_History> Res_DeviceMetric_History_List { get; set; }
    public ICollection<Res_DeviceMetric_Index_type> type_List { get; set; }
    public ICollection<Res_DeviceMetric_Index__profile> _profile_List { get; set; }
    public ICollection<Res_DeviceMetric_Index__security> _security_List { get; set; }
    public ICollection<Res_DeviceMetric_Index__tag> _tag_List { get; set; }
   
    public Res_DeviceMetric()
    {
      this.type_List = new HashSet<Res_DeviceMetric_Index_type>();
      this._profile_List = new HashSet<Res_DeviceMetric_Index__profile>();
      this._security_List = new HashSet<Res_DeviceMetric_Index__security>();
      this._tag_List = new HashSet<Res_DeviceMetric_Index__tag>();
      this.Res_DeviceMetric_History_List = new HashSet<Res_DeviceMetric_History>();
    }
  }
}

