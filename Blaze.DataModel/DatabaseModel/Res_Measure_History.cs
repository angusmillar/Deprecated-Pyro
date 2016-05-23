using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Measure_History : ResourceIndexBase
  {
    public int Res_Measure_HistoryID {get; set;}
    public virtual Res_Measure Res_Measure { get; set; }
   
    public Res_Measure_History()
    {
    }
  }
}

