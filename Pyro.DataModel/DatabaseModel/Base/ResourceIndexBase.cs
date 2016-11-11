using System;
using Hl7.Fhir.Model;

namespace Pyro.DataModel.DatabaseModel.Base
{
  public abstract class ResourceIndexBase : ModelBase
  {
    public string FhirId { get; set; }
    public bool IsDeleted { get; set; }
    public string versionId { get; set; }
    public DateTimeOffset lastUpdated { get; set; }
    public string XmlBlob { get; set; }
    public Bundle.HTTPVerb Method {get; set;}
  }
}
