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
using Hl7.Fhir.Model;


namespace Pyro.DataLayer.DbModel.DatabaseInitializer
{
  public class ServiceSearchParameterInitializer : CreateDatabaseIfNotExists<PyroDbContext>
  {
    protected override void Seed(PyroDbContext context)
    {
      IList<ServiceSearchParameter> ServiceSearchParameterList = new List<ServiceSearchParameter>();

      foreach (var SearchParameter in ModelInfo.SearchParameters)
      {
        //A searchParameter with no expression or name or Resource is useless
        if (!string.IsNullOrWhiteSpace(SearchParameter.Expression) && 
          !string.IsNullOrWhiteSpace(SearchParameter.Name) &&
          !string.IsNullOrWhiteSpace(SearchParameter.Resource))
        {
          ServiceSearchParameterList.Add(new ServiceSearchParameter()
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
      }

      foreach (ServiceSearchParameter Parameter in ServiceSearchParameterList)
        context.ServiceSearchParameter.Add(Parameter);

      base.Seed(context);
      context.SaveChanges();
    }
  }
}
