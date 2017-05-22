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
      [EnumLiteral("server-search-parameter-set")]
      ServerSearchParameterSet,
      [EnumLiteral("server-search-parameter-index")]
      serverSearchParameterIndexPending,
      [EnumLiteral("server-search-parameter-report")]
      serverSearchParameterIndexReport
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
        {BaseOperationType.ServerSearchParameterSet.GetPyroLiteral(), BaseOperationType.ServerSearchParameterSet},
        {BaseOperationType.serverSearchParameterIndexPending.GetPyroLiteral(), BaseOperationType.serverSearchParameterIndexPending},
        {BaseOperationType.serverSearchParameterIndexReport.GetPyroLiteral(), BaseOperationType.serverSearchParameterIndexReport},
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