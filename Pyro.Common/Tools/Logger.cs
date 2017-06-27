using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Pyro.Common.Tools
{
  public static class Logger
  {
    public static readonly NLog.ILogger Log = NLog.LogManager.GetCurrentClassLogger();
  }
}
