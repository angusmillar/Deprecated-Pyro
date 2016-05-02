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
  public class Res_ProcessRequest_Configuration : EntityTypeConfiguration<Res_ProcessRequest>
  {

    public Res_ProcessRequest_Configuration()
    {
      HasKey(x => x.Res_ProcessRequestID).Property(x => x.Res_ProcessRequestID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.action_Code).IsOptional();
      Property(x => x.action_System).IsOptional();
      Property(x => x.organization_FhirId).IsOptional();
      Property(x => x.organization_Type).IsOptional();
      HasOptional(x => x.organization_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.organization_Url).WithMany().HasForeignKey(x => x.organization_Url_Blaze_RootUrlStoreID);
      Property(x => x.provider_FhirId).IsOptional();
      Property(x => x.provider_Type).IsOptional();
      HasOptional(x => x.provider_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.provider_Url).WithMany().HasForeignKey(x => x.provider_Url_Blaze_RootUrlStoreID);
    }
  }
}
