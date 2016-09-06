using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using NUnit.Framework;
using Blaze.Common.Tools;
using NUnit.Framework.Constraints;

namespace Blaze.Test.Support
{
  [TestFixture]
  class Test_FhirDateTimeSupport
  {
    [Test]
    public void Test_Date_DateIndexSetter_GoodFormat()
    {
      //Arrange
      //string Date = "1974-12-25";
      string Date = "1974";

      //Act
      var Result = Blaze.Common.Tools.FhirDateTimeSupport.GetPression(Date);

      //Assert
      Assert.AreEqual(FhirDateTimeSupport.Pression.HourMin, Result);
    }
  }
}
