﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Observation_Index_component_value_concept
  {
    public int Res_Observation_Index_component_value_conceptID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Observation Res_Observation { get; set; }
   
    public Res_Observation_Index_component_value_concept()
    {
    }
  }
}

