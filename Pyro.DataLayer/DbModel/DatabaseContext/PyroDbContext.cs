using Pyro.DataLayer.DbModel.Entity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Pyro.DataLayer.DbModel.DatabaseContextConfig;
using System.Data.Entity.ModelConfiguration.Conventions;
//This class's other partial is auto code generated

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  public partial class PyroDbContext : DbContext, IPyroDbContext
  {
    public PyroDbContext(string ConnectionString)
      : base(ConnectionString){ }
    
    public new DbEntityEntry Entry(object entity)
    {
      return base.Entry(entity);
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {            
      return base.Set<TEntity>();
    }

    public new DbSet Set(System.Type entityType)
    {
      return base.Set(entityType);
    }    

    public DbSet<_ServiceBaseUrl> ServiceBaseUrl { get; set; }
    public DbSet<_ServiceConfiguration> ServiceConfiguration { get; set; }    
    public DbSet<_ServiceSearchParameter> ServiceSearchParameter { get; set; }
    public DbSet<_ServiceSearchParameterCompositePivot> ServiceSearchParameterCompositePivot { get; set; }
    public DbSet<_ServiceCompartment> ServiceCompartment { get; set; }
    public DbSet<_ServiceCompartmentResource> ServiceCompartmentResource { get; set; }
    public DbSet<_FhirRelease> FhirRelease { get; set; }
    public DbSet<_BackburnerConnection> BackburnerConnection { get; set; }

    private void OnModelCreatingExtra(DbModelBuilder Mb)
    {      
      Mb.Conventions.Remove<PluralizingTableNameConvention>();

      Mb.Configurations.Add(new ServiceConfigurationContextConfig());

      Mb.Configurations.Add(new ServiceBaseUrlContextConfig());

      Mb.Configurations.Add(new ServiceSearchParameterConfig());
      Mb.Configurations.Add(new ServiceSearchParameterTargetResourceConfig());
      Mb.Configurations.Add(new ServiceSearchParameterCompositePivotConfig());

      Mb.Configurations.Add(new ServiceCompartmentContextConfig());
      Mb.Configurations.Add(new ServiceCompartmentResourceContextConfig());

      Mb.Configurations.Add(new BackburnerConnectionConfig());
    }
  }  
}
