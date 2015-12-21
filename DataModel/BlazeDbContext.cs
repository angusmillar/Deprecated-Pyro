using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;

namespace DataModel
{
  public class BlazeDbContext : DbContext
  {
    public BlazeDbContext()
      : base("BlazeConnectionString")
    {
      //Database.SetInitializer<BlazeDbContext>(new DropCreateDatabaseAlways<BlazeDbContext>());       
    }

    public DbSet<Model.Resource> Resource { get; set; }

    public DbSet<Model.PatientResource> PatientResource { get; set; }

    public DbSet<Model.Period> Period { get; set; }

    public DbSet<Model.HumanName> HumanName { get; set; }
    public DbSet<Model.Family> Family { get; set; }
    public DbSet<Model.Given> Given { get; set; }
    public DbSet<Model.Prefix> Prefix { get; set; }
    public DbSet<Model.Suffix> Suffix { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      //Resource
      modelBuilder.Entity<Model.Resource>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.Version).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.Xml).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.Received).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.IsCurrent).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.IsDeleted).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.PatientResourceId).IsOptional();
      modelBuilder.Entity<Model.Resource>()
        .HasOptional<Model.PatientResource>(x => x.PatientResource)
        .WithMany(x => x.Resources)
        .HasForeignKey(x => x.PatientResourceId);

      //PatientResource
      modelBuilder.Entity<Model.PatientResource>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.PatientResource>().Property(x => x.FhirResourceId).IsRequired().HasMaxLength(500)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(
          new IndexAttribute("IX_FhirResourceId") { IsUnique = true }));
      modelBuilder.Entity<Model.PatientResource>().Property(x => x.Gender).IsOptional();


      //Period
      modelBuilder.Entity<Model.Period>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Period>().Property(x => x.Start).IsOptional();
      modelBuilder.Entity<Model.Period>().Property(x => x.End).IsOptional();
      modelBuilder.Entity<Model.Period>()
        .HasOptional(x => x.OfHumanName)
        .WithOptionalPrincipal(x => x.Period);

      //HumanNmae
      modelBuilder.Entity<Model.HumanName>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.HumanName>().Property(x => x.Use).IsOptional();
      modelBuilder.Entity<Model.HumanName>().Property(x => x.Text).IsOptional();
      modelBuilder.Entity<Model.HumanName>().Property(x => x.PatientResourceId).IsOptional();
      modelBuilder.Entity<Model.HumanName>().HasOptional(x => x.PatientResource);

      //Family
      modelBuilder.Entity<Model.Family>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Family>().Property(x => x.Value).IsRequired();
      modelBuilder.Entity<Model.Family>().Property(x => x.HumanNameId).IsRequired();

      //Given
      modelBuilder.Entity<Model.Given>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Given>().Property(x => x.Value).IsRequired();
      modelBuilder.Entity<Model.Given>().Property(x => x.HumanNameId).IsRequired();

      //Prefix
      modelBuilder.Entity<Model.Prefix>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Prefix>().Property(x => x.Value).IsRequired();
      modelBuilder.Entity<Model.Prefix>().Property(x => x.HumanNameId).IsRequired();

      //Suffix
      modelBuilder.Entity<Model.Suffix>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Suffix>().Property(x => x.Value).IsRequired();
      modelBuilder.Entity<Model.Suffix>().Property(x => x.HumanNameId).IsRequired();

    }


  }
}
