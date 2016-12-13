using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pyro.Common.Extentions
{
  public static class FormDataCollectionExtentions
  {
    public static IEnumerable<Tuple<string, string>> GetAsTupleCollection(this IEnumerable<KeyValuePair<string, string>> values)
    {
      List<Tuple<string, string>> SearchTupleCollection = new List<Tuple<string, string>>();
      foreach(var Pair in values)
        SearchTupleCollection.Add(new Tuple<string, string>(Pair.Key, Pair.Value));
      return SearchTupleCollection;
    }
  }
}
