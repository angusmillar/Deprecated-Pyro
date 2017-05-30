using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.Support;
using System.Data.Entity;
//This is an Auto generated file do not change it's contents!!.

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  public partial class PyroDbContext : DbContext
  {
    public PyroDbContext()
      : base("PyroConnectionString")
    {      
      DbContextUtils<PyroDbContext>.SetInitializer(new MigrateDatabaseToLatestVersion<PyroDbContext, Migrations.Configuration>());
    }

    public DbSet<ServiceBaseUrl> ServiceBaseUrl { get; set; }
    public DbSet<ServiceSearchParameter> ServiceSearchParameter { get; set; }
    
  }
}
