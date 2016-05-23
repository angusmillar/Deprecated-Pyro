using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_GuidanceResponse_History : ResourceIndexBase
  {
    public int Res_GuidanceResponse_HistoryID {get; set;}
    public virtual Res_GuidanceResponse Res_GuidanceResponse { get; set; }
   
    public Res_GuidanceResponse_History()
    {
    }
  }
}

