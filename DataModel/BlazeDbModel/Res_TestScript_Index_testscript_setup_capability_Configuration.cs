﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;

//This is an Auto generated file do not change it's contents!!.

namespace DataModel.BlazeDbModel
{
  public class Res_TestScript_Index_testscript_setup_capability_Configuration : EntityTypeConfiguration<Res_TestScript_Index_testscript_setup_capability>
  {
    public Res_TestScript_Index_testscript_setup_capability_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      HasRequired(x => x.Res_TestScript);
      Property(x => x.String).IsRequired();
     }
  }
}