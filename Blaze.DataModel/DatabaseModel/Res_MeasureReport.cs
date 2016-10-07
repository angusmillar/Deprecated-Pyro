using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MeasureReport : ResourceIndexBase
  {
    public int Res_MeasureReportID {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_MeasureReport_History> Res_MeasureReport_History_List { get; set; }
    public ICollection<Res_MeasureReport_Index__profile> _profile_List { get; set; }
    public ICollection<Res_MeasureReport_Index__security> _security_List { get; set; }
    public ICollection<Res_MeasureReport_Index__tag> _tag_List { get; set; }
   
    public Res_MeasureReport()
    {
      this._profile_List = new HashSet<Res_MeasureReport_Index__profile>();
      this._security_List = new HashSet<Res_MeasureReport_Index__security>();
      this._tag_List = new HashSet<Res_MeasureReport_Index__tag>();
      this.Res_MeasureReport_History_List = new HashSet<Res_MeasureReport_History>();
    }
  }
}

