using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Global;

namespace Pyro.DataLayer.Migrations.DbSeeding
{
  public class SeedServiceOperationValidate : IPyroSeedService
  {
    private PyroDbContext _Context;
    public SeedServiceOperationValidate(PyroDbContext Context)
    {
      _Context = Context;
    }

    public string ServiceName => "SeedServiceOperationValidate";

    public bool DoesSeedNeedToRun()
    {
      //url = "http://hl7.org/fhir/OperationDefinition/Resource-validate"
      //id = Resource-validate
      //_Context.

      throw new NotImplementedException();
    }

    public void Seed()
    {
      throw new NotImplementedException();
    }
  }
}
