﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ExpansionProfile_Index__profile : UriIndex
  {
    public int Res_ExpansionProfile_Index__profileID {get; set;}
    public virtual Res_ExpansionProfile Res_ExpansionProfile { get; set; }
   
    public Res_ExpansionProfile_Index__profile()
    {
    }
  }
}
