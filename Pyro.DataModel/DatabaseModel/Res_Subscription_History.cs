﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Subscription_History : ResourceIndexBase
  {
    public int Res_Subscription_HistoryID {get; set;}
    public virtual Res_Subscription Res_Subscription { get; set; }
   
    public Res_Subscription_History()
    {
    }
  }
}
