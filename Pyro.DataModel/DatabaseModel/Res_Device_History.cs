using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Device_History : ResourceIndexBase
  {
    public int Res_Device_HistoryID {get; set;}
    public virtual Res_Device Res_Device { get; set; }
   
    public Res_Device_History()
    {
    }
  }
}

