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

    public DbSet<Model.ResourceIdentity> ResourceIdentity { get; set; }

    public DbSet<Model.Resource> Resource { get; set; }

    public DbSet<Model.PatientResource> PatientResource { get; set; }
    public DbSet<Model.ValueSetResource> ValueSetResource { get; set; }
    public DbSet<Model.ConceptMapResource> ConceptMapResource { get; set; }

    public DbSet<Model.Identifier> Identifier { get; set; }
    public DbSet<Model.CodeableConcept> CodeableConcept { get; set; }
    public DbSet<Model.Coding> Codeing { get; set; }

    public DbSet<Model.Concept> Concept { get; set; }
    public DbSet<Model.CodeSystem> CodeSystem { get; set; }
    public DbSet<Model.Expansion> Expansion { get; set; }
    public DbSet<Model.Compose> Compose { get; set; }
    public DbSet<Model.Include> Include { get; set; }

    public DbSet<Model.Period> Period { get; set; }

    public DbSet<Model.HumanName> HumanName { get; set; }
    public DbSet<Model.Family> Family { get; set; }
    public DbSet<Model.Given> Given { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

      //ResourceIdentity
      modelBuilder.Entity<Model.ResourceIdentity>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.ResourceIdentity>().Property(x => x.FhirResourceId).IsRequired().HasMaxLength(500)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(
          new IndexAttribute("IX_FhirResourceId") { IsUnique = true }));;

      //Resource
      modelBuilder.Entity<Model.Resource>().HasKey(x => x.Id).Property(x => x.Id).IsRequired().HasColumnOrder(0);
      //modelBuilder.Entity<Model.Resource>().Property(x => x.ResourceIdentity_Id).IsRequired().HasColumnOrder(1);      
      modelBuilder.Entity<Model.Resource>().Property(x => x.Version).IsRequired().HasColumnOrder(2);            
      modelBuilder.Entity<Model.Resource>().Property(x => x.IsCurrent).IsRequired().HasColumnOrder(3);
      modelBuilder.Entity<Model.Resource>().Property(x => x.IsDeleted).IsRequired().HasColumnOrder(4);
      modelBuilder.Entity<Model.Resource>().Property(x => x.Received).IsRequired().HasColumnOrder(5);
      modelBuilder.Entity<Model.Resource>().Property(x => x.ResourceType).IsRequired().HasColumnOrder(6);
      modelBuilder.Entity<Model.Resource>().Property(x => x.Xml).IsRequired().HasColumnOrder(7);
      modelBuilder.Entity<Model.Resource>().Property(x => x.ResourceIdentity_Id).IsRequired().HasColumnOrder(8);
      modelBuilder.Entity<Model.Resource>().Property(x => x.PatientResource_Id).IsOptional().HasColumnOrder(9);
      modelBuilder.Entity<Model.Resource>().Property(x => x.ValueSetResource_Id).IsOptional().HasColumnOrder(10);
      modelBuilder.Entity<Model.Resource>().Property(x => x.ConceptMapResource_Id).IsOptional().HasColumnOrder(11);
      modelBuilder.Entity<Model.Resource>().HasRequired(x => x.ResourceIdentity).WithMany(x => x.Resource).HasForeignKey(x => x.ResourceIdentity_Id);
      modelBuilder.Entity<Model.Resource>()
          .HasOptional(x => x.PatientResource)
          .WithMany(x => x.Resources).HasForeignKey(x => x.PatientResource_Id);
      modelBuilder.Entity<Model.Resource>()
          .HasOptional(x => x.ValueSetResource)
          .WithMany(x => x.Resource).HasForeignKey(x => x.ValueSetResource_Id);
      modelBuilder.Entity<Model.Resource>()
          .HasOptional(x => x.ConceptMapResource)
          .WithMany(x => x.Resource).HasForeignKey(x => x.ConceptMapResource_Id);
      

      //PatientResource
      modelBuilder.Entity<Model.PatientResource>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.PatientResource>().Property(x => x.Gender).IsOptional();
      modelBuilder.Entity<Model.PatientResource>().Property(x => x.BirthDate).IsOptional();
      modelBuilder.Entity<Model.PatientResource>().HasRequired(x => x.ResourceIdentity).WithMany(x => x.PatientResource).HasForeignKey(x => x.ResourceIdentity_Id);
      modelBuilder.Entity<Model.PatientResource>()
        .HasMany(x => x.Resources);

      //ValueSetResource
      modelBuilder.Entity<Model.ValueSetResource>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.ValueSetResource>().Property(x => x.Date).IsOptional();      
      modelBuilder.Entity<Model.ValueSetResource>().Property(x => x.Name).IsOptional();
      modelBuilder.Entity<Model.ValueSetResource>().Property(x => x.Description).IsOptional();            
      modelBuilder.Entity<Model.ValueSetResource>().Property(x => x.Publisher).IsOptional();
      modelBuilder.Entity<Model.ValueSetResource>().Property(x => x.Version).IsOptional();
      modelBuilder.Entity<Model.ValueSetResource>().Property(x => x.Url).IsOptional();
      modelBuilder.Entity<Model.ValueSetResource>().Property(x => x.Status).IsRequired();
      modelBuilder.Entity<Model.ValueSetResource>()
        .HasOptional(x => x.Identifier)
        .WithOptionalDependent(x => x.ValueSetResource);
      modelBuilder.Entity<Model.ValueSetResource>()
        .HasOptional(x => x.Expansion)
        .WithOptionalDependent(x => x.ValueSetResource);
      modelBuilder.Entity<Model.ValueSetResource>()
        .HasOptional(x => x.CodeSystem)
        .WithOptionalDependent(x => x.ValueSetResource); // Note: the ValueSetResource keyed to this CodeSystem is dependant on the ValueSetResource
      modelBuilder.Entity<Model.ValueSetResource>()
        .HasOptional(x => x.Compose)
        .WithOptionalDependent(x => x.ValueSetResource); // Note: the ValueSetResource keyed to this Compose is dependant on the ValueSetResource
      modelBuilder.Entity<Model.ValueSetResource>()
        .HasMany(x => x.UseContext)
        .WithOptional(x => x.ValueSetResource);        
      modelBuilder.Entity<Model.ValueSetResource>().HasRequired(x => x.ResourceIdentity)
        .WithMany(x => x.ValueSetResource)
        .HasForeignKey(x => x.ResourceIdentity_Id);
      modelBuilder.Entity<Model.ValueSetResource>()
        .HasMany(x => x.Resource);

      // ConceptMapResource
      modelBuilder.Entity<Model.ConceptMapResource>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.ConceptMapResource>().Property(x => x.Date).IsOptional();      
      modelBuilder.Entity<Model.ConceptMapResource>().Property(x => x.Name).IsOptional();
      modelBuilder.Entity<Model.ConceptMapResource>().Property(x => x.Description).IsOptional();            
      modelBuilder.Entity<Model.ConceptMapResource>().Property(x => x.Publisher).IsOptional();
      modelBuilder.Entity<Model.ConceptMapResource>().Property(x => x.Version).IsOptional();
      modelBuilder.Entity<Model.ConceptMapResource>().Property(x => x.Url).IsOptional();
      modelBuilder.Entity<Model.ConceptMapResource>().Property(x => x.Status).IsRequired();
      modelBuilder.Entity<Model.ConceptMapResource>().Property(x => x.SourceUri).IsOptional();
      modelBuilder.Entity<Model.ConceptMapResource>()
        .HasOptional(x => x.Identifier)
        .WithOptionalDependent(x => x.ConceptMapResource);
      modelBuilder.Entity<Model.ConceptMapResource>()
        .HasMany(x => x.UseContext)
        .WithOptional(x => x.ConceptMapResource);        
      modelBuilder.Entity<Model.ConceptMapResource>().HasRequired(x => x.ResourceIdentity)
        .WithMany(x => x.ConceptMapResource)
        .HasForeignKey(x => x.ResourceIdentity_Id);
      //modelBuilder.Entity<Model.ConceptMapResource>()
      //  .HasOptional(x => x.SourceReference)
      //  .HasForeignKey(x => x.ConceptMapResource);
      modelBuilder.Entity<Model.ConceptMapResource>()
        .HasMany(x => x.Resource);
              
      //CodeSystem
      modelBuilder.Entity<Model.CodeSystem>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.CodeSystem>().Property(x => x.System).IsRequired();
   
      //Concept
      modelBuilder.Entity<Model.Concept>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.Concept>().Property(x => x.Code).IsRequired().HasMaxLength(128);
      modelBuilder.Entity<Model.Concept>()
        .HasRequired(x => x.CodeSystem)
        .WithMany(x => x.Concept)
        .HasForeignKey(x => x.CodeSystem_Id);
      modelBuilder.Entity<Model.Concept>()
        .HasMany(x => x.ConceptChild)
        .WithOptional(x => x.ConceptParent);
      //Create an constraint that Code + CodeSystem_Id must be unique, a code must be unique within a single CodeSystem  
      //FHIR Spec DSTU 2.1: vsd-3: On ValueSet.codeSystem: Within a code system definition, all the codes SHALL be unique (xpath on f:ValueSet/f:codeSystem: count(distinct-values(descendant::f:concept/f:code/@value))=count(descendant::f:concept))
      modelBuilder.Entity<Model.Concept>().Property(t => t.Code)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Code_CodeSystem", 1) { IsUnique = true }));
      modelBuilder.Entity<Model.Concept>().Property(t => t.CodeSystem_Id)
                   .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Code_CodeSystem", 2) { IsUnique = true }));


      //Expansion
      modelBuilder.Entity<Model.Expansion>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.Expansion>().Property(x => x.Identifier).IsRequired();

      //Compose
      modelBuilder.Entity<Model.Compose>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.Compose>()
        .HasMany(x => x.Include)
        .WithOptional(x => x.Compose);

      //Include
      modelBuilder.Entity<Model.Include>().HasKey(k => k.Id).Property(p => p.Id).IsRequired();
      modelBuilder.Entity<Model.Include>().Property(x => x.System).IsRequired();
      
      //Identifier
      modelBuilder.Entity<Model.Identifier>().HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      modelBuilder.Entity<Model.Identifier>().Property(x => x.Use).IsOptional();
      modelBuilder.Entity<Model.Identifier>().Property(x => x.System).IsOptional();
      modelBuilder.Entity<Model.Identifier>().Property(x => x.Value).IsOptional();      
      modelBuilder.Entity<Model.Identifier>()
        .HasOptional(x => x.Type)
        .WithOptionalDependent(x => x.Identifier);

      modelBuilder.Entity<Model.Identifier>()
        .HasOptional(x => x.Period)
        .WithOptionalDependent(x => x.Identifier); // Note: the Period keyed to this Identifier is dependant on the Identifier
      modelBuilder.Entity<Model.Identifier>()
        .HasOptional(x => x.PatientResource)
        .WithMany(x => x.Identifier);             //Note: PatientResource_ID key on Identifier so PatientResource can have many Identifiers

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
