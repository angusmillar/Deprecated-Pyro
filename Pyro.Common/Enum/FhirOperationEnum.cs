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
      [EnumLiteral(Hl7.Fhir.Rest.RestOperation.VALIDATE_RESOURCE)]
      Validate,
      [EnumLiteral("x-ihisearchorvalidate")]
      xIHISearchOrValidate,
      [EnumLiteral("x-set-compartment-active")]
      xSetCompartmentActive,
      [EnumLiteral("x-set-compartment-inactive")]
      xSetCompartmentInActive,
      [EnumLiteral("process-message")]
      ProcessMessage,

    }

    public static Dictionary<string, OperationType> GetOperationTypeByString()
    {
      return new Dictionary<string, OperationType>()
      {        
        {OperationType.ServerIndexesSet.GetPyroLiteral(), OperationType.ServerIndexesSet},
        {OperationType.ServerIndexesIndex.GetPyroLiteral(), OperationType.ServerIndexesIndex},
        {OperationType.ServerSearchParameterIndexReport.GetPyroLiteral(), OperationType.ServerSearchParameterIndexReport},
        {OperationType.ServerResourceReport.GetPyroLiteral(), OperationType.ServerResourceReport},
        {OperationType.ConnectathonAnswer.GetPyroLiteral(), OperationType.ConnectathonAnswer},
        {OperationType.Validate.GetPyroLiteral(), OperationType.Validate},
        {OperationType.xIHISearchOrValidate.GetPyroLiteral(), OperationType.xIHISearchOrValidate},
        {OperationType.xSetCompartmentActive.GetPyroLiteral(), OperationType.xSetCompartmentActive},
        {OperationType.xSetCompartmentInActive.GetPyroLiteral(), OperationType.xSetCompartmentInActive},
        {OperationType.ProcessMessage.GetPyroLiteral(), OperationType.ProcessMessage},
      };
    }
    
  }
}