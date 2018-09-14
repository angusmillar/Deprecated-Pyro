using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.Database;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ServiceCompartmentContextConfig : EntityTypeConfiguration<_ServiceCompartment>
  {
    public ServiceCompartmentContextConfig()
    {
      ToTable("_Compartment");
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.Url).IsRequired().HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength);
      Property(x => x.CompartmentDefinitionResourceId).IsRequired().HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength);
      Property(x => x.CompartmentDefinitionResourceVersion).IsRequired().HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength);
      Property(x => x.Name).IsRequired().HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.NameMaxLength);
      //Removed STU3 to R4
      //Property(x => x.Title).IsOptional().HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.DescriptionMaxLength);

      Property(x => x.Code)
       .IsRequired()
       .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.ResourceTypeStringMaxLength)
       .HasColumnAnnotation(IndexAnnotation.AnnotationName,
       new IndexAnnotation(new IndexAttribute("ix_CompartmentCode") { IsUnique = true }));

      Property(x => x.LastUpdated)
       .HasPrecision(StaticDatabaseInfo.BaseDatabaseFieldLength.DateTimeOffsetPrecision)
       .IsRequired();
      
      HasMany(c => c.ResourceList).WithRequired(c => c.ServiceCompartment).HasForeignKey(c => c._ServiceCompartmentId).WillCascadeOnDelete(true);
    }
  }
}
