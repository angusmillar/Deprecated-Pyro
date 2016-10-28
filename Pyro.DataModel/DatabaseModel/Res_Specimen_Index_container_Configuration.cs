﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;

//This is an Auto generated file do not change it's contents!!.

namespace Blaze.DataModel.DatabaseModel
{
  public class Res_Specimen_Index_container_Configuration : EntityTypeConfiguration<Res_Specimen_Index_container>
  {

    public Res_Specimen_Index_container_Configuration()
    {
      HasKey(x => x.Res_Specimen_Index_containerID).Property(x => x.Res_Specimen_Index_containerID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Specimen).WithMany(x => x.container_List).WillCascadeOnDelete(true);
    }
  }
}