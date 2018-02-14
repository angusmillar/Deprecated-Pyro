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
    public enum OperationScope
    {
      Base,
      Resource,
      Instance
    }

    public enum OperationType
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
      ServerResourceReport,
      [EnumLiteral("connectathon-answer")]
      ConnectathonAnswer,
      //[EnumLiteral(Hl7.Fhir.Rest.FhirClientOperations.Operation.VALIDATE_RESOURCE)]
      [EnumLiteral(Hl7.Fhir.Rest.RestOperation.VALIDATE_RESOURCE)]
      Validate
    }

    public static Dictionary<string, OperationType> GetOperationTypeByString()
    {
      return new Dictionary<string, OperationType>()
      {
        {OperationType.ServerIndexesDeleteHistoryIndexes.GetPyroLiteral(), OperationType.ServerIndexesDeleteHistoryIndexes},
        {OperationType.ServerIndexesSet.GetPyroLiteral(), OperationType.ServerIndexesSet},
        {OperationType.ServerIndexesIndex.GetPyroLiteral(), OperationType.ServerIndexesIndex},
        {OperationType.ServerSearchParameterIndexReport.GetPyroLiteral(), OperationType.ServerSearchParameterIndexReport},
        {OperationType.ServerResourceReport.GetPyroLiteral(), OperationType.ServerResourceReport},
        {OperationType.ConnectathonAnswer.GetPyroLiteral(), OperationType.ConnectathonAnswer},
        {OperationType.Validate.GetPyroLiteral(), OperationType.Validate},
      };
    }






    //public enum BaseOperationType
    //{
    //  [EnumLiteral("server-indexes-delete-history-indexes")]
    //  ServerIndexesDeleteHistoryIndexes,

    //  [EnumLiteral("server-indexes-set")]
    //  ServerIndexesSet,

    //  [EnumLiteral("server-indexes-index")]
    //  ServerIndexesIndex,

    //  [EnumLiteral("server-indexes-report")]
    //  ServerSearchParameterIndexReport,

    //  [EnumLiteral("server-resource-report")]
    //  ServerResourceReport,

    //  [EnumLiteral(Hl7.Fhir.Rest.FhirClientOperations.Operation.VALIDATE_RESOURCE)]
    //  Validate,

    //};

    //public enum ResourceOperationType
    //{
    //  [EnumLiteral("server-indexes-delete-history-indexes")]
    //  ServerIndexesDeleteHistoryIndexes,
    //  [EnumLiteral(Hl7.Fhir.Rest.FhirClientOperations.Operation.VALIDATE_RESOURCE)]
    //  Validate,

    //};

    //public enum ResourceInstanceOperationType
    //{
    //  [EnumLiteral(Hl7.Fhir.Rest.FhirClientOperations.Operation.VALIDATE_RESOURCE)]
    //  Validate,
    //};

    //public static Dictionary<string, BaseOperationType> GetBaseOperationTypeByString()
    //{
    //  return new Dictionary<string, BaseOperationType>()
    //  {
    //    {BaseOperationType.ServerIndexesDeleteHistoryIndexes.GetPyroLiteral(), BaseOperationType.ServerIndexesDeleteHistoryIndexes},
    //    {BaseOperationType.ServerIndexesSet.GetPyroLiteral(), BaseOperationType.ServerIndexesSet},
    //    {BaseOperationType.ServerIndexesIndex.GetPyroLiteral(), BaseOperationType.ServerIndexesIndex},
    //    {BaseOperationType.ServerSearchParameterIndexReport.GetPyroLiteral(), BaseOperationType.ServerSearchParameterIndexReport},
    //    {BaseOperationType.ServerResourceReport.GetPyroLiteral(), BaseOperationType.ServerResourceReport},
    //  };
    //}

    //public static Dictionary<string, ResourceOperationType> GetResourceOperationTypeByString()
    //{
    //  return new Dictionary<string, ResourceOperationType>()
    //  {
    //    {ResourceOperationType.ServerIndexesDeleteHistoryIndexes.GetPyroLiteral(), ResourceOperationType.ServerIndexesDeleteHistoryIndexes},
    //    {ResourceOperationType.Validate.GetPyroLiteral(), ResourceOperationType.Validate},
    //  };
    //}

    //public static Dictionary<string, ResourceInstanceOperationType> GetResourceInstanceOperationTypeByString()
    //{
    //  return new Dictionary<string, ResourceInstanceOperationType>()
    //  {
    //    {ResourceInstanceOperationType.Validate.GetPyroLiteral(), ResourceInstanceOperationType.Validate},
    //  };
    //}


  }
}