using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using System.Diagnostics;
using System.Reflection;

namespace Pyro.Common.Logging
{
  /// <summary>
  /// Logging for use with Dependency Injection 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class Log<T> : ILog
  {
    private static readonly ILogger logger = LogManager.GetLogger(typeof(T).FullName, typeof(T));

    public void Trace(Exception exception, string message)
    {
      logger.Trace(exception, message);
    }

    public void Trace(string message)
    {
      logger.Trace(message);
    }

    public void Debug(Exception exception, string message)
    {
      logger.Debug(exception, message);
    }

    public void Debug(string message)
    {
      logger.Debug(message);
    }

    public void Info(Exception exception, string message)
    {
      logger.Info(exception, message);
    }

    public void Info(string message)
    {
      logger.Info(message);
    }

    public void Warn(Exception exception, string message)
    {
      logger.Warn(exception, message);
    }

    public void Warn(string message)
    {
      logger.Warn(message);
    }

    public void Error(Exception exception, string message)
    {
      logger.Error(exception, message);
    }

    public void Error(string message)
    {
      logger.Error(message);
    }

    public void Fatal(Exception exception, string message)
    {
      logger.Fatal(exception, message);
    }

    public void Fatal(string message)
    {
      logger.Fatal(message);
    }

  }


}