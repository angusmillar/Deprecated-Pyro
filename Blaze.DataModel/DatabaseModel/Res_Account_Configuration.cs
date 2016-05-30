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

namespace Blaze.DataModel.DatabaseModel
{
  public class Res_Account_Configuration : EntityTypeConfiguration<Res_Account>
  {

    public Res_Account_Configuration()
    {
      HasKey(x => x.Res_AccountID).Property(x => x.Res_AccountID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.balance_Quantity).IsOptional();
      Property(x => x.balance_System).IsOptional();
      Property(x => x.balance_Code).IsOptional();
      Property(x => x.name_String).IsOptional();
      Property(x => x.owner_VersionId).IsOptional();
      Property(x => x.owner_FhirId).IsOptional();
      Property(x => x.owner_Type).IsOptional();
      HasOptional(x => x.owner_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.owner_Url).WithMany().HasForeignKey(x => x.owner_Url_Blaze_RootUrlStoreID);
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_Url_Blaze_RootUrlStoreID);
      Property(x => x.period_DateTimeOffset).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.subject_VersionId).IsOptional();
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      HasOptional(x => x.subject_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.subject_Url).WithMany().HasForeignKey(x => x.subject_Url_Blaze_RootUrlStoreID);
    }
  }
}
