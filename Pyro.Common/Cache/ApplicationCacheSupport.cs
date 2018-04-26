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
      var cacheItem = MemoryCache.Default.Get(cacheKey);
      if (cacheItem is CacheNull)
      {
        return null;
      }
      else
      {
        T item = cacheItem as T;
        if (item == null)
        {
          item = getItemCallback();
          if (item == null)
          {
            MemoryCache.Default.Add(cacheKey, new CacheNull(), DateTime.Now.AddMinutes(20));
            return null;
          }
          else
          {
            MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(20));
          }
        }
        return item;
      }
    }

    public void Set(string cacheKey, object value)
    {
      if (value == null)
      {
        MemoryCache.Default.Add(cacheKey, new CacheNull(), DateTime.Now.AddMinutes(20));
      }
      else
      {
        MemoryCache.Default.Add(cacheKey, value, DateTime.Now.AddMinutes(20));
      }
    }

    public object Get(string cacheKey)
    {
      var cacheItem = MemoryCache.Default.Get(cacheKey);
      if (cacheItem is CacheNull)
      {
        return null;
      }
      else
      {
        return cacheItem;
      }
    }

    public T GetOrSet<T>(Expression<Func<T>> getItemCallback) where T : class
    {
      string cacheKey = string.Empty;
      var methodcall = getItemCallback.Body as MethodCallExpression;
      if (methodcall != null)
      {
        cacheKey = methodcall.Method.Name;
      }
      else
      {
        throw new NullReferenceException("Internal Server error: methodcall for call back is null.");
      }
      var cacheItem = MemoryCache.Default.Get(cacheKey);
      if (cacheItem is CacheNull)
      {
        return null;
      }
      else
      {
        T item = cacheItem as T;        
        if (item == null)
        {
          Func<T> CompiledCall = getItemCallback.Compile();
          item = CompiledCall();

          if (item == null)
          {
            MemoryCache.Default.Add(cacheKey, new CacheNull(), DateTime.Now.AddMinutes(20));
            return null;
          }
          else
          {
            MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(20));            
          }
        }
        return item;
      }
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

  /// <summary>
  /// CacheNull is a simple object stored when we wish to store a cache Key as null.
  /// The MemoryCache cannot store null so we store this object instead and then
  /// on any Get get check if what we got was the CacheNull object and if so return a
  /// normal null.
  /// Do not confuse this with a Get where the provided cache key has never been stored in the cache.
  /// In this case the MemoryCache will return a normal null and not the CacheNull object.
  /// </summary>
  public class CacheNull
  {
    public CacheNull()
    {
      this.IsNull = true;
    }
    public bool IsNull { get; set; }
  }
}
