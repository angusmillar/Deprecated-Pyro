using System;
using System.Configuration;

namespace Pyro.Web.ApplicationCache
{
  public static class WebConfigProperties
  {
    public static string ServiceBaseURL()
    {
      try
      {
        return new Uri(ConfigurationManager.AppSettings["ServiceBaseURL"].ToString().TrimEnd('/')).ToString();        
      }
      catch
      {
        string Msg = "The Web.Config file of the server has an invalid 'ServiceBaseURL' property value.";
        throw new Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
          Common.Tools.FhirOperationOutcomeSupport.Create(Hl7.Fhir.Model.OperationOutcome.IssueSeverity.Fatal, Hl7.Fhir.Model.OperationOutcome.IssueType.Exception, Msg), Msg);
      }

    }
  }
}