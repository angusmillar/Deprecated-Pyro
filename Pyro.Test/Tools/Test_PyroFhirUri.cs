using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Extentions;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Test.Tools
{
  [TestFixture]
  [Category("Tool: PyroFhirUri")]
  class Test_PyroFhirUri
  {
    private string PrimaryServiceRootLocal = "http://localhost:8888/fhir";
    //private string PrimaryServiceRootWeb = "http://pyrohealth.net/fhir";
    private string PrimaryServiceRootWeb = "https://stu3.test.pyrohealth.net/fhir";
    private string PrimaryServiceRootRemote = "http://SomeOther/one/two/three/fhir";
    private Moq.Mock<IPrimaryServiceRootCache> MokPrimaryServiceRootCache = null;


    private void SetServiceRootMok(string PrimaryServiceRoot)
    {
      Moq.Mock<IDtoRootUrlStore> MokDtoRootUrlStore = new Moq.Mock<IDtoRootUrlStore>();
      MokDtoRootUrlStore.Setup(x => x.Url).Returns(PrimaryServiceRoot);
      MokDtoRootUrlStore.Setup(x => x.RootUri).Returns(new Uri(PrimaryServiceRoot));
      MokDtoRootUrlStore.Setup(x => x.Id).Returns(1);
      MokDtoRootUrlStore.Setup(x => x.IsServersPrimaryUrlRoot).Returns(true);

      MokPrimaryServiceRootCache = new Moq.Mock<IPrimaryServiceRootCache>();
      MokPrimaryServiceRootCache.Setup(x => x.GetPrimaryRootUrlFromDatabase()).Returns(MokDtoRootUrlStore.Object);
      MokPrimaryServiceRootCache.Setup(x => x.GetPrimaryRootUrlFromWebConfig()).Returns(PrimaryServiceRoot);
    }

    [Test]
    public void Test_BasicLocal()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/Organization/1
      string HttpsPrimaryServiceRootLocal = "https://localhost:8888/fhir";
      SetServiceRootMok(HttpsPrimaryServiceRootLocal);
      string Request = HttpsPrimaryServiceRootLocal + "/Patient/10";

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, HttpsPrimaryServiceRootLocal);
      Assert.AreEqual(Result.ResourseName, "Patient");
      Assert.AreEqual(Result.ResourceId, "10");
      Assert.AreEqual(Result.IsRelativeToServer, true);
      Assert.AreEqual(Result.IsOperation, false);
      Assert.AreEqual(Result.OperationType, null);
      Assert.AreEqual(Result.OperationName, null);
    }

    [Test]
    public void Test_BasicLocalGuidResourceId()
    {
      //Arrange
      // URl : http://localhost:8888/fhir/Binary/d20cf99e-1e97-4ca8-b856-824f4ca15448
      string HttpsPrimaryServiceRootLocal = "http://localhost:8888/fhir";
      SetServiceRootMok(HttpsPrimaryServiceRootLocal);
      //string Request = HttpsPrimaryServiceRootLocal + "/Binary/d20cf99e-1e97-4ca8-b856-824f4ca15448";
      string Request = "http://localhost:8888/fhir/Binary/489effed-92c1-4ce0-a74e-c9ea13626c7d";

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, HttpsPrimaryServiceRootLocal);
      Assert.AreEqual(Result.ResourseName, "Binary");
      Assert.AreEqual(Result.ResourceId, "489effed-92c1-4ce0-a74e-c9ea13626c7d");
      Assert.AreEqual(Result.IsRelativeToServer, true);
      Assert.AreEqual(Result.IsOperation, false);
      Assert.AreEqual(Result.OperationType, null);
      Assert.AreEqual(Result.OperationName, null);
    }

    

    [Test]
    public void Test_BasicWeb()
    {
      //Arrange      
      string Request = PrimaryServiceRootWeb + "/Patient/10";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);


      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.ResourseName, "Patient");
      Assert.AreEqual(Result.ResourceId, "10");
      Assert.AreEqual(Result.IsRelativeToServer, true);

    }


    [Test]
    public void Test_BasicRemote()
    {
      //Arrange      
      string Request = PrimaryServiceRootRemote + "/Patient/10";
      SetServiceRootMok(PrimaryServiceRootLocal);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);


      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootRemote.OriginalString, PrimaryServiceRootRemote);
      Assert.AreEqual(Result.ResourseName, "Patient");
      Assert.AreEqual(Result.ResourceId, "10");
      Assert.AreEqual(Result.IsRelativeToServer, false);

    }

    [Test]
    public void Test_Contained()
    {
      //Arrange      
      string Request = "#10";
      SetServiceRootMok(PrimaryServiceRootLocal);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.IsContained, true);
      Assert.AreEqual(Result.ResourceId, "10");
      Assert.AreEqual(Result.ResourseName, null);
      Assert.AreEqual(Result.IsRelativeToServer, false);

    }

    [Test]
    public void Test_ContainedWithResourceRef()
    {
      //Arrange      
      string Request = "Patient/#10";
      SetServiceRootMok(PrimaryServiceRootLocal);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.IsContained, true);
      Assert.AreEqual(Result.ResourceId, "10");
      Assert.AreEqual(Result.ResourseName, "Patient");
      Assert.AreEqual(Result.IsRelativeToServer, false);
    }

    [Test]
    public void Test_BasicRemoteHistoryId()
    {
      //Arrange      
      string Request = PrimaryServiceRootRemote + "/Patient/10/_history/20";
      SetServiceRootMok(PrimaryServiceRootLocal);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootRemote.OriginalString, PrimaryServiceRootRemote);
      Assert.AreEqual(Result.IsHistoryReferance, true);
      Assert.AreEqual(Result.VersionId, "20");
      Assert.AreEqual(Result.IsRelativeToServer, false);
    }

    [Test]
    public void Test_BasicRemoteHistory()
    {
      //Arrange      
      string Request = PrimaryServiceRootRemote + "/Patient/10/_history";
      SetServiceRootMok(PrimaryServiceRootLocal);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootRemote.OriginalString, PrimaryServiceRootRemote);
      Assert.AreEqual(Result.IsHistoryReferance, true);
      Assert.AreEqual(Result.VersionId, null);
      Assert.AreEqual(Result.IsRelativeToServer, false);
    }

    [Test]
    public void Test_RelativeHistoryId()
    {
      //Arrange      
      string Request = "Patient/10/_history/20";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.IsHistoryReferance, true);
      Assert.AreEqual(Result.VersionId, "20");
      Assert.AreEqual(Result.IsRelativeToServer, true);
    }

    [Test]
    public void Test_BasicRemoteBaseOperation()
    {
      //Arrange      
      string Request = PrimaryServiceRootRemote + "/$SomeOperation?given=john&family=smith";
      SetServiceRootMok(PrimaryServiceRootLocal);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootRemote.OriginalString, PrimaryServiceRootRemote);
      Assert.AreEqual(Result.IsRelativeToServer, false);
      Assert.AreEqual(Result.IsOperation, true);
      Assert.AreEqual(Result.OperationType, Pyro.Common.Enum.FhirOperationEnum.OperationScope.Base);
      Assert.AreEqual(Result.OperationName, "SomeOperation");
      Assert.AreEqual(Result.Query, "given=john&family=smith");
    }

    [Test]
    public void Test_BasicWebResourceOperation()
    {
      //Arrange      
      string Request = PrimaryServiceRootWeb + "/Patient/$SomeOperation?given=john&family=smith";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.IsRelativeToServer, true);
      Assert.AreEqual(Result.IsOperation, true);
      Assert.AreEqual(Result.OperationType, Pyro.Common.Enum.FhirOperationEnum.OperationScope.Resource);
      Assert.AreEqual(Result.OperationName, "SomeOperation");
      Assert.AreEqual(Result.Query, "given=john&family=smith");
    }

    [Test]
    public void Test_BasicWebResourceInstanceOperation()
    {
      //Arrange      
      string Request = PrimaryServiceRootWeb + "/Patient/10/$SomeOperation?given=john&family=smith";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.IsRelativeToServer, true);
      Assert.AreEqual(Result.IsOperation, true);
      Assert.AreEqual(Result.OperationType, Pyro.Common.Enum.FhirOperationEnum.OperationScope.Instance);
      Assert.AreEqual(Result.OperationName, "SomeOperation");
      Assert.AreEqual(Result.Query, "given=john&family=smith");
    }

    [Test]
    public void Test_BasicWebFormData()
    {
      //Arrange      
      //Http://localhost:50579/fhirapi/Organization/_search
      string Request = PrimaryServiceRootWeb + "/Patient/_search";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.IsHistoryReferance, false);
      Assert.AreEqual(Result.IsFormDataSearch, true);
      Assert.AreEqual(Result.IsRelativeToServer, true);
    }

    [Test]
    public void Test_BasicWebRubbishAtEnd()
    {
      //Arrange            
      string Request = PrimaryServiceRootWeb + "/Patient/10/RUBBISH";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsFalse(Result.Parse(Request));
      Assert.IsTrue(Result.ErrorInParseing);
      Assert.IsTrue(!string.IsNullOrWhiteSpace(Result.ParseErrorMessage));
    }

    [Test]
    public void Test_urn_uuid()
    {
      //Arrange            
      string Request = "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.IsUrn, true);
      Assert.AreEqual(Result.UrnType, UrnType.uuid);
      Assert.AreEqual(Result.Urn, "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a");
    }

    [Test]
    public void Test_urn_oid()
    {
      //Arrange            
      string Request = "urn:oid:1.2.36.1.2001.1001.101";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.IsUrn, true);
      Assert.AreEqual(Result.UrnType, UrnType.oid);
      Assert.AreEqual(Result.Urn, "urn:oid:1.2.36.1.2001.1001.101");

      Assert.AreEqual(Result.IsContained, false);
      Assert.AreEqual(Result.IsFormDataSearch, false);
      Assert.AreEqual(Result.IsHistoryReferance, false);
      Assert.AreEqual(Result.IsMetaData, false);
      Assert.AreEqual(Result.IsOperation, false);
      Assert.AreEqual(Result.IsRelativeToServer, false);
      Assert.AreEqual(Result.OperationType, null);
      Assert.AreEqual(Result.OperationName, null);
      Assert.AreEqual(Result.PrimaryServiceRootRemote, null);
      Assert.AreEqual(Result.ResourceId, null);
      Assert.AreEqual(Result.ResourseName, null);
      Assert.AreEqual(Result.VersionId, null);
    }

    [Test]
    public void Test_urn_oid_TryParse_True()
    {
      //Arrange            
      string Request = "urn:oid:1.2.36.1.2001.1001.101";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.Urn, "urn:oid:1.2.36.1.2001.1001.101");
      Assert.AreEqual(Result.IsUrn, true);
      Assert.AreEqual(Result.UrnType, UrnType.oid);
    }

    [Test]
    public void Test_urn_oid_TryParse_False()
    {
      //Arrange            
      string Request = "urn:oid:1.2.06.0.2001.1001.101";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsFalse(Result.Parse(Request));
      Assert.AreEqual(Result.ParseErrorMessage, "The urn:oid value given is not valid: urn:oid:1.2.06.0.2001.1001.101");
    }

    [Test]
    public void Test_urn_uuid_TryParse_True()
    {
      //Arrange            
      string Request = "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.Urn, "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a");
      Assert.AreEqual(Result.IsUrn, true);
      Assert.AreEqual(Result.UrnType, UrnType.uuid);
    }

    [Test]
    public void Test_urn_uuid_TryParse_False()
    {
      //Arrange            
      string Request = "urn:uuid:61ebe359-XXXXX-bfdc-4613-8bf2-c5e300945f0a";
      SetServiceRootMok(PrimaryServiceRootWeb);

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsFalse(Result.Parse(Request));
      Assert.AreEqual(Result.ParseErrorMessage, "The urn:uuid value given is not valid: urn:uuid:61ebe359-XXXXX-bfdc-4613-8bf2-c5e300945f0a");
      Assert.IsTrue(Result.ErrorInParseing);
    }



    [Test]
    public void Test_BasicCompartment()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/Patient/10/Condition
      string HttpsPrimaryServiceRootLocal = "https://localhost:8888/fhir";
      SetServiceRootMok(HttpsPrimaryServiceRootLocal);
      string Request = HttpsPrimaryServiceRootLocal + "/Patient/10/Condition";

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, HttpsPrimaryServiceRootLocal);
      Assert.AreEqual(Result.ResourseName, "Patient");
      Assert.AreEqual(Result.ResourceId, "10");
      Assert.IsTrue(Result.IsCompartment);
      Assert.AreEqual(Result.CompartmentalisedResourseName, "Condition");
      Assert.AreEqual(Result.IsRelativeToServer, true);
      Assert.AreEqual(Result.IsOperation, false);
      Assert.AreEqual(Result.OperationType, null);
      Assert.AreEqual(Result.OperationName, null);
    }

    [Test]
    public void Test_Compartment_With_SearchParameters()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/Patient/10/Condition?code:in=http://hspc.org/ValueSet/acute-concerns
      string HttpsPrimaryServiceRootLocal = "https://localhost:8888/fhir";
      SetServiceRootMok(HttpsPrimaryServiceRootLocal);
      string Request = HttpsPrimaryServiceRootLocal + "/Patient/10/Condition?code:in=http://hspc.org/ValueSet/acute-concerns";

      //Act      
      var Result = new PyroFhirUri(MokPrimaryServiceRootCache.Object);

      //Assert
      Assert.IsTrue(Result.Parse(Request));
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, HttpsPrimaryServiceRootLocal);
      Assert.AreEqual(Result.ResourseName, "Patient");
      Assert.AreEqual(Result.ResourceId, "10");
      Assert.IsTrue(Result.IsCompartment);
      Assert.AreEqual(Result.CompartmentalisedResourseName, "Condition");
      Assert.AreEqual(Result.IsRelativeToServer, true);
      Assert.AreEqual(Result.IsOperation, false);
      Assert.AreEqual(Result.OperationType, null);
      Assert.AreEqual(Result.OperationName, null);
      Assert.AreEqual(Result.Query, "code:in=http://hspc.org/ValueSet/acute-concerns");
    }


  }
}
