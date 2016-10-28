using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_ProcessRequest_History : ResourceIndexBase
  {
    public int Res_ProcessRequest_HistoryID {get; set;}
    public virtual Res_ProcessRequest Res_ProcessRequest { get; set; }
   
    public Res_ProcessRequest_History()
    {
    }
  }
}

