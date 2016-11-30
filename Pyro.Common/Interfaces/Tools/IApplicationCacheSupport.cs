﻿using System;
using System.Linq.Expressions;

namespace Pyro.Common.Interfaces.Tools
{
  public interface IApplicationCacheSupport
  {
    T GetOrSet<T>(Expression<Func<T>> getItemCallback) where T : class;
    T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
    void Set(string cacheKey, object value);
    object Get(string cacheKey);
  }
}
