using Pyro.Common.BusinessEntities.Dto;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Pyro.DataLayer.DbModel.Entity;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<Pyro.DataLayer.DbModel.DatabaseContext.PyroDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(Pyro.DataLayer.DbModel.DatabaseContext.PyroDbContext context)
    {
      DbSeeding.SeedPyroDatabase PyroSeed = new DbSeeding.SeedPyroDatabase(context);
      PyroSeed.Seed();
      base.Seed(context);

      ////First Check the table is empty of the default search parameters as Seed is run
      ////on any Migration not just the first migration
      //int Count = context.ServiceSearchParameter.Where(x => x.SearchParameterResourceId == null).Count();
      //if (Count == 0)
      //{
      //  IList<DtoServiceSearchParameter> DtoServiceSearchParameterList = Common.BusinessEntities.Dto.Search.ServiceSearchParameterFactory.FhirAPISearchParameters();
      //  var LastUpdated = DateTimeOffset.Now;
      //  foreach (var SearchParameter in DtoServiceSearchParameterList)
      //  {
      //    var ServiceSearchParameter = new ServiceSearchParameter()
      //    {
      //      Name = SearchParameter.Name,
      //      Description = SearchParameter.Description,
      //      Expression = SearchParameter.Expression,
      //      Resource = SearchParameter.Resource,
      //      Type = SearchParameter.Type,
      //      Url = SearchParameter.Url,
      //      XPath = SearchParameter.XPath,
      //      IsIndexed = true,
      //      LastUpdated = LastUpdated,
      //      Status = PublicationStatus.Active
      //    };
      //    if (SearchParameter.TargetResourceTypeList != null && SearchParameter.TargetResourceTypeList.Count > 0)
      //    {
      //      ServiceSearchParameter.TargetResourceTypeList = new List<ServiceSearchParameterTargetResource>();
      //      foreach (var ResourceTypeTarget in SearchParameter.TargetResourceTypeList)
      //        ServiceSearchParameter.TargetResourceTypeList.Add(new ServiceSearchParameterTargetResource() { ResourceType = ResourceTypeTarget.ResourceType });
      //    }
      //    context.ServiceSearchParameter.Add(ServiceSearchParameter);
      //  }
      //  base.Seed(context);
      //  context.SaveChanges();
    }

  }
}

