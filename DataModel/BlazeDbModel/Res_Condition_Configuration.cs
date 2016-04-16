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

namespace DataModel.BlazeDbModel
{
  public class Res_Condition_Configuration : EntityTypeConfiguration<Res_Condition>
  {

    public Res_Condition_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Property(x => x.Received).IsRequired();
      Property(x => x.XmlBlob).IsRequired();      
      Property(x => x.asserter_FhirId).IsOptional();
      Property(x => x.asserter_Type).IsOptional();
      Property(x => x.asserter_Url).IsOptional();
      Property(x => x.clinicalstatus_Code).IsOptional();
      Property(x => x.clinicalstatus_System).IsOptional();
      Property(x => x.date_recorded_DateTimeOffset).IsOptional();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      Property(x => x.encounter_Url).IsOptional();
      Property(x => x.onset_DateTimeOffset).IsOptional();
      Property(x => x.onset_info_String).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      Property(x => x.patient_Url).IsOptional();
     
     }
  }
}
