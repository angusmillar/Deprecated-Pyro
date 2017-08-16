using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.CompositionRoot;

namespace Pyro.Common.Search
{
  public class SearchParameterReferance : SearchParameterBase, ISearchParameterReferance
  {
    private readonly ICommonFactory ICommonFactory;
    public SearchParameterReferance(ICommonFactory ICommonFactory)
      : base()
    {
      this.ICommonFactory = ICommonFactory;
      this.Type = Hl7.Fhir.Model.SearchParamType.Reference;
    }

    public List<SearchParameterReferanceValue> ValueList { get; set; }
    public IList<string> AllowedReferanceResourceList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<SearchParameterReferanceValue>();
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterReferanceValue = new SearchParameterReferanceValue();
        if (this.Modifier.HasValue && this.Modifier == Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing)
        {
          bool? IsMissing = DtoSearchParameterReferanceValue.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterReferanceValue.IsMissing = IsMissing.Value;
            this.ValueList.Add(DtoSearchParameterReferanceValue);
          }
          else
          {
            return false;
          }
        }
        else
        {
          IPyroFhirUri RequestUri = ICommonFactory.CreateFhirRequestUri();
          if (RequestUri.Parse(Value.Trim()))
          {
            DtoSearchParameterReferanceValue.FhirRequestUri = RequestUri;
          }
          else if (!string.IsNullOrWhiteSpace(Value.Trim()) && this.Modifier.HasValue && this.Modifier == Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Type && !string.IsNullOrWhiteSpace(this.TypeModifierResource))
          {
            IPyroFhirUri RequestUri2 = ICommonFactory.CreateFhirRequestUri();
            if (RequestUri2.Parse($"{this.TypeModifierResource}/{Value.Trim()}"))
            {
              DtoSearchParameterReferanceValue.FhirRequestUri = RequestUri2;
            }
            else
            {
              this.InvalidMessage = $"Unable to parse the Resource reference search parameter. {RequestUri2.ParseErrorMessage}";
              return false;
            }
          }
          else if (!string.IsNullOrWhiteSpace(Value.Trim()) && this.AllowedReferanceResourceList.Count() == 1)
          {
            IPyroFhirUri RequestUri3 = ICommonFactory.CreateFhirRequestUri();
            if (RequestUri3.Parse($"{this.AllowedReferanceResourceList[0]}/{Value.Trim()}"))
            {
              DtoSearchParameterReferanceValue.FhirRequestUri = RequestUri3;
            }
            else
            {
              this.InvalidMessage = $"The Resource Name was not given as a Type modifier in the reference search parameter and the search parameter supports many Resource types. You must specify the resource name the reference relates to. {RequestUri3.ParseErrorMessage}";
              return false;
            }
          }
          else
          {
            this.InvalidMessage = $"The Resource Name was not given as a Type modifier in the reference search parameter and the search parameter supports many Resource types. You must specify the resource name the reference relates to.";
            return false;
          }

          if (!this.AllowedReferanceResourceList.Contains(DtoSearchParameterReferanceValue.FhirRequestUri.ResourseName))
          {
            this.InvalidMessage = $"The Resource Name used in the reference search parameter is not allowed for this search parameter against this Resource.";
            return false;
          }
          else
          {
            this.ValueList.Add(DtoSearchParameterReferanceValue);
          }
        }
      }
      if (this.ValueList.Count() > 1)
        this.HasLogicalOrProperties = true;
      if (this.ValueList.Count > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public override bool ValidatePrefixes(ServiceSearchParameterLight DtoSupportedSearchParameters)
    {
      //String Search parameter types never have prefixes so always return true.
      return true;
    }

  }
}
