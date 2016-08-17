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
      this.DbSearchParameterType = DatabaseEnum.BlazeIndexType.StringIndex;
    }
    #endregion
    public override bool TryParseValue(string Value)
    {
      this.Values = Value.Split(OrDelimiter);
      if (this.Values.Count() > 1)
        this.HasLogicalOrProperties = true;
      return true;
    }
    public string[] Values { get; set; }
  }
}
