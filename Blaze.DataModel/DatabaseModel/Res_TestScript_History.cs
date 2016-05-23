using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_TestScript_History : ResourceIndexBase
  {
    public int Res_TestScript_HistoryID {get; set;}
    public virtual Res_TestScript Res_TestScript { get; set; }
   
    public Res_TestScript_History()
    {
    }
  }
}

