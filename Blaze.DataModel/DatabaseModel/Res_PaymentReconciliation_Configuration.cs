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
  public class Res_PaymentReconciliation_Configuration : EntityTypeConfiguration<Res_PaymentReconciliation>
  {

    public Res_PaymentReconciliation_Configuration()
    {
      HasKey(x => x.Res_PaymentReconciliationID).Property(x => x.Res_PaymentReconciliationID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.created_DateTimeOffset).IsOptional();
      Property(x => x.disposition_String).IsOptional();
      Property(x => x.organizationidentifier_Code).IsOptional();
      Property(x => x.organizationidentifier_System).IsOptional();
      Property(x => x.organizationreference_FhirId).IsOptional();
      Property(x => x.organizationreference_Type).IsOptional();
      HasOptional(x => x.organizationreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.organizationreference_Url).WithMany().HasForeignKey(x => x.organizationreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.outcome_Code).IsOptional();
      Property(x => x.outcome_System).IsOptional();
      Property(x => x.requestidentifier_Code).IsOptional();
      Property(x => x.requestidentifier_System).IsOptional();
      Property(x => x.requestorganizationidentifier_Code).IsOptional();
      Property(x => x.requestorganizationidentifier_System).IsOptional();
      Property(x => x.requestorganizationreference_FhirId).IsOptional();
      Property(x => x.requestorganizationreference_Type).IsOptional();
      HasOptional(x => x.requestorganizationreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.requestorganizationreference_Url).WithMany().HasForeignKey(x => x.requestorganizationreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.requestprovideridentifier_Code).IsOptional();
      Property(x => x.requestprovideridentifier_System).IsOptional();
      Property(x => x.requestproviderreference_FhirId).IsOptional();
      Property(x => x.requestproviderreference_Type).IsOptional();
      HasOptional(x => x.requestproviderreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.requestproviderreference_Url).WithMany().HasForeignKey(x => x.requestproviderreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.requestreference_FhirId).IsOptional();
      Property(x => x.requestreference_Type).IsOptional();
      HasOptional(x => x.requestreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.requestreference_Url).WithMany().HasForeignKey(x => x.requestreference_Url_Blaze_RootUrlStoreID);
    }
  }
}
