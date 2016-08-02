using System;
using NUnit.Framework;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Blaze.Test.IndexSetters
{
  [TestFixture]
  class Test_Token_IndexSetter
  {
    [Test]
    public void Test_Address_StringIndexSetter_GoodFormat()
    {
      //Arrange
      Bundle.BundleType TheCode = Bundle.BundleType.Document;
      string CodeString = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Bundle.BundleType)).GetLiteral(TheCode);

      var Code = new Code<Bundle.BundleType>();
      Code.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, CodeString);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_Address_StringIndexSetter_CodeT_IsNull()
    {
      //Arrange
      Bundle.BundleType TheCode = Bundle.BundleType.Document;
      string CodeString = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Bundle.BundleType)).GetLiteral(TheCode);

      Code<Bundle.BundleType> Code = null;

      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_Address_StringIndexSetter_No_Code_Set()
    {
      //Arrange
      var Code = new Code<Bundle.BundleType>();

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert            
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Address_StringIndexSetter_UnsupportedCodeType()
    {
      //Arrange
      var TheCode = Hl7.Fhir.Model.Bundle.SearchEntryMode.Include;
      string CodeString = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Bundle.SearchEntryMode)).GetLiteral(TheCode);

      var Code = new Code<Bundle.SearchEntryMode>();
      Code.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<Blaze.Common.BusinessEntities.Dto.DtoBlazeException>());
    }


    [Test]
    public void Test_Code_StringIndexSetter_GoodFormat()
    {
      //Arrange      
      string CodeString = "SomeCode";

      var Code = new Code();
      Code.Value = CodeString;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, CodeString);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_Code_StringIndexSetter_No_Code_Set()
    {
      //Arrange      
      string CodeString = "";

      var Code = new Code();
      Code.Value = CodeString;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert            
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Code_StringIndexSetter_Code_IsNull()
    {
      //Arrange      
      Code Code = null;
      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_CodableConcept_StringIndexSetter_UnsupportedCodeType()
    {
      //Arrange
      var CodeableConcept = new CodeableConcept();
      CodeableConcept.Coding = new System.Collections.Generic.List<Coding>() { new Coding() { Code = "SomeCode", System = "SomeSystem" } };

      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(CodeableConcept, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<Blaze.Common.BusinessEntities.Dto.DtoBlazeException>());
    }


    [Test]
    public void Test_Coding_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string TheCode = "SomeCode";
      string TheSystem = "SomeCodeSystem";

      var Coding = new Coding();
      Coding.Code = TheCode;
      Coding.System = TheSystem;
      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Coding, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCode);
      Assert.AreEqual(Index.System, TheSystem);
    }

    [Test]
    public void Test_Coding_StringIndexSetter_OnlyCode()
    {
      //Arrange
      string TheCode = "SomeCode";

      var Coding = new Coding();
      Coding.Code = TheCode;
      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Coding, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCode);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_Coding_StringIndexSetter_OnlySystem()
    {
      //Arrange
      string TheSystem = "SomeCodeSystem";
      var Coding = new Coding();
      Coding.System = TheSystem;
      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Coding, Index) as TokenIndex;

      //Assert      
      Assert.IsNull(Index.Code);
      Assert.AreEqual(Index.System, TheSystem);

    }

    [Test]
    public void Test_Coding_StringIndexSetter_Coding_IsNull()
    {
      //Arrange
      Coding Coding = null;

      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(Coding, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_Coding_StringIndexSetter_No_Code_Set()
    {
      //Arrange
      var Code = new Coding();

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert            
      Assert.IsNull(Index);
    }


    [Test]
    public void Test_ContactPoint_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string TheValue = "angusmillar@iinet.net.au";
      ContactPoint.ContactPointSystem TheSystem = Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Email;
      string TheSystemString = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ContactPoint.ContactPointSystem)).GetLiteral(TheSystem);

      var ContactPoint = new ContactPoint();
      ContactPoint.Value = TheValue;
      ContactPoint.System = TheSystem;
      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ContactPoint, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheValue);
      Assert.AreEqual(Index.System, TheSystemString);
    }

    [Test]
    public void Test_ContactPoint_StringIndexSetter_OnlyCode()
    {
      //Arrange
      string TheValue = "angusmillar@iinet.net.au";

      var ContactPoint = new ContactPoint();
      ContactPoint.Value = TheValue;
      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ContactPoint, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheValue);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_ContactPoint_StringIndexSetter_OnlySystem()
    {
      //Arrange      
      ContactPoint.ContactPointSystem TheSystem = Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Email;
      string TheSystemString = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ContactPoint.ContactPointSystem)).GetLiteral(TheSystem);

      var ContactPoint = new ContactPoint();
      ContactPoint.System = TheSystem;
      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ContactPoint, Index) as TokenIndex;

      //Assert      
      Assert.IsNull(Index.Code);
      Assert.AreEqual(Index.System, TheSystemString);
    }

    [Test]
    public void Test_ContactPoint_StringIndexSetter_ContactPoint_IsNull()
    {
      //Arrange
      ContactPoint ContactPoint = null;

      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(ContactPoint, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_ContactPoint_StringIndexSetter_No_Code_Set()
    {
      //Arrange
      var Code = new ContactPoint();

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert            
      Assert.IsNull(Index);
    }


    [Test]
    public void Test_FhirBoolean_StringIndexSetter_GoodFormatTrue()
    {
      //Arrange
      bool TheCode = true;

      var Code = new FhirBoolean();
      Code.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, "true");
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_FhirBoolean_StringIndexSetter_GoodFormatFalse()
    {
      //Arrange
      bool TheCode = false;

      var Code = new FhirBoolean();
      Code.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Code, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, "false");
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_FhirBoolean_StringIndexSetter_FhirBoolean_IsNull()
    {
      //Arrange     
      FhirBoolean FhirBoolean = null;

      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(FhirBoolean, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_FhirBoolean_StringIndexSetter_No_Code_Set_As_Null()
    {
      //Arrange
      var FhirBoolean = new FhirBoolean();
      FhirBoolean.Value = null;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(FhirBoolean, Index) as TokenIndex;

      //Assert            
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_FhirDate_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string TheCode = "2012-12-28T09:03:04+11:00";

      var FhirDateTime = new FhirDateTime();
      FhirDateTime.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(FhirDateTime, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCode);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_FhirDate_StringIndexSetter_BadFormat()
    {
      //Arrange
      string TheCode = "2012-12-28T09:03:04+11:90";

      var FhirDateTime = new FhirDateTime();
      FhirDateTime.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(FhirDateTime, Index) as TokenIndex;

      //Assert      
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_FhirDateTime_StringIndexSetter_FhirDateTime_IsNull()
    {
      //Arrange           
      FhirDateTime FhirDateTime = null;
      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(FhirDateTime, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Test_FhirString_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string TheCode = "Some string stuff";

      var FhirDateTime = new FhirString();
      FhirDateTime.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(FhirDateTime, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCode);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_FhirString_StringIndexSetter_EmptyString()
    {
      //Arrange
      string TheCode = string.Empty;

      var FhirDateTime = new FhirString();
      FhirDateTime.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(FhirDateTime, Index) as TokenIndex;

      //Assert            
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_FhirString_StringIndexSetter_FhirString_IsNull()
    {
      //Arrange           
      FhirString FhirString = null;
      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(FhirString, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_Id_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string TheCode = "4d09741b-e407-4a1f-808a-4b9bf864d956";

      var Id = new Id();
      Id.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Id, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCode);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_Id_StringIndexSetter_EmptyString()
    {
      //Arrange
      string TheCode = string.Empty;

      var Id = new Id();
      Id.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Id, Index) as TokenIndex;

      //Assert            
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Id_StringIndexSetter_FhirString_IsNull()
    {
      //Arrange           
      Id Id = null;
      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(Id, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_Identifier_StringIndexSetter_GoodFormat()
    {
      //Arrange
      string TheCode = "1234567890123456";
      string TheSystem = "http://ns.electronichealth.net.au/id/hi/ihi/1.0";

      var Identifier = new Identifier();
      Identifier.Value = TheCode;
      Identifier.System = TheSystem;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Identifier, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCode);
      Assert.AreEqual(Index.System, TheSystem);
    }

    [Test]
    public void Test_Identifier_StringIndexSetter_System_IsNull()
    {
      //Arrange
      string TheCode = "1234567890";

      var Identifier = new Identifier();
      Identifier.Value = TheCode;
      Identifier.System = null;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Identifier, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCode);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_Identifier_StringIndexSetter_Value_IsNull()
    {
      //Arrange      
      string TheSystem = "http://ns.electronichealth.net.au/id/hi/ihi/1.0";

      var Identifier = new Identifier();
      Identifier.Value = null;
      Identifier.System = TheSystem;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Identifier, Index) as TokenIndex;

      //Assert      
      Assert.IsNull(Index.Code);
      Assert.AreEqual(Index.System, TheSystem);
    }

    [Test]
    public void Test_Identifier_StringIndexSetter_Identifier_IsNull()
    {
      //Arrange           
      Identifier Identifier = null;
      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(Identifier, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_PositiveInt_StringIndexSetter_GoodFormat()
    {
      //Arrange
      int TheCode = 12345;
      string TheCodeString = "12345";

      var PositiveInt = new PositiveInt();
      PositiveInt.Value = TheCode;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(PositiveInt, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCodeString);
      Assert.IsNull(Index.System);
    }

    [Test]
    public void Test_PositiveInt_StringIndexSetter_Value_IsNull()
    {
      //Arrange            
      var PositiveInt = new PositiveInt();
      PositiveInt.Value = null;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(PositiveInt, Index) as TokenIndex;

      //Assert      
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_PositiveInt_StringIndexSetter_Identifier_IsNull()
    {
      //Arrange           
      PositiveInt PositiveInt = null;
      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(PositiveInt, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


    [Test]
    public void Test_Quantity_StringIndexSetter_GoodFormat()
    {
      //Arrange
      decimal TheCode = 001123.5500M;
      string TheCodeString = "1123.5500";
      string TheSystem = "mg/L";

      var Quantity = new Quantity();
      Quantity.Value = TheCode;
      Quantity.Unit = TheSystem;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Quantity, Index) as TokenIndex;

      //Assert      
      Assert.AreEqual(Index.Code, TheCodeString);
      Assert.AreEqual(Index.System, TheSystem);
    }

    [Test]
    public void Test_Quantity_StringIndexSetter_Value_IsNull()
    {
      //Arrange            
      var Quantity = new Quantity();
      Quantity.Value = null;

      TokenIndex Index = new TokenIndex();

      //Act
      Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(Quantity, Index) as TokenIndex;

      //Assert      
      Assert.IsNull(Index);
    }

    [Test]
    public void Test_Quantity_StringIndexSetter_Quantity_IsNull()
    {
      //Arrange           
      Quantity Quantity = null;
      TokenIndex Index = new TokenIndex();

      //Act      
      ActualValueDelegate<TokenIndex> testDelegate = () => IndexSetterFactory.Create(typeof(TokenIndex)).Set(Quantity, Index) as TokenIndex;

      //Assert
      Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
    }


  }
}
