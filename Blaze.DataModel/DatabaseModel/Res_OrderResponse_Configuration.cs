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
  public class Res_OrderResponse_Configuration : EntityTypeConfiguration<Res_OrderResponse>
  {

    public Res_OrderResponse_Configuration()
    {
      HasKey(x => x.Res_OrderResponseID).Property(x => x.Res_OrderResponseID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.code_Code).IsOptional();
      Property(x => x.code_System).IsOptional();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.request_FhirId).IsOptional();
      Property(x => x.request_Type).IsOptional();
      HasOptional(x => x.request_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.request_Url).WithMany().HasForeignKey(x => x.request_Url_Blaze_RootUrlStoreID);
      Property(x => x.who_FhirId).IsOptional();
      Property(x => x.who_Type).IsOptional();
      HasOptional(x => x.who_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.who_Url).WithMany().HasForeignKey(x => x.who_Url_Blaze_RootUrlStoreID);
    }
  }
}
