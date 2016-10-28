using System;
using NUnit.Framework;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Blaze.Test.IndexSetters
{
  [TestFixture]
  class Test_String_IndexSetter
  {
    [Test]
    public void Test_Address_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string Line1 = "unit 1 LineOne";
      string Line2 = "15 Some St LineTwo";
      string City = "Ball Hills";
      string PostCode = "4036";
      string State = "QLD";
      string Country = "Australia";

      var Address = new Address();
      Address.Line = new string[] { Line1, Line2 };
      Address.City = City;
      Address.PostalCode = PostCode;
      Address.State = State;
      Address.Country = Country;

      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(Address, Index) as StringIndex;

      //Assert
      var ResultString = string.Format("{0} {1} {2} {3} {4} {5}", Line1, Line2, City, PostCode, State, Country);
      Assert.AreEqual(Index.String, Blaze.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(ResultString));
    }

    [Test]
    public void Test_Address_StringIndexSetter_NoAddress()
    {
      //Arrange
      var Address = new Address();
      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(Address, Index) as StringIndex;

      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Address_StringIndexSetter_Address_IsNull()
    {
      //Arrange      
      var Address = new Address();
      StringIndex Index = null;

      //Act      
      ActualValueDelegate<StringIndex> testDelegate = () => IndexSetterFactory.Create(typeof(StringIndex)).Set(Address, Index) as StringIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_Annotation_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string Text = "This is the Annotation Text";
      
      var Annotation = new Annotation();
      Annotation.Text = Text; 
      
      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(Annotation, Index) as StringIndex;

      //Assert      
      Assert.AreEqual(Index.String, Blaze.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Text));
    }

    [Test]
    public void Test_Annotation_StringIndexSetter_NoAddress()
    {
      //Arrange
      var Annotation = new Annotation();
      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(Annotation, Index) as StringIndex;

      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Annotation_StringIndexSetter_Address_IsNull()
    {
      //Arrange      
      var Annotation = new Annotation();
      StringIndex Index = null;

      //Act      
      ActualValueDelegate<StringIndex> testDelegate = () => IndexSetterFactory.Create(typeof(StringIndex)).Set(Annotation, Index) as StringIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_FhirString_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string Text = "This is the Fhir string Text";

      var FhirString = new FhirString();
      FhirString.Value = Text;

      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(FhirString, Index) as StringIndex;

      //Assert      
      Assert.AreEqual(Index.String, Blaze.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Text));
    }

    [Test]
    public void Test_FhirString_StringIndexSetter_NoAddress()
    {
      //Arrange
      var FhirString = new FhirString();
      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(FhirString, Index) as StringIndex;

      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_FhirString_StringIndexSetter_Address_IsNull()
    {
      //Arrange      
      var FhirString = new FhirString();
      StringIndex Index = null;

      //Act      
      ActualValueDelegate<StringIndex> testDelegate = () => IndexSetterFactory.Create(typeof(StringIndex)).Set(FhirString, Index) as StringIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_HumanName_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string Given1 = "Bob";
      string Given2 = "John";
      string Family1 = "Smith";
      string Family2 = "Johnston";
      
      var HumanName = new HumanName();
      HumanName.Given = new string[] { Given1, Given2 };
      HumanName.Family = new string[] { Family1, Family2 };

      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(HumanName, Index) as StringIndex;

      //Assert 
      string HumanNameString = string.Format("{0} {1} {2} {3}", Given1, Given2, Family1, Family2);     
      Assert.AreEqual(Index.String, Blaze.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(HumanNameString));
    }

    [Test]
    public void Test_HumanName_StringIndexSetter_NoAddress()
    {
      //Arrange
      var HumanName = new HumanName();
      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(HumanName, Index) as StringIndex;

      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_HumanName_StringIndexSetter_Address_IsNull()
    {
      //Arrange      
      var HumanName = new HumanName();
      StringIndex Index = null;

      //Act      
      ActualValueDelegate<StringIndex> testDelegate = () => IndexSetterFactory.Create(typeof(StringIndex)).Set(HumanName, Index) as StringIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_Markdown_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string Text = "This is the Markdown string Text";

      var Markdown = new Markdown();
      Markdown.Value = Text;

      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(Markdown, Index) as StringIndex;

      //Assert      
      Assert.AreEqual(Index.String, Blaze.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Text));
    }

    [Test]
    public void Test_Markdown_StringIndexSetter_NoAddress()
    {
      //Arrange
      var Markdown = new Markdown();
      StringIndex Index = new StringIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(Markdown, Index) as StringIndex;

      //Assert
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Markdown_StringIndexSetter_Address_IsNull()
    {
      //Arrange      
      var Markdown = new Markdown();
      StringIndex Index = null;

      //Act      
      ActualValueDelegate<StringIndex> testDelegate = () => IndexSetterFactory.Create(typeof(StringIndex)).Set(Markdown, Index) as StringIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }
    

  }
}
