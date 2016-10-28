using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public static class IndexSetterFactory
  {
    public static IIndexSetter Create(Type IndexType)
    {
      if (IndexType == typeof(DateTimeIndex))
      {
        return new DateTimeIndexSetter();
      }
      else if (IndexType == typeof(DateTimePeriodIndex))
      {
        return new DateTimePeriodIndexSetter();
      }
      else if (IndexType == typeof(DateIndex))
      {
        return new DateIndexSetter();
      }
      else if (IndexType == typeof(NumberIndex))
      {
        return new NumberIndexSetter();
      }
      else if (IndexType == typeof(QuantityIndex))
      {
        return new QuantityIndexSetter();
      }
      else if (IndexType == typeof(QuantityRangeIndex))
      {
        return new QuantityRangeIndexSetter();
      }
      else if (IndexType == typeof(ReferenceIndex))
      {
        return new ReferanceIndexSetter();
      }
      else if (IndexType == typeof(StringIndex))
      {
        return new StringIndexSetter();
      }
      else if (IndexType == typeof(TokenIndex))
      {
        return new TokenIndexSetter();
      }
      else if (IndexType == typeof(UriIndex))
      {
        return new UriIndexSetter();
      }
      else
      {
        throw new Exception("Unexpected Search index type passed into Index Setter Factory.");
      }
    }
  }
}
