using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Search
{
  public class SearchParameterToken : SearchParameterBase
  {
    protected const char TokenDelimiter = '|';

    #region Constructor
    public SearchParameterToken()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.Token;
      //this.DbSearchParameterType = DatabaseEnum.DbIndexType.TokenIndex;
    }
    #endregion

    public List<SearchParameterTokenValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<SearchParameterTokenValue>();
      foreach (var Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterNumber = new SearchParameterTokenValue();
        if (this.Modifier.HasValue && this.Modifier == Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing)
        {
          bool? IsMissing = DtoSearchParameterNumber.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterNumber.IsMissing = IsMissing.Value;
            this.ValueList.Add(DtoSearchParameterNumber);
          }
          else
          {
            return false;
          }
        }
        else
        {
          if (Value.Contains(TokenDelimiter))
          {
            string[] CodeSystemSplit = Value.Split(TokenDelimiter);
            DtoSearchParameterNumber.Code = CodeSystemSplit[1].Trim();
            DtoSearchParameterNumber.System = CodeSystemSplit[0].Trim();
            if (string.IsNullOrEmpty(DtoSearchParameterNumber.Code) && string.IsNullOrEmpty(DtoSearchParameterNumber.System))
            {
              return false;
            }
            else if (string.IsNullOrEmpty(DtoSearchParameterNumber.System))
            {
              DtoSearchParameterNumber.SearchType = SearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem;
            }
            else if (string.IsNullOrEmpty(DtoSearchParameterNumber.Code))
            {
              DtoSearchParameterNumber.SearchType = SearchParameterTokenValue.TokenSearchType.MatchSystemOnly;
            }
            else
            {
              DtoSearchParameterNumber.SearchType = SearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem;
            }
            this.ValueList.Add(DtoSearchParameterNumber);
          }
          else
          {
            DtoSearchParameterNumber.SearchType = SearchParameterTokenValue.TokenSearchType.MatchCodeOnly;
            DtoSearchParameterNumber.Code = Value.Trim();
            if (string.IsNullOrEmpty(DtoSearchParameterNumber.Code))
            {
              return false;
            }
            this.ValueList.Add(DtoSearchParameterNumber);
          }
        }
      }
      if (this.ValueList.Count == 0)
        return false;
      else
        return true;
    }
    public override bool ValidatePrefixes(ServiceSearchParameterLight DtoSupportedSearchParameters)
    {
      //Token search parameters do not contain prefixes, so return true      
      return true;
    }

  }
}
