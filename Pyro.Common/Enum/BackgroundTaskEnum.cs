using Pyro.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Enum
{
  public static class BackgroundTaskEnum
  {
    public enum BroadcastType
    {
      [EnumLiteral("BackgroundTask")]
      BackgroundTask,
    }

    public enum BackgroundTaskType
    {
      [EnumLiteral("HiServiceIHISearch")]
      HiServiceIHISearch,
      [EnumLiteral("PyroServerIndexing")]
      PyroServerIndexing,
    }
  }
}
