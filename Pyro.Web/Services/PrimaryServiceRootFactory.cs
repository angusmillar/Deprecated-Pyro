using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.UriSupport;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Web.ApplicationCache;
using Hl7.Fhir.Model;


namespace Pyro.Web.Services
{
  public static class PrimaryServiceRootFactory
  {
    public static IDtoFhirRequestUri Create(ICommonServices CommonServices, Uri RequestUri)
    {
      string ErrorMsg = "Error message not set in PrimaryServiceRootFactory";
      IFhirUri RequestFhirUri = null;
      if (!DtoFhirUri.TryParse(RequestUri, out RequestFhirUri))
      {
        ErrorMsg = $"Unable to parse the request Uri as a FHIR Uri. That Uri was {RequestUri.ToString()}";
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, ErrorMsg), ErrorMsg);        
      }

      IDtoRootUrlStore PrimaryRootUrlStore = StaticCache.GetPrimaryRootUrlStore(CommonServices as ICommonServices);
      string WebConfigServiceBase = StaticCache.WebConfigServiceBaseURLForComparison;

      if (PrimaryRootUrlStore != null && 
        RequestFhirUri.ServiceRootUrlForComparison == PrimaryRootUrlStore.RootUrl &&
        RequestFhirUri.ServiceRootUrlForComparison == WebConfigServiceBase)
      {
        //All checks a good return 
        return Common.CommonFactory.GetFhirRequestUri(PrimaryRootUrlStore, RequestFhirUri);
      }

      if (PrimaryRootUrlStore == null &&
        RequestFhirUri.ServiceRootUrlForComparison == WebConfigServiceBase)
      {
        //Clean install.
        //There is no primary in the database / Cache.
        //If the Web.Config ServiceBaseURL equals the incomming request Service Base URL 
        //Therefore set the database's primary service root URL, as this is a clean install.
        PrimaryRootUrlStore = CommonServices.SetPrimaryRootUrlStore(RequestFhirUri.ServiceRootUrlForComparison);
        return Common.CommonFactory.GetFhirRequestUri(PrimaryRootUrlStore, RequestFhirUri);
      }

      if (PrimaryRootUrlStore != null &&
        RequestFhirUri.ServiceRootUrlForComparison == WebConfigServiceBase &&
        RequestFhirUri.ServiceRootUrlForComparison != PrimaryRootUrlStore.RootUrl)
      {
        //Web.Config Chnaged
        //The incomming request Service Base URL equals the Web.Config entry yet does not equal the Service Base URL
        //found in the database. We will asume soneone knows what they are doing if they are capable of changing the Web.Config setting.
        //So update the database primary Service Base URL to match the Web.Config and request
        PrimaryRootUrlStore = CommonServices.SetPrimaryRootUrlStore(RequestFhirUri.ServiceRootUrlForComparison);
        return Common.CommonFactory.GetFhirRequestUri(PrimaryRootUrlStore, RequestFhirUri);
      }


      if (PrimaryRootUrlStore == null &&
        RequestFhirUri.ServiceRootUrlForComparison != WebConfigServiceBase)
      {
        //Clean Install yet request does not match Web.Config file
        //There is no primary in the database / Cache and the incomming request Service Base URL 
        //does not match that in the Web.Config file.
        //This is a config error.
        ErrorMsg = "The ServiceBaseURL configured in the Servers Web.Config does not match the service root URL found in the incomming request.";
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, ErrorMsg), ErrorMsg);
      }

      if (PrimaryRootUrlStore != null &&
        (RequestFhirUri.ServiceRootUrlForComparison != WebConfigServiceBase ||
        RequestFhirUri.ServiceRootUrlForComparison != PrimaryRootUrlStore.RootUrl))
      {
        //Exsisting server moved and Web.Config file not updated to match the move.
        //The incomming request Service Base URL does not equal the Web.Config entry or the Database
        //Warn the user about the ramifications of this change if they should seek to make the change to the Web.Config file 
        ErrorMsg = 
          $"The incoming Http request had a service root URL of: '{RequestFhirUri.ServiceRootUrlForComparison}'. " +
          $"The server's database service root URL was '{PrimaryRootUrlStore.RootUrl}'. " + 
          $"The servers Web.Config file service root URL was '{WebConfigServiceBase}'. " +
          "All three URLs must match for the server to contiue! "+
          "This is most likely due to the server being move from it's original URL location, or the Web.Config value being incorrect. " + 
          "You need to consider carefully the ramifications of or actions. you take next. " + 
          "External systems may have absolute references to FHIR resources in this server " +
          "and changing the primary service root URL may render these external references invalid. " +
          "What can you do?. In the servers Web.Config appSetttings is a Key names 'ServiceBaseURL'. You can update this to " + 
          $"the new service root URL in use. If you change that this to equal '{RequestFhirUri.ServiceRootUrl}' the server " + 
          "will use this going forward as the service root URL for new resource. Yet all absolute references outside the database " + 
          "will become invalid. " + 
          "This change is not to be taken lightly and you should consider the ramifications carefully in the context of the " + 
          "systems that interact with this service.";
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, ErrorMsg), ErrorMsg);
      }

      ErrorMsg = "Server Internal Error: Logic to resolve the Primary Service Root has failed.";
      throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, ErrorMsg), ErrorMsg);

    }
  }
}