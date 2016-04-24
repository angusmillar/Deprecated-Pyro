using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Immunization_History
  {
    public int Res_ImmunizationID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_Immunization Res_Immunization { get; set; }
   
    public Res_Immunization_History()
    {
    }
  }
}

