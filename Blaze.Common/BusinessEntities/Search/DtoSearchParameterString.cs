using System;
using System.Linq;
using Blaze.Common.Enum;


namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterString : DtoSearchParameterBase
  {
    #region Constructor
    public DtoSearchParameterString()
      : base()
    {
      this.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
    }
    #endregion
    public override bool TryParseValue(string Value)
    {
      this.Values = Value.Split(OrDelimiter);
      if (this.Values.Count() > 1)
        this.HasLogicalOrProperties = true;
      return true;
    }

    public override bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters)
    {
      //String Search parameter types never have prefixes so always return true.
      return true;      
    }

    public string[] Values { get; set; }
  }
}
