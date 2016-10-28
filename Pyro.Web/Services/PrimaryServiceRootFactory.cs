using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Services;
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
      IFhirUri RequestFhirUri = null;
      if (DtoFhirUri.TryParse(RequestUri, out RequestFhirUri))
      {
        IDtoRootUrlStore PrimaryRootUrlStore = StaticCache.LoadStaticCache(CommonServices as ICommonServices);
        if (PrimaryRootUrlStore == null)
        {
          //There is no primary in the cache or in the database, so we can use the RequestUri to set
          //the primary as this is a clean install, or someone has manual removed the primary reference from the database. 
          PrimaryRootUrlStore = CommonServices.SetPrimaryRootUrlStore(RequestFhirUri.ServiceRootUrlForComparison);
        }
        else
        {
          if (PrimaryRootUrlStore.RootUrl != RequestFhirUri.ServiceRootUrlForComparison)
          {
            //Throw exception
            var OpOutCome = new OperationOutcome();
            OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Processing;
            string ErrorMsg = "The incoming Http request had a service root URL of: '{0}' which is different to primary service root URL stored in the services database. The database was expecting: '{1}'. " +
                              "This is most likely due to the server being move from it's original URL location. You need to consider carefully the ramifications of this move. " +
                              "External systems may have absolute references to FHIR resources in this database and changing the primary service root may render these external stored references invalid." +
                              "You have two choices moving forward. In the database table named 'Pyro_RootUrlStore' you can locate the record with 'IsServersPrimaryUrlRoot = ture'. " +
                              "If you change that record's 'RootUrl' property to be equal '{0}' then all existing relative references in the database's search indexes will be equal to the new URL. Yet all absolute references outside the database will become invalid. " +
                              "The other option is to set the 'IsServersPrimaryUrlRoot = ture' to equal 'false'. In this case all existing relative references in the database search indexes will remain on the old URL. " +
                              "Note that these URL changes discussed are only made to the database's search indexes and not to references contained in the resources, they remain unchanged. " +
                              "Regardless of which change you make you will need to restart the service for the change to be picked up by the service. When the service detects no 'IsServersPrimaryUrlRoot = ture' " +
                              "it will take the root URL of the first request it receives as the new 'IsServersPrimaryUrlRoot = ture' " +
                              "This change is not to be taken lightly and you should consider the ramifications carefully in the context of the systems that interact with this service.";
            OpOutComeIssueComp.Diagnostics = ErrorMsg;
            OpOutCome.Issue.Add(OpOutComeIssueComp);
            throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutCome, ErrorMsg);
          }
        }
        return DtoFhirRequestUri.Create(PrimaryRootUrlStore, RequestFhirUri);
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
  }
}