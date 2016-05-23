using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OperationOutcome_History : ResourceIndexBase
  {
    public int Res_OperationOutcome_HistoryID {get; set;}
    public virtual Res_OperationOutcome Res_OperationOutcome { get; set; }
   
    public Res_OperationOutcome_History()
    {
    }
  }
}

