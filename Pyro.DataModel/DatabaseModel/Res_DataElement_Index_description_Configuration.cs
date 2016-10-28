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
  public class Res_DataElement_Index_description_Configuration : EntityTypeConfiguration<Res_DataElement_Index_description>
  {

    public Res_DataElement_Index_description_Configuration()
    {
      HasKey(x => x.Res_DataElement_Index_descriptionID).Property(x => x.Res_DataElement_Index_descriptionID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_DataElement).WithMany(x => x.description_List).WillCascadeOnDelete(true);
    }
  }
}