using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.Tools
{
  [TestFixture]
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
      int Expected = 10;
      //Act
      int Result = PagingSupport.GetNextPageNumber(PageCurrentlyRequired, PagesTotal);

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
      int Result = PagingSupport.GetNextPageNumber(PageCurrentlyRequired, PagesTotal);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_GetNextPageNumber_TestOuter()
    {
      //Arrange      
      int PageCurrentlyRequired = 15;
      int PagesTotal = 10;
      int Expected = 10;
      //Act
      int Result = PagingSupport.GetNextPageNumber(PageCurrentlyRequired, PagesTotal);

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
      Uri Result = PagingSupport.GetPageNavigationUri(RequestUri, NewPageNumber);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_GetPreviousPageNumber_MidNumber()
    {
      //Arrange      
      int PageCurrentlyRequired = 10;      
      int Expected = 9;
      //Act
      int Result = PagingSupport.GetPreviousPageNumber(PageCurrentlyRequired);

      //Assert
      Assert.AreEqual(Expected, Result);
    }

    [Test]
    public void Test_GetPreviousPageNumber_LowerEdge()
    {
      //Arrange      
      int PageCurrentlyRequired = 1;
      int Expected = 1;
      //Act
      int Result = PagingSupport.GetPreviousPageNumber(PageCurrentlyRequired);

      //Assert
      Assert.AreEqual(Expected, Result);
    }


  }
}
