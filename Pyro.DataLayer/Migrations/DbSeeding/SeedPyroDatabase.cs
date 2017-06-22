using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.DatabaseContext;

namespace Pyro.DataLayer.Migrations.DbSeeding
{
  public class SeedPyroDatabase
  {
    private PyroDbContext _Context;
    private List<IPyroSeedService> SeedServiceList;
    public SeedPyroDatabase(PyroDbContext Context)
    {
      _Context = Context;
      SeedServiceList = new List<IPyroSeedService>();
      SeedServiceList.Add(new PyroSeedServiceSearchParameters(_Context));
    }

    public void Seed()
    {
      foreach (var SeedService in SeedServiceList)
      {
        try
        {
          SeedService.Seed();
        }
        catch (Exception Exec)
        {
          throw new Exception($"The Pyro database seed service named {SeedService.ServiceName} has encountered a problem. Seed inner exception for more detail. ", Exec);
        }
      }
    }
  }
}
