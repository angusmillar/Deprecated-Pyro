using System;

namespace Pyro.Common.Interfaces.UriSupport
{
  public interface IFhirUri
  {
    string[] ApiSegments { get; }
    string Authority { get; }
    string Id { get; }
    string ResourceOperation { get; }
    string VersionId { get; }
    bool IsFormDataSearch { get; }
    string ResourseType { get; }
    System.Uri ServiceRootUrl { get; }
    string Schema { get; }
    string SchemaDelimiter { get; }
    System.Uri Uri { get; }
    string ServiceRootUrlForComparison { get; }
    string Query { get; }
  }
}
