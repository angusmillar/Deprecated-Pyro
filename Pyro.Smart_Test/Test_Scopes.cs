using System;
using NUnit.Framework;
using Pyro.Smart.Scopes;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;

namespace Pyro.Smart_Test
{
  [TestFixture]
  [Category("Scopes")]
  class Test_Scopes
  {    
    [Test]
    public void TestUserEntity()
    {
      //Arrange
      string ScopeString = "user/Patient.read";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsTrue(ParseOk);
      Assert.AreEqual(SmartEnum.Entity.User, SmartScope.Entity);
      Assert.AreEqual(FHIRAllTypes.Patient, SmartScope.Resource);
      Assert.AreEqual(SmartEnum.Action.Read, SmartScope.Action);
    }

    [Test]
    public void TestPatientEntity()
    {
      //Arrange
      string ScopeString = "patient/Patient.read";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsTrue(ParseOk);
      Assert.AreEqual(SmartEnum.Entity.Patient, SmartScope.Entity);
      Assert.AreEqual(FHIRAllTypes.Patient, SmartScope.Resource);
      Assert.AreEqual(SmartEnum.Action.Read, SmartScope.Action);
    }

    [Test]
    public void TestNotPatientOrUserEntity()
    {
      //Arrange
      string ScopeString = "patX/Patient.read";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsFalse(ParseOk);
    }

    [Test]
    public void TestObservationResource()
    {
      //Arrange
      string ScopeString = "patient/Observation.read";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsTrue(ParseOk);
      Assert.AreEqual(SmartEnum.Entity.Patient, SmartScope.Entity);
      Assert.AreEqual(FHIRAllTypes.Observation, SmartScope.Resource);
      Assert.AreEqual(SmartEnum.Action.Read, SmartScope.Action);
    }

    [Test]
    public void TestResourceAll()
    {
      //Arrange
      string ScopeString = "patient/*.read";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsTrue(ParseOk);
      Assert.AreEqual(SmartEnum.Entity.Patient, SmartScope.Entity);
      Assert.AreEqual(FHIRAllTypes.Resource, SmartScope.Resource);
      Assert.AreEqual(SmartEnum.Action.Read, SmartScope.Action);
    }

    [Test]
    public void TestNotAResource()
    {
      //Arrange
      string ScopeString = "patient/ObsXX.read";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsFalse(ParseOk);
    }

    [Test]
    public void TestActionRead()
    {
      //Arrange
      string ScopeString = "patient/Observation.read";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsTrue(ParseOk);
      Assert.AreEqual(SmartEnum.Entity.Patient, SmartScope.Entity);
      Assert.AreEqual(FHIRAllTypes.Observation, SmartScope.Resource);
      Assert.AreEqual(SmartEnum.Action.Read, SmartScope.Action);
    }

    [Test]
    public void TestActionWrite()
    {
      //Arrange
      string ScopeString = "patient/Observation.write";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsTrue(ParseOk);
      Assert.AreEqual(SmartEnum.Entity.Patient, SmartScope.Entity);
      Assert.AreEqual(FHIRAllTypes.Observation, SmartScope.Resource);
      Assert.AreEqual(SmartEnum.Action.Write, SmartScope.Action);
    }

    [Test]
    public void TestActionReadWrite()
    {
      //Arrange
      string ScopeString = "patient/Observation.*";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsTrue(ParseOk);
      Assert.AreEqual(SmartEnum.Entity.Patient, SmartScope.Entity);
      Assert.AreEqual(FHIRAllTypes.Observation, SmartScope.Resource);
      Assert.AreEqual(SmartEnum.Action.ReadWrite, SmartScope.Action);
    }

    [Test]
    public void TestResourceAnyActionReadWrite()
    {
      //Arrange
      string ScopeString = "patient/*.*";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsTrue(ParseOk);
      Assert.AreEqual(SmartEnum.Entity.Patient, SmartScope.Entity);
      Assert.AreEqual(FHIRAllTypes.Resource, SmartScope.Resource);
      Assert.AreEqual(SmartEnum.Action.ReadWrite, SmartScope.Action);
    }

    [Test]
    public void TestActionErrorString()
    {
      //Arrange
      string ScopeString = "patient/Observation.xx";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsFalse(ParseOk);
    }

    [Test]
    public void TestActionErrorMissing()
    {
      //Arrange
      string ScopeString = "patient/Observation";
      IScopeParse ScopeParse = new ScopeParse();

      //Act
      var ParseOk = ScopeParse.Parse(ScopeString, out ISmartScope SmartScope);

      //Assert
      Assert.IsFalse(ParseOk);
    }
  }
}
