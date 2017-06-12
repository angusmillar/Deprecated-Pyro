using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Pyro.Common.BusinessEntities.Dto.Search
{
  public static class ServiceSearchParameterFactory
  {
    public static IList<DtoServiceSearchParameter> FhirAPISearchParameters()
    {
      List<DtoServiceSearchParameter> ServiceSearchParameterList = new List<DtoServiceSearchParameter>();

      //Add all the base Resource parameters 
      ServiceSearchParameterList.AddRange(BaseResourceSearchParameters());

      //Add the ones for each Resource
      foreach (var SearchParameter in ModelInfo.SearchParameters)
      {
        //A searchParameter with no expression or name or Resource is useless
        if (!string.IsNullOrWhiteSpace(SearchParameter.Expression) &&
          !string.IsNullOrWhiteSpace(SearchParameter.Name) &&
          !string.IsNullOrWhiteSpace(SearchParameter.Resource))
        {
          var DtoServiceSearchParameter = new DtoServiceSearchParameter()
          {
            Name = SearchParameter.Name,
            Description = SearchParameter.Description,
            Expression = SearchParameter.Expression,
            Resource = SearchParameter.Resource,
            Type = SearchParameter.Type,
            Url = SearchParameter.Url,
            XPath = SearchParameter.XPath,
            SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Resource
          };
          if (SearchParameter.Target != null && SearchParameter.Target.Count() > 0)
          {
            DtoServiceSearchParameter.TargetResourceTypeList = new List<Common.Interfaces.Dto.IServiceSearchParameterTargetResource>();
            foreach (var ResourceType in SearchParameter.Target)
              DtoServiceSearchParameter.TargetResourceTypeList.Add(new DtoServiceSearchParameterTargetResource() { ResourceType = ResourceType });
          }
          ServiceSearchParameterList.Add(DtoServiceSearchParameter);
        }
      }
      return ServiceSearchParameterList;
    }

    public static IList<DtoServiceSearchParameter> BaseResourceSearchParameters()
    {
      IList<DtoServiceSearchParameter> ServiceSearchParameterList = new List<DtoServiceSearchParameter>();

      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = "_id",
        Description = "Logical id of this artifact",
        Expression = "Resource.id",
        Resource = FHIRAllTypes.Resource.GetLiteral(),
        Type = SearchParamType.Token,
        Url = "http://hl7.org/fhir/SearchParameter/Resource-id",
        XPath = "f:Resource/f:id",
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Resource
      });

      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = "_lastUpdated",
        Description = "When the resource version last changed",
        Expression = "Resource.meta.lastUpdated",
        Resource = FHIRAllTypes.Resource.GetLiteral(),
        Type = SearchParamType.Date,
        Url = "http://hl7.org/fhir/SearchParameter/Resource-lastUpdated",
        XPath = "f:Resource/f:meta/f:lastUpdated",
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Resource
      });

      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = "_profile",
        Description = "Profiles this resource claims to conform to",
        Expression = "Resource.meta.profile",
        Resource = FHIRAllTypes.Resource.GetLiteral(),
        Type = SearchParamType.Uri,
        Url = "http://hl7.org/fhir/SearchParameter/Resource-profile",
        XPath = "f:Resource/f:meta/f:profile",
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Resource
      });

      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = "_security",
        Description = "Security Labels applied to this resource",
        Expression = "Resource.meta.security",
        Resource = FHIRAllTypes.Resource.GetLiteral(),
        Type = SearchParamType.Token,
        Url = "http://hl7.org/fhir/SearchParameter/Resource-security",
        XPath = "f:Resource/f:meta/f:security",
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Resource
      });

      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = "_tag",
        Description = "Tags applied to this resource",
        Expression = "Resource.meta.tag",
        Resource = FHIRAllTypes.Resource.GetLiteral(),
        Type = SearchParamType.Token,
        Url = "http://hl7.org/fhir/SearchParameter/Resource-tag",
        XPath = "f:Resource/f:meta/f:tag",
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Resource
      });

      return ServiceSearchParameterList;
    }

    public static IList<DtoServiceSearchParameter> BaseSearchParameters()
    {
      IList<DtoServiceSearchParameter> ServiceSearchParameterList = new List<DtoServiceSearchParameter>();
      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = Hl7.Fhir.Rest.HttpUtil.RESTPARAM_FORMAT,
        Description = "Required resource format XML or JSON to be returned",
        Expression = null,
        Resource = null,
        Type = SearchParamType.String,
        Url = null,
        XPath = null,
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Base
      });

      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_SUMMARY,
        Description = "The _summary parameter requests the server to return a subset of the resource. It can contain one of the following values: true | text | data | count | false where the default is false.",
        Expression = null,
        Resource = null,
        Type = SearchParamType.Token,
        Url = null,
        XPath = null,
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Base,
      });

      return ServiceSearchParameterList;
    }

    public static IList<DtoServiceSearchParameter> BundleSearchParameters()
    {
      IList<DtoServiceSearchParameter> ServiceSearchParameterList = new List<DtoServiceSearchParameter>();
      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = "page",
        Description = "Required for pagination, the page required",
        Expression = null,
        Resource = null,
        Type = SearchParamType.Number,
        Url = null,
        XPath = null,
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Bundle
      });

      ServiceSearchParameterList.Add(new DtoServiceSearchParameter()
      {
        Name = "_sort",
        Description = "Sort order requested",
        Expression = null,
        Resource = null,
        Type = SearchParamType.String,
        Url = null,
        XPath = null,
        SearchParameterServiceType = Service.SearchParameterService.SearchParameterServiceType.Bundle
      });
      return ServiceSearchParameterList;
    }

    public static IList<string> GetSearchParameterTargetResourceList(Pyro.Common.BusinessEntities.Search.DtoSearchParameterBase oSearchParameterBase)
    {
      IList<string> Result = new List<string>();
      foreach (var Res in oSearchParameterBase.TargetResourceTypeList)
      {
        Result.Add(Res.ResourceType.GetLiteral());
      }
      return Result;
    }

  }
}
