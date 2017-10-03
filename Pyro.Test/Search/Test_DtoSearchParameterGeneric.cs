using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using Pyro.Common.Search;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.CompositionRoot;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.Service;
using Pyro.Common.ServiceSearchParameter;
using System.Collections.Generic;
using Pyro.Test.IntergrationTest;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Tools.UriSupport;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  [Category("Search")]
  class Test_DtoSearchParameterGeneric
  {
    [Test]
    public void Test_Simple()
    {
      //Arrange
      string UrlSearchParametersString = "?family=Millar&given=Angus";
      var DtoSearchParameterGeneric = new SearchParameterGeneric();

      //Act
      ISearchParameterGeneric Result = DtoSearchParameterGeneric.Parse(UrlSearchParametersString);

      //Assert
      Assert.AreEqual(2, Result.ParameterList.Count);
      Assert.AreEqual("Millar", Result.ParameterList[0].Item2);
      Assert.AreEqual("Angus", Result.ParameterList[1].Item2);
      Assert.IsNull(Result.Count);
      Assert.IsNull(Result.SummaryType);
    }

    [Test]
    public void Test_Include()
    {
      //Arrange
      string UrlSearchParametersString = "?_count=5&_count=10&family=Millar,Darmody1&family=Millar2&given=Angus&_include=Patient%3Aorganization";
      var DtoSearchParameterGeneric = new SearchParameterGeneric();

      //Act
      ISearchParameterGeneric Result = DtoSearchParameterGeneric.Parse(UrlSearchParametersString);

      //Assert
      Assert.AreEqual(3, Result.ParameterList.Count);
      Assert.AreEqual("Millar,Darmody1", Result.ParameterList[0].Item2);
      Assert.AreEqual("Millar2", Result.ParameterList[1].Item2);
      Assert.AreEqual(10, Result.Count.Value);
      Assert.IsNull(Result.SummaryType);
      Assert.AreEqual(1, Result.Include.Count);
      Assert.AreEqual("Patient:organization", Result.Include[0].Item2);
    }

    [Test]
    public void Test_Simple_Chain()
    {
      //Arrange
      //example: GET [base]/DiagnosticReport?subject:Patient.name=peter
      string UrlSearchParametersString = "?subject:Patient.name=peter";
      var DtoSearchParameterGeneric = new SearchParameterGeneric();

      //Act
      ISearchParameterGeneric Result = DtoSearchParameterGeneric.Parse(UrlSearchParametersString);

      //Assert
      Assert.AreEqual(1, Result.ParameterList.Count);
      Assert.AreEqual("subject:Patient.name", Result.ParameterList[0].Item1);
      Assert.AreEqual("peter", Result.ParameterList[0].Item2);
    }

    [Test]
    public void Test_Chain_Recursive_x1()
    {
      //Arrange
      //from DiagnosticReport to Patient to Organization's name
      //example: GET [base]/DiagnosticReport?subject:Patient.organization.name=peter
      string UrlSearchParametersString = "?subject:Patient.organization.name=acme";
      var DtoSearchParameterGeneric = new SearchParameterGeneric();

      //Act
      ISearchParameterGeneric Result = DtoSearchParameterGeneric.Parse(UrlSearchParametersString);

      //Assert
      Assert.AreEqual(1, Result.ParameterList.Count);
      Assert.AreEqual("subject:Patient.organization.name", Result.ParameterList[0].Item1);
      Assert.AreEqual("acme", Result.ParameterList[0].Item2);
    }

    [Test]
    public void Test_Chain_Recursive_x2()
    {
      //Arrange
      //from DiagnosticReport to Patient to Organization to Endpoint's name
      //example: GET [base]/DiagnosticReport?subject:Patient.organization.endpoint.name=AcmeMail
      string UrlSearchParametersString = "?subject:Patient.organization.endpoint.name=AcmeMail";
      var DtoSearchParameterGeneric = new SearchParameterGeneric();

      //Act
      ISearchParameterGeneric Result = DtoSearchParameterGeneric.Parse(UrlSearchParametersString);

      //Assert
      Assert.AreEqual(1, Result.ParameterList.Count);
      Assert.AreEqual("subject:Patient.organization.endpoint.name", Result.ParameterList[0].Item1);
      Assert.AreEqual("AcmeMail", Result.ParameterList[0].Item2);
    }

    private SearchParameterReferance GetMokedSearchParameterReferance()
    {
      string ServiceRootUrlString = StaticTestData.FhirEndpoint();
      Moq.Mock<IDtoRootUrlStore> MokIDtoRootUrlStore = new Moq.Mock<IDtoRootUrlStore>();
      MokIDtoRootUrlStore.Setup(x => x.Id).Returns(1);
      MokIDtoRootUrlStore.Setup(x => x.IsServersPrimaryUrlRoot).Returns(true);
      MokIDtoRootUrlStore.Setup(x => x.RootUri).Returns(new Uri(ServiceRootUrlString));
      MokIDtoRootUrlStore.Setup(x => x.Url).Returns(ServiceRootUrlString);

      Moq.Mock<IPrimaryServiceRootCache> MokIPrimaryServiceRootCache = new Moq.Mock<IPrimaryServiceRootCache>();
      MokIPrimaryServiceRootCache.Setup(x => x.GetPrimaryRootUrlFromDatabase()).Returns(MokIDtoRootUrlStore.Object);
      MokIPrimaryServiceRootCache.Setup(x => x.GetPrimaryRootUrlFromWebConfig()).Returns(ServiceRootUrlString);

      Moq.Mock<IPyroFhirUriFactory> MokIPyroFhirUriFactory = new Moq.Mock<IPyroFhirUriFactory>();

      MokIPyroFhirUriFactory.Setup(x => x.CreateFhirRequestUri()).Returns(new PyroFhirUri(MokIPrimaryServiceRootCache.Object));

      return new SearchParameterReferance(MokIPyroFhirUriFactory.Object);
    }

    [Test]
    public void Test_Chain()
    {
      //Arrange     
      Moq.Mock<ISearchParameterGenericFactory> MokISearchParameterGenericFactory = new Moq.Mock<ISearchParameterGenericFactory>();
      MokISearchParameterGenericFactory.Setup(x => x.CreateDtoSearchParameterGeneric()).Returns(new SearchParameterGeneric());

      Moq.Mock<ISearchParameterReferanceFactory> MokISearchParameterReferanceFactory = new Moq.Mock<ISearchParameterReferanceFactory>();
      MokISearchParameterReferanceFactory.Setup(x => x.CreateDtoSearchParameterReferance()).Returns(GetMokedSearchParameterReferance());


      // SearchParameterServiceFactory Set-up =======================
      // These are the actual supported search parameters that come from the database.
      var MokISearchParametersServiceOutcomeFactory = new Moq.Mock<ISearchParametersServiceOutcomeFactory>();
      MokISearchParametersServiceOutcomeFactory.Setup(x => x.CreateSearchParametersServiceOutcome()).Returns(new SearchParametersServiceOutcome());

      var MokIServiceSearchParameterCache = new Moq.Mock<IServiceSearchParameterCache>();

      //Search Parameters for DiagnosticReport Resource ---------------------------------------
      List<ServiceSearchParameterLight> DiagnosticReportServiceSearchParameterLightList = new List<ServiceSearchParameterLight>();

      ServiceSearchParameterLight ServiceSearchParameterLight_DiagnosticReportSubject = new ServiceSearchParameterLight();
      ServiceSearchParameterLight_DiagnosticReportSubject.Expression = "Test_Expression for subject";
      ServiceSearchParameterLight_DiagnosticReportSubject.Id = 1;
      ServiceSearchParameterLight_DiagnosticReportSubject.Name = "subject";
      ServiceSearchParameterLight_DiagnosticReportSubject.Resource = "DiagnosticReport";
      var oTargetResourceTypeListDiagnosticReport = new List<IServiceSearchParameterTargetResource>();
      oTargetResourceTypeListDiagnosticReport.Add(new ServiceSearchParameterTargetResource() { Id = 11, ResourceType = ResourceType.Patient, ServiceSearchParameter = null, ServiceSearchParameterId = 111 });
      ServiceSearchParameterLight_DiagnosticReportSubject.TargetResourceTypeList = oTargetResourceTypeListDiagnosticReport;
      ServiceSearchParameterLight_DiagnosticReportSubject.Type = SearchParamType.Reference;
      DiagnosticReportServiceSearchParameterLightList.Add(ServiceSearchParameterLight_DiagnosticReportSubject);

      ServiceSearchParameterLight ServiceSearchParameterLight_DiagnosticReportIdentifier = new ServiceSearchParameterLight();
      ServiceSearchParameterLight_DiagnosticReportIdentifier.Expression = "Test_Expression for identifier";
      ServiceSearchParameterLight_DiagnosticReportIdentifier.Id = 11;
      ServiceSearchParameterLight_DiagnosticReportIdentifier.Name = "identifier";
      ServiceSearchParameterLight_DiagnosticReportIdentifier.Resource = "DiagnosticReport";
      ServiceSearchParameterLight_DiagnosticReportIdentifier.Type = SearchParamType.Token;
      DiagnosticReportServiceSearchParameterLightList.Add(ServiceSearchParameterLight_DiagnosticReportIdentifier);

      MokIServiceSearchParameterCache.Setup(x => x.GetSearchParameterForResource("DiagnosticReport")).Returns(DiagnosticReportServiceSearchParameterLightList);

      //Search Parameters for Patient Resource ---------------------------------------
      List<ServiceSearchParameterLight> PatientServiceSearchParameterLightList = new List<ServiceSearchParameterLight>();

      ServiceSearchParameterLight ServiceSearchParameterLight_PatientOrganization = new ServiceSearchParameterLight();
      ServiceSearchParameterLight_PatientOrganization.Expression = "Test_Expression for organization";
      ServiceSearchParameterLight_PatientOrganization.Id = 2;
      ServiceSearchParameterLight_PatientOrganization.Name = "organization";
      ServiceSearchParameterLight_PatientOrganization.Resource = "Patient";
      var oTargetResourceTypeListOrganization = new List<IServiceSearchParameterTargetResource>();
      oTargetResourceTypeListOrganization.Add(new ServiceSearchParameterTargetResource() { Id = 22, ResourceType = ResourceType.Organization, ServiceSearchParameter = null, ServiceSearchParameterId = 222 });
      ServiceSearchParameterLight_PatientOrganization.TargetResourceTypeList = oTargetResourceTypeListOrganization;
      ServiceSearchParameterLight_PatientOrganization.Type = SearchParamType.Reference;
      PatientServiceSearchParameterLightList.Add(ServiceSearchParameterLight_PatientOrganization);

      MokIServiceSearchParameterCache.Setup(x => x.GetSearchParameterForResource("Patient")).Returns(PatientServiceSearchParameterLightList);

      //Search Parameters for Organization Resource ---------------------------------------
      List<ServiceSearchParameterLight> OrganizationServiceSearchParameterLightList = new List<ServiceSearchParameterLight>();

      ServiceSearchParameterLight ServiceSearchParameterLight_OrganizationEndpoint = new ServiceSearchParameterLight();
      ServiceSearchParameterLight_OrganizationEndpoint.Expression = "Test_Expression for endpoint";
      ServiceSearchParameterLight_OrganizationEndpoint.Id = 3;
      ServiceSearchParameterLight_OrganizationEndpoint.Name = "endpoint";
      ServiceSearchParameterLight_OrganizationEndpoint.Resource = "Organization";
      var oTargetResourceTypeListEndpoint = new List<IServiceSearchParameterTargetResource>();
      oTargetResourceTypeListEndpoint.Add(new ServiceSearchParameterTargetResource() { Id = 33, ResourceType = ResourceType.Endpoint, ServiceSearchParameter = null, ServiceSearchParameterId = 333 });
      ServiceSearchParameterLight_OrganizationEndpoint.TargetResourceTypeList = oTargetResourceTypeListEndpoint;
      ServiceSearchParameterLight_OrganizationEndpoint.Type = SearchParamType.Reference;
      OrganizationServiceSearchParameterLightList.Add(ServiceSearchParameterLight_OrganizationEndpoint);

      MokIServiceSearchParameterCache.Setup(x => x.GetSearchParameterForResource("Organization")).Returns(OrganizationServiceSearchParameterLightList);

      //Search Parameters for Endpoint Resource ---------------------------------------
      List<ServiceSearchParameterLight> EndpointServiceSearchParameterLightList = new List<ServiceSearchParameterLight>();

      ServiceSearchParameterLight ServiceSearchParameterLight_EndpointName = new ServiceSearchParameterLight();
      ServiceSearchParameterLight_EndpointName.Expression = "Test_Expression for Endpoint";
      ServiceSearchParameterLight_EndpointName.Id = 4;
      ServiceSearchParameterLight_EndpointName.Name = "name";
      ServiceSearchParameterLight_EndpointName.Resource = "Endpoint";
      ServiceSearchParameterLight_EndpointName.TargetResourceTypeList = null;
      ServiceSearchParameterLight_EndpointName.Type = SearchParamType.String;
      EndpointServiceSearchParameterLightList.Add(ServiceSearchParameterLight_EndpointName);

      MokIServiceSearchParameterCache.Setup(x => x.GetSearchParameterForResource("Endpoint")).Returns(EndpointServiceSearchParameterLightList);

      //--------------------------------------------------------------------------------

      Moq.Mock<ISearchParameterServiceFactory> MokISearchParameterServiceFactory = new Moq.Mock<ISearchParameterServiceFactory>();

      //The SearchParameterFactory returns individual search parameters
      SearchParameterFactory SearchParameterFactory = new SearchParameterFactory(MokISearchParameterServiceFactory.Object, MokISearchParameterGenericFactory.Object, MokISearchParameterReferanceFactory.Object);
      // The SearchParameterService wraps the factory above and processes all search parameters for a single URL
      SearchParameterService SearchParameterService = new SearchParameterService(MokISearchParametersServiceOutcomeFactory.Object, SearchParameterFactory, MokIServiceSearchParameterCache.Object);
      // A factor used by the SearchParameterService when processing chained parameters recusivly
      MokISearchParameterServiceFactory.Setup(x => x.CreateSearchParameterService()).Returns(SearchParameterService);
      //====================================================

      string UrlSearchParametersString = "?subject:Patient.organization.endpoint.name=AcmeMail&identifier=123";
      var DtoSearchParameterGeneric = new SearchParameterGeneric();


      //Act
      DtoSearchParameterGeneric.Parse(UrlSearchParametersString);
      ISearchParametersServiceOutcome Result = SearchParameterService.ProcessResourceSearchParameters(DtoSearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Resource, FHIRAllTypes.DiagnosticReport);

      //Assert
      Assert.NotNull(Result, "Test returned null");
      //Assert.AreEqual("subject:Patient.organization.endpoint.name", Result.ParameterList[0].Item1);
      //Assert.AreEqual("AcmeMail", Result.ParameterList[0].Item2);
    }



  }
}
