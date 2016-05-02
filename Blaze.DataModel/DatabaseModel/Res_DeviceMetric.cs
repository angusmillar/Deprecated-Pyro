using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DeviceMetric
  {
    public int Res_DeviceMetricID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string category_Code {get; set;}
    public string category_System {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string parent_FhirId {get; set;}
    public string parent_Type {get; set;}
    public virtual Blaze_RootUrlStore parent_Url { get; set; }
    public int? parent_Url_Blaze_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Blaze_RootUrlStore source_Url { get; set; }
    public int? source_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_DeviceMetric_Index_type> type_List { get; set; }
   
    public Res_DeviceMetric()
    {
      this.type_List = new HashSet<Res_DeviceMetric_Index_type>();
    }
  }
}

