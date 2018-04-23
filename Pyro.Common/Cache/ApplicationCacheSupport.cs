using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Linq.Expressions;
using Pyro.Common.Interfaces.ITools;

namespace Pyro.Common.Cache
{
  public class ApplicationCacheSupport : IApplicationCacheSupport
  {
    private Object ThreadLock = new object();
    public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
    {

      T item = MemoryCache.Default.Get(cacheKey) as T;
      if (item == null)
      {
        item = getItemCallback();
        MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(20));
      }
      return item;
    }

    public void Set(string cacheKey, object value)
    {
      MemoryCache.Default.Add(cacheKey, value, DateTime.Now.AddMinutes(20));
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
      else
      {
        throw new NullReferenceException("Internal Server error: methodcall for call back is null.");
      }

      T item = MemoryCache.Default.Get(CacheKey) as T;
      if (item == null)
      {
        Func<T> CompiledCall = getItemCallback.Compile();
        item = CompiledCall();
        if (item != null)
        {
          MemoryCache.Default.Add(CacheKey, item, DateTime.Now.AddMinutes(20));
        }
      }
      return item;
    }

    public void RemoveAll()
    {
      lock (ThreadLock)
      {
        foreach (var element in MemoryCache.Default)
        {
          MemoryCache.Default.Remove(element.Key);
        }
      }
    }

    public void RemoveKey(string Key)
    {
      lock (ThreadLock)
      {
        MemoryCache.Default.Remove(Key);
      }
    }
  }

}
