using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MedicationStatement_History
  {
    public int Res_MedicationStatementID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_MedicationStatement Res_MedicationStatement { get; set; }
   
    public Res_MedicationStatement_History()
    {
    }
  }
}

