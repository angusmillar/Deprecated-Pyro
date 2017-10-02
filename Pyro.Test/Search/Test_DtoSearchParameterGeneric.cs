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

    [Test]
    public void Test_Chain()
    {
      //Arrange
      Moq.Mock<ISearchParameterReferance> MokISearchParameterReferance = new Moq.Mock<ISearchParameterReferance>();
      MokISearchParameterReferance.Setup(x => x.Expression).Returns("Dummy_Expression");
      MokISearchParameterReferance.Setup(x => x.Id).Returns(1);
      MokISearchParameterReferance.Setup(x => x.Name).Returns("TestChain");
      MokISearchParameterReferance.Setup(x => x.Resource).Returns("Patient");
      MokISearchParameterReferance.SetupProperty(x => x.RawValue);
      MokISearchParameterReferance.SetupProperty(x => x.TypeModifierResource);
      MokISearchParameterReferance.SetupProperty(x => x.Modifier);
      var oTargetResourceTypeList = new System.Collections.Generic.List<IServiceSearchParameterTargetResource>();
      oTargetResourceTypeList.Add(new ServiceSearchParameterTargetResource() { Id = 2, ResourceType = ResourceType.Observation, ServiceSearchParameter = null, ServiceSearchParameterId = 3 });
      MokISearchParameterReferance.Setup(x => x.TargetResourceTypeList).Returns(oTargetResourceTypeList);
      MokISearchParameterReferance.Setup(x => x.Type).Returns(SearchParamType.Reference);
      MokISearchParameterReferance.SetupProperty(x => x.ChainedSearchParameter);

      //CommonFactory Set-up
      //Moq.Mock<ICommonFactory> MokICommonFactory = new Moq.Mock<ICommonFactory>();

      Moq.Mock<ISearchParameterGenericFactory> MokISearchParameterGenericFactory = new Moq.Mock<ISearchParameterGenericFactory>();
      MokISearchParameterGenericFactory.Setup(x => x.CreateDtoSearchParameterGeneric()).Returns(new SearchParameterGeneric());

      Moq.Mock<ISearchParameterReferanceFactory> MokISearchParameterReferanceFactory = new Moq.Mock<ISearchParameterReferanceFactory>();
      MokISearchParameterReferanceFactory.Setup(x => x.CreateDtoSearchParameterReferance()).Returns(MokISearchParameterReferance.Object);



      // SearchParameterServiceFactory Set-up =======================
      var MokISearchParametersServiceOutcomeFactory = new Moq.Mock<ISearchParametersServiceOutcomeFactory>();
      MokISearchParametersServiceOutcomeFactory.Setup(x => x.CreateSearchParametersServiceOutcome()).Returns(new SearchParametersServiceOutcome());

      var MokIServiceSearchParameterCache = new Moq.Mock<IServiceSearchParameterCache>();
      List<ServiceSearchParameterLight> ServiceSearchParameterLightList = new List<ServiceSearchParameterLight>();

      //Search Parameters for Patient Resource ---------------------------------------
      ServiceSearchParameterLight ServiceSearchParameterLight = new ServiceSearchParameterLight();
      ServiceSearchParameterLight.Expression = "Test_Expression";
      ServiceSearchParameterLight.Id = 1;
      ServiceSearchParameterLight.Name = "organization";
      ServiceSearchParameterLight.Resource = "Patient";
      var oTargetResourceTypeList2 = new List<IServiceSearchParameterTargetResource>();
      oTargetResourceTypeList2.Add(new ServiceSearchParameterTargetResource() { Id = 2, ResourceType = ResourceType.Organization, ServiceSearchParameter = null, ServiceSearchParameterId = 3 });
      ServiceSearchParameterLight.TargetResourceTypeList = oTargetResourceTypeList2;
      ServiceSearchParameterLight.Type = SearchParamType.Reference;
      ServiceSearchParameterLightList.Add(ServiceSearchParameterLight);
      MokIServiceSearchParameterCache.Setup(x => x.GetSearchParameterForResource("Patient")).Returns(ServiceSearchParameterLightList);

      Moq.Mock<ISearchParameterServiceFactory> MokISearchParameterServiceFactory = new Moq.Mock<ISearchParameterServiceFactory>();

      SearchParameterFactory SearchParameterFactory = new SearchParameterFactory(MokISearchParameterServiceFactory.Object, MokISearchParameterGenericFactory.Object, MokISearchParameterReferanceFactory.Object);
      SearchParameterService SearchParameterService = new SearchParameterService(MokISearchParametersServiceOutcomeFactory.Object, SearchParameterFactory, MokIServiceSearchParameterCache.Object);

      MokISearchParameterServiceFactory.Setup(x => x.CreateSearchParameterService()).Returns(SearchParameterService);
      //====================================================


      ServiceSearchParameterLight para = new ServiceSearchParameterLight();
      para.Expression = "Dummy_Expression";
      para.Id = 1;
      para.Name = "TestChain";
      para.Resource = "Patient";
      para.TargetResourceTypeList = new System.Collections.Generic.List<IServiceSearchParameterTargetResource>();
      para.TargetResourceTypeList.Add(new ServiceSearchParameterTargetResource() { Id = 2, ResourceType = ResourceType.Observation, ServiceSearchParameter = null, ServiceSearchParameterId = 3 });
      para.Type = SearchParamType.Reference;

      var Turp = new Tuple<string, string>("subject:Patient.organization.endpoint.name", "AcmeMail");
      ISearchParameterBase oSearchParameterBase = SearchParameterFactory.CreateSearchParameter(para, Turp);



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



  }
}
