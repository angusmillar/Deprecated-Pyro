using NUnit.Framework;
using Hl7.Fhir.Utility;
using Pyro.Common.Search.SearchParameterEntity;
using System;
using System.Collections.Generic;

namespace Pyro.Test.Search
{
  [TestFixture]
  [Category("Search")]
  class Test_SearchParamCustom
  {
    /// <summary>
    /// This test case is to check weather the .NET FHIR API has fixed a 
    /// bug they have with the _sort parameter when using an underscore search parameter
    /// An exampe would be [base]/Patient?_sort=lastUpdated.
    /// So if this test case fails the bug is mostlikly fixed.
    /// In this case we can remove our custom implmentation of SearchParams which
    /// is found here  Pyro.Common.Search.CustomSearchParams and is tested 
    /// in the next test case as an example.
    /// </summary>
    [Test]
    public void Test_APISearchParamBug()
    {
      //Arrange
      string Sort = Common.Enum.SearchParameterSearchResultParameterType._sort.GetLiteral();
      string LastUpdated = Common.Enum.SearchParameterForAllResourcesType._lastUpdated.GetLiteral();
      Hl7.Fhir.Rest.SearchParams SearchParam = new Hl7.Fhir.Rest.SearchParams();

      //Act & Assert
      Assert.Throws<FormatException>(() => SearchParam.Add(Sort, LastUpdated));
    }

    /// <summary>
    /// This is a test of the SearchParamCustom implmentation that can be
    /// removed if the test case above does not throw an exception and fails.
    /// </summary>
    [Test]
    public void Test_APISearchParamCustom()
    {
      //Arrange
      string SortText = Common.Enum.SearchParameterSearchResultParameterType._sort.GetLiteral();
      string LastUpdatedText = Common.Enum.SearchParameterForAllResourcesType._lastUpdated.GetLiteral();

      var SearchList = new List<Tuple<string, string>>();
      SearchList.Add(new Tuple<string, string>(SortText, LastUpdatedText));

      //Act 
      var CustomSearchParams = Common.Search.CustomSearchParams.FromUriParamList(SearchList);
      var Sort = CustomSearchParams.Sort;

      //Assert
      Assert.AreSame(LastUpdatedText, Sort[0].Item1);
      Assert.AreEqual(Hl7.Fhir.Rest.SortOrder.Ascending, Sort[0].Item2);
      
    }


  }
}
