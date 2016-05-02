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
  public class Res_PaymentNotice_Configuration : EntityTypeConfiguration<Res_PaymentNotice>
  {

    public Res_PaymentNotice_Configuration()
    {
      HasKey(x => x.Res_PaymentNoticeID).Property(x => x.Res_PaymentNoticeID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.created_DateTimeOffset).IsOptional();
      Property(x => x.organizationidentifier_Code).IsOptional();
      Property(x => x.organizationidentifier_System).IsOptional();
      Property(x => x.organizationreference_FhirId).IsOptional();
      Property(x => x.organizationreference_Type).IsOptional();
      HasOptional(x => x.organizationreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.organizationreference_Url).WithMany().HasForeignKey(x => x.organizationreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.paymentstatus_Code).IsOptional();
      Property(x => x.paymentstatus_System).IsOptional();
      Property(x => x.provideridentifier_Code).IsOptional();
      Property(x => x.provideridentifier_System).IsOptional();
      Property(x => x.providerreference_FhirId).IsOptional();
      Property(x => x.providerreference_Type).IsOptional();
      HasOptional(x => x.providerreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.providerreference_Url).WithMany().HasForeignKey(x => x.providerreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.requestidentifier_Code).IsOptional();
      Property(x => x.requestidentifier_System).IsOptional();
      Property(x => x.requestreference_FhirId).IsOptional();
      Property(x => x.requestreference_Type).IsOptional();
      HasOptional(x => x.requestreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.requestreference_Url).WithMany().HasForeignKey(x => x.requestreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.responseidentifier_Code).IsOptional();
      Property(x => x.responseidentifier_System).IsOptional();
      Property(x => x.responsereference_FhirId).IsOptional();
      Property(x => x.responsereference_Type).IsOptional();
      HasOptional(x => x.responsereference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.responsereference_Url).WithMany().HasForeignKey(x => x.responsereference_Url_Blaze_RootUrlStoreID);
      Property(x => x.statusdate_DateTimeOffset).IsOptional();
    }
  }
}
