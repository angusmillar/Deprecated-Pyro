using System;
using Pyro.Common.Search;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IDateTimeIndex : IIndexBase
  {
    new int ServiceSearchParameterId { get; }

    DateTimeOffset? DateTimeOffsetHigh { get; set; }
    DateTimeOffset? DateTimeOffsetLow { get; set; }    
  }
}