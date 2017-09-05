using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Extentions
{
  public static class CollectionExtentions
  {
    public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T> source)
    {
      foreach (T item in source)
      {
        destination.Add(item);
      }
    }
  }
}
