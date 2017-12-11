using System;
using Pyro.Common.Enum;

namespace Pyro.Common.Tools.UriSupport
{
  public interface IPyroFhirUri
  {
    bool IsContained { get; }
    bool IsFormDataSearch { get; }
    bool IsHistoryReferance { get; }
    bool IsMetaData { get; }
    bool IsOperation { get; }
    bool IsRelativeToServer { get; }
    bool IsUrn { get; }
    string OperationName { get; }
    FhirOperationEnum.OperationScope? OperationType { get; }
    Uri UriPrimaryServiceRoot { get; }
    Uri PrimaryServiceRootRemote { get; }
    Uri PrimaryServiceRootServers { get; }
    string Query { get; }
    string ResourceId { get; }
    string ResourseName { get; }
    string CompartmentalisedResourseName { get; }
    string Urn { get; }
    UrnType? UrnType { get; }
    string VersionId { get; }
    string OriginalString { get; }
    string ParseErrorMessage { get; }
    bool ErrorInParseing { get; }
    bool Parse(string RequestUri);
  }
}