using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.Tools
{
  [TestFixture]
  [Category("Tools")]
  class Test_PagingSupport
  {
    [Test]
    public void Test_FirstPage()
    {
      //Arrange
      int Expected = 1;

      //Act
      int Result = PagingSupport.GetFirstPageNumber();

      //Assert
      Assert.AreEqual(Expected, Result);
    }


    [Test]
    public void Test_GetLastPageNumber()
    {
      //Arrange
      int Expected = 101;
      int TotalPages = 101;

      //Act
      int Result = PagingSupport.GetLastPageNumber(TotalPages);

      //Assert
      Assert.AreEqual(Expected, Result);
    }


    [Test]
    public void Test_CalculatePageRequired_OuterEdge()
    {
      //Arrange
      int RequiredPageNumber = 15;
      int TotalRecordCount = 101;
      int NumberOfRecordsPerPage = 10;
      int Expected = 11;
      //Act
      int Result = PagingSupport.CalculatePageRequired(RequiredPageNumber, NumberOfRecordsPerPage, TotalRecordCount);

      //Assert
      Assert.AreEqual(Expected, Result);
    }


    [Test]
    public void Test_CalculatePageRequired_Mid()
    {
      //Arrange
      int RequiredPageNumber = 5;
      int TotalRecordCount = 101;
      int NumberOfRecordsPerPage = 10;
      int Expected = 5;
      //Act
      int Result = PagingSupport.CalculatePageRequired(RequiredPageNumber, NumberOfRecordsPerPage, TotalRecordCount);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_CalculateTotalPages()
    {
      //Arrange      
      int TotalRecordCount = 101;
      int NumberOfRecordsPerPage = 10;
      int Expected = 11;
      //Act
      int Result = PagingSupport.CalculateTotalPages(NumberOfRecordsPerPage, TotalRecordCount);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_GetNextPageNumber_TestEdge()
    {
      //Arrange      
      int PageCurrentlyRequired = 10;
      int PagesTotal = 10;
      int? Expected = null;
      //Act
      int? Result = PagingSupport.GetNextPageNumber(PageCurrentlyRequired, PagesTotal);

      //Assert
      Assert.AreEqual(Expected, Result);
    }


    [Test]
    public void Test_GetNextPageNumber_TestMid()
    {
      //Arrange      
      int PageCurrentlyRequired = 5;
      int PagesTotal = 10;
      int Expected = 6;
      //Act
      int? Result = PagingSupport.GetNextPageNumber(PageCurrentlyRequired, PagesTotal);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_GetNextPageNumber_TestOuter()
    {
      //Arrange      
      int PageCurrentlyRequired = 15;
      int PagesTotal = 10;
      int? Expected = null;
      //Act
      int? Result = PagingSupport.GetNextPageNumber(PageCurrentlyRequired, PagesTotal);

      //Assert
      Assert.AreEqual(Expected, Result);
    }


    [Test]
    public void Test_GetPageNavigationUri()
    {
      //Arrange      
      Uri RequestUri = new Uri("http://localhost:50579/fhirapi/Patient/Angus7/_history?page=9&_count=2");
      int NewPageNumber = 2;
      Uri Expected = new Uri("http://localhost:50579/fhirapi/Patient/Angus7/_history?page=2&_count=2");

      //Act
      Uri Result = PagingSupport.GetPageNavigationUri(RequestUri.OriginalString, NewPageNumber);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_GetPreviousPageNumber_MidNumber()
    {
      //Arrange      
      int PageCurrentlyRequired = 10;
      int Expected = 9;
      int TotalPages = 15;
      //Act
      int? Result = PagingSupport.GetPreviousPageNumber(PageCurrentlyRequired, TotalPages);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_GetPreviousPageNumber_LowerEdge()
    {
      //Arrange      
      int PageCurrentlyRequired = 1;
      int? Expected = null;
      int TotalPages = 15;
      //Act
      int? Result = PagingSupport.GetPreviousPageNumber(PageCurrentlyRequired, TotalPages);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_SetBundlePagnation_LowerEdge()
    {
      //Arrange      
      int TotalPages = 1;
      int PageCurrentlyRequired = 1;
      Bundle Bundle = new Bundle();
      string RequestUriString = "http://someserver.net/fhir/Patient";

      //Act
      PagingSupport.SetBundlePagnation(Bundle, RequestUriString, TotalPages, PageCurrentlyRequired);

      //Assert
      Assert.AreEqual(Bundle.FirstLink, "http://someserver.net/fhir/Patient?page=1");
      Assert.AreEqual(Bundle.PreviousLink, null);
      Assert.AreEqual(Bundle.NextLink, null);
      Assert.AreEqual(Bundle.LastLink, "http://someserver.net/fhir/Patient?page=1");
    }

    [Test]
    public void Test_SetBundlePagnation_LowerOuter()
    {
      //Arrange      
      int TotalPages = 10;
      int PageCurrentlyRequired = 0;
      Bundle Bundle = new Bundle();
      string RequestUriString = "http://someserver.net/fhir/Patient";

      //Act
      PagingSupport.SetBundlePagnation(Bundle, RequestUriString, TotalPages, PageCurrentlyRequired);

      //Assert
      Assert.AreEqual(Bundle.FirstLink, "http://someserver.net/fhir/Patient?page=1");
      Assert.AreEqual(Bundle.PreviousLink, null);
      Assert.AreEqual(Bundle.NextLink, "http://someserver.net/fhir/Patient?page=2");
      Assert.AreEqual(Bundle.LastLink, "http://someserver.net/fhir/Patient?page=10");
    }


    [Test]
    public void Test_SetBundlePagnation_Mid()
    {
      //Arrange      
      int TotalPages = 10;
      int PageCurrentlyRequired = 5;
      Bundle Bundle = new Bundle();
      string RequestUriString = "http://someserver.net/fhir/Patient";

      //Act
      PagingSupport.SetBundlePagnation(Bundle, RequestUriString, TotalPages, PageCurrentlyRequired);

      //Assert
      Assert.AreEqual(Bundle.FirstLink, "http://someserver.net/fhir/Patient?page=1");
      Assert.AreEqual(Bundle.PreviousLink, "http://someserver.net/fhir/Patient?page=4");
      Assert.AreEqual(Bundle.NextLink, "http://someserver.net/fhir/Patient?page=6");
      Assert.AreEqual(Bundle.LastLink, "http://someserver.net/fhir/Patient?page=10");
    }

    [Test]
    public void Test_SetBundlePagnation_Last()
    {
      //Arrange      
      int TotalPages = 10;
      int PageCurrentlyRequired = 10;
      Bundle Bundle = new Bundle();
      string RequestUriString = "http://someserver.net/fhir/Patient";

      //Act
      PagingSupport.SetBundlePagnation(Bundle, RequestUriString, TotalPages, PageCurrentlyRequired);

      //Assert
      Assert.AreEqual(Bundle.FirstLink, "http://someserver.net/fhir/Patient?page=1");
      Assert.AreEqual(Bundle.PreviousLink, "http://someserver.net/fhir/Patient?page=9");
      Assert.AreEqual(Bundle.NextLink, null);
      Assert.AreEqual(Bundle.LastLink, "http://someserver.net/fhir/Patient?page=10");
    }

    [Test]
    public void Test_SetBundlePagnation_LastOuter()
    {
      //Arrange      
      int TotalPages = 10;
      int PageCurrentlyRequired = 15;
      Bundle Bundle = new Bundle();
      string RequestUriString = "http://someserver.net/fhir/Patient";

      //Act
      PagingSupport.SetBundlePagnation(Bundle, RequestUriString, TotalPages, PageCurrentlyRequired);

      //Assert
      Assert.AreEqual(Bundle.FirstLink, "http://someserver.net/fhir/Patient?page=1");
      Assert.AreEqual(Bundle.PreviousLink, "http://someserver.net/fhir/Patient?page=9");
      Assert.AreEqual(Bundle.NextLink, null);
      Assert.AreEqual(Bundle.LastLink, "http://someserver.net/fhir/Patient?page=10");
    }

    [Test]
    public void Test_SetBundlePagnation_PageRequestedAtEnd()
    {
      //Arrange      
      int TotalPages = 10;
      int PageCurrentlyRequired = 15;
      Bundle Bundle = new Bundle();
      string RequestUriString = "http://someserver.net/fhir/Patient?given=testman&page=" + PageCurrentlyRequired;
      Uri SearchPerformedUri = new Uri(RequestUriString);
      //Act
      PagingSupport.SetBundlePagnation(Bundle, RequestUriString, TotalPages, PageCurrentlyRequired, SearchPerformedUri);

      //Assert
      Assert.AreEqual(Bundle.FirstLink, "http://someserver.net/fhir/Patient?given=testman&page=" + 1.ToString());
      Assert.AreEqual(Bundle.PreviousLink, "http://someserver.net/fhir/Patient?given=testman&page=" + 9.ToString());
      Assert.AreEqual(Bundle.NextLink, null);
      Assert.AreEqual(Bundle.LastLink, "http://someserver.net/fhir/Patient?given=testman&page=" + 10.ToString());
    }

    [Test]
    public void Test_SetBundlePagnation_PageRequestedInMid()
    {
      //Arrange      
      int TotalPages = 10;
      int PageCurrentlyRequired = 15;
      Bundle Bundle = new Bundle();
      string RequestUriString = "http://someserver.net/fhir/Patient?page=" + PageCurrentlyRequired + "&given=testman";
      Uri SearchPerformedUri = new Uri(RequestUriString);
      //Act
      PagingSupport.SetBundlePagnation(Bundle, RequestUriString, TotalPages, PageCurrentlyRequired, SearchPerformedUri);

      //Assert
      Assert.AreEqual(Bundle.FirstLink, "http://someserver.net/fhir/Patient?page=" + 1.ToString() + "&given=testman");
      Assert.AreEqual(Bundle.PreviousLink, "http://someserver.net/fhir/Patient?page=" + 9.ToString() + "&given=testman");
      Assert.AreEqual(Bundle.NextLink, null);
      Assert.AreEqual(Bundle.LastLink, "http://someserver.net/fhir/Patient?page=" + 10.ToString() + "&given=testman");
    }

    [Test]
    public void Test_SetBundlePagnation_SearchParameterNoPageParameter()
    {
      //Arrange      
      int TotalPages = 10;
      int PageCurrentlyRequired = 15;
      Bundle Bundle = new Bundle();
      string RequestUriString = "http://someserver.net/fhir/Patient?given=testman";
      Uri SearchPerformedUri = new Uri(RequestUriString);
      //Act
      PagingSupport.SetBundlePagnation(Bundle, RequestUriString, TotalPages, PageCurrentlyRequired, SearchPerformedUri);

      //Assert
      Assert.AreEqual(Bundle.FirstLink, "http://someserver.net/fhir/Patient?given=testman&page=" + 1.ToString());
      Assert.AreEqual(Bundle.PreviousLink, "http://someserver.net/fhir/Patient?given=testman&page=" + 9.ToString());
      Assert.AreEqual(Bundle.NextLink, null);
      Assert.AreEqual(Bundle.LastLink, "http://someserver.net/fhir/Patient?given=testman&page=" + 10.ToString());
    }




  }
}
