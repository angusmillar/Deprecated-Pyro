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

namespace Blaze.DataModel.BlazeDbModel
{
  public class Res_DeviceMetric_Configuration : EntityTypeConfiguration<Res_DeviceMetric>
  {

    public Res_DeviceMetric_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();      
      Property(x => x.category_Code).IsOptional();
      Property(x => x.category_System).IsOptional();
      Property(x => x.identifier_Code).IsOptional();
      Property(x => x.identifier_System).IsOptional();
      Property(x => x.parent_FhirId).IsOptional();
      Property(x => x.parent_Type).IsOptional();
      Property(x => x.parent_Url).IsOptional();
      Property(x => x.source_FhirId).IsOptional();
      Property(x => x.source_Type).IsOptional();
      Property(x => x.source_Url).IsOptional();
     
     }
  }
}
