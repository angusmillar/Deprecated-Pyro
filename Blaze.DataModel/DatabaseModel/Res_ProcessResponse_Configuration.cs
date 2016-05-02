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
  public class Res_ProcessResponse_Configuration : EntityTypeConfiguration<Res_ProcessResponse>
  {

    public Res_ProcessResponse_Configuration()
    {
      HasKey(x => x.Res_ProcessResponseID).Property(x => x.Res_ProcessResponseID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.organization_FhirId).IsOptional();
      Property(x => x.organization_Type).IsOptional();
      HasOptional(x => x.organization_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.organization_Url).WithMany().HasForeignKey(x => x.organization_Url_Blaze_RootUrlStoreID);
      Property(x => x.request_FhirId).IsOptional();
      Property(x => x.request_Type).IsOptional();
      HasOptional(x => x.request_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.request_Url).WithMany().HasForeignKey(x => x.request_Url_Blaze_RootUrlStoreID);
      Property(x => x.requestorganization_FhirId).IsOptional();
      Property(x => x.requestorganization_Type).IsOptional();
      HasOptional(x => x.requestorganization_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.requestorganization_Url).WithMany().HasForeignKey(x => x.requestorganization_Url_Blaze_RootUrlStoreID);
      Property(x => x.requestprovider_FhirId).IsOptional();
      Property(x => x.requestprovider_Type).IsOptional();
      HasOptional(x => x.requestprovider_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.requestprovider_Url).WithMany().HasForeignKey(x => x.requestprovider_Url_Blaze_RootUrlStoreID);
    }
  }
}
