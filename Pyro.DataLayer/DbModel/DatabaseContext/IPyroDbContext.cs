using System.Data.Entity;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  public partial interface IPyroDbContext
  {    
    Database Database { get; }
    int SaveChanges();
    void Dispose();
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
    DbSet<_ServiceBaseUrl> ServiceBaseUrl { get; set; }
    DbSet<_ServiceSearchParameter> ServiceSearchParameter { get; set; }
    DbSet<_ServiceCompartment> ServiceCompartment { get; set; }
    DbSet<_ServiceCompartmentResource> ServiceCompartmentResource { get; set; }
  }
}