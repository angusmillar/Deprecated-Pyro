using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DeviceUseRequest_History
  {
    public int Res_DeviceUseRequestID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_DeviceUseRequest Res_DeviceUseRequest { get; set; }
   
    public Res_DeviceUseRequest_History()
    {
    }
  }
}

