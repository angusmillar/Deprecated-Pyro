using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ResourceBase : ModelBase, IModelBase, IResourceBase
  {
    public bool IsCurrent { get; set; }
    public string FhirId { get; set; }
    public bool IsDeleted { get; set; }
    public string VersionId { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public string XmlBlob { get; set; }
    public Bundle.HTTPVerb Method { get; set; }
    public virtual _FhirRelease FhirRelease { get; set; }
    public int FhirReleaseId { get; set; }
  }
}
