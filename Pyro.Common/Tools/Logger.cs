using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Pyro.Common.Tools
{
  /// <summary>
  /// This is just a simple logger for when Dependency Injection is not possible
  /// </summary>
  public static class Logger
  {
    public static readonly NLog.ILogger Log = NLog.LogManager.GetCurrentClassLogger();
  }
}
