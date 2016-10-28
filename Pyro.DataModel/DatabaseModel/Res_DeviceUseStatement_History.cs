using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_DeviceUseStatement_History : ResourceIndexBase
  {
    public int Res_DeviceUseStatement_HistoryID {get; set;}
    public virtual Res_DeviceUseStatement Res_DeviceUseStatement { get; set; }
   
    public Res_DeviceUseStatement_History()
    {
    }
  }
}

