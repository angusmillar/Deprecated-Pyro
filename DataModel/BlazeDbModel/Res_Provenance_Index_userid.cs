﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Provenance_Index_userid
  {
    public int Id {get; set;}
    public string Code {get; set;}                  
    public string System {get; set;}                
    
    //Keyed
    public virtual Res_Provenance Res_Provenance { get; set; }                     
  }
}