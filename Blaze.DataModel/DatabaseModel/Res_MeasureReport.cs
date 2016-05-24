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
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_MeasureReport_History> Res_MeasureReport_History_List { get; set; }
    public ICollection<Res_MeasureReport_Index_profile> profile_List { get; set; }
    public ICollection<Res_MeasureReport_Index_security> security_List { get; set; }
    public ICollection<Res_MeasureReport_Index_tag> tag_List { get; set; }
   
    public Res_MeasureReport()
    {
      this.profile_List = new HashSet<Res_MeasureReport_Index_profile>();
      this.security_List = new HashSet<Res_MeasureReport_Index_security>();
      this.tag_List = new HashSet<Res_MeasureReport_Index_tag>();
      this.Res_MeasureReport_History_List = new HashSet<Res_MeasureReport_History>();
    }
  }
}

