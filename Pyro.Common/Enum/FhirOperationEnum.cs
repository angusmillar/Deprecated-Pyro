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
    public enum OperationType
    {
      Base,
      Resource,
      Instance
    }

    public enum BaseOperationType
    {
      [EnumLiteral("delete-history-indexes")]
      DeleteHistoryIndexes,
    };

    public enum ResourceOperationType
    {
      [EnumLiteral("delete-history-indexes")]
      DeleteHistoryIndexes,
    };

    public static Dictionary<string, BaseOperationType> GetBaseOperationTypeByString()
    {
      return new Dictionary<string, BaseOperationType>()
      {
        {BaseOperationType.DeleteHistoryIndexes.GetPyroLiteral(), BaseOperationType.DeleteHistoryIndexes},
      };
    }

    public static Dictionary<string, ResourceOperationType> GetResourceOperationTypeByString()
    {
      return new Dictionary<string, ResourceOperationType>()
      {
        {ResourceOperationType.DeleteHistoryIndexes.GetPyroLiteral(), ResourceOperationType.DeleteHistoryIndexes},
      };
    }

  }  
}