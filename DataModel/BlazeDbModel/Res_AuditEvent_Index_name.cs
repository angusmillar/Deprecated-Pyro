﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_AuditEvent_Index_name
  {
    public int Id {get; set;}
    public string String {get; set;}                  
    
    //Keyed
    public virtual Res_AuditEvent Res_AuditEvent { get; set; }                     
  }
}