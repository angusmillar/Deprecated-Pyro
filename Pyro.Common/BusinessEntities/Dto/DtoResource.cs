using System;
using Hl7.Fhir.Model;


namespace Pyro.Common.BusinessEntities.Dto
{
  public class DtoResource
  {
    public int Id { get; set; }
    public string FhirId { get; set; }
    public int FhirReleaseId { get; set; }
    public bool IsCurrent { get; set; }
    public string Xml { get; set; }
    public string Version { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset Received { get; set; }
    public Bundle.HTTPVerb Method { get; set; }
    public FHIRAllTypes? ResourceType { get; set; }
  }
}
