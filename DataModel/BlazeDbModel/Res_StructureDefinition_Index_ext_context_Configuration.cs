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
  public class Res_StructureDefinition_Index_ext_context_Configuration : EntityTypeConfiguration<Res_StructureDefinition_Index_ext_context>
  {
    public Res_StructureDefinition_Index_ext_context_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      HasRequired(x => x.Res_StructureDefinition);
      Property(x => x.String).IsRequired();
     }
  }
}