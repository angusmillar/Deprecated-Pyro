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
  public class Res_Linkage_Configuration : EntityTypeConfiguration<Res_Linkage>
  {

    public Res_Linkage_Configuration()
    {
      HasKey(x => x.Res_LinkageID).Property(x => x.Res_LinkageID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.author_VersionId).IsOptional();
      Property(x => x.author_FhirId).IsOptional();
      Property(x => x.author_Type).IsOptional();
      HasOptional(x => x.author_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.author_Url).WithMany().HasForeignKey(x => x.author_Url_Blaze_RootUrlStoreID);
    }
  }
}
