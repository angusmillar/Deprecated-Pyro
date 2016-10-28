using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Binary_History : ResourceIndexBase
  {
    public int Res_Binary_HistoryID {get; set;}
    public virtual Res_Binary Res_Binary { get; set; }
   
    public Res_Binary_History()
    {
    }
  }
}

