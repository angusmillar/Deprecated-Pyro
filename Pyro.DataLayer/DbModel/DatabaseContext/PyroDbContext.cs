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
      DbContextUtils<PyroDbContext>.SetInitializer(new MigrateDatabaseToLatestVersion<PyroDbContext, Migrations.Configuration>());
    }

    public DbContextTransaction BeginTransaction()
    {
      return base.Database.BeginTransaction();
    }

    public new int SaveChanges()
    {
      return base.SaveChanges();
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public new System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity)
    {
      return base.Entry(entity);
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
      return base.Set<TEntity>();
    }

    public DbSet<ServiceBaseUrl> ServiceBaseUrl { get; set; }

    public DbSet<ServiceSearchParameter> ServiceSearchParameter { get; set; }

  }
}
