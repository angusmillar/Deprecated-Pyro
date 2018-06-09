using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.Support;
using System.Data.Entity;
//This class's other partial is auto code generated

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  public partial class PyroDbContext : DbContext, IPyroDbContext
  {
    public PyroDbContext()
      : base("PyroConnectionString")
    {
      //Below is only commented out for LinqPad Debug testing
      DbContextUtils<PyroDbContext>.SetInitializer(new MigrateDatabaseToLatestVersion<PyroDbContext, Migrations.Configuration>());
    }
    
    public new System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity)
    {
      return base.Entry(entity);
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
      return base.Set<TEntity>();
    }

    public DbSet<_ServiceBaseUrl> ServiceBaseUrl { get; set; }
    public DbSet<_ServiceConfiguration> ServiceConfiguration { get; set; }    
    public DbSet<_ServiceSearchParameter> ServiceSearchParameter { get; set; }
    public DbSet<_ServiceCompartment> ServiceCompartment { get; set; }
    public DbSet<_ServiceCompartmentResource> ServiceCompartmentResource { get; set; }
    public DbSet<_FhirRelease> FhirRelease { get; set; }
  }
}
