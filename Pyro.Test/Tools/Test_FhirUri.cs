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
  [Category("Tools")]
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
    public void Test_Relative_ReferanceToResourcey()
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

  }
}
