using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Hl7.Fhir.Model;
using CodeGenerationSupport.FhirApiIntrospection;

namespace TestBlaze.CodeGenerationSupport
{
  [TestFixture]
  class Test_FhirApiSearchParameterInfoFactory
  {
    [Test]
    public void Test_GetApiSearchParameterInfo()
    {
      List<FhirApiSearchParameterInfo> oSearchParameterList = FhirApiSearchParameterInfoFactory.GetApiSearchParameterInfo();
    }

    [Test]
    public void Test_ConstructClassNameForResourceClass_ReturnsTheCorrectString()
    {
      string ResourceClassName = FhirApiSearchParameterInfoFactory.ConstructClassNameForResourceClass("MyResourceName");
      Assert.AreEqual("Res_MyResourceName", ResourceClassName);         
    }

    [Test]
    public void Test_ConstructClassNameForResourceSearchClass_ReturnsTheCorrectString()
    {
      var oFhirApiSearchParameterInfo = new FhirApiSearchParameterInfo();
      oFhirApiSearchParameterInfo.SearchName = "MyParameter-thing-[x]";
      oFhirApiSearchParameterInfo.SearchParamType = SearchParamType.Composite;
      string ResourceClassName = FhirApiSearchParameterInfoFactory.ConstructClassNameForResourceSearchClass("MyResourceName", oFhirApiSearchParameterInfo);
      Assert.AreEqual("Res_MyResourceName_Index_MyParameter_thing", ResourceClassName);
    }

    [Test]
    public void Test_ConstructCollectionListName_ReturnsTheCorrectString()
    {
      var oFhirApiSearchParameterInfo = new FhirApiSearchParameterInfo();
      oFhirApiSearchParameterInfo.SearchName = "MyParameter-thing-[x]";
      oFhirApiSearchParameterInfo.SearchParamType = SearchParamType.Composite;
      string ResourceClassName = FhirApiSearchParameterInfoFactory.ConstructCollectionListName(oFhirApiSearchParameterInfo);
      Assert.AreEqual("MyParameter_thing_List", ResourceClassName);
    }

  }
}
