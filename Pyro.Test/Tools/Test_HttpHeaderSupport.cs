using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  [Category("Tools2")]
  class Test_HttpHeaderSupport
  {

    private string QuotedString(string Version)
    {
      return $"{'"'}{Version}{'"'}";
    }

    private string WeakETagString(string Version)
    {
      return $"W/{QuotedString(Version)}";
    }

    [Test]
    public void Test_AddResponseLocation_WithFhirId()
    {
      //Arrange
      string RequestUriString = "https://someserver.com/thing/fhir/Patient";
      var RequestUri = new Uri(RequestUriString);
      string FhirId = "123456";

      //Act
      Uri Location = Pyro.Common.Tools.HttpHeaderSupport.AddResponseLocation(RequestUri, FhirId);

      //Assert
      Assert.AreEqual(Location.OriginalString, $"{RequestUriString}/{FhirId}");
    }

    [Test]
    public void Test_AddResponseLocation_WithOutFhirId()
    {
      //Arrange
      string RequestUriString = "https://someserver.com/thing/fhir/Patient";
      var RequestUri = new Uri(RequestUriString);

      //Act
      Uri Location = Pyro.Common.Tools.HttpHeaderSupport.AddResponseLocation(RequestUri);

      //Assert
      Assert.AreEqual(Location.OriginalString, $"{RequestUriString}");
    }

    [Test]
    public void Test_GetETagString()
    {
      //Arrange
      string Version = "10";
      string Expected = WeakETagString(Version);
      //Act
      string Result = Pyro.Common.Tools.HttpHeaderSupport.GetETagString(Version);

      //Assert
      Assert.AreEqual(Result, Expected);
    }

    [Test]
    public void Test_GetEntityTagHeaderValueFromVersion()
    {
      //Arrange
      string Version = "10";
      string Expected = WeakETagString(Version);
      //Act
      System.Net.Http.Headers.EntityTagHeaderValue Result = Pyro.Common.Tools.HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(Version);

      //Assert
      Assert.AreEqual(Result.ToString(), Expected);
    }

    [Test]
    public void Test_GetETagEntityTagHeaderValueFromETagString()
    {
      //Arrange
      string Version = "10";
      string Expected = WeakETagString(Version);
      //Act
      System.Net.Http.Headers.EntityTagHeaderValue Result = Pyro.Common.Tools.HttpHeaderSupport.GetETagEntityTagHeaderValueFromETagString(Expected);

      //Assert
      Assert.AreEqual(Result.ToString(), Expected);
    }


    [Test]
    public void Test_GetVersionString()
    {
      //Arrange
      string Version = "10";
      System.Net.Http.Headers.EntityTagHeaderValue EntityTagHeaderValue = new System.Net.Http.Headers.EntityTagHeaderValue($"{'"'}{Version}{'"'}", true);
      string Expected = WeakETagString(Version);
      //Act
      string Result = Pyro.Common.Tools.HttpHeaderSupport.GetVersionString(EntityTagHeaderValue);

      //Assert
      Assert.AreEqual(Result, Version);
    }

    [Test]
    public void Test_IsAcceptMediaTypeSetInRequest()
    {
      //Arrange
      string RequestUriString = "https://someserver.com/thing/fhir/Patient";
      var RequestUri = new Uri(RequestUriString);

      var client = new HttpClient
      {
        BaseAddress = new Uri(RequestUriString)
      };
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
      HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, RequestUriString);

      //Act
      bool Result = Pyro.Common.Tools.HttpHeaderSupport.IsAcceptMediaTypeSetInRequest(req);

      //Assert
      Assert.AreEqual(Result, true);
    }

    [Test]
    public void Test_GetFhirMediaTypeString_ForXML()
    {
      //Arrange
      string Expected = "application/fhir+xml";
      //Remeber that the '+' you seen in mediaype strings is an escape for the space, i.e application/fhir+xml = application/fhir xml
      List<string> MediaTypeList = new List<string>()
      {
        "text/xml",
        "application/fhir xml",
        "text/xml fhir",
        "application/xml",
        "application/xml fhir",
      };

      foreach (string MediaType in MediaTypeList)
      {
        //Act
        string Result = Pyro.Common.Tools.HttpHeaderSupport.GetFhirMediaTypeString(MediaType);

        //Assert
        Assert.AreEqual(Result, Expected);
      }

    }

    [Test]
    public void Test_GetFhirMediaTypeString_ForJSON()
    {
      //Arrange
      string Expected = "application/fhir+json";
      List<string> MediaTypeList = new List<string>()
      {
        "application/fhir json",
        "text/json",
        "application/json",
        "application/json fhir",
      };

      foreach (string MediaType in MediaTypeList)
      {
        //Act
        string Result = Pyro.Common.Tools.HttpHeaderSupport.GetFhirMediaTypeString(MediaType);

        //Assert
        Assert.AreEqual(Result, Expected);
      }
    }

    [Test]
    public void Test_IsModifiedOrNoneMatch_DiffModifiedDate_IsModified()
    {
      //Arrange
      bool ExpectedResult = true;
      // ifNoneMatch is the resource version numbner
      string ifNoneMatch = HttpHeaderSupport.GetETagString("5");
      // ifModifiedSince is a date time point in time to see if the resource has ben modified after this point in time
      string ifModifiedSince = "Thu, 11 Jan 2018 03:40:00 GMT";
      // resourceVersionNumber is the version number of the resource from the server's database
      string resourceVersionNumber = "5";
      // lastModified is the dateTime stamp of the resource from the server's database
      DateTimeOffset lastModified = DateTimeOffset.Parse("Thu, 11 Jan 2018 03:50:00 GMT", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);

      //Act
      bool Result = Pyro.Common.Tools.HttpHeaderSupport.IsModifiedOrNoneMatch(ifNoneMatch, ifModifiedSince, resourceVersionNumber, lastModified);

      //Assert
      Assert.AreEqual(Result, ExpectedResult);


    }

    [Test]
    public void Test_IsModifiedOrNoneMatch_DiffModifiedDate_IsNotModified()
    {
      //Arrange
      bool ExpectedResult = false;
      // ifNoneMatch is the resource version numbner
      string ifNoneMatch = HttpHeaderSupport.GetETagString("5");
      // ifModifiedSince is a date time point in time to see if the resource has ben modified after this point in time
      string ifModifiedSince = "Thu, 11 Jan 2018 03:40:00 GMT";
      // resourceVersionNumber is the version number of the resource from the server's database
      string resourceVersionNumber = "5";
      // lastModified is the dateTime stamp of the resource from the server's database
      DateTimeOffset lastModified = DateTimeOffset.Parse("Thu, 11 Jan 2018 03:30:00 GMT", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);

      //Act
      bool Result = Pyro.Common.Tools.HttpHeaderSupport.IsModifiedOrNoneMatch(ifNoneMatch, ifModifiedSince, resourceVersionNumber, lastModified);

      //Assert
      Assert.AreEqual(Result, ExpectedResult);


    }

    [Test]
    public void Test_IsModifiedOrNoneMatch_DiffVersion_IsModified()
    {
      //Arrange
      bool ExpectedResult = true;
      // ifNoneMatch is the resource version numbner
      string ifNoneMatch = HttpHeaderSupport.GetETagString("5");
      // ifModifiedSince is a date time point in time to see if the resource has ben modified after this point in time
      string ifModifiedSince = "Thu, 11 Jan 2018 03:40:00 GMT";
      // resourceVersionNumber is the version number of the resource from the server's database
      string resourceVersionNumber = "6";
      // lastModified is the dateTime stamp of the resource from the server's database
      DateTimeOffset lastModified = DateTimeOffset.Parse("Thu, 11 Jan 2018 03:40:00 GMT", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);

      //Act
      bool Result = Pyro.Common.Tools.HttpHeaderSupport.IsModifiedOrNoneMatch(ifNoneMatch, ifModifiedSince, resourceVersionNumber, lastModified);

      //Assert
      Assert.AreEqual(Result, ExpectedResult);
    }

    [Test]
    public void Test_IsModifiedOrNoneMatch_SameVersion_IsNotModified()
    {
      //Arrange
      bool ExpectedResult = false;
      // ifNoneMatch is the resource version numbner
      string ifNoneMatch = HttpHeaderSupport.GetETagString("6");
      // ifModifiedSince is a date time point in time to see if the resource has ben modified after this point in time
      string ifModifiedSince = "Thu, 11 Jan 2018 03:40:00 GMT";
      // resourceVersionNumber is the version number of the resource from the server's database
      string resourceVersionNumber = "6";
      // lastModified is the dateTime stamp of the resource from the server's database
      DateTimeOffset lastModified = DateTimeOffset.Parse("Thu, 11 Jan 2018 03:40:00 GMT", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);

      //Act
      bool Result = Pyro.Common.Tools.HttpHeaderSupport.IsModifiedOrNoneMatch(ifNoneMatch, ifModifiedSince, resourceVersionNumber, lastModified);

      //Assert
      Assert.AreEqual(Result, ExpectedResult);
    }

    [Test]
    public void Test_IsModifiedOrNoneMatch_DiffVersion_IsModified2()
    {
      //Arrange
      bool ExpectedResult = true;
      // ifNoneMatch is the resource version numbner
      string ifNoneMatch = HttpHeaderSupport.GetETagString("6"); ;
      // ifModifiedSince is a date time point in time to see if the resource has ben modified after this point in time
      string ifModifiedSince = "Thu, 11 Jan 2018 03:40:00 GMT";
      // resourceVersionNumber is the version number of the resource from the server's database
      string resourceVersionNumber = "7";
      // lastModified is the dateTime stamp of the resource from the server's database
      DateTimeOffset lastModified = DateTimeOffset.Parse("Thu, 11 Jan 2018 03:40:00 GMT", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);

      //Act
      bool Result = Pyro.Common.Tools.HttpHeaderSupport.IsModifiedOrNoneMatch(ifNoneMatch, ifModifiedSince, resourceVersionNumber, lastModified);

      //Assert
      Assert.AreEqual(Result, ExpectedResult);
    }

    [Test]
    public void Test_ParseHttpDate_OK()
    {
      //Arrange
      string HttpDate = "Thu, 11 Jan 2018 03:40:00 GMT";
     
      // lastModified is the dateTime stamp of the resource from the server's database
      DateTimeOffset Expected = DateTimeOffset.Parse(HttpDate, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);

      //Act
      DateTimeOffset? Result = Pyro.Common.Tools.HttpHeaderSupport.ParseHttpDate(HttpDate);

      //Assert
      Assert.AreEqual(Result, Expected);
    }

    [Test]
    public void Test_ParseHttpDate_NotOK()
    {
      //Arrange
      string HttpDate = "Thux, 11 Jan 2018 03:40:00 GMT";
      
      //Act
      DateTimeOffset? Result = Pyro.Common.Tools.HttpHeaderSupport.ParseHttpDate(HttpDate);

      //Assert
      Assert.IsNull(Result);
    }
  }
}
