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
      [EnumLiteral("server-indexes-delete-history-indexes")]
      ServerIndexesDeleteHistoryIndexes,
      
      [EnumLiteral("server-indexes-set")]
      ServerIndexesSet,

      [EnumLiteral("server-indexes-index")]
      ServerIndexesIndex,

      [EnumLiteral("server-indexes-report")]
      ServerSearchParameterIndexReport,

      [EnumLiteral("server-resource-report")]
      ServerResourceReport

    };

    public enum ResourceOperationType
    {
      [EnumLiteral("server-indexes-delete-history-indexes")]
      ServerIndexesDeleteHistoryIndexes,
    };

    public static Dictionary<string, BaseOperationType> GetBaseOperationTypeByString()
    {
      return new Dictionary<string, BaseOperationType>()
      {
        {BaseOperationType.ServerIndexesDeleteHistoryIndexes.GetPyroLiteral(), BaseOperationType.ServerIndexesDeleteHistoryIndexes},
        {BaseOperationType.ServerIndexesSet.GetPyroLiteral(), BaseOperationType.ServerIndexesSet},
        {BaseOperationType.ServerIndexesIndex.GetPyroLiteral(), BaseOperationType.ServerIndexesIndex},
        {BaseOperationType.ServerSearchParameterIndexReport.GetPyroLiteral(), BaseOperationType.ServerSearchParameterIndexReport},
        {BaseOperationType.ServerResourceReport.GetPyroLiteral(), BaseOperationType.ServerResourceReport},
      };
    }

    public static Dictionary<string, ResourceOperationType> GetResourceOperationTypeByString()
    {
      return new Dictionary<string, ResourceOperationType>()
      {
        {ResourceOperationType.ServerIndexesDeleteHistoryIndexes.GetPyroLiteral(), ResourceOperationType.ServerIndexesDeleteHistoryIndexes},
      };
    }

  }  
}