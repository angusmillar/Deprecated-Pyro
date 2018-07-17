using System;
using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IDateTimeIndex
  {
    DateTimeOffset? DateTimeOffsetHigh { get; set; }
    DateTimeOffset? DateTimeOffsetLow { get; set; }
    IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }
  }
}