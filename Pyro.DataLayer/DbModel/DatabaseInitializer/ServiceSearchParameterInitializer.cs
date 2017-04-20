using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.DataLayer.DbModel.DatabaseContextConfig;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.BusinessEntities.Dto.Search;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;


namespace Pyro.DataLayer.DbModel.DatabaseInitializer
{
  public class ServiceSearchParameterInitializer : CreateDatabaseIfNotExists<PyroDbContext>
  {
    protected override void Seed(PyroDbContext context)
    {      
      IList<DtoServiceSearchParameter> DtoServiceSearchParameterList = Common.BusinessEntities.Dto.Search.ServiceSearchParameterFactory.FhirAPISearchParameters();
      foreach (var SearchParameter in DtoServiceSearchParameterList)
      {
        context.ServiceSearchParameter.Add(new ServiceSearchParameter()
        {
          Name = SearchParameter.Name,
          Description = SearchParameter.Description,
          Expression = SearchParameter.Expression,
          Resource = SearchParameter.Resource,
          Type = SearchParameter.Type,
          Url = SearchParameter.Url,
          XPath = SearchParameter.XPath
        });
      }
      base.Seed(context);
      context.SaveChanges();
    }
  }
}
