using System;
using Hl7.Fhir.Model;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public interface IResourceBase
  {
    string FhirId { get; set; }
    bool IsCurrent { get; set; }
    bool IsDeleted { get; set; }
    DateTimeOffset LastUpdated { get; set; }
    Bundle.HTTPVerb Method { get; set; }
    string VersionId { get; set; }
    string XmlBlob { get; set; }
    _FhirRelease FhirRelease { get; set; }
    int FhirReleaseId { get; set; }
  }
}