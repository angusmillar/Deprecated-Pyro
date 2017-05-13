  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Rest;


namespace Pyro.Test.IntergrationTest
{
  [TestFixture]
  [Category("IntergrationTest: Operation")]
  class Test_OperationDeleteHistoryIndexes
  {
    private System.IDisposable Server;
    private const string OperationName = "delete-history-indexes";
    [SetUp]
    public void Setup()
    {

      Server = StaticTestData.StartupServer();
    }

    [TearDown]
    public void TearDown()
    {
      Server.Dispose();
    }

    [Test]
    public void Test_DeleteHistoryIndexes()
    {

      FhirClient clientFhir = new FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      string PatientOneResourceId = Guid.NewGuid().ToString();
      string PatientOneMRNIdentifer = Guid.NewGuid().ToString();

      //Add a Patient resource by Create
      Patient PatientOne = new Patient();
      PatientOne.Id = PatientOneResourceId;
      PatientOne.Name.Add(HumanName.ForFamily("TestPatient").WithGiven("Test"));
      PatientOne.BirthDateElement = new Date("1979-09-30");
      PatientOne.Identifier.Add(new Identifier(StaticTestData.TestIdentiferSystem, PatientOneMRNIdentifer));
      PatientOne.Gender = AdministrativeGender.Unknown;

      Patient PatientResult = null;
      try
      {
        PatientResult = clientFhir.Update<Patient>(PatientOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on Patient resource Update: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource create by Updated returned resource of null");
      
      PatientResult = null;

      //Update the patient again to ensure there are History indexes to delete
      try
      {
        PatientResult = clientFhir.Update<Patient>(PatientOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on Patient resource Update: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource create by Updated returned resource of null");

      //------------------------------------------------------------------------------------
      // ------------ Base Operation, limited types by parameters --------------------------
      //------------------------------------------------------------------------------------

      //Now setup to use the base operation $delete-history-indexes      
      //Parameter Resource
      Parameters ParametersIn = new Parameters();
      ParametersIn.Id = Guid.NewGuid().ToString();
      ParametersIn.Parameter = new List<Parameters.ParameterComponent>();
      var ParamOne = new Parameters.ParameterComponent();
      ParametersIn.Parameter.Add(ParamOne);
      ParamOne.Name = "ResourceType";
      ParamOne.Value = new FhirString(FHIRAllTypes.Patient.GetLiteral());      

      Parameters ParametersResult = null;
      try
      {
        var ResourceResult = clientFhir.WholeSystemOperation(OperationName, ParametersIn);
        ParametersResult = ResourceResult as Parameters;
      }
      catch (Exception Exec)
      {
        Assert.True(false, $"Exception thrown on Operation call to ${OperationName}: " + Exec.Message);
      }
      Assert.NotNull(ParametersResult, "Resource create by Updated returned resource of null");
      Assert.NotNull(ParametersResult.Parameter, "ParametersResult.Parameter is null");
      Assert.AreEqual(ParametersResult.Parameter.Count(), 1, "ParametersResult.Parameter contains more than one parameter.");
      Assert.AreEqual(ParametersResult.Parameter[0].Name, $"{FHIRAllTypes.Patient.GetLiteral()}_TotalIndexesDeletedCount", "ParametersResult.Parameter.Name not as expected.");
      Assert.IsInstanceOf<FhirDecimal>(ParametersResult.Parameter[0].Value, "ParametersResult.Parameter.Value expected FhirDecimal.");
      Assert.Greater((ParametersResult.Parameter[0].Value as FhirDecimal).Value, 0, "ParametersResult.Parameter.Value expected to be greater than 0.");
      ParametersResult = null;


      //------------------------------------------------------------------------------------
      // ------------ Resource Base Operation ALL resource ResourceType = *----------------------------------------------
      //------------------------------------------------------------------------------------

      //Now setup to use the base operation $delete-history-indexes      
      //Parameter Resource
      ParametersIn = new Parameters();
      ParametersIn.Id = Guid.NewGuid().ToString();
      ParametersIn.Parameter = new List<Parameters.ParameterComponent>();
      ParamOne = new Parameters.ParameterComponent();
      ParametersIn.Parameter.Add(ParamOne);
      ParamOne.Name = "ResourceType";
      ParamOne.Value = new FhirString("*");

      ParametersResult = null;
      try
      {
        var ResourceResult = clientFhir.WholeSystemOperation(OperationName, ParametersIn);
        ParametersResult = ResourceResult as Parameters;
      }
      catch (Exception Exec)
      {
        Assert.True(false, $"Exception thrown on Operation call to ${OperationName}: " + Exec.Message);
      }
      Assert.NotNull(ParametersResult, "Resource create by Updated returned resource of null");
      Assert.NotNull(ParametersResult.Parameter, "ParametersResult.Parameter is null");
      Assert.AreEqual(ParametersResult.Parameter.Count(), ModelInfo.SupportedResources.Count, "ParametersResult.Parameter.Count Not equal to Supported resource total.");
      ParametersResult = null;

      //------------------------------------------------------------------------------------
      // ------------ Resource Type Operation ----------------------------------------------
      //------------------------------------------------------------------------------------

      //Update the patient again to ensure there are History indexes to delete
      PatientResult = null;      
      try
      {
        PatientResult = clientFhir.Update<Patient>(PatientOne);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on Patient resource Update: " + Exec.Message);
      }
      Assert.NotNull(PatientResult, "Resource create by Updated returned resource of null");

      ParametersIn = new Parameters();
      ParametersIn.Id = Guid.NewGuid().ToString();

      ParametersResult = null;
      try
      {
        var ResourceResult = clientFhir.TypeOperation<Patient>(OperationName, ParametersIn);
        ParametersResult = ResourceResult as Parameters;
      }
      catch (Exception Exec)
      {
        Assert.True(false, $"Exception thrown on Operation call to ${OperationName}: " + Exec.Message);
      }
      Assert.NotNull(ParametersResult, "Resource create by Updated returned resource of null");
      Assert.NotNull(ParametersResult.Parameter, "ParametersResult.Parameter is null");
      Assert.AreEqual(ParametersResult.Parameter.Count(), 1, "ParametersResult.Parameter contains more than one parameter.");
      Assert.AreEqual(ParametersResult.Parameter[0].Name, $"{FHIRAllTypes.Patient.GetLiteral()}_TotalIndexesDeletedCount", "ParametersResult.Parameter.Name not as expected.");
      Assert.IsInstanceOf<FhirDecimal>(ParametersResult.Parameter[0].Value, "ParametersResult.Parameter.Value expected FhirDecimal.");
      Assert.Greater((ParametersResult.Parameter[0].Value as FhirDecimal).Value, 0, "ParametersResult.Parameter.Value expected to be greater than 0.");
      
      //--- Clean Up ---------------------------------------------------------
      //Clean up by deleting all Test Patients
      SearchParams sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
      try
      {
        clientFhir.Delete("Patient", sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, "Exception thrown on conditional delete of resource Patient: " + Exec.Message);
      }

    }
  }

}
