using System;
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
  public class Res_Patient_Configuration : EntityTypeConfiguration<Res_Patient>
  {

    public Res_Patient_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Property(x => x.Received).IsRequired();
      Property(x => x.XmlBlob).IsRequired();      
      Property(x => x.active_Code).IsOptional();
      Property(x => x.active_System).IsOptional();
      Property(x => x.birthdate_DateTimeOffset).IsOptional();
      Property(x => x.deathdate_DateTimeOffset).IsOptional();
      Property(x => x.deceased_Code).IsOptional();
      Property(x => x.deceased_System).IsOptional();
      Property(x => x.gender_Code).IsOptional();
      Property(x => x.gender_System).IsOptional();
      Property(x => x.organization_FhirId).IsOptional();
      Property(x => x.organization_Type).IsOptional();
      Property(x => x.organization_Url).IsOptional();
     
     }
  }
}
