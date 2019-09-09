using Pyro.Common.Enum;
using System.Collections.Generic;

namespace Pyro.Common.FhirOperation
{
  public static class OperationClassFactory
  {
    public static List<OperationClass> OperationClassList
    {
      get
      {
        var List = new List<OperationClass>();

        ////$server-indexes-delete-history-indexes (Base, Resource)
        //List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.ServerIndexesDeleteHistoryIndexes, Scope = FhirOperationEnum.OperationScope.Base });
        //List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.ServerIndexesDeleteHistoryIndexes, Scope = FhirOperationEnum.OperationScope.Resource });

        //$server-indexes-set (Base)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.ServerIndexesSet, Scope = FhirOperationEnum.OperationScope.Base });

        //$server-indexes-index (Base)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.ServerIndexesIndex, Scope = FhirOperationEnum.OperationScope.Base });

        //$server-indexes-report (Base)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.ServerSearchParameterIndexReport, Scope = FhirOperationEnum.OperationScope.Base });

        //$server-resource-report (Base)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.ServerResourceReport, Scope = FhirOperationEnum.OperationScope.Base });

        //$validate (Resource, Instance)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.Validate, Scope = FhirOperationEnum.OperationScope.Resource });
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.Validate, Scope = FhirOperationEnum.OperationScope.Instance });

        //$connectathon-answer (Base)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.ConnectathonAnswer, Scope = FhirOperationEnum.OperationScope.Base });

        //$x-IHISearchOrValidate (Resource)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.xIHISearchOrValidate, Scope = FhirOperationEnum.OperationScope.Resource });

        //$xSetCompartmentActive (Instance)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.xSetCompartmentActive, Scope = FhirOperationEnum.OperationScope.Instance });

        //$xSetCompartmentInActive (Instance)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.xSetCompartmentInActive, Scope = FhirOperationEnum.OperationScope.Instance });

        //$process-message (Base)
        List.Add(new OperationClass() { Type = FhirOperationEnum.OperationType.ProcessMessage, Scope = FhirOperationEnum.OperationScope.Base });

        return List;
      }
    }
  }
}
