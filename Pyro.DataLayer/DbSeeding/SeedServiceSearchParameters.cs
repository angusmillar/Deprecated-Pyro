using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.Search;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.DbSeeding
{
  /// <summary>
  /// Seed service that add the FHIR search parameters information to the database
  /// </summary>
  public class PyroSeedServiceSearchParameters : IPyroSeedService
  {
    private PyroDbContext _Context;
    public PyroSeedServiceSearchParameters(PyroDbContext Context)
    {
      _Context = Context;
    }

    public string ServiceName => "PyroSeedServiceSearchParameters";


    /// <summary>
    /// Returns True if the Seed method need to run and false if it is not required.
    /// This is needed as Migrations will run the seeding process or all migrations 
    /// </summary>
    /// <returns>True if Seed() method is required to run</returns>
    public bool DoesSeedNeedToRun()
    {
      if (_Context.ServiceSearchParameter.Where(x => x.SearchParameterResourceId == null).Count() == 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public void Seed()
    {
      IList<DtoServiceSearchParameter> DtoServiceSearchParameterList = ServiceSearchParameterFactory.FhirAPISearchParameters();
      var LastUpdated = DateTimeOffset.Now;
      foreach (var SearchParameter in DtoServiceSearchParameterList)
      {
        var ServiceSearchParameter = new DbModel.Entity._ServiceSearchParameter()
        {
          Name = SearchParameter.Name,
          Description = SearchParameter.Description,
          Expression = SearchParameter.Expression,
          Resource = SearchParameter.Resource,
          Type = SearchParameter.Type,
          Url = SearchParameter.Url,
          XPath = SearchParameter.XPath,
          IsIndexed = true,
          LastUpdated = LastUpdated,
          Status = PublicationStatus.Active
        };
        if (SearchParameter.TargetResourceTypeList != null && SearchParameter.TargetResourceTypeList.Count > 0)
        {
          ServiceSearchParameter.TargetResourceTypeList = new List<_ServiceSearchParameterTargetResource>();
          foreach (var ResourceTypeTarget in SearchParameter.TargetResourceTypeList)
            ServiceSearchParameter.TargetResourceTypeList.Add(new _ServiceSearchParameterTargetResource() { ResourceType = ResourceTypeTarget.ResourceType });
        }
        _Context.ServiceSearchParameter.Add(ServiceSearchParameter);
      }
      _Context.SaveChanges();
    }
  }
}
