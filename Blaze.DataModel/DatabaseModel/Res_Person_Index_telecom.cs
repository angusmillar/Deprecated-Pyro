﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Person_Index_telecom : TokenIndex
  {
    public int Res_Person_Index_telecomID {get; set;}
    public virtual Res_Person Res_Person { get; set; }
   
    public Res_Person_Index_telecom()
    {
    }
  }
}
