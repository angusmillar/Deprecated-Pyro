using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Media_History : ResourceIndexBase
  {
    public int Res_Media_HistoryID {get; set;}
    public virtual Res_Media Res_Media { get; set; }
   
    public Res_Media_History()
    {
    }
  }
}

