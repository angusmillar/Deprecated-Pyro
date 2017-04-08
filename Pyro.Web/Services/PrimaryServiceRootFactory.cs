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
    public static IDtoFhirRequestUri CreateOld(ICommonServices CommonServices, Uri RequestUri)
    {
      IFhirUri RequestFhirUri = null;
      if (DtoFhirUri.TryParse(RequestUri, out RequestFhirUri))
      {
        IDtoRootUrlStore PrimaryRootUrlStore = StaticCache.GetPrimaryRootUrlStore(CommonServices as ICommonServices);
        if (PrimaryRootUrlStore == null)
        {
          //There is no primary in the database / Cache.
          //If the Web.Config ServiceBaseURL = the incomming request Service Base URL then set the database's primary service root URL. 
          // as this is a clean install.
          if (StaticCache.WebConfigServiceBaseURL == RequestFhirUri.ServiceRootUrlForComparison)
          {
            PrimaryRootUrlStore = CommonServices.SetPrimaryRootUrlStore(RequestFhirUri.ServiceRootUrlForComparison);
          }
          else
          {
            string Message = "The ServiceBaseURL configured in the Servers Web.Config does not match the service root URL found in the incomming request.";
            throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, Message), Message);
          }
        }
        else if (PrimaryRootUrlStore.RootUrl != RequestFhirUri.ServiceRootUrlForComparison && RequestFhirUri.ServiceRootUrlForComparison == StaticCache.WebConfigServiceBaseURL)
        {
          // The Web.Config has been chnaged and the incomming request service root URL equal the new Web.Config service root URL, so update the database
          // to the new service root URL and contiue. We asume soneone knows what they are doing if they are capable of changing the Web.Config setting.
          PrimaryRootUrlStore = CommonServices.SetPrimaryRootUrlStore(RequestFhirUri.ServiceRootUrlForComparison);
        }
        else
        {
          if (PrimaryRootUrlStore.RootUrl != RequestFhirUri.ServiceRootUrlForComparison  || PrimaryRootUrlStore.RootUrl != StaticCache.WebConfigServiceBaseURL)
          {
            //Throw exception
            var OpOutCome = new OperationOutcome();
            OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Processing;
            string ErrorMsg = "The incoming Http request had a service root URL of: '{0}'. The servers database service root URL was '{1}'. The servers Web.Config file service root URL was '{2}'" +
                              "This is most likely due to the server being move from it's original URL location. You need to consider carefully the ramifications of this move. " +
                              "External systems may have absolute references to FHIR resources in this database and changing the primary service root may render these external stored references invalid." +
                              "You have two choices moving forward. In the database table named 'Pyro_RootUrlStore' you can locate the record with 'IsServersPrimaryUrlRoot = true'. " +
                              "If you change that record's 'RootUrl' property to be equal '{0}' then all existing relative references in the database's search indexes will be equal to the new URL. Yet all absolute references outside the database will become invalid. " +
                              "The other option is to set the 'IsServersPrimaryUrlRoot = true' to equal 'false'. In this case all existing relative references in the database search indexes will remain on the old URL. " +
                              "Note that these URL changes discussed are only made to the database's search indexes and not to references contained in the resources, they remain unchanged. " +
                              "Regardless of which change you make you will need to restart the service for the change to be picked up by the service. When the service detects no 'IsServersPrimaryUrlRoot = true' " +
                              "it will take the root URL of the first request it receives as the new 'IsServersPrimaryUrlRoot = true' " +
                              "This change is not to be taken lightly and you should consider the ramifications carefully in the context of the systems that interact with this service.";
            ErrorMsg = string.Format(ErrorMsg, RequestFhirUri.ServiceRootUrlForComparison, PrimaryRootUrlStore.RootUrl);
            OpOutComeIssueComp.Diagnostics = ErrorMsg;
            OpOutCome.Issue.Add(OpOutComeIssueComp);
            throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutCome, ErrorMsg);
          }
        }
        return Common.CommonFactory.GetFhirRequestUri(PrimaryRootUrlStore, RequestFhirUri);
      }
      else
      {
        var OpOutCome = new OperationOutcome();
        OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Processing;
        string ErrorMsg = $"Unable to parse the request Uri as a FHIR Uri. That Uri was {RequestUri.ToString()}";
        OpOutComeIssueComp.Diagnostics = ErrorMsg;
        OpOutCome.Issue.Add(OpOutComeIssueComp);
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutCome, ErrorMsg);
      }
    }

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

      if (PrimaryRootUrlStore != null && 
        RequestFhirUri.ServiceRootUrlForComparison == PrimaryRootUrlStore.RootUrl &&
        RequestFhirUri.ServiceRootUrlForComparison == StaticCache.WebConfigServiceBaseURL)
      {
        //All checks a good return 
        return Common.CommonFactory.GetFhirRequestUri(PrimaryRootUrlStore, RequestFhirUri);
      }

      if (PrimaryRootUrlStore == null &&
        RequestFhirUri.ServiceRootUrlForComparison == StaticCache.WebConfigServiceBaseURL)
      {
        //Clean install.
        //There is no primary in the database / Cache.
        //If the Web.Config ServiceBaseURL equals the incomming request Service Base URL 
        //Therefore set the database's primary service root URL, as this is a clean install.
        PrimaryRootUrlStore = CommonServices.SetPrimaryRootUrlStore(RequestFhirUri.ServiceRootUrlForComparison);
        return Common.CommonFactory.GetFhirRequestUri(PrimaryRootUrlStore, RequestFhirUri);
      }

      if (PrimaryRootUrlStore != null &&
        RequestFhirUri.ServiceRootUrlForComparison == StaticCache.WebConfigServiceBaseURL &&
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
        RequestFhirUri.ServiceRootUrlForComparison != StaticCache.WebConfigServiceBaseURL)
      {
        //Clean Install yet request does not match Web.Config file
        //There is no primary in the database / Cache and the incomming request Service Base URL 
        //does not match that in the Web.Config file.
        //This is a config error.
        ErrorMsg = "The ServiceBaseURL configured in the Servers Web.Config does not match the service root URL found in the incomming request.";
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, ErrorMsg), ErrorMsg);
      }

      if (PrimaryRootUrlStore != null &&
        (RequestFhirUri.ServiceRootUrlForComparison != StaticCache.WebConfigServiceBaseURL ||
        RequestFhirUri.ServiceRootUrlForComparison != PrimaryRootUrlStore.RootUrl))
      {
        //Exsisting server moved and Web.Config file not updated to match the move.
        //The incomming request Service Base URL does not equal the Web.Config entry or the Database
        //Warn the user about the ramifications of this change if they should seek to make the change to the Web.Config file 
        ErrorMsg = 
          $"The incoming Http request had a service root URL of: '{RequestFhirUri.ServiceRootUrlForComparison}'. " +
          $"The server's database service root URL was '{PrimaryRootUrlStore.RootUrl}'. " + 
          $"The servers Web.Config file service root URL was '{StaticCache.WebConfigServiceBaseURL}'. " +
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