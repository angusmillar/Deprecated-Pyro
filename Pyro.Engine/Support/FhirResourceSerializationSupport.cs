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
        string Message = string.Format("Internal Server Error: Serialisation of a Resource failed with the following message: {0}", oExec.Message);
        OperationOutcome OpOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, Message);
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, Message);
      }

    }
  }
}
