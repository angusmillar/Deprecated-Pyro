using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using Pyro.DataLayer.DbModel.EntityGenerated;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.DatabaseContextConfig;
using Pyro.DataLayer.DbModel.DatabaseInitializer;
using Pyro.DataLayer.Support;
//This is an Auto generated file do not change it's contents!!.

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  public class PyroDbContext : DbContext
  {
    public PyroDbContext()
      : base("PyroConnectionString")
    {
      DbContextUtils<PyroDbContext>.SetInitializer(new ServiceSearchParameterInitializer());      
    }

    public DbSet<ServiceBaseUrl> ServiceBaseUrl { get; set; }
    public DbSet<ServiceSearchParameter> ServiceSearchParameter { get; set; }

    public DbSet<PatientRes> Patient { get; set; }    
    public DbSet<PatientResIndex> PatientIndex { get; set; }

    public DbSet<ObservationRes> Observation { get; set; }    
    public DbSet<ObservationResIndex> ObservationIndex { get; set; }


    protected override void OnModelCreating(DbModelBuilder Mb)
    {
      base.OnModelCreating(Mb);

      Mb.Conventions.Remove<PluralizingTableNameConvention>();
      
      Mb.Configurations.Add(new ServiceBaseUrlContextConfig());
      Mb.Configurations.Add(new ServiceSearchParameterConfig());

      Mb.Configurations.Add(new ResourceContextConfig<PatientRes, PatientResIndex>());            
      Mb.Configurations.Add(new IndexContextConfig<PatientRes, PatientResIndex>());

      Mb.Configurations.Add(new ResourceContextConfig<ObservationRes, ObservationResIndex>());      
      Mb.Configurations.Add(new IndexContextConfig<ObservationRes, ObservationResIndex>());

    }
  }
}
