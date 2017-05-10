using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Extentions;

namespace Pyro.Test.Tools
{
  [TestFixture]
  [Category("Tool: FhirRequestUri")]
  class Test_FhirRequestUri
  {    
    private string PrimaryServiceRootLocal = "http://localhost:8888/test/stu3/fhir";
    private string PrimaryServiceRootWeb = "http://pyrohealth.net/test/stu3/fhir";
    private string PrimaryServiceRootRemote = "http://SomeOther/one/two/three/fhir";

    [Test]
    public void Test_BasicLocal()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/Organization/1
      string Request = PrimaryServiceRootLocal + "/Patient/10";

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootLocal, Request);

      //Assert
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootLocal);
      Assert.AreEqual(Result.ResourseName, "Patient");
      Assert.AreEqual(Result.ResourceId, "10");
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

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootWeb, Request);

      //Assert
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
      
      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootLocal, Request);

      //Assert
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

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootLocal, Request);

      //Assert      
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

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootLocal, Request);

      //Assert      
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

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootLocal, Request);

      //Assert
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

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootLocal, Request);

      //Assert
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

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootWeb, Request);

      //Assert
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


      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootLocal, Request);

      //Assert
      Assert.AreEqual(Result.PrimaryServiceRootRemote.OriginalString, PrimaryServiceRootRemote);
      Assert.AreEqual(Result.IsRelativeToServer, false);
      Assert.AreEqual(Result.IsOperation, true);
      Assert.AreEqual(Result.OperationType, Pyro.Common.Enum.FhirOperationEnum.OperationType.Base);
      Assert.AreEqual(Result.OperationName, "SomeOperation");
      Assert.AreEqual(Result.Query, "given=john&family=smith");
    }

    [Test]
    public void Test_BasicWebResourceOperation()
    {
      //Arrange      
      string Request = PrimaryServiceRootWeb + "/Patient/$SomeOperation?given=john&family=smith";


      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootWeb, Request);

      //Assert
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.IsRelativeToServer, true);
      Assert.AreEqual(Result.IsOperation, true);
      Assert.AreEqual(Result.OperationType, Pyro.Common.Enum.FhirOperationEnum.OperationType.Resource);      
      Assert.AreEqual(Result.OperationName, "SomeOperation");      
      Assert.AreEqual(Result.Query, "given=john&family=smith");
    }

    [Test]
    public void Test_BasicWebResourceInstanceOperation()
    {
      //Arrange      
      string Request = PrimaryServiceRootWeb + "/Patient/10/$SomeOperation?given=john&family=smith";


      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootWeb, Request);

      //Assert
      Assert.AreEqual(Result.PrimaryServiceRootServers.OriginalString, PrimaryServiceRootWeb);
      Assert.AreEqual(Result.IsRelativeToServer, true);
      Assert.AreEqual(Result.IsOperation, true);
      Assert.AreEqual(Result.OperationType, Pyro.Common.Enum.FhirOperationEnum.OperationType.Instance);
      Assert.AreEqual(Result.OperationName, "SomeOperation");
      Assert.AreEqual(Result.Query, "given=john&family=smith");
    }

    [Test]
    public void Test_BasicWebFormData()
    {
      //Arrange      
      //Http://localhost:50579/fhirapi/Organization/_search
      string Request = PrimaryServiceRootWeb + "/Patient/_search";

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootWeb, Request);

      //Assert
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

      //Act
      try
      {
        var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootWeb, Request);
      }
      catch(FormatException Exec)
      {
        Assert.AreEqual(Exec.Message, "The URI has extra unknown content near the end of : 'RUBBISH'. The full URI was: 'http://pyrohealth.net/test/stu3/fhir/Patient/10/RUBBISH'");
      }      
    }
    
    [Test]
    public void Test_urn_uuid()
    {
      //Arrange            
      string Request = "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a";

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootWeb, Request);

      //Assert
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

      //Act
      var Result = Common.CommonFactory.GetFhirRequestUri(PrimaryServiceRootWeb, Request);

      //Assert
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

      //Act
      IFhirRequestUri Result;
      string ErrorMessage;
      if (FhirRequestUri.TryParse(PrimaryServiceRootWeb, Request, out Result, out ErrorMessage))
      {
        Assert.AreEqual(Result.Urn, "urn:oid:1.2.36.1.2001.1001.101");
        Assert.AreEqual(Result.IsUrn, true);
        Assert.AreEqual(Result.UrnType, UrnType.oid);
      }
    }

    [Test]
    public void Test_urn_oid_TryParse_False()
    {
      //Arrange            
      string Request = "urn:oid:1.2.06.0.2001.1001.101";

      //Act
      IFhirRequestUri Result;
      string ErrorMessage;
      if (!FhirRequestUri.TryParse(PrimaryServiceRootWeb, Request, out Result, out ErrorMessage))
      {
        Assert.AreEqual(ErrorMessage, "The urn:oid value given is not valid: urn:oid:1.2.06.0.2001.1001.101");
      }             
    }

    [Test]
    public void Test_urn_uuid_TryParse_True()
    {
      //Arrange            
      string Request = "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a";

      //Act
      IFhirRequestUri Result;
      string ErrorMessage;
      if (FhirRequestUri.TryParse(PrimaryServiceRootWeb, Request, out Result, out ErrorMessage))
      {
        Assert.AreEqual(Result.Urn, "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a");
        Assert.AreEqual(Result.IsUrn, true);
        Assert.AreEqual(Result.UrnType, UrnType.uuid);
      }
    }

    [Test]
    public void Test_urn_uuid_TryParse_False()
    {
      //Arrange            
      string Request = "urn:uuid:61ebe359-XXXXX-bfdc-4613-8bf2-c5e300945f0a";

      //Act
      IFhirRequestUri Result;
      string ErrorMessage;
      if (!FhirRequestUri.TryParse(PrimaryServiceRootWeb, Request, out Result, out ErrorMessage))
      {
        Assert.AreEqual(ErrorMessage, "The urn:uuid value given is not valid: urn:uuid:61ebe359-XXXXX-bfdc-4613-8bf2-c5e300945f0a");
      }
    }


  }
}
