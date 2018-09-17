using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;

namespace Pyro.Test.IntergrationTest
{
  [TestFixture]
  [Parallelizable(ParallelScope.None)]
  [Category("IntergrationTest")]
  class Test_Metadata
  {
    private System.IDisposable Server;

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
    [NonParallelizable]
    public void Test_MetadataCapabilityStatment()
    {
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 720; // give the call a while to execute (particularly while debugging).

      Resource CapabilityStatment = null;
      try
      {
        CapabilityStatment = clientFhir.CapabilityStatement(SummaryType.Data);        
      }
      catch (FhirOperationException ex)
      {        
        Assert.Fail($"Call to server metadata operation threw an exception. {ex.Message}");
      }

      if (CapabilityStatment is CapabilityStatement Cap)
      {
        Assert.NotNull(Cap.Contact, "No Contact element in CapabilityStatement.");        
        Assert.AreEqual(1, Cap.Contact.Count(), "Not exactly 1 Contact elements in CapabilityStatement.");
        Assert.NotNull(Cap.Contact[0].Telecom, "No Contact[0].Telecom element in CapabilityStatement.");
        Assert.AreEqual(2, Cap.Contact[0].Telecom.Count(), "Not exactly 2 Contact[0].Telecom elements in CapabilityStatement.");

        Assert.AreEqual(1, Cap.Contact.Count(), "Not exactly 1 Format element in CapabilityStatement.");

        Assert.NotNull(Cap.Format, "No Format element in CapabilityStatement.");
        Assert.AreEqual(9, Cap.Format.Count(), "Not exactly 9 Format elements in CapabilityStatement.");

        Assert.NotNull(Cap.Rest, "No Rest element in CapabilityStatement.");
        Assert.AreEqual(1, Cap.Rest.Count, "Not exactly one Rest element in CapabilityStatement.");


        Assert.NotNull(Cap.Rest[0].Resource, "No Rest.Resource element in CapabilityStatement.");
        Assert.GreaterOrEqual(Cap.Rest[0].Resource.Count(), 145, "Less than 145 FHIR resources in CapabilityStatement.");

        var ObsResourceElement = Cap.Rest[0].Resource.SingleOrDefault(x => x.Type == ResourceType.Observation);
        Assert.NotNull(ObsResourceElement, "No Observation Resource element in CapabilityStatement.");
        Assert.NotNull(ObsResourceElement.Interaction, "No Observation Interaction element in CapabilityStatement.");
        Assert.GreaterOrEqual(8, ObsResourceElement.Interaction.Count(), "Less than 8 Observation Interactions in CapabilityStatement.");
        Assert.AreEqual(CapabilityStatement.ResourceVersionPolicy.Versioned, ObsResourceElement.Versioning, "Versioning element incorrect");
        Assert.AreEqual(true, ObsResourceElement.ReadHistory, "ReadHistory should be True");
        Assert.AreEqual(true, ObsResourceElement.UpdateCreate, "UpdateCreate should be True");
        Assert.AreEqual(true, ObsResourceElement.ConditionalCreate, "conditionalCreate should be True");
        Assert.AreEqual(CapabilityStatement.ConditionalReadStatus.FullSupport, ObsResourceElement.ConditionalRead, "conditionalUpdate should be True");
        Assert.AreEqual(true, ObsResourceElement.ConditionalUpdate, "conditionalUpdate should be True");
        Assert.AreEqual(CapabilityStatement.ConditionalDeleteStatus.Multiple, ObsResourceElement.ConditionalDelete, "ConditionalDelete should be True");
        Assert.AreEqual(CapabilityStatement.ReferenceHandlingPolicy.Literal, ObsResourceElement.ReferencePolicy.ElementAt(0), "ReferencePolicy 1 should be True");
        Assert.AreEqual(CapabilityStatement.ReferenceHandlingPolicy.Local, ObsResourceElement.ReferencePolicy.ElementAt(1), "ReferencePolicy 2 should be True");

        Assert.AreEqual(ObsResourceElement.SearchInclude.Count(),181, "Not exactly 181 SearchInclude elements in CapabilityStatement.");
        Assert.AreEqual(ObsResourceElement.SearchRevInclude.Count(), 72, "Not exactly 67 SearchRevInclude elements in CapabilityStatement.");
        Assert.AreEqual(ObsResourceElement.SearchParam.Count(),44, "Not exactly 43 SearchParam elements in CapabilityStatement.");
        Assert.IsNotEmpty(ObsResourceElement.SearchParam[0].Name, "SearchParam Name element should not be empty in CapabilityStatement.");
        Assert.IsNotEmpty(ObsResourceElement.SearchParam[0].Definition, "SearchParam Definition element should not be empty in CapabilityStatement.");
        Assert.IsNotNull(ObsResourceElement.SearchParam[0].Type, "SearchParam Type element should not be empty in CapabilityStatement.");
        Assert.IsNotEmpty(ObsResourceElement.SearchParam[0].Documentation.Value, "SearchParam documentation element should not be empty in CapabilityStatement.");


      }
      else
      {
        Assert.Fail($"Call to server metadata operation returned a resource not of type CapabilityStatement");
      }
      

    }

    private void CleanUpByIdentifier(ResourceType ResourceType)
    {
      // give the call a while to execute (particularly while debugging).
      Hl7.Fhir.Rest.FhirClient clientFhir = new Hl7.Fhir.Rest.FhirClient(StaticTestData.FhirEndpoint(), false);
      clientFhir.Timeout = 1000 * 1000;

      //--- Clean Up ---------------------------------------------------------
      //Clean up by deleting all Test Patients

      SearchParams sp = new SearchParams().Where($"identifier={StaticTestData.TestIdentiferSystem}|");
      try
      {
        clientFhir.Delete(ResourceType.GetLiteral(), sp);
      }
      catch (Exception Exec)
      {
        Assert.True(false, $"Exception thrown on clean up delete of resource {ResourceType.GetLiteral()}: " + Exec.Message);
      }

    }
  }

}
