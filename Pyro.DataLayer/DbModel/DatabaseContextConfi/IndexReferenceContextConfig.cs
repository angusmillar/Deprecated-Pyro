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
using Pyro.DataLayer.DbModel.EntityGenerated;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.Database;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class IndexReferenceContextConfig<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> : EntityTypeConfiguration<ResIndexReferenceType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexBaseType : ResourceIndexBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
  {
    public IndexReferenceContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.ResourceId).IsRequired();
      HasOptional<ServiceSearchParameter>(x => x.ServiceSearchParameter).WithMany().HasForeignKey(x => x.ServiceSearchParameterId);
      Property(x => x.ServiceSearchParameterId)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ServiceSearchParameterId") { IsUnique = false }));

      Property(x => x.ReferenceFhirId)
      .HasColumnAnnotation("CaseSensitive", true)
      .HasMaxLength(StaticDatabaseInfo.BaseResourceConstatnts.FhirIdMaxLength)
      .IsRequired()
      //.IsOptional()
      .HasColumnAnnotation(IndexAnnotation.AnnotationName,
      new IndexAnnotation(new IndexAttribute("ix_ReferenceFhirId") { IsUnique = false }));

      Property(x => x.ReferenceResourceType).HasMaxLength(50)
        .IsRequired();
      //.IsOptional();

      Property(x => x.ReferenceVersionId)
        .HasColumnAnnotation("CaseSensitive", true)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceConstatnts.FhirIdMaxLength)
        .IsOptional();

      HasOptional(x => x.ReferenceUrl);
      HasOptional<ServiceBaseUrl>(x => x.ReferenceUrl).WithMany().HasForeignKey(x => x.ReferenceServiceBaseUrlId);
      Property(x => x.ReferenceServiceBaseUrlId)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ReferenceServiceBaseUrlId") { IsUnique = false }));

    }
  }
}
