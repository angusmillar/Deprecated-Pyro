using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using NUnit.Framework.Constraints;
using System.Collections.Generic;

namespace Pyro.Test.Tools
{
  [TestFixture]
  [Category("Tools - StringSupport")]
  class Test_StringSupport
  {
    [Test]
    public void Test_ReconstructSortSearchParameter()
    {
      //Arrange
      string Expected = "_sort=_lastUpdated,-family,given";
      var Setup = new List<Tuple<string, Hl7.Fhir.Rest.SortOrder>>();
      Setup.Add(new Tuple<string, Hl7.Fhir.Rest.SortOrder>("_lastUpdated", Hl7.Fhir.Rest.SortOrder.Ascending));
      Setup.Add(new Tuple<string, Hl7.Fhir.Rest.SortOrder>("family", Hl7.Fhir.Rest.SortOrder.Descending));
      Setup.Add(new Tuple<string, Hl7.Fhir.Rest.SortOrder>("given", Hl7.Fhir.Rest.SortOrder.Ascending));


      //Act)
      string Result = StringSupport.ReconstructSortSearchParameter(Setup);

      //Assert
      Assert.AreEqual(Expected, Result);
    }


    
  }
}
