using System;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;

namespace Pyro.Common.Tools.UriSupport
{
  public interface IPyroFhirUri
  {
    bool IsContained { get; }
    bool IsCompartment { get; set; }
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
    ResourceType? ResourceType { get; set; }
    string CompartmentalisedResourseName { get; set; }
    ResourceType? CompartmentalisedResourseType { get; set; }    
    string Urn { get; }
    UrnType? UrnType { get; }
    string VersionId { get; }
    string OriginalString { get; }
    string ParseErrorMessage { get; }
    bool ErrorInParseing { get; }
    bool Parse(string RequestUri);
  }
}