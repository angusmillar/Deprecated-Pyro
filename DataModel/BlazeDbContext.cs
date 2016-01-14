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

    public DbSet<Model.Identifier> Identifier { get; set; }
    public DbSet<Model.CodeableConcept> CodeableConcept { get; set; }
    public DbSet<Model.Coding> Codeing { get; set; }

    public DbSet<Model.Period> Period { get; set; }

    public DbSet<Model.HumanName> HumanName { get; set; }
    public DbSet<Model.Family> Family { get; set; }
    public DbSet<Model.Given> Given { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

      //Resource
      modelBuilder.Entity<Model.Resource>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.Version).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.Xml).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.Received).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.IsCurrent).IsRequired();
      modelBuilder.Entity<Model.Resource>().Property(x => x.IsDeleted).IsRequired();
      modelBuilder.Entity<Model.Resource>()
          .HasOptional(x => x.PatientResource)
          .WithMany(x => x.Resources);
      
      //PatientResource
      modelBuilder.Entity<Model.PatientResource>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();      
      modelBuilder.Entity<Model.PatientResource>().Property(x => x.Gender).IsOptional();
      modelBuilder.Entity<Model.PatientResource>().Property(x => x.BirthDate).IsOptional();
      modelBuilder.Entity<Model.PatientResource>().Property(x => x.FhirResourceId).IsRequired().HasMaxLength(500)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(
          new IndexAttribute("IX_FhirResourceId") { IsUnique = true }));
      modelBuilder.Entity<Model.PatientResource>().Property(x => x.Gender).IsOptional();

      //Identifier
      modelBuilder.Entity<Model.Identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Identifier>().Property(x => x.Use).IsOptional();
      modelBuilder.Entity<Model.Identifier>().Property(x => x.System).IsOptional();
      modelBuilder.Entity<Model.Identifier>().Property(x => x.Value).IsOptional();
      modelBuilder.Entity<Model.Identifier>().Property(x => x.Assigner).IsOptional();
      modelBuilder.Entity<Model.Identifier>()
        .HasOptional(x => x.Period)
        .WithOptionalDependent(x => x.Identifier); // Note: the Period keyed to this Identifier is dependant on the Identifier
      modelBuilder.Entity<Model.Identifier>()
        .HasOptional(x => x.PatientResource)
        .WithMany(x => x.Identifier);             //Note: PatientResource_ID key on Identifier so PatientResource can have many Identifiers
      modelBuilder.Entity<Model.Identifier>()
        .HasOptional(x => x.Type)
        .WithOptionalDependent(x => x.Identifier); // Note: the Type(CodableConcept) keyed to this Identifier is dependant on the Identifier          

      //CodeableConcept
      modelBuilder.Entity<Model.CodeableConcept>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.CodeableConcept>().Property(x => x.Text).IsOptional();


      //Coding
      modelBuilder.Entity<Model.Coding>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Coding>().Property(x => x.System).IsOptional();
      modelBuilder.Entity<Model.Coding>().Property(x => x.Version).IsOptional();
      modelBuilder.Entity<Model.Coding>().Property(x => x.Code).IsOptional();
      modelBuilder.Entity<Model.Coding>().Property(x => x.Display).IsOptional();
      modelBuilder.Entity<Model.Coding>().Property(x => x.UserSelected).IsOptional();      
      modelBuilder.Entity<Model.Coding>()
        .HasOptional(x => x.CodeableConcept)
        .WithMany(x => x.Coding);

      //Period
      modelBuilder.Entity<Model.Period>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Period>().Property(x => x.Start).IsOptional();
      modelBuilder.Entity<Model.Period>().Property(x => x.End).IsOptional();
      
      //HumanNmae
      modelBuilder.Entity<Model.HumanName>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.HumanName>().Property(x => x.Use).IsOptional();
      modelBuilder.Entity<Model.HumanName>().Property(x => x.Text).IsOptional();      
      modelBuilder.Entity<Model.HumanName>().HasOptional(x => x.Period).WithOptionalDependent(x => x.HumanName);
      modelBuilder.Entity<Model.HumanName>()
        .HasOptional(x => x.PatientResource)
        .WithMany(x => x.HumanName);
        
      //Family
      modelBuilder.Entity<Model.Family>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Family>().Property(x => x.Value).IsRequired();
      modelBuilder.Entity<Model.Family>().HasRequired(x => x.HumanName);      

      //Given
      modelBuilder.Entity<Model.Given>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Given>().Property(x => x.Value).IsRequired();
      modelBuilder.Entity<Model.Given>().HasRequired(x => x.HumanName);
      
     

    }


  }
}
