using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Engine.Support
{
  public static class FhirResourceSerializationSupport
  {
    public static Resource Serialize(string Xml)
    {
      try
      {        
        FhirXmlParser FhirXmlParser = new FhirXmlParser();         
        return FhirXmlParser.Parse<Resource>(Xml);
      }
      catch (Exception oExec)
      {
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: Serialisation of a Resource failed with the following message: {0}", oExec.Message);
        var OpOutcome = new OperationOutcome();
        OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
      }

    }
  }
}
