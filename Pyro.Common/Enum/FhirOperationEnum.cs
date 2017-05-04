using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Attributes;

namespace Pyro.Common.Enum
{
  public static class FhirOperationEnum
  {
    public enum ResourceOperationType
    {
      [EnumLiteral("delete-history-indexes")]
      DeleteHistoryIndexes,
    };

    public static Dictionary<string, ResourceOperationType> GetResourceOperationTypeByString()
    {
      return new Dictionary<string, ResourceOperationType>()
      {
        {ResourceOperationType.DeleteHistoryIndexes.GetPyroLiteral(), ResourceOperationType.DeleteHistoryIndexes},
      };
    }

  }  
}