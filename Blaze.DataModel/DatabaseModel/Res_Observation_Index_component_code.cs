﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Observation_Index_component_code : TokenIndex
  {
    public int Res_Observation_Index_component_codeID {get; set;}
    public virtual Res_Observation Res_Observation { get; set; }
   
    public Res_Observation_Index_component_code()
    {
    }
  }
}
