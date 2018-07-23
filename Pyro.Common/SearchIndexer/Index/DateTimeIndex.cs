using Pyro.Common.Search;
using System;

namespace Pyro.Common.SearchIndexer.Index
{
  public class DateTimeIndex : IndexBase, IDateTimeIndex
  {
    public DateTimeIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
      : base(ServiceSearchParameterLight){ }

    new int ServiceSearchParameterId { get; }
    public DateTimeOffset? DateTimeOffsetHigh { get; set; }
    public DateTimeOffset? DateTimeOffsetLow { get; set; }

  }
}
