using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_ProcedureRequest_History : ResourceIndexBase
  {
    public int Res_ProcedureRequest_HistoryID {get; set;}
    public virtual Res_ProcedureRequest Res_ProcedureRequest { get; set; }
   
    public Res_ProcedureRequest_History()
    {
    }
  }
}

