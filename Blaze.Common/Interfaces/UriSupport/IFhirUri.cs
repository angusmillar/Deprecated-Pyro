using System;

namespace Blaze.Common.Interfaces.UriSupport
{
  public interface IFhirUri
  {
    string[] ApiSegments { get; }
    string Authority { get; }
    string Id { get; }
    string VersionId { get; }
    string ResourseType { get; }
    System.Uri ServiceRootUrl { get; }
    string Schema { get; }
    string SchemaDelimiter { get; }
    System.Uri Uri { get; }
    string ServiceRootUrlForComparison { get; }
    string Query { get; }
  }
}
