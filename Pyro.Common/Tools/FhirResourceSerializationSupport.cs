using System;
using System.Xml;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Pyro.Common.Exceptions;

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
        throw new PyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, Message);
      }
    }

    public static Resource DeSerializeFromGZip(byte[] GZipResourceBytes)
    {      
      return FhirResourceSerializationSupport.DeSerializeFromXml(Common.Tools.GZip.GZipper.Decompress(GZipResourceBytes));
    }

    public static string SerializeToXml(Resource Resource)
    {
      try
      {
        FhirXmlSerializer FhirXmlSerializer = new FhirXmlSerializer();
        return FhirXmlSerializer.SerializeToString(Resource, Hl7.Fhir.Rest.SummaryType.False);

        //Now obsolete in FHIR .NET API
        //return FhirSerializer.SerializeResourceToXml(Resource, Hl7.Fhir.Rest.SummaryType.False);                
      }
      catch (Exception oExec)
      {
        string Message = string.Format("Serialisation of Resource to XML failed with the following message: {0}", oExec.Message);
        OperationOutcome OpOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, Message);
        throw new PyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, Message);
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
        throw new PyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, Message);
      }
    }

  }
}
