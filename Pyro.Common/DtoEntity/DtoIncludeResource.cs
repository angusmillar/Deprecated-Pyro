using System;
using Hl7.Fhir.Model;


namespace Pyro.Common.DtoEntity
{
  public class DtoIncludeResource : DtoResource
  {
    public DtoIncludeResource(DtoResource DtoResource)
    {
      this.FhirId = DtoResource.FhirId;
      this.Id = DtoResource.Id;
      this.IsCurrent = DtoResource.IsCurrent;
      this.IsDeleted = DtoResource.IsDeleted;
      this.Method = DtoResource.Method;
      this.ResourceType = DtoResource.ResourceType;
      this.Version = DtoResource.Version;
      this.Xml = DtoResource.Xml;
    }
  }
}
