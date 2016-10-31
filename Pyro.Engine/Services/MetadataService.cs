using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.Search;
using Hl7.Fhir.Introspection;

namespace Pyro.Engine.Services
{
  public class MetadataService
  {
    public Common.Interfaces.Services.IServiceOperationOutcome GetServersConformanceResource(Common.Interfaces.Dto.IDtoRootUrlStore IDtoRootUrlStore, string ApplicationVersion)
    {
      string ServerName = "Pyro Server";
      string ApplicationReleaseDate = "2016-11-01T09:00:00+10:00";
      var Conformance = new Conformance();
      Conformance.Id = "PyroServerConformance";
      Conformance.Url = IDtoRootUrlStore.RootUrl.ToString() + @"/metadata";
      Conformance.Version = ApplicationVersion;
      Conformance.Name = ServerName;
      Conformance.Status = ConformanceResourceStatus.Active;
      Conformance.Experimental = true;
      Conformance.Date = ApplicationReleaseDate;
      Conformance.Publisher = "PyroHealth.net";

      var Contact = new Conformance.ContactComponent();
      Contact.Name = "Angus Millar";
      Contact.Telecom = new List<ContactPoint>() { new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Mobile, "0418059995") };
      Conformance.Contact = new List<Conformance.ContactComponent>() { Contact };

      Conformance.Description = new Markdown(ServerName + " Conformance statement");

      var Australia = new CodeableConcept("urn:iso:std:iso:3166", "AU", "Australia");
      Conformance.UseContext = new List<CodeableConcept>() { Australia };

      Conformance.Requirements = new Markdown("Reference implementation of a FHIR Server");
      Conformance.Copyright = "Copyright (C) PyroHealth.net";
      Conformance.Kind = Conformance.ConformanceStatementKind.Instance;
      Conformance.Software = new Conformance.SoftwareComponent() { Name = ServerName, Version = ApplicationVersion, ReleaseDate = ApplicationReleaseDate };
      Conformance.Implementation = new Conformance.ImplementationComponent() { Description = ServerName, Url = IDtoRootUrlStore.RootUrl };

      Conformance.FhirVersion = Hl7.Fhir.Model.ModelInfo.Version;
      Conformance.AcceptUnknown = Conformance.UnknownContentCode.Both;
      var ContentFormatList = new List<string>();
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADERS)
        ContentFormatList.Add(mediaType);
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADERS)
        ContentFormatList.Add(mediaType);
      Conformance.Format = ContentFormatList;

      Conformance.Rest = new List<Conformance.RestComponent>();
      var RestComponent = new Conformance.RestComponent();
      Conformance.Rest.Add(RestComponent);
      RestComponent.Mode = Conformance.RestfulConformanceMode.Server;
      RestComponent.Documentation = "STU3 V1.6 FHIR Server";
      RestComponent.Security = new Conformance.SecurityComponent();
      RestComponent.Security.Description = "No Security has been implemented, server if open";


      RestComponent.Resource = new List<Conformance.ResourceComponent>();

      var ResourceTypeList = Enum.GetValues(typeof(ResourceType));
      foreach (ResourceType ResourceType in ResourceTypeList)
      {
        FHIRAllTypes? FhirType = Hl7.Fhir.Model.ModelInfo.FhirTypeNameToFhirType(ResourceType.GetLiteral());
        var ResourceComponent = new Conformance.ResourceComponent();
        RestComponent.Resource.Add(ResourceComponent);
        ResourceComponent.Type = ResourceType;
        ResourceComponent.Interaction = new List<Conformance.ResourceInteractionComponent>()
        {
          new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.Create},
          new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.Delete},
          new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.Read},
          new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.Update},
          new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.Vread},
          new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.SearchType }
            //new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.HistoryInstance,
            //new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.HistoryType},        
        };
        ResourceComponent.Versioning = Conformance.ResourceVersionPolicy.Versioned;
        ResourceComponent.ReadHistory = true;
        ResourceComponent.UpdateCreate = true;
        ResourceComponent.ConditionalCreate = true;
        ResourceComponent.ConditionalRead = Conformance.ConditionalReadStatus.NotSupported;
        ResourceComponent.ConditionalUpdate = false;
        ResourceComponent.ConditionalDelete = Conformance.ConditionalDeleteStatus.NotSupported;
        //ResourceComponent.SearchInclude = new List<string>() {"???", "??????" };
        //ResourceComponent.SearchRevInclude = new List<string>() { "???", "??????" };

        List<DtoSupportedSearchParameters> SupportedSearchParametersList = DtoSupportedSearchParametersFactory.GetSupportedParametersForResourceTypeList((FHIRAllTypes)FhirType);
        ResourceComponent.SearchParam = new List<Conformance.SearchParamComponent>();
        foreach (var SupportedSearchParam in SupportedSearchParametersList)
        {
          Conformance.SearchParamComponent SearchParamComponent = new Conformance.SearchParamComponent();
          ResourceComponent.SearchParam.Add(SearchParamComponent);

          SearchParamComponent.Name = Common.Enum.FhirSearchEnum.GetSearchParameterNameString()[SupportedSearchParam.Name];
          SearchParamComponent.Type = SupportedSearchParam.SearchParameterType;
          if (SupportedSearchParam.TypeModifierResourceList != null && SupportedSearchParam.TypeModifierResourceList.Count > 0)
          {
            var TargetResourceTypeList = new List<ResourceType?>();
            foreach (var x in SupportedSearchParam.TypeModifierResourceList)
              TargetResourceTypeList.Add(Common.Enum.FhirSearchEnum.GetResourceTypeByString()[x]);
            SearchParamComponent.Target = TargetResourceTypeList;
          }
          if (SupportedSearchParam.ModifierList != null && SupportedSearchParam.ModifierList.Count > 0)
          {
            var ModifierList = new List<Conformance.SearchModifierCode?>();
            foreach (Common.Enum.FhirSearchEnum.SearchModifierType SearchModifierType in SupportedSearchParam.ModifierList)
              ModifierList.Add(Common.Enum.FhirSearchEnum.GetConformanceSearchModifierCodeDictionary()[SearchModifierType]);
            SearchParamComponent.Modifier = ModifierList;
          }
        }
      }


      var ServiceOperationOutcome = Pyro.Common.CommonFactory.GetPyroServiceOperationOutcome();
      ServiceOperationOutcome.DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      ServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource = new Common.BusinessEntities.Dto.DtoResource();
      ServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.FhirId = Conformance.Id;
      ServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.IsCurrent = true;
      ServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.IsDeleted = false;
      ServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.Version = "1";
      ServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResource.Xml = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(Conformance);

      ServiceOperationOutcome.DatabaseOperationOutcome.ReturnedResourceCount = 1;
      ServiceOperationOutcome.DatabaseOperationOutcome.SingleResourceRead = true;
      ServiceOperationOutcome.FhirResourceId = Conformance.Id; ;
      ServiceOperationOutcome.OperationType = Common.Enum.RestEnum.CrudOperationType.Read;
      ServiceOperationOutcome.ResourceVersionNumber = "1";


      return ServiceOperationOutcome;
    }


  }
}
