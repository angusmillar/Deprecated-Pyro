using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Substance_History : ResourceIndexBase
  {
    public int Res_Substance_HistoryID {get; set;}
    public virtual Res_Substance Res_Substance { get; set; }
   
    public Res_Substance_History()
    {
    }
  }
}

