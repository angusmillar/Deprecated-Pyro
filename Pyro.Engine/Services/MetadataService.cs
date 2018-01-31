using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Service;
using Hl7.Fhir.Introspection;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Global;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Service;

namespace Pyro.Engine.Services
{
  public class MetadataService : IMetadataService
  {
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IGlobalProperties IGlobalProperties;
    private readonly ICommonServices ICommonServices;
    private readonly ICommonFactory ICommonFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;

    public MetadataService(IPrimaryServiceRootCache IPrimaryServiceRootCache, IGlobalProperties IGlobalProperties, ICommonServices ICommonServices, ICommonFactory ICommonFactory, ISearchParameterServiceFactory ISearchParameterServiceFactory)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.IGlobalProperties = IGlobalProperties;
      this.ICommonServices = ICommonServices;
      this.ICommonFactory = ICommonFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
    }

    public IResourceServiceOutcome GetServersConformanceResource(ISearchParameterGeneric SearchParameterGeneric)
    {
      IResourceServiceOutcome ServiceOperationOutcome = ICommonFactory.CreateResourceServiceOutcome();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ServiceOperationOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ServiceOperationOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ServiceOperationOutcome;
      }
      var Conformance = new CapabilityStatement();
      var ApplicationReleaseDate = new DateTimeOffset(2017, 10, 17, 6, 00, 00, new TimeSpan(8, 0, 0));
      string ServerName = "Pyro Server";
      string Https = "https://";

      Conformance.Id = "metadata";
      Conformance.Url = $"{Https}{IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Url}/metadata";
      Conformance.Version = $"V{IGlobalProperties.ApplicationVersionInfo}";
      Conformance.Meta = new Meta();
      Conformance.Meta.LastUpdated = ApplicationReleaseDate;
      Conformance.Name = ServerName;
      Conformance.Status = PublicationStatus.Active;
      Conformance.Experimental = true;
      Conformance.Date = ApplicationReleaseDate.ToString();
      Conformance.Publisher = "PyroHealth.net";

      var Contact = new ContactDetail();
      Contact.Name = "Angus Millar";
      Contact.Telecom = new List<ContactPoint>();
      var PhoneContactPoint = new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Mobile, "0481 059 995");
      PhoneContactPoint.Rank = 1;
      PhoneContactPoint.Period = new Period();
      PhoneContactPoint.Period.StartElement = new FhirDateTime(new DateTimeOffset(2017, 12, 22, 8, 00, 00, new TimeSpan(8, 00, 00)));      
      Contact.Telecom.Add(PhoneContactPoint);

      var EmailContactPoint = new ContactPoint(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Home, "angusbmillar@gmail.com");
      EmailContactPoint.Rank = 1;
      EmailContactPoint.Period = new Period();
      EmailContactPoint.Period.StartElement = new FhirDateTime(new DateTimeOffset(2017, 12, 22, 8, 00, 00, new TimeSpan(8, 00, 00)));
      Contact.Telecom.Add(EmailContactPoint);
      Conformance.Contact = new List<ContactDetail>() { Contact };

      Conformance.Description = new Markdown("Conformance statement for the " + ServerName);

      var Australia = new CodeableConcept("urn:iso:std:iso:3166", "AU", "Australia");
      Conformance.Jurisdiction = new List<CodeableConcept>() { Australia };

      Conformance.Purpose = new Markdown("FHIR Server reference implementation");

      Conformance.Copyright = new Markdown("Copyright: PyroHealth.net");
      Conformance.Kind = CapabilityStatement.CapabilityStatementKind.Instance;

      Conformance.Software = new CapabilityStatement.SoftwareComponent();
      Conformance.Software.Name = ServerName;
      Conformance.Software.Version = $"V{IGlobalProperties.ApplicationVersionInfo}";
      Conformance.Software.ReleaseDate = ApplicationReleaseDate.ToString();

      Conformance.Implementation = new CapabilityStatement.ImplementationComponent();
      Conformance.Implementation.Description = $"{ServerName} is an implementation of a FHIR server supporting V{Hl7.Fhir.Model.ModelInfo.Version} of the specification. This instance is a publicly available testing server and its resource may be cleared at any time.";
      Conformance.Implementation.Url = $"{Https}{IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Url}";

      Conformance.FhirVersion = $"V{Hl7.Fhir.Model.ModelInfo.Version}";
      Conformance.AcceptUnknown = CapabilityStatement.UnknownContentCode.Extensions;

      var ContentFormatList = new List<string>();
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADERS)
        ContentFormatList.Add(mediaType);
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADERS)
        ContentFormatList.Add(mediaType);
      Conformance.Format = ContentFormatList;

      Conformance.Rest = new List<CapabilityStatement.RestComponent>();
      var RestComponent = new CapabilityStatement.RestComponent();
      Conformance.Rest.Add(RestComponent);
      RestComponent.Mode = CapabilityStatement.RestfulCapabilityMode.Server;
      RestComponent.Documentation = $"STU{Hl7.Fhir.Model.ModelInfo.Version.Split('.')[0]} V{Hl7.Fhir.Model.ModelInfo.Version} FHIR Server";
      RestComponent.Security = new CapabilityStatement.SecurityComponent();
      RestComponent.Security.Description = "No Security has been implemented, server if publicly open";

      RestComponent.Interaction = new List<CapabilityStatement.SystemInteractionComponent>();
      var SystemInteractionComponent = new CapabilityStatement.SystemInteractionComponent();
      RestComponent.Interaction.Add(SystemInteractionComponent);
      SystemInteractionComponent.Code = CapabilityStatement.SystemRestfulInteraction.Transaction;
      SystemInteractionComponent.Documentation = "Batch Transaction supports all request methods (Delete, POST, PUT, GET) including conditional create/update/delete. Operatons are not supported within Transaction bundles.";

      RestComponent.Resource = new List<CapabilityStatement.ResourceComponent>();

      List<ServiceSearchParameterHeavy> DtoServiceSearchParameterHeavyList = ICommonServices.GetServiceSearchParametersHeavy(false);

      var ResourceTypeList = Enum.GetValues(typeof(ResourceType));
      foreach (ResourceType ResourceType in ResourceTypeList)
      {
        string CurrentResourceString = ResourceType.GetLiteral();
        FHIRAllTypes? FhirType = Hl7.Fhir.Model.ModelInfo.FhirTypeNameToFhirType(CurrentResourceString);
        var ResourceComponent = new CapabilityStatement.ResourceComponent();
        RestComponent.Resource.Add(ResourceComponent);
        ResourceComponent.Type = ResourceType;
        ResourceComponent.Interaction = new List<CapabilityStatement.ResourceInteractionComponent>()
        {
          new CapabilityStatement.ResourceInteractionComponent() { Code = CapabilityStatement.TypeRestfulInteraction.Create },
          new CapabilityStatement.ResourceInteractionComponent() { Code = CapabilityStatement.TypeRestfulInteraction.Delete},
          new CapabilityStatement.ResourceInteractionComponent() { Code = CapabilityStatement.TypeRestfulInteraction.Read},
          new CapabilityStatement.ResourceInteractionComponent() { Code = CapabilityStatement.TypeRestfulInteraction.Update},
          new CapabilityStatement.ResourceInteractionComponent() { Code = CapabilityStatement.TypeRestfulInteraction.Vread},
          new CapabilityStatement.ResourceInteractionComponent() { Code = CapabilityStatement.TypeRestfulInteraction.SearchType },
          new CapabilityStatement.ResourceInteractionComponent() { Code = CapabilityStatement.TypeRestfulInteraction.HistoryInstance }
            //new Conformance.ResourceInteractionComponent() { Code = Conformance.TypeRestfulInteraction.HistoryType},        
        };
        ResourceComponent.Versioning = CapabilityStatement.ResourceVersionPolicy.Versioned;
        ResourceComponent.ReadHistory = true;
        ResourceComponent.UpdateCreate = true;
        ResourceComponent.ConditionalCreate = true;
        ResourceComponent.ConditionalRead = CapabilityStatement.ConditionalReadStatus.FullSupport;
        ResourceComponent.ConditionalUpdate = true;
        ResourceComponent.ConditionalDelete = CapabilityStatement.ConditionalDeleteStatus.Multiple;

        List<ServiceSearchParameterHeavy> DtoServiceSearchParameterHeavyForResourceList = DtoServiceSearchParameterHeavyList.Where(x => x.Resource == CurrentResourceString || x.Resource == FHIRAllTypes.Resource.GetLiteral()).ToList();

        //List<ServiceSearchParameterHeavy> DtoServiceSearchParameterHeavyForResourceList = ICommonServices.GetServiceSearchParametersHeavyForResource(FhirType.Value.GetLiteral());
        //DtoServiceSearchParameterHeavyForResourceList.AddRange(ICommonServices.GetServiceSearchParametersHeavyForResource(FHIRAllTypes.Resource.GetLiteral()));
        ResourceComponent.SearchParam = new List<CapabilityStatement.SearchParamComponent>();
        List<string> IncludesList = null;
        List<string> RevIncludesList = null;
        foreach (var SupportedSearchParam in DtoServiceSearchParameterHeavyForResourceList)
        {
          if (SupportedSearchParam.IsIndexed && SupportedSearchParam.Status == PublicationStatus.Active)
          {
            //Include (RevIncludes are below)
            if (SupportedSearchParam.Type == SearchParamType.Reference)
            {
              if (IncludesList == null)
                IncludesList = new List<string>();
              if (SupportedSearchParam.TargetResourceTypeList.Count > 1)
              {
                foreach (var Target in SupportedSearchParam.TargetResourceTypeList)
                {
                  IncludesList.Add($"{SupportedSearchParam.Resource}:{SupportedSearchParam.Name}:{Target.ResourceType.GetLiteral()}");
                }
              }
              else
              {
                IncludesList.Add($"{SupportedSearchParam.Resource}:{SupportedSearchParam.Name}");
              }
            }

            CapabilityStatement.SearchParamComponent SearchParamComponent = new CapabilityStatement.SearchParamComponent();
            ResourceComponent.SearchParam.Add(SearchParamComponent);

            SearchParamComponent.Name = SupportedSearchParam.Name;
            SearchParamComponent.Type = SupportedSearchParam.Type;
            SearchParamComponent.Definition = SupportedSearchParam.Url;
            if (!string.IsNullOrWhiteSpace(SupportedSearchParam.Description))
              SearchParamComponent.Documentation = SupportedSearchParam.Description;
          }
        }
        ResourceComponent.SearchInclude = IncludesList;

        //RevIncludes
        var RevIncludeSearchParameterList = DtoServiceSearchParameterHeavyList.Where(x => x.Type == SearchParamType.Reference && x.TargetResourceTypeList.Any(c => c.ResourceType == ResourceType));
        foreach (var Rev in RevIncludeSearchParameterList)
        {
          if (RevIncludesList == null)
            RevIncludesList = new List<string>();
          if (Rev.TargetResourceTypeList.Count > 1)
          {
            RevIncludesList.Add($"{Rev.Resource}:{Rev.Name}:{CurrentResourceString}");
          }
          else
          {
            RevIncludesList.Add($"{Rev.Resource}:{Rev.Name}");
          }
        }

        ResourceComponent.SearchRevInclude = RevIncludesList;
      }
      ConstructConformanceResourceNarrative(Conformance);

      IDatabaseOperationOutcome DatabaseOperationOutcome = ICommonFactory.CreateDatabaseOperationOutcome();
      ServiceOperationOutcome.FhirResourceId = Conformance.Id;
      ServiceOperationOutcome.ResourceVersionNumber = Conformance.Version;
      ServiceOperationOutcome.LastModified = Conformance.Meta.LastUpdated;
      ServiceOperationOutcome.OperationType = Common.Enum.RestEnum.CrudOperationType.Read;
      ServiceOperationOutcome.IsDeleted = false;
      ServiceOperationOutcome.RequestUri = null;
      ServiceOperationOutcome.ResourceResult = Conformance;
      ServiceOperationOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      ServiceOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      return ServiceOperationOutcome;
    }

    private void ConstructConformanceResourceNarrative(CapabilityStatement Conformance)
    {
      var XDoc = new XmlDocument();
      var Xroot = XDoc.CreateElement("div");
      var xmlns = XDoc.CreateAttribute("xmlns");
      xmlns.Value = XmlNs.XHTML;
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

      var Interactions = XDoc.CreateElement("p");
      Xroot.AppendChild(Interactions);
      var InteractionsBold = XDoc.CreateElement("b");
      InteractionsBold.AppendChild(XDoc.CreateTextNode("Interactions: "));
      Interactions.AppendChild(InteractionsBold);
      CapabilityStatement.SystemInteractionComponent SystemInteractionComponent = Conformance.Rest[0].Interaction.SingleOrDefault(y => y.Code == CapabilityStatement.SystemRestfulInteraction.Transaction);
      normal = Interactions.AppendChild(XDoc.CreateTextNode(SystemInteractionComponent.Code.ToString()));
      Interactions.AppendChild(normal);

      var ResourceTable = XDoc.CreateElement("table");
      Xroot.AppendChild(ResourceTable);
      foreach (CapabilityStatement.RestComponent RestComponent in Conformance.Rest)
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

        foreach (CapabilityStatement.ResourceComponent Resource in RestComponent.Resource)
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
          foreach (CapabilityStatement.ResourceInteractionComponent Interaction in Resource.Interaction)
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
