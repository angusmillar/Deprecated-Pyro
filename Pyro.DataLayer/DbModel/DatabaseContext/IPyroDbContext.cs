using System.Data.Entity;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.EntityGenerated;

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  public partial interface IPyroDbContext
  {
    //DbContextTransaction BeginTransaction();
    Database Database { get; }
    int SaveChanges();
    void Dispose();
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
    DbSet<ServiceBaseUrl> ServiceBaseUrl { get; set; }
    DbSet<ServiceSearchParameter> ServiceSearchParameter { get; set; }
  }
}