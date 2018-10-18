using Pyro.Common.Database;
using Pyro.DataLayer.DbModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class BackburnerConnectionConfig : EntityTypeConfiguration<_BackburnerConnection>
  {
    public BackburnerConnectionConfig()
    {
      ToTable("_BackburnerConnection");
      Property(x => x.IsConnected)
        .IsRequired();

      Property(x => x.ConnectionId)
        .IsRequired()
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ConnectId") { IsUnique = true }));      
    }
  }
}
