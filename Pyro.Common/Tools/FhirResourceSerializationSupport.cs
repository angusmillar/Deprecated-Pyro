using System;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.Tools
{
  public static class FhirResourceSerializationSupport
  {
    public static Resource DeSerializeFromXml(string Xml)
    {
      try
      {
        FhirXmlParser FhirXmlParser = new FhirXmlParser();
        return FhirXmlParser.Parse<Resource>(Xml);
      }
      catch (Exception oExec)
      {
        string Message = string.Format("DeSerialisation of a XML to FHIR Resource failed with the following message: {0}", oExec.Message);
        OperationOutcome OpOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, Message);
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, Message);
      }
    }

    public static Resource DeSerializeFromJson(string Json)
    {
      try
      {
        FhirJsonParser FhirJsonParser = new FhirJsonParser();
        return FhirJsonParser.Parse<Resource>(Json);        
      }
      catch (Exception oExec)
      {
        string Message = string.Format("DeSerialisation of a JSON to FHIR Resource failed with the following message: {0}", oExec.Message);
        OperationOutcome OpOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, Message);
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, Message);
      }
    }

  }
}
