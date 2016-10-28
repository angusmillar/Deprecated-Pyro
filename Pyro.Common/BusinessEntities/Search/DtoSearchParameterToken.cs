using System.Collections.Generic;
using System.Linq;
using Blaze.Common.Enum;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterToken : DtoSearchParameterBase
  {
    protected const char TokenDelimiter = '|';

    #region Constructor
    public DtoSearchParameterToken()
      : base()
    {
      this.DbSearchParameterType = DatabaseEnum.DbIndexType.TokenIndex;
    }
    #endregion

    public List<DtoSearchParameterTokenValue> ValueList { get; set; }

    public override bool TryParseValue(string Values)
    {
      this.ValueList = new List<DtoSearchParameterTokenValue>();
      foreach (var Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterNumber = new DtoSearchParameterTokenValue();
        if (this.Modifier == Enum.FhirSearchEnum.SearchModifierType.Missing)
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
              DtoSearchParameterNumber.SearchType = DtoSearchParameterTokenValue.TokenSearchType.MatchCodeWithNullSystem;
            }
            else if (string.IsNullOrEmpty(DtoSearchParameterNumber.Code))
            {
              DtoSearchParameterNumber.SearchType = DtoSearchParameterTokenValue.TokenSearchType.MatchSystemOnly;
            }
            else
            {
              DtoSearchParameterNumber.SearchType = DtoSearchParameterTokenValue.TokenSearchType.MatchCodeAndSystem;
            }
            this.ValueList.Add(DtoSearchParameterNumber);
          }
          else
          {
            DtoSearchParameterNumber.SearchType = DtoSearchParameterTokenValue.TokenSearchType.MatchCodeOnly;
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
    public override bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters)
    {
      //Token search parameters do not contain prefixes, so return true      
      return true;
    }

  }
}
