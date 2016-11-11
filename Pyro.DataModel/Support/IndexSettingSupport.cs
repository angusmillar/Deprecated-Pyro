using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.DataModel.DatabaseModel;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Repository;
using Pyro.DataModel.IndexSetter;


namespace Pyro.DataModel.Support
{
  public static class IndexSettingSupport
  {

    private static void SetResourceBase(Resource Resource, ResourceIndexBase ResourceIndexBase, string FhirResourceId, string Version, bool IsDeleted, Bundle.HTTPVerb Method)
    {
      ResourceIndexBase.IsDeleted = IsDeleted;
      ResourceIndexBase.versionId = Version;
      ResourceIndexBase.Method = Method;
      if (!IsDeleted)
      {
        ResourceIndexBase.FhirId = Resource.Id;
        ResourceIndexBase.XmlBlob = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(Resource);
        ResourceIndexBase.lastUpdated = (DateTimeOffset)Resource.Meta.LastUpdated;        
      }
      else
      {
        ResourceIndexBase.FhirId = FhirResourceId;
        ResourceIndexBase.XmlBlob = "";
        ResourceIndexBase.lastUpdated = DateTimeOffset.Now;        
      }
    }

    public static DtoResource SetDtoResource(DatabaseModel.Base.ResourceIndexBase ResourceIndexBase, FHIRAllTypes ResourceType, bool IsCurrent)
    {
      var DtoResource = new DtoResource();
      DtoResource.FhirId = ResourceIndexBase.FhirId;
      DtoResource.IsCurrent = IsCurrent;
      DtoResource.IsDeleted = ResourceIndexBase.IsDeleted;
      DtoResource.Received = ResourceIndexBase.lastUpdated;
      DtoResource.Version = ResourceIndexBase.versionId;
      DtoResource.Xml = ResourceIndexBase.XmlBlob;
      DtoResource.Method = ResourceIndexBase.Method;
      DtoResource.ResourceType = ResourceType;
      return DtoResource;
    }

    public static void SetResourceBaseAsDelete(ResourceIndexBase ResourceIndexBase, string FhirResourceId, string Version, Bundle.HTTPVerb Method)
    {
      SetResourceBase(null, ResourceIndexBase, FhirResourceId, Version, true, Method);
    }

    public static void SetResourceBaseAddOrUpdate(Resource Resource, ResourceIndexBase ResourceIndexBase, string Version, bool IsDeleted, Bundle.HTTPVerb Method)
    {
      SetResourceBase(Resource, ResourceIndexBase, null, Version, false, Method);
    }

    public static void ResetResourceEntityBase(ResourceIndexBase ResourceIndexBase)
    {      
      ResourceIndexBase.FhirId = null;
      ResourceIndexBase.IsDeleted = false;
      ResourceIndexBase.lastUpdated = DateTimeOffset.MinValue;
      ResourceIndexBase.Method = Bundle.HTTPVerb.GET;
      ResourceIndexBase.versionId = "Reset";
      ResourceIndexBase.XmlBlob = null;      
    }

    public static void SetHistoryResourceEntity(DatabaseModel.Base.ResourceIndexBase ResourceEntity, DatabaseModel.Base.ResourceIndexBase HistoryResourceEntity)
    {
      HistoryResourceEntity.FhirId = ResourceEntity.FhirId;
      HistoryResourceEntity.IsDeleted = ResourceEntity.IsDeleted;
      HistoryResourceEntity.XmlBlob = ResourceEntity.XmlBlob;
      HistoryResourceEntity.lastUpdated = ResourceEntity.lastUpdated;
      HistoryResourceEntity.versionId = ResourceEntity.versionId;
      HistoryResourceEntity.Method = ResourceEntity.Method;
    }

  }
}
