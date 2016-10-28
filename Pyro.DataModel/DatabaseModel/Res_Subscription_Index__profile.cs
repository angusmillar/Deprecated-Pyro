using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Subscription_Index__profile : UriIndex
  {
    public int Res_Subscription_Index__profileID {get; set;}
    public virtual Res_Subscription Res_Subscription { get; set; }
   
    public Res_Subscription_Index__profile()
    {
    }
  }
}

