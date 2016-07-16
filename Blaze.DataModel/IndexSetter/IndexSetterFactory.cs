using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public enum IndexSetterType { QuantityRange, Quantity };
  static class IndexSetterFactory
  {
    public static IIndexSetter Create(Type IndexType)
    {
      if (IndexType == typeof(DateIndex))
      {
        throw new NotImplementedException();
      }
      else if (IndexType == typeof(DatePeriodIndex))
      {
        throw new NotImplementedException();
      }
      else if (IndexType == typeof(NumberIndex))
      {
        throw new NotImplementedException();
      }
      else if (IndexType == typeof(QuantityIndex))
      {
        throw new NotImplementedException();
      }
      else if (IndexType == typeof(QuantityRangeIndex))
      {
        return new QuantityRangeIndexSetter();
      }
      else if (IndexType == typeof(ReferenceIndex))
      {
        throw new NotImplementedException();
      }
      else if (IndexType == typeof(StringIndex))
      {
        throw new NotImplementedException();
      }
      else if (IndexType == typeof(TokenIndex))
      {
        throw new NotImplementedException();
      }
      else if (IndexType == typeof(UriIndex))
      {
        throw new NotImplementedException();
      }
      else
      {
        throw new Exception("Unexpected Search index type passed into Index Setter Factory.");
      }
    }
  }
}
