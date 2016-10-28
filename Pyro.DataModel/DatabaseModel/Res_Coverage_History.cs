using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Coverage_History : ResourceIndexBase
  {
    public int Res_Coverage_HistoryID {get; set;}
    public virtual Res_Coverage Res_Coverage { get; set; }
   
    public Res_Coverage_History()
    {
    }
  }
}

