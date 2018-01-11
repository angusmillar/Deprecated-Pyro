using System;
using System.Configuration;
using Pyro.Common.Tools;
using Pyro.Common.Exceptions;

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
        throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
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

    public static bool FhirAuditEventLogRequestData()
    {
      try
      {
        string FhirAuditEventLogRequestData = ConfigurationManager.AppSettings["FhirAuditEventLogRequestData"].ToString();
        return StringSupport.StringToBoolean(FhirAuditEventLogRequestData);
      }
      catch (NullReferenceException)
      {
        //if not set in file then default to true;
        return true;
      }
    }

    public static bool FhirAuditEventLogResponseData()
    {
      try
      {
        string FhirAuditEventLogResponseData = ConfigurationManager.AppSettings["FhirAuditEventLogResponseData"].ToString();
        return StringSupport.StringToBoolean(FhirAuditEventLogResponseData);
      }
      catch (NullReferenceException)
      {
        //if not set in file then default to true;
        return true;
      }
    }


    /// <summary>
    /// This setting sets the default number of Resource returned for one page of search results. 
    /// i.e The number of resource returned in a search bundle. 
    /// Users can modify this per call with the _count search parameter
    /// up to the MaxNumberOfRecordsPerPage value and not beyond.
    /// If this is not set in the web config file then it defaults to the SystemDefaultNumberOfRecordsPerPageString
    /// </summary>
    /// <returns>NumberOfRecordsPerPage integer</returns>
    public static int NumberOfRecordsPerPageDefault()
    {
      int SystemDefaultNumberOfRecordsPerPageString = 50;
      try
      {
        string NumberOfRecordsPerPageString = ConfigurationManager.AppSettings["NumberOfRecordsPerPageDefault"].ToString();
        int Value;
        if (int.TryParse(NumberOfRecordsPerPageString, out Value))
        {
          return Value;
        }
        else
        {
          return SystemDefaultNumberOfRecordsPerPageString;
        }
      }
      catch (NullReferenceException)
      {
        //if not set in file then default;
        return SystemDefaultNumberOfRecordsPerPageString;
      }
    }

    /// <summary>
    /// This setting sets the maximum number of Resource returned for one page of search results. 
    /// i.e The number of resource returned in a search bundle. 
    /// Users cannot modify this per call. If the _count search parameter is greater than this maximum then
    /// the MaxNumberOfRecordsPerPage value is used.
    /// Furthermore, the Web Config file cannot set this value beyond the absolute max value that is 
    /// set here in code at 5000.
    /// up to the MaxNumberOfRecordsPerPage value and not beyond.
    /// </summary>
    /// <returns>NumberOfRecordsPerPage integer</returns>
    public static int MaxNumberOfRecordsPerPage()
    {
      const int AbsoluteMaxNumberOfRecordsPerPage = 5000;
      const int SystemDefaultMaxNumberOfRecordsPerPage = 1000;
      try
      {
        string MaxNumberOfRecordsPerPageString = ConfigurationManager.AppSettings["MaxNumberOfRecordsPerPage"].ToString();
        int Value;
        if (int.TryParse(MaxNumberOfRecordsPerPageString, out Value))
        {
          if (Value > AbsoluteMaxNumberOfRecordsPerPage)
            return AbsoluteMaxNumberOfRecordsPerPage;
          else
            return Value;
        }
        else
        {
          return SystemDefaultMaxNumberOfRecordsPerPage;
        }
      }
      catch (NullReferenceException)
      {
        //if not set in file then default;
        return SystemDefaultMaxNumberOfRecordsPerPage;
      }
    }

  }
}