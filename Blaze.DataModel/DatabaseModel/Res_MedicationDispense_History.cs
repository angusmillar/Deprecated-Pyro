using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MedicationDispense_History
  {
    public int Res_MedicationDispenseID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_MedicationDispense Res_MedicationDispense { get; set; }
   
    public Res_MedicationDispense_History()
    {
    }
  }
}

