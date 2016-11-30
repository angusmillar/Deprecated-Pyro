using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Linq.Expressions;
using Pyro.Common.Interfaces.Tools;

namespace Pyro.Common.Tools
{
  public class ApplicationCacheSupport : IApplicationCacheSupport
  {
    public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
    {
      T item = MemoryCache.Default.Get(cacheKey) as T;
      if (item == null)
      {
        item = getItemCallback();
        MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
      }
      return item;
    }

    public void Set(string cacheKey, object value)
    {
      MemoryCache.Default.Add(cacheKey, value, DateTime.Now.AddMinutes(10));
    }

    public object Get(string cacheKey)
    {
      return MemoryCache.Default.Get(cacheKey);
    }

    public T GetOrSet<T>(Expression<Func<T>> getItemCallback) where T : class
    {
      string CacheKey = string.Empty;
      var methodcall = getItemCallback.Body as MethodCallExpression;
      if (methodcall != null)
      {
        CacheKey = methodcall.Method.Name;
      }
      T item = MemoryCache.Default.Get(CacheKey) as T;
      if (item == null)
      {
        Func<T> x = getItemCallback.Compile();
        item = x();
        MemoryCache.Default.Add(CacheKey, item, DateTime.Now.AddMinutes(10));
      }
      return item;
    }
  }
  
}
