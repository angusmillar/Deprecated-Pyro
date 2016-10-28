using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_SupplyDelivery_History : ResourceIndexBase
  {
    public int Res_SupplyDelivery_HistoryID {get; set;}
    public virtual Res_SupplyDelivery Res_SupplyDelivery { get; set; }
   
    public Res_SupplyDelivery_History()
    {
    }
  }
}

