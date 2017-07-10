using System;
using System.Configuration;
using Pyro.Common.Tools;

namespace Pyro.Common.Cache
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

    public static bool ApplicationCacheServicesActive()
    {
      try
      {
        string CacheServicesActive = ConfigurationManager.AppSettings["ApplicationCacheServicesActive"].ToString();
        return StringSupport.StringToBoolean(CacheServicesActive);
      }
      catch (NullReferenceException)
      {
        //if not set in file then default to true;
        return true;
      }
    }



  }
}