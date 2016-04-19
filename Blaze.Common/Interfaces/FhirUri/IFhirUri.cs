using System;

namespace Blaze.Common.Interfaces.FhirUri
{
  public interface IFhirUri
  {
    string ApiSegments { get; set; }
    string Authority { get; set; }
    string Compartment { get; set; }
    string Id { get; set; }
    string ResourseType { get; set; }
    System.Uri RootFhirUri { get; }
    string Schema { get; set; }
    string SchemaDilemeter { get; set; }
    System.Uri Uri { get; set; }
  }
}
