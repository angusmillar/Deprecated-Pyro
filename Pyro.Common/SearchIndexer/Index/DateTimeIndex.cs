using Pyro.Common.Search;
using System;

namespace Pyro.Common.SearchIndexer.Index
{
  public class DateTimeIndex : IDateTimeIndex
  {
    public DateTimeIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
    {
      this.ServiceSearchParameterLight = ServiceSearchParameterLight;
    }

    public IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }

    public DateTimeOffset? DateTimeOffsetHigh { get; set; }
    public DateTimeOffset? DateTimeOffsetLow { get; set; }

  }
}
