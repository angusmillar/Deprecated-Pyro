using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.Service;
using Hl7.Fhir.Introspection;

namespace Pyro.Engine.Services
{
  public class MetadataService
  {
    public Common.Interfaces.Service.IResourceServiceOutcome GetServersConformanceResource(IResourceServiceRequest ResourceServiceRequest, Common.Interfaces.Dto.IDtoRootUrlStore IDtoRootUrlStore, string ApplicationVersion)
    {
      IResourceServiceOutcome ServiceOperationOutcome = Common.CommonFactory.GetPyroServiceOperationOutcome();      
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(ResourceServiceRequest.SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ServiceOperationOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        return ServiceOperationOutcome;
      }

      string ApplicationReleaseDate = "2016-11-01T10:00:00+10:00";
      string ServerName = "Pyro Server";

      var Conformance = new Conformance();
      Conformance.Id = "metadata";
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

      Conformance.Description = new Markdown("Conformance statement for the " + ServerName);

      var Australia = new CodeableConcept("urn:iso:std:iso:3166", "AU", "Australia");
      Conformance.UseContext = new List<CodeableConcept>() { Australia };

      Conformance.Requirements = new Markdown("Reference implementation of a FHIR Server");
      Conformance.Copyright = "PyroHealth.net";
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
      ConstructConformanceResourceNarrative(Conformance);


      IDatabaseOperationOutcome DatabaseOperationOutcome = Common.CommonFactory.GetDatabaseOperationOutcome();
      ServiceOperationOutcome.FhirResourceId = Conformance.Id;
      ServiceOperationOutcome.ResourceVersionNumber = Conformance.Version;
      ServiceOperationOutcome.LastModified = DateTimeOffset.Parse(ApplicationReleaseDate);
      ServiceOperationOutcome.OperationType = Common.Enum.RestEnum.CrudOperationType.Read;
      ServiceOperationOutcome.IsDeleted = false;
      ServiceOperationOutcome.RequestUri = null;
      ServiceOperationOutcome.ResourceResult = Conformance;
      ServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      return ServiceOperationOutcome;
    }

    private void ConstructConformanceResourceNarrative(Conformance Conformance)
    {
      var XDoc = new XmlDocument();
      // NarrativeString.AppendLine("<div xmlns=\"http://www.w3.org/1999/xhtml\">");
      var Xroot = XDoc.CreateElement("div");
      var xmlns = XDoc.CreateAttribute("xmlns");
      xmlns.Value = "http://www.w3.org/1999/xhtml";
      Xroot.SetAttributeNode(xmlns);
      XDoc.AppendChild(Xroot);

      var Heading = XDoc.CreateElement("h1");
      Heading.AppendChild(XDoc.CreateTextNode(Conformance.Name + " FHIR Conformance Statement"));
      Xroot.AppendChild(Heading);

      var PublishDate = XDoc.CreateElement("p");
      Xroot.AppendChild(PublishDate);
      var PublishDateBold = XDoc.CreateElement("b");
      PublishDateBold.AppendChild(XDoc.CreateTextNode("Date Published: "));
      PublishDate.AppendChild(PublishDateBold);
      var normal = PublishDate.AppendChild(XDoc.CreateTextNode(Conformance.Date));
      PublishDate.AppendChild(normal);

      var ServerVersion = XDoc.CreateElement("p");
      Xroot.AppendChild(ServerVersion);
      var ServerVersionBold = XDoc.CreateElement("b");
      ServerVersionBold.AppendChild(XDoc.CreateTextNode("Server Version: "));
      ServerVersion.AppendChild(ServerVersionBold);
      normal = ServerVersion.AppendChild(XDoc.CreateTextNode(Conformance.Version));
      ServerVersion.AppendChild(normal);

      var FhirVersion = XDoc.CreateElement("p");
      Xroot.AppendChild(FhirVersion);
      var FhirVersionBold = XDoc.CreateElement("b");
      FhirVersionBold.AppendChild(XDoc.CreateTextNode("Fhir Version: "));
      FhirVersion.AppendChild(FhirVersionBold);
      normal = FhirVersion.AppendChild(XDoc.CreateTextNode(Conformance.FhirVersion));
      FhirVersion.AppendChild(normal);

      var ResourceTable = XDoc.CreateElement("table");
      Xroot.AppendChild(ResourceTable);
      foreach (Conformance.RestComponent RestComponent in Conformance.Rest)
      {
        var HeaderRow = XDoc.CreateElement("tr");
        ResourceTable.AppendChild(HeaderRow);
        var Col1Head = XDoc.CreateElement("td");
        HeaderRow.AppendChild(Col1Head);
        var Col1HeadBold = XDoc.CreateElement("b");
        Col1HeadBold.AppendChild(XDoc.CreateTextNode("Resource Name"));
        Col1Head.AppendChild(Col1HeadBold);

        var Col2Head = XDoc.CreateElement("td");
        HeaderRow.AppendChild(Col2Head);
        var Col2HeadBold = XDoc.CreateElement("b");
        Col2HeadBold.AppendChild(XDoc.CreateTextNode("Interaction"));
        Col2Head.AppendChild(Col2HeadBold);

        foreach (Conformance.ResourceComponent Resource in RestComponent.Resource)
        {
          var ResourceRow = XDoc.CreateElement("tr");
          ResourceTable.AppendChild(ResourceRow);

          var Col1 = XDoc.CreateElement("td");
          ResourceRow.AppendChild(Col1);
          var ResourceTypeNameBold = XDoc.CreateElement("b");
          ResourceTypeNameBold.AppendChild(XDoc.CreateTextNode(Resource.Type.GetLiteral()));
          Col1.AppendChild(ResourceTypeNameBold);

          var Col2 = XDoc.CreateElement("td");
          ResourceRow.AppendChild(Col2);
          StringBuilder sb = new StringBuilder();
          foreach (Conformance.ResourceInteractionComponent Interaction in Resource.Interaction)
          {
            sb.Append(Interaction.Code);
            sb.Append(", ");
          }
          Col2.AppendChild(XDoc.CreateTextNode(sb.ToString().Substring(0, sb.ToString().Count() - 2)));
        }

      }


      Conformance.Text = new Narrative();
      Conformance.Text.Div = XDoc.OuterXml;
      Conformance.Text.Status = Narrative.NarrativeStatus.Generated;
    }
  }
}
