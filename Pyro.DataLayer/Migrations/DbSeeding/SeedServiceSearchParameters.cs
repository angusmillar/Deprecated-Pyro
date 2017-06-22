using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.Migrations.DbSeeding
{
  public class PyroSeedServiceSearchParameters : IPyroSeedService
  {
    private PyroDbContext _Context;
    public PyroSeedServiceSearchParameters(PyroDbContext Context)
    {
      _Context = Context;
    }

    public string ServiceName => "PyroSeedServiceSearchParameters";

    public bool DoesSeedNeedToRun()
    {
      throw new NotImplementedException();
    }

    public void Seed()
    {
      //First Check the table is empty of the default search parameters as Seed is run
      //on any Migration not just the first migration
      int Count = _Context.ServiceSearchParameter.Where(x => x.SearchParameterResourceId == null).Count();
      if (Count == 0)
      {
        IList<DtoServiceSearchParameter> DtoServiceSearchParameterList = Common.BusinessEntities.Dto.Search.ServiceSearchParameterFactory.FhirAPISearchParameters();
        var LastUpdated = DateTimeOffset.Now;
        foreach (var SearchParameter in DtoServiceSearchParameterList)
        {
          var ServiceSearchParameter = new ServiceSearchParameter()
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
            ServiceSearchParameter.TargetResourceTypeList = new List<ServiceSearchParameterTargetResource>();
            foreach (var ResourceTypeTarget in SearchParameter.TargetResourceTypeList)
              ServiceSearchParameter.TargetResourceTypeList.Add(new ServiceSearchParameterTargetResource() { ResourceType = ResourceTypeTarget.ResourceType });
          }
          _Context.ServiceSearchParameter.Add(ServiceSearchParameter);
        }
        _Context.SaveChanges();
      }
    }
  }
}
