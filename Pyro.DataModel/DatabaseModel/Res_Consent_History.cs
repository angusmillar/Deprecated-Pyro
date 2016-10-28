using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Consent_History : ResourceIndexBase
  {
    public int Res_Consent_HistoryID {get; set;}
    public virtual Res_Consent Res_Consent { get; set; }
   
    public Res_Consent_History()
    {
    }
  }
}

