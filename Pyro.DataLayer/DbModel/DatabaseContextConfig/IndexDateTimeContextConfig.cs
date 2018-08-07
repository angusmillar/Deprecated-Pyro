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
using Pyro.DataLayer.DbModel.EntityGenerated;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.Database;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class IndexDateTimeContextConfig<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> : EntityTypeConfiguration<ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    
  {
    public IndexDateTimeContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();

      Property(x => x.ResourceId).IsRequired();
      HasOptional<_ServiceSearchParameter>(x => x.ServiceSearchParameter).WithMany().HasForeignKey(x => x.ServiceSearchParameterId);
      Property(x => x.ServiceSearchParameterId)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_SearchParamId") { IsUnique = false }));
     
      Property(x => x.LowUtcDateTime)
     .HasPrecision(StaticDatabaseInfo.BaseDatabaseFieldLength.DateTimeOffsetPrecision)
     .IsOptional()
     .HasColumnAnnotation(IndexAnnotation.AnnotationName,
     new IndexAnnotation(new IndexAttribute("ix_LowUtcDateTime") { IsUnique = false }));

      Property(x => x.HighUtcDateTime)
        .HasPrecision(StaticDatabaseInfo.BaseDatabaseFieldLength.DateTimeOffsetPrecision)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_HighUtcDateTime") { IsUnique = false }));

    }
  }
}
