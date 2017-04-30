using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.Interfaces.UriSupport;


namespace Pyro.Test.Tools
{
  [TestFixture]
  [Category("ATools")]
  class Test_FhirUri
  {
    private char UriDelimieter = '/';
    private string ApiSegmentsToPath(string[] ApiSegments)
    {
      var ReturnString = string.Empty;
      ReturnString += String.Join(UriDelimieter.ToString(), ApiSegments);
      return ReturnString;
    }

    [Test]
    public void Test_ReferanceToResource_ById()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/Organization/1
      string Schema = "http";
      string SchemaDelimiter = "://";
      string Authority = "localhost:50579";
      string[] ApiSegments = new string[] { "fhirapi" };
      string ResourseType = "Organization";
      string Id = "1";

      string ServiceRootUrlForComparison = $"{Authority}/{ApiSegmentsToPath(ApiSegments)}";
      Uri ServiceRootUrl = new Uri($"{Schema}{SchemaDelimiter}{ServiceRootUrlForComparison}");

      string Url = $"{Schema}{SchemaDelimiter}{Authority}/{ApiSegmentsToPath(ApiSegments)}/{ResourseType}/{Id}";

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(Url);


      //Assert
      Assert.AreEqual(Schema, FhirUri.Schema);
      Assert.AreEqual(SchemaDelimiter, FhirUri.SchemaDelimiter);
      Assert.AreEqual(Authority, FhirUri.Authority);
      Assert.AreEqual(ResourseType, FhirUri.ResourseType);
      Assert.AreEqual(ApiSegments, FhirUri.ApiSegments);
      Assert.AreEqual(Id, FhirUri.Id);

      Assert.AreEqual(ServiceRootUrl.ToString(), FhirUri.ServiceRootUrl.ToString());
      Assert.AreEqual(ServiceRootUrlForComparison, FhirUri.ServiceRootUrlForComparison);
    }

    [Test]
    public void Test_ReferanceToResource_ById_WithEscapedApiCharaters()
    {
      //Arrange
      // URl : Http://localhost:50579/fhir api/Organization/1
      string Schema = "http";
      string SchemaDelimiter = "://";
      string Authority = "burnflame.com.au";
      string[] ApiSegments = new string[] { "fhir%20api", "open%23server" };
      string[] ApiSegmentsExpected = new string[] { "fhir api", "open#server" };
      string ResourseType = "Organization";
      string Id = "1";

      string ServiceRootUrlForComparison = $"{Authority}/{ApiSegmentsToPath(ApiSegmentsExpected)}";
      Uri ServiceRootUrl = new Uri($"{Schema}{SchemaDelimiter}{ServiceRootUrlForComparison}");

      string Url = $"{Schema}{SchemaDelimiter}{Authority}/{ApiSegmentsToPath(ApiSegments)}/{ResourseType}/{Id}";

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(Url);


      //Assert
      Assert.AreEqual(Schema, FhirUri.Schema);
      Assert.AreEqual(SchemaDelimiter, FhirUri.SchemaDelimiter);
      Assert.AreEqual(Authority, FhirUri.Authority);
      Assert.AreEqual(ResourseType, FhirUri.ResourseType);
      Assert.AreEqual(ApiSegmentsExpected, FhirUri.ApiSegments);
      Assert.AreEqual(Id, FhirUri.Id);

      Assert.AreEqual(ServiceRootUrl.ToString(), FhirUri.ServiceRootUrl.ToString());
      Assert.AreEqual(ServiceRootUrlForComparison, FhirUri.ServiceRootUrlForComparison);
    }

    [Test]
    public void Test_ReferanceToResource_ById_And_HistoryVersion()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/Organization/1/_history/5
      string Schema = "http";
      string SchemaDelimiter = "://";
      string Authority = "localhost:50579";
      string[] ApiSegments = new string[] { "fhirapi" };
      string ResourseType = "Organization";
      string Id = "1";
      string VersionId = "5";
      //string Query = "gender=male";


      string ServiceRootUrlForComparison = $"{Authority}/{ApiSegmentsToPath(ApiSegments)}";
      Uri ServiceRootUrl = new Uri($"{Schema}{SchemaDelimiter}{ServiceRootUrlForComparison}");

      string Url = $"{Schema}{SchemaDelimiter}{Authority}/{ApiSegmentsToPath(ApiSegments)}/{ResourseType}/{Id}/_history/{VersionId}";

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(Url);


      //Assert
      Assert.AreEqual(Schema, FhirUri.Schema);
      Assert.AreEqual(SchemaDelimiter, FhirUri.SchemaDelimiter);
      Assert.AreEqual(Authority, FhirUri.Authority);
      Assert.AreEqual(ResourseType, FhirUri.ResourseType);
      Assert.AreEqual(ApiSegments, FhirUri.ApiSegments);
      Assert.AreEqual(Id, FhirUri.Id);
      Assert.AreEqual(VersionId, FhirUri.VersionId);

      Assert.AreEqual(ServiceRootUrl.ToString(), FhirUri.ServiceRootUrl.ToString());
      Assert.AreEqual(ServiceRootUrlForComparison, FhirUri.ServiceRootUrlForComparison);
    }

    [Test]
    public void Test_ReferanceToResource_With_Query()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/Organization?gender=male
      string Schema = "http";
      string SchemaDelimiter = "://";
      string Authority = "localhost:50579";
      string[] ApiSegments = new string[] { "fhirapi" };
      string ResourseType = "Organization";
      string Query = "?gender=male";


      string ServiceRootUrlForComparison = $"{Authority}/{ApiSegmentsToPath(ApiSegments)}";
      Uri ServiceRootUrl = new Uri($"{Schema}{SchemaDelimiter}{ServiceRootUrlForComparison}");

      string Url = $"{Schema}{SchemaDelimiter}{Authority}/{ApiSegmentsToPath(ApiSegments)}/{ResourseType}{Query}";

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(Url);


      //Assert
      Assert.AreEqual(Schema, FhirUri.Schema);
      Assert.AreEqual(SchemaDelimiter, FhirUri.SchemaDelimiter);
      Assert.AreEqual(Authority, FhirUri.Authority);
      Assert.AreEqual(ResourseType, FhirUri.ResourseType);
      Assert.AreEqual(ApiSegments, FhirUri.ApiSegments);
      Assert.AreEqual(Query, FhirUri.Query);

      Assert.AreEqual(ServiceRootUrl.ToString(), FhirUri.ServiceRootUrl.ToString());
      Assert.AreEqual(ServiceRootUrlForComparison, FhirUri.ServiceRootUrlForComparison);
    }

    [Test]
    public void Test_Relative_ReferanceToResource()
    {
      //Arrange
      // URl : Organization/1

      string ResourseType = "Organization";
      string FhirId = "1";

      string Url = $"{ResourseType}/{FhirId}";
      Uri test = new Uri(Url, UriKind.Relative);
      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(test);


      //Assert
      Assert.AreEqual(ResourseType, FhirUri.ResourseType);
      Assert.AreEqual(FhirId, FhirUri.Id);


    }





    [Test]
    public void Test_ReferanceToResource_With_FormData_Search()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/Organization/_search
      string Schema = "http";
      string SchemaDelimiter = "://";
      string Authority = "localhost:50579";
      string[] ApiSegments = new string[] { "fhirapi" };
      string ResourseType = "Organization";
      string _search = "_search";


      string ServiceRootUrlForComparison = $"{Authority}/{ApiSegmentsToPath(ApiSegments)}";
      Uri ServiceRootUrl = new Uri($"{Schema}{SchemaDelimiter}{ServiceRootUrlForComparison}");

      string Url = $"{Schema}{SchemaDelimiter}{Authority}/{ApiSegmentsToPath(ApiSegments)}/{ResourseType}/{_search}";

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(Url);


      //Assert
      Assert.AreEqual(Schema, FhirUri.Schema);
      Assert.AreEqual(SchemaDelimiter, FhirUri.SchemaDelimiter);
      Assert.AreEqual(Authority, FhirUri.Authority);
      Assert.AreEqual(ResourseType, FhirUri.ResourseType);
      Assert.AreEqual(ApiSegments, FhirUri.ApiSegments);
      Assert.AreEqual(true, FhirUri.IsFormDataSearch);
      Assert.AreEqual(null, FhirUri.Query);

      Assert.AreEqual(ServiceRootUrl.ToString(), FhirUri.ServiceRootUrl.ToString());
      Assert.AreEqual(ServiceRootUrlForComparison, FhirUri.ServiceRootUrlForComparison);
    }


    [Test]
    public void Test_ReferanceToResourceOperation()
    {
      //Arrange
      // URl : Http://localhost:50579/fhirapi/ValueSet/$lookup
      string Schema = "http";
      string SchemaDelimiter = "://";
      string Authority = "localhost:50579";
      string[] ApiSegments = new string[] { "fhirapi" };
      string ResourseType = "ValueSet";
      string _OperationName = "lookup";


      string ServiceRootUrlForComparison = $"{Authority}/{ApiSegmentsToPath(ApiSegments)}";
      Uri ServiceRootUrl = new Uri($"{Schema}{SchemaDelimiter}{ServiceRootUrlForComparison}");

      string Url = $"{Schema}{SchemaDelimiter}{Authority}/{ApiSegmentsToPath(ApiSegments)}/{ResourseType}/${_OperationName}";

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(Url);


      //Assert
      Assert.AreEqual(Schema, FhirUri.Schema);
      Assert.AreEqual(SchemaDelimiter, FhirUri.SchemaDelimiter);
      Assert.AreEqual(Authority, FhirUri.Authority);
      Assert.AreEqual(ResourseType, FhirUri.ResourseType);
      Assert.AreEqual(ApiSegments, FhirUri.ApiSegments);
      Assert.AreEqual(_OperationName, FhirUri.ResourceOperation);
      Assert.AreEqual(false, FhirUri.IsFormDataSearch);
      Assert.AreEqual(null, FhirUri.Query);

      Assert.AreEqual(ServiceRootUrl.ToString(), FhirUri.ServiceRootUrl.ToString());
      Assert.AreEqual(ServiceRootUrlForComparison, FhirUri.ServiceRootUrlForComparison);
    }

    
    [Test]
    public void Test_ReferanceToResourceValidUuid()
    {
      //Arrange
      // URl : "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a"
      string uuid = "urn:uuid:61ebe359-bfdc-4613-8bf2-c5e300945f0a";
      Uri ServiceRootUrl = new Uri(uuid);
      
      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(uuid);

      //Assert
      Assert.AreEqual("urn", FhirUri.Schema);
      Assert.AreEqual("", FhirUri.SchemaDelimiter);
      Assert.AreEqual("", FhirUri.Authority);
      Assert.AreEqual(null, FhirUri.ResourseType);
      Assert.AreEqual(null, FhirUri.ApiSegments);
      Assert.AreEqual(null, FhirUri.ResourceOperation);
      Assert.AreEqual(false, FhirUri.IsFormDataSearch);
      Assert.AreEqual(null, FhirUri.Query);
      Assert.AreEqual(true, FhirUri.IsUuid);
      Assert.AreEqual(true, FhirUri.IsUuidValid);
      Assert.AreEqual(false, FhirUri.IsOid);
      Assert.AreEqual(uuid, FhirUri.Id);
      Assert.AreEqual(null, FhirUri.ServiceRootUrl);
      Assert.AreEqual("", FhirUri.ServiceRootUrlForComparison);

    }

    [Test]
    public void Test_ReferanceToResourceInValidUuid()
    {
      //Arrange
      // URl : "urn:uuid:61ebe359-CAPSError-4613-8bf2-c5e300945f0a"
      string uuid = "urn:uuid:61ebe359-BFBC-4613-8bf2-c5e300945f0a";
      Uri ServiceRootUrl = new Uri(uuid);

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(uuid);

      //Assert
      Assert.AreEqual("urn", FhirUri.Schema);
      Assert.AreEqual("", FhirUri.SchemaDelimiter);
      Assert.AreEqual("", FhirUri.Authority);
      Assert.AreEqual(null, FhirUri.ResourseType);
      Assert.AreEqual(null, FhirUri.ApiSegments);
      Assert.AreEqual(null, FhirUri.ResourceOperation);
      Assert.AreEqual(false, FhirUri.IsFormDataSearch);
      Assert.AreEqual(null, FhirUri.Query);
      Assert.AreEqual(true, FhirUri.IsUuid);
      Assert.AreEqual(false, FhirUri.IsUuidValid);
      Assert.AreEqual(false, FhirUri.IsOid);
      Assert.AreEqual(uuid, FhirUri.Id);
      Assert.AreEqual(null, FhirUri.ServiceRootUrl);
      Assert.AreEqual("", FhirUri.ServiceRootUrlForComparison);

    }

    [Test]
    public void Test_ReferanceToResourceValidOid()
    {
      //Arrange
      // URl : "urn:oid:1.2.36.1.2001.1001.101"
      string uuid = "urn:oid:1.2.36.1.2001.1001.101";
      Uri ServiceRootUrl = new Uri(uuid);

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(uuid);

      //Assert
      Assert.AreEqual("urn", FhirUri.Schema);
      Assert.AreEqual("", FhirUri.SchemaDelimiter);
      Assert.AreEqual("", FhirUri.Authority);
      Assert.AreEqual(null, FhirUri.ResourseType);
      Assert.AreEqual(null, FhirUri.ApiSegments);
      Assert.AreEqual(null, FhirUri.ResourceOperation);
      Assert.AreEqual(false, FhirUri.IsFormDataSearch);
      Assert.AreEqual(null, FhirUri.Query);
      Assert.AreEqual(false, FhirUri.IsUuid);
      Assert.AreEqual(false, FhirUri.IsUuidValid);
      Assert.AreEqual(true, FhirUri.IsOid);
      Assert.AreEqual(true, FhirUri.IsOidValid);
      Assert.AreEqual(uuid, FhirUri.Id);
      Assert.AreEqual(null, FhirUri.ServiceRootUrl);
      Assert.AreEqual("", FhirUri.ServiceRootUrlForComparison);

    }

    [Test]
    public void Test_ReferanceToResourceInValidOid()
    {
      //Arrange
      // URl : "urn:oid:1.2.36.1.2001.1001.101"
      string uuid = "urn:oid:1.2.36.1.ABCD.1001.101";
      Uri ServiceRootUrl = new Uri(uuid);

      //Act
      IFhirUri FhirUri = Common.CommonFactory.GetFhirUri(uuid);

      //Assert
      Assert.AreEqual("urn", FhirUri.Schema);
      Assert.AreEqual("", FhirUri.SchemaDelimiter);
      Assert.AreEqual("", FhirUri.Authority);
      Assert.AreEqual(null, FhirUri.ResourseType);
      Assert.AreEqual(null, FhirUri.ApiSegments);
      Assert.AreEqual(null, FhirUri.ResourceOperation);
      Assert.AreEqual(false, FhirUri.IsFormDataSearch);
      Assert.AreEqual(null, FhirUri.Query);
      Assert.AreEqual(false, FhirUri.IsUuid);
      Assert.AreEqual(false, FhirUri.IsUuidValid);
      Assert.AreEqual(true, FhirUri.IsOid);
      Assert.AreEqual(false, FhirUri.IsOidValid);
      Assert.AreEqual(uuid, FhirUri.Id);
      Assert.AreEqual(null, FhirUri.ServiceRootUrl);
      Assert.AreEqual("", FhirUri.ServiceRootUrlForComparison);

    }

    [Test]
    public void Test_ReferanceToNotValidServiceRootOnly()
    {
      //Arrange
      // URl : "http://localhost:8888"
      string uuid = "http://localhost:8888";
      Uri ServiceRootUrl = new Uri(uuid);

      //Act
      IFhirUri FhirUri;
      bool IsParsed = DtoFhirUri.TryParse(uuid, out FhirUri);

      //Assert
      Assert.AreEqual(false, IsParsed);

    }

    [Test]
    public void Test_ReferanceToServiceRootOnly()
    {
      //Arrange
      // URl : "http://localhost:8888/test/stu3/fhir"
      string uuid = "http://localhost:8888/test/stu3/fhir";
      Uri ServiceRootUrl = new Uri(uuid);

      //Act
      IFhirUri FhirUri;
      bool IsParsed = DtoFhirUri.TryParse(uuid, out FhirUri);


      //Assert
      Assert.AreEqual(true, IsParsed);
      Assert.AreEqual("http", FhirUri.Schema);
      Assert.AreEqual("://", FhirUri.SchemaDelimiter);
      Assert.AreEqual("localhost:8888", FhirUri.Authority);
      Assert.AreEqual(null, FhirUri.ResourseType);
      Assert.AreEqual(3, FhirUri.ApiSegments.Length);
      Assert.AreEqual(null, FhirUri.ResourceOperation);
      Assert.AreEqual(false, FhirUri.IsFormDataSearch);
      Assert.AreEqual(null, FhirUri.Query);
      Assert.AreEqual(false, FhirUri.IsUuid);
      Assert.AreEqual(false, FhirUri.IsUuidValid);
      Assert.AreEqual(false, FhirUri.IsOid);
      Assert.AreEqual(false, FhirUri.IsOidValid);
      Assert.AreEqual(null, FhirUri.Id);
      Assert.AreEqual(uuid, FhirUri.ServiceRootUrl.OriginalString);
      Assert.AreEqual("localhost:8888/test/stu3/fhir", FhirUri.ServiceRootUrlForComparison);
    }

    [Test]
    public void Test_ReferanceToServiceRootMetadata()
    {
      //Arrange
      // URl : "http://localhost:8888/test/stu3/fhir/metadata"
      string uuid = "http://localhost:8888/test/stu3/fhir/metadata";
      Uri ServiceRootUrl = new Uri(uuid);

      //Act
      IFhirUri FhirUri;
      bool IsParsed = DtoFhirUri.TryParse(uuid, out FhirUri);


      //Assert
      Assert.AreEqual(true, IsParsed);
      Assert.AreEqual("http", FhirUri.Schema);
      Assert.AreEqual("://", FhirUri.SchemaDelimiter);
      Assert.AreEqual("localhost:8888", FhirUri.Authority);
      Assert.AreEqual(null, FhirUri.ResourseType);
      Assert.AreEqual(3, FhirUri.ApiSegments.Length);
      Assert.AreEqual(null, FhirUri.ResourceOperation);
      Assert.AreEqual(false, FhirUri.IsFormDataSearch);
      Assert.AreEqual(null, FhirUri.Query);
      Assert.AreEqual(false, FhirUri.IsUuid);
      Assert.AreEqual(false, FhirUri.IsUuidValid);
      Assert.AreEqual(false, FhirUri.IsOid);
      Assert.AreEqual(false, FhirUri.IsOidValid);
      Assert.AreEqual(null, FhirUri.Id);
      Assert.AreEqual("metadata", FhirUri.BaseOperation);
      Assert.AreEqual("localhost:8888/test/stu3/fhir", FhirUri.ServiceRootUrlForComparison);
    }



  }
}
