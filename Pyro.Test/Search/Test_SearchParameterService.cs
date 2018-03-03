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
using Pyro.Test.CommonTestSetup;
using Hl7.Fhir.Utility;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  [Category("Search")]
  class Test_SearchParameterService
  {
    private SearchParameterReferance GetMokedSearchParameterReferance()
    {     
      return new SearchParameterReferance(TestSetupMocks.GetIPyroFhirUriFactory());
    }

    [Test]
    public void Test_RecursiveChainSearch()
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
      oTargetResourceTypeListDiagnosticReport.Add(
        new _ServiceSearchParameterTargetResource()
        {
          Id = 11,
          ResourceType = ResourceType.Patient,
          ServiceSearchParameter = null,
          ServiceSearchParameterId = 111
        });
      oTargetResourceTypeListDiagnosticReport.Add(new _ServiceSearchParameterTargetResource()
      {
        Id = 111,
        ResourceType = ResourceType.Location,
        ServiceSearchParameter = null,
        ServiceSearchParameterId = 112
      });
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
      oTargetResourceTypeListOrganization.Add(new _ServiceSearchParameterTargetResource() { Id = 22, ResourceType = ResourceType.Organization, ServiceSearchParameter = null, ServiceSearchParameterId = 222 });
      ServiceSearchParameterLight_PatientOrganization.TargetResourceTypeList = oTargetResourceTypeListOrganization;
      ServiceSearchParameterLight_PatientOrganization.Type = SearchParamType.Reference;
      PatientServiceSearchParameterLightList.Add(ServiceSearchParameterLight_PatientOrganization);

      ServiceSearchParameterLight ServiceSearchParameterLight_PatientFamily = new ServiceSearchParameterLight();
      ServiceSearchParameterLight_PatientFamily.Expression = "Test_Expression for family";
      ServiceSearchParameterLight_PatientFamily.Id = 22;
      ServiceSearchParameterLight_PatientFamily.Name = "family";
      ServiceSearchParameterLight_PatientFamily.Resource = "Patient";
      ServiceSearchParameterLight_PatientFamily.Type = SearchParamType.String;
      PatientServiceSearchParameterLightList.Add(ServiceSearchParameterLight_PatientFamily);

      MokIServiceSearchParameterCache.Setup(x => x.GetSearchParameterForResource("Patient")).Returns(PatientServiceSearchParameterLightList);

      //Search Parameters for Organization Resource ---------------------------------------
      List<ServiceSearchParameterLight> OrganizationServiceSearchParameterLightList = new List<ServiceSearchParameterLight>();

      ServiceSearchParameterLight ServiceSearchParameterLight_OrganizationEndpoint = new ServiceSearchParameterLight();
      ServiceSearchParameterLight_OrganizationEndpoint.Expression = "Test_Expression for endpoint";
      ServiceSearchParameterLight_OrganizationEndpoint.Id = 3;
      ServiceSearchParameterLight_OrganizationEndpoint.Name = "endpoint";
      ServiceSearchParameterLight_OrganizationEndpoint.Resource = "Organization";
      var oTargetResourceTypeListEndpoint = new List<IServiceSearchParameterTargetResource>();
      oTargetResourceTypeListEndpoint.Add(new _ServiceSearchParameterTargetResource() { Id = 33, ResourceType = ResourceType.Endpoint, ServiceSearchParameter = null, ServiceSearchParameterId = 333 });
      oTargetResourceTypeListEndpoint.Add(new _ServiceSearchParameterTargetResource() { Id = 32, ResourceType = ResourceType.Location, ServiceSearchParameter = null, ServiceSearchParameterId = 332 });
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
      // A factor used by the SearchParameterService when processing chained parameters recursively
      MokISearchParameterServiceFactory.Setup(x => x.CreateSearchParameterService()).Returns(SearchParameterService);
      //====================================================

      string UrlSearchParametersString = "?subject:Patient.organization.endpoint:Endpoint.name=AcmeMail,AcmeMail2&identifier=123";
      var DtoSearchParameterGeneric = new SearchParameterGeneric();
      DtoSearchParameterGeneric.Parse(UrlSearchParametersString);

      //Act    
      ISearchParametersServiceOutcome Result = SearchParameterService.ProcessResourceSearchParameters(DtoSearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Resource, FHIRAllTypes.DiagnosticReport);

      //Assert
      Assert.NotNull(Result, "Test returned null");
      Assert.NotNull(Result.SearchParameters, "SearchParameters returned null");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList.Count, 2, "SearchParametersList must have 3 items");

      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].Type, SearchParamType.Reference);
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].Name, "subject");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].Resource, FHIRAllTypes.DiagnosticReport.GetLiteral());
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].TypeModifierResource, FHIRAllTypes.Patient.GetLiteral());
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList.Count, 3, "Should have 3 chained search parameters");
      Assert.AreEqual((Result.SearchParameters.SearchParametersList[0] is SearchParameterReferance), true, "Expected SearchParameterReferance type cast");
      Assert.AreEqual((Result.SearchParameters.SearchParametersList[0] as SearchParameterReferance).IsChained, true, "Expected IsChained = true");

      //Patient.organization
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[0].Type, SearchParamType.Reference, "First chain should be type Referance");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[0].Name, "organization", "First chain must have name of organization");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[0].Resource, FHIRAllTypes.Patient.GetLiteral(), $"First chain should be Resource of {FHIRAllTypes.Patient.GetLiteral()}");

      //Organization.endpoint
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[1].Type, SearchParamType.Reference, "First chain should be type Reference");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[1].Name, "endpoint", "First chain must have name of endpoint");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[1].Resource, FHIRAllTypes.Organization.GetLiteral(), $"First chain should be Resource of {FHIRAllTypes.Organization.GetLiteral()}");

      //Endpoint.name=AcmeMail
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[2].Type, SearchParamType.String, "First chain should be type String");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[2].Name, "name", "First chain must have name of name");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[2].Resource, FHIRAllTypes.Endpoint.GetLiteral(), $"First chain should be Resource of {FHIRAllTypes.Endpoint.GetLiteral()}");
      Assert.AreEqual((Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[2] as SearchParameterString).ValueList.Count, 2, $"Must 1 and only one value");
      Assert.AreEqual((Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[2] as SearchParameterString).ValueList[0].Value, "AcmeMail", $"Value should be a string of 'AcmeMail'");
      Assert.AreEqual((Result.SearchParameters.SearchParametersList[0].ChainedSearchParameterList[2] as SearchParameterString).ValueList[1].Value, "AcmeMail2", $"Value should be a string of 'AcmeMail2'");

      //DiagnosticReport.identifier
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[1].Type, SearchParamType.Token, "First chain should be type Token");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[1].Name, "identifier", "First chain must have name of identifier");
      Assert.AreEqual(Result.SearchParameters.SearchParametersList[1].Resource, FHIRAllTypes.DiagnosticReport.GetLiteral(), $"First chain should be Resource of {FHIRAllTypes.Organization.GetLiteral()}");
      Assert.AreEqual((Result.SearchParameters.SearchParametersList[1] is SearchParameterToken), true, "Expected SearchParameterToken type cast");
      Assert.AreEqual((Result.SearchParameters.SearchParametersList[1] as SearchParameterToken).ValueList.Count, 1, "Expected ValueList count = 1");
      Assert.AreEqual((Result.SearchParameters.SearchParametersList[1] as SearchParameterToken).ValueList[0].Code, "123", "Expected ValueList[0] to be '123'");


    }



  }
}
