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
  public class Res_Communication_Configuration : EntityTypeConfiguration<Res_Communication>
  {

    public Res_Communication_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Property(x => x.Received).IsRequired();
      Property(x => x.XmlBlob).IsRequired();      
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      Property(x => x.encounter_Url).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      Property(x => x.patient_Url).IsOptional();
      Property(x => x.received_DateTimeOffset).IsOptional();
      Property(x => x.request_FhirId).IsOptional();
      Property(x => x.request_Type).IsOptional();
      Property(x => x.request_Url).IsOptional();
      Property(x => x.sender_FhirId).IsOptional();
      Property(x => x.sender_Type).IsOptional();
      Property(x => x.sender_Url).IsOptional();
      Property(x => x.sent_DateTimeOffset).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      Property(x => x.subject_Url).IsOptional();
     
     }
  }
}
