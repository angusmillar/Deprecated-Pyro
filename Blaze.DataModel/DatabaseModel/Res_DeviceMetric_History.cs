using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DeviceMetric_History
  {
    public int Res_DeviceMetricID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_DeviceMetric Res_DeviceMetric { get; set; }
   
    public Res_DeviceMetric_History()
    {
    }
  }
}

