using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using Pyro.Common.Search;
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
using Pyro.Common.Service.SearchParameters;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Test.Search
{
  [TestFixture]
  [Category("Search")]
  class Test_SearchParameterParse
  {
    [Test]
    public void Test_SearchParameterReferance_ResourceAndId_Positive()
    {
      //Arrange
      IPyroFhirUriFactory PyroFhirUriFactory = TestSetupMocks.GetIPyroFhirUriFactory();
      SearchParameterReferance SearchParameterReferance = new SearchParameterReferance(PyroFhirUriFactory);
      SearchParameterReferance.Id = 10;
      SearchParameterReferance.Expression = "Not Required For Test";
      SearchParameterReferance.AllowedReferanceResourceList = new List<string>()
      {
        ResourceType.Patient.GetLiteral(),
        ResourceType.Group.GetLiteral(),
      };

      string TestResourceId = "MyResID";
      ResourceType TestResourceType = ResourceType.Patient;
      string TestResourceName = TestResourceType.GetLiteral();
      //Looks like: Patient/MyResId
      string TestParameter = $"{TestResourceName}/{TestResourceId}";

      //Act
      bool Result = SearchParameterReferance.TryParseValue(TestParameter);

      //Assert
      Assert.IsTrue(Result, "Parse retruned False, expected True");
      Assert.AreEqual(SearchParameterReferance.ValueList.Count, 1, "To many Values returned for parse");
      Assert.IsFalse(SearchParameterReferance.ValueList[0].IsMissing, "IsMissing should be False");
      Assert.IsNull(SearchParameterReferance.ChainedSearchParameter, "ChainedSearchParameter should be null");
      Assert.IsFalse(SearchParameterReferance.HasLogicalOrProperties, "HasLogicalOrProperties should be False");
      Assert.IsNull(SearchParameterReferance.InvalidMessage, "InvalidMessage should be Null");
      Assert.IsFalse(SearchParameterReferance.IsChained, "IsChained should be False");
      Assert.IsTrue(SearchParameterReferance.IsValid, "IsValid  should be True");
      Assert.IsNull(SearchParameterReferance.Modifier, "Modifier should be NUll");      
      Assert.IsNull(SearchParameterReferance.TypeModifierResource, "RawValue does not match parameter");
      Assert.IsNotNull(SearchParameterReferance.ValueList[0].FhirRequestUri, "FhirRequestUri can not be Null");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourceType, TestResourceType, "FhirRequestUri.ResourceType should be Patient");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourseName, TestResourceName, "FhirRequestUri.ResourceName should be Patient");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourceId, TestResourceId, "FhirRequestUri.ResourceName should be Patient");
    }

    [Test]
    public void Test_ORSearchParameterReferance_ResourceAndId_Positive()
    {
      //Arrange
      IPyroFhirUriFactory PyroFhirUriFactory = TestSetupMocks.GetIPyroFhirUriFactory();
      SearchParameterReferance SearchParameterReferance = new SearchParameterReferance(PyroFhirUriFactory);
      SearchParameterReferance.Id = 10;
      SearchParameterReferance.Expression = "Not Required For Test";
      SearchParameterReferance.AllowedReferanceResourceList = new List<string>()
      {
        ResourceType.Patient.GetLiteral(),
        ResourceType.Group.GetLiteral(),
      };

      string TestResourceId = "MyResID1";
      string TestResourceId2 = "MyResID2";
      ResourceType TestResourceType = ResourceType.Patient;
      ResourceType TestResourceType2 = ResourceType.Group;
      string TestResourceName = TestResourceType.GetLiteral();
      string TestResourceName2 = TestResourceType2.GetLiteral();
      //Looks like: Patient/MyResId
      string TestParameter = $"{TestResourceName}/{TestResourceId},{TestResourceName2}/{TestResourceId2}";

      //Act
      bool Result = SearchParameterReferance.TryParseValue(TestParameter);

      //Assert
      Assert.IsTrue(Result, "Parse retruned False, expected True");
      Assert.AreEqual(SearchParameterReferance.ValueList.Count, 2, "To many Values returned for parse");
      Assert.IsFalse(SearchParameterReferance.ValueList[0].IsMissing, "IsMissing should be False");
      Assert.IsNull(SearchParameterReferance.ChainedSearchParameter, "ChainedSearchParameter should be null");
      Assert.IsTrue(SearchParameterReferance.HasLogicalOrProperties, "HasLogicalOrProperties should be False");
      Assert.IsNull(SearchParameterReferance.InvalidMessage, "InvalidMessage should be Null");
      Assert.IsFalse(SearchParameterReferance.IsChained, "IsChained should be False");
      Assert.IsTrue(SearchParameterReferance.IsValid, "IsValid  should be True");
      Assert.IsNull(SearchParameterReferance.Modifier, "Modifier should be NUll");
      Assert.IsNull(SearchParameterReferance.TypeModifierResource, "RawValue does not match parameter");

      Assert.IsNotNull(SearchParameterReferance.ValueList[0].FhirRequestUri, "FhirRequestUri can not be Null");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourceType, TestResourceType, "FhirRequestUri.ResourceType should be Patient");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourseName, TestResourceName, "FhirRequestUri.ResourceName should be Patient");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourceId, TestResourceId, "FhirRequestUri.ResourceName should be Patient");

      Assert.IsNotNull(SearchParameterReferance.ValueList[1].FhirRequestUri, "FhirRequestUri can not be Null");
      Assert.AreEqual(SearchParameterReferance.ValueList[1].FhirRequestUri.ResourceType, TestResourceType2, "FhirRequestUri.ResourceType should be Patient");
      Assert.AreEqual(SearchParameterReferance.ValueList[1].FhirRequestUri.ResourseName, TestResourceName2, "FhirRequestUri.ResourceName should be Patient");
      Assert.AreEqual(SearchParameterReferance.ValueList[1].FhirRequestUri.ResourceId, TestResourceId2, "FhirRequestUri.ResourceName should be Patient");
    }


    [Test]
    public void Test_SearchParameterReferance_Id_Positive()
    {
      //Arrange
      IPyroFhirUriFactory PyroFhirUriFactory = TestSetupMocks.GetIPyroFhirUriFactory();
      SearchParameterReferance SearchParameterReferance = new SearchParameterReferance(PyroFhirUriFactory);
      SearchParameterReferance.Id = 10;
      SearchParameterReferance.Expression = "Not Required For Test";
      SearchParameterReferance.AllowedReferanceResourceList = new List<string>()
      {
        ResourceType.Patient.GetLiteral(),        
      };

      string TestResourceId = "MyResID";
      ResourceType TestResourceType = ResourceType.Patient;
      string TestResourceName = TestResourceType.GetLiteral();
      //Looks like: Patient/MyResId
      string TestParameter = $"{TestResourceId}";

      //Act
      bool Result = SearchParameterReferance.TryParseValue(TestParameter);

      //Assert
      Assert.IsTrue(Result, "Parse retruned False, expected True");
      Assert.AreEqual(SearchParameterReferance.ValueList.Count, 1, "To many Values returned for parse");
      Assert.IsFalse(SearchParameterReferance.ValueList[0].IsMissing, "IsMissing should be False");
      Assert.IsNull(SearchParameterReferance.ChainedSearchParameter, "ChainedSearchParameter should be null");
      Assert.IsFalse(SearchParameterReferance.HasLogicalOrProperties, "HasLogicalOrProperties should be False");
      Assert.IsNull(SearchParameterReferance.InvalidMessage, "InvalidMessage should be Null");
      Assert.IsFalse(SearchParameterReferance.IsChained, "IsChained should be False");
      Assert.IsTrue(SearchParameterReferance.IsValid, "IsValid  should be True");
      Assert.IsNull(SearchParameterReferance.Modifier, "Modifier should be NUll");
      Assert.IsNull(SearchParameterReferance.TypeModifierResource, "RawValue does not match parameter");
      Assert.IsNotNull(SearchParameterReferance.ValueList[0].FhirRequestUri, "FhirRequestUri can not be Null");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourceType, TestResourceType, "FhirRequestUri.ResourceType should be Patient");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourseName, TestResourceName, "FhirRequestUri.ResourceName should be Patient");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourceId, TestResourceId, "FhirRequestUri.ResourceName should be Patient");
    }

    [Test]
    public void Test_SearchParameterReferance_Id_Negative()
    {
      //Arrange
      IPyroFhirUriFactory PyroFhirUriFactory = TestSetupMocks.GetIPyroFhirUriFactory();
      SearchParameterReferance SearchParameterReferance = new SearchParameterReferance(PyroFhirUriFactory);
      SearchParameterReferance.Id = 10;
      SearchParameterReferance.Expression = "Not Required For Test";
      SearchParameterReferance.AllowedReferanceResourceList = new List<string>()
      {
        ResourceType.Patient.GetLiteral(),
        ResourceType.Group.GetLiteral(),
      };

      string TestResourceId = "MyResID";
      ResourceType TestResourceType = ResourceType.Patient;
      string TestResourceName = TestResourceType.GetLiteral();
      //Looks like: MyResId
      string TestParameter = $"{TestResourceId}";

      //Act
      bool Result = SearchParameterReferance.TryParseValue(TestParameter);

      //Assert
      Assert.IsTrue(Result, "Parse retruned False, expected True");
      Assert.AreEqual(SearchParameterReferance.ValueList.Count, 1, "To many Values returned for parse");
      Assert.IsFalse(SearchParameterReferance.ValueList[0].IsMissing, "IsMissing should be False");
      Assert.IsNull(SearchParameterReferance.ChainedSearchParameter, "ChainedSearchParameter should be null");
      Assert.IsFalse(SearchParameterReferance.HasLogicalOrProperties, "HasLogicalOrProperties should be False");
      Assert.IsNull(SearchParameterReferance.InvalidMessage, "InvalidMessage should be Null");
      Assert.IsFalse(SearchParameterReferance.IsChained, "IsChained should be False");
      Assert.IsTrue(SearchParameterReferance.IsValid, "IsValid  should be True");
      Assert.IsNull(SearchParameterReferance.Modifier, "Modifier should be NUll");
      Assert.IsNull(SearchParameterReferance.TypeModifierResource, "RawValue does not match parameter");
      Assert.IsNotNull(SearchParameterReferance.ValueList[0].FhirRequestUri, "FhirRequestUri can not be Null");
      Assert.IsNull(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourceType, "FhirRequestUri.ResourceType should be Null");
      Assert.IsNull(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourseName, "FhirRequestUri.ResourceName should be Null");
      Assert.AreEqual(SearchParameterReferance.ValueList[0].FhirRequestUri.ResourceId, TestResourceId, "FhirRequestUri.ResourceName should be Patient");
    }


  }
}
