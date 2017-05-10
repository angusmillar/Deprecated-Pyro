using System;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.UriSupport;

namespace Pyro.Common.Interfaces.UriSupport
{
  public interface IFhirRequestUri
  {
    bool IsContained { get; set; }
    bool IsFormDataSearch { get; set; }
    bool IsHistoryReferance { get; set; }
    bool IsMetaData { get; set; }
    bool IsOperation { get; }
    bool IsRelativeToServer { get; set; }
    bool IsUrn { get; set; }
    string OperationName { get; set; }
    FhirOperationEnum.OperationType? OperationType { get; }
    Uri PrimaryServiceRootRemote { get; set; }
    Uri PrimaryServiceRootServers { get; set; }
    string Query { get; set; }
    string ResourceId { get; set; }
    string ResourseName { get; set; }
    string Urn { get; set; }
    UrnType? UrnType { get; }
    string VersionId { get; set; }    
  }
}