using System;
using System.Linq;
using System.Collections.Generic;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.BusinessEntities.Search
{
  public class SearchParameterFactory : ISearchParameterFactory
  {
    private readonly char _ParameterNameParameterValueDilimeter = '=';
    private readonly char _ParameterNameModifierDilimeter = ':';
    private string _RawSearchParameterAndValueString = string.Empty;

    private readonly ICommonFactory ICommonFactory;
    public SearchParameterFactory(ICommonFactory ICommonFactory)
    {
      this.ICommonFactory = ICommonFactory;
    }

    public IDtoSearchParameterBase CreateSearchParameter(DtoServiceSearchParameterLight DtoSupportedSearchParametersResource, Tuple<string, string> Parameter)
    {

      IDtoSearchParameterBase oSearchParameter = InitalizeSearchParameter(DtoSupportedSearchParametersResource.Type);

      string ParameterName = Parameter.Item1;
      string ParameterValue = Parameter.Item2;
      oSearchParameter.Id = DtoSupportedSearchParametersResource.Id;
      oSearchParameter.Resource = DtoSupportedSearchParametersResource.Resource;
      oSearchParameter.Name = DtoSupportedSearchParametersResource.Name;
      oSearchParameter.TargetResourceTypeList = DtoSupportedSearchParametersResource.TargetResourceTypeList;
      oSearchParameter.RawValue = ParameterName + _ParameterNameParameterValueDilimeter + ParameterValue;
      _RawSearchParameterAndValueString = oSearchParameter.RawValue;
      if (!ParseModifier(ParameterName, oSearchParameter))
      {
        oSearchParameter.IsValid = false;
        oSearchParameter.InvalidMessage = $"Unable to parse the given search parameter's Modifier: {ParameterName}', ";
      }

      if (oSearchParameter.Modifier.HasValue &&
        oSearchParameter.Modifier.Value == SearchParameter.SearchModifierCode.Type &&
        !string.IsNullOrWhiteSpace(oSearchParameter.TypeModifierResource) &&
        ParameterName.Contains(Hl7.Fhir.Rest.SearchParams.SEARCH_CHAINSEPARATOR))
      {
        //This is a resourceReferance with a Chained parameter, resolve that chained parameter to a search parameter here (is a recursive call).
        var SearchParameterGeneric = new DtoSearchParameterGeneric();
        SearchParameterGeneric.ParameterList = new List<Tuple<string, string>>();
        var ChainedSearchParam = new Tuple<string, string>(ParameterName.Split('.')[1], ParameterValue);
        SearchParameterGeneric.ParameterList.Add(ChainedSearchParam);

        ISearchParameterService SearchService = ICommonFactory.CreateSearchParameterService();
        oSearchParameter.ChainedSearchParameter = SearchService.ProcessResourceSearchParameters(SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Resource, Hl7.Fhir.Model.ModelInfo.FhirTypeNameToFhirType(oSearchParameter.TypeModifierResource).Value);
      }
      else
      {
        if (oSearchParameter.Type == SearchParamType.Reference)
        {
          (oSearchParameter as DtoSearchParameterReferance).AllowedReferanceResourceList = Pyro.Common.BusinessEntities.Dto.Search.ServiceSearchParameterFactory.GetSearchParameterTargetResourceList(oSearchParameter);
        }

        if (!oSearchParameter.TryParseValue(ParameterValue))
        {
          oSearchParameter.IsValid = false;
        }
      }
      return oSearchParameter;
    }

    private IDtoSearchParameterBase InitalizeSearchParameter(SearchParamType DbSearchParameterType)
    {
      switch (DbSearchParameterType)
      {
        case SearchParamType.Number:
          return new DtoSearchParameterNumber();
        case SearchParamType.Date:
          //I think I need to make one of these handle both Date and DateTime, the value given will be one or the other
          return new DtoSearchParameterDateTime();
        //return new DtoSearchParameterDate();          
        case SearchParamType.String:
          return new DtoSearchParameterString();
        case SearchParamType.Token:
          return new DtoSearchParameterToken();
        case SearchParamType.Reference:
          return ICommonFactory.CreateDtoSearchParameterReferance();
        case SearchParamType.Composite:
          throw new System.ComponentModel.InvalidEnumArgumentException(DbSearchParameterType.ToString(), (int)DbSearchParameterType, typeof(SearchParamType));
        case SearchParamType.Quantity:
          return new DtoSearchParameterQuantity();
        case SearchParamType.Uri:
          return new DtoSearchParameterUri();
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(DbSearchParameterType.ToString(), (int)DbSearchParameterType, typeof(SearchParamType));
      }
    }
    private bool ParseModifier(string Name, IDtoSearchParameterBase oSearchParameter)
    {
      if (Name.Contains(_ParameterNameModifierDilimeter))
      {
        return ParseModifierType(oSearchParameter, Name.Split(_ParameterNameModifierDilimeter)[1]);
      }
      else
      {
        oSearchParameter.Modifier = null;
        oSearchParameter.TypeModifierResource = null;
        return true;
      }
    }
    private bool ParseModifierType(IDtoSearchParameterBase SearchParameter, string value)
    {
      var SearchModifierTypeDic = FhirSearchEnum.GetSearchModifierTypeDictionary();
      string ValueCaseCorrectly = StringSupport.ToLowerFast(value);
      if (SearchModifierTypeDic.ContainsKey(ValueCaseCorrectly))
      {
        SearchParameter.Modifier = SearchModifierTypeDic[ValueCaseCorrectly];
        return true;
      }
      else
      {
        string TypedResourceName = value;
        if (value.Contains("."))
        {
          char[] delimiters = { '.' };
          TypedResourceName = value.Split(delimiters)[0].Trim();
        }

        Type ResourceType = ModelInfo.GetTypeForFhirType(TypedResourceName);
        if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
        {
          SearchParameter.TypeModifierResource = TypedResourceName;
          SearchParameter.Modifier = Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Type;
          return true;
        }
        return false;
      }
    }

  }
}
