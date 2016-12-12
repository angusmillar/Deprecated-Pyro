using System;
using NUnit.Framework;
using Pyro.DataModel.IndexSetter;
using Pyro.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  [Category("IndexSetters")]
  class Test_Uri_IndexSetter
  {
    [Test]
    public void Test_FhirUri_UriIndexSetter_GoodFormat()
    {
      //Arrange
      Uri TheUri = new Uri("http://acme.org/fhir/ValueSet/123");

      var FhirUri = new FhirUri();
      FhirUri.Value = TheUri.OriginalString;

      UriIndex Index = new UriIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(FhirUri, Index) as UriIndex;

      //Assert      
      Assert.AreEqual(Index.Uri, TheUri.OriginalString);
    }

    [Test]
    public void Test_FhirUri_UriIndexSetter_FhirUri_Value_IsNull()
    {
      //Arrange
      var FhirUri = new FhirUri();
      FhirUri.Value = null;
      UriIndex Index = new UriIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(FhirUri, Index) as UriIndex;

      //Assert            
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_FhirUri_StringIndexSetter_FhirUri_IsNull()
    {
      //Arrange
      FhirUri FhirUri = null;

      UriIndex Index = new UriIndex();

      //Act      
      ActualValueDelegate<UriIndex> testDelegate = () => IndexSetterFactory.Create(typeof(UriIndex)).Set(FhirUri, Index) as UriIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_Oid_UriIndexSetter_GoodFormat()
    {
      //Arrange
      string OidString = "urn:oid:1.2.3.4.5";
      Oid Oid = new Oid(OidString);
      UriIndex Index = new UriIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(Oid, Index) as UriIndex;

      //Assert      
      Assert.AreEqual(Index.Uri, OidString);
    }

    [Test]
    public void Test_Oid_UriIndexSetter_Oid_Value_IsNull()
    {
      //Arrange
      var Oid = new Oid();
      Oid.Value = null;
      UriIndex Index = new UriIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(Oid, Index) as UriIndex;

      //Assert            
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Oid_StringIndexSetter_Oid_IsNull()
    {
      //Arrange
      Oid Oid = null;

      UriIndex Index = new UriIndex();

      //Act      
      ActualValueDelegate<UriIndex> testDelegate = () => IndexSetterFactory.Create(typeof(UriIndex)).Set(Oid, Index) as UriIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


  }
}
