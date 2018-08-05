using Pyro.DataLayer.DbModel.Entity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
//This class's other partial is auto code generated

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  public partial class PyroDbContext : DbContext, IPyroDbContext
  {
    public PyroDbContext()
      : base(Common.Global.DatabaseConnection.PyroConnectionStringName){ }
    
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
    public DbSet<_ServiceCompartment> ServiceCompartment { get; set; }
    public DbSet<_ServiceCompartmentResource> ServiceCompartmentResource { get; set; }
    public DbSet<_FhirRelease> FhirRelease { get; set; }
  }



 
}
