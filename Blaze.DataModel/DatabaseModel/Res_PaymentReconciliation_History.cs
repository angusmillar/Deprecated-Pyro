using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_PaymentReconciliation_History
  {
    public int Res_PaymentReconciliationID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public virtual Res_PaymentReconciliation Res_PaymentReconciliation { get; set; }
   
    public Res_PaymentReconciliation_History()
    {
    }
  }
}

