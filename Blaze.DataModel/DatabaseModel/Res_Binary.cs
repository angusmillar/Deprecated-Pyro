﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Binary : ResourceIndexBase
  {
    public int Res_BinaryID {get; set;}
    public string contenttype_Code {get; set;}
    public string contenttype_System {get; set;}
    public ICollection<Res_Binary_History> Res_Binary_History_List { get; set; }
    public ICollection<Res_Binary_Index_profile> profile_List { get; set; }
    public ICollection<Res_Binary_Index_security> security_List { get; set; }
    public ICollection<Res_Binary_Index_tag> tag_List { get; set; }
   
    public Res_Binary()
    {
      this.profile_List = new HashSet<Res_Binary_Index_profile>();
      this.security_List = new HashSet<Res_Binary_Index_security>();
      this.tag_List = new HashSet<Res_Binary_Index_tag>();
      this.Res_Binary_History_List = new HashSet<Res_Binary_History>();
    }
  }
}

