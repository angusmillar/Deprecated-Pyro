using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_EnrollmentResponse_History
  {
    public int Res_EnrollmentResponseID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_EnrollmentResponse Res_EnrollmentResponse { get; set; }
   
    public Res_EnrollmentResponse_History()
    {
    }
  }
}

