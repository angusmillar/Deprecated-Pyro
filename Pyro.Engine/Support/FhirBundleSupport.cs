using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Tools;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Model;

namespace Pyro.Engine.Support
{
  public static class FhirBundleSupport
  {
    public static Bundle CreateBundle(ICollection<DtoResource> ResourceList, Bundle.BundleType BundleType, IDtoFhirRequestUri FhirRequestUri, int SearchTotal, int PagesTotal, int PageRequested)
    {
      var FhirBundle = new Bundle() { Type = Bundle.BundleType.Searchset };
      FhirBundle.Type = BundleType;
      FhirBundle.Total = SearchTotal;

      //Paging           
      int LastPageNumber = PagingSupport.GetLastPageNumber(PagesTotal);
      FhirBundle.FirstLink = PagingSupport.GetPageNavigationUri(FhirRequestUri.FhirUri.Uri, PagingSupport.GetFirstPageNumber());
      FhirBundle.LastLink = PagingSupport.GetPageNavigationUri(FhirRequestUri.FhirUri.Uri, LastPageNumber);
      FhirBundle.NextLink = PagingSupport.GetPageNavigationUri(FhirRequestUri.FhirUri.Uri, PagingSupport.GetNextPageNumber(PageRequested, PagesTotal));
      FhirBundle.PreviousLink = PagingSupport.GetPageNavigationUri(FhirRequestUri.FhirUri.Uri, PagingSupport.GetPreviousPageNumber(PageRequested));

      foreach (DtoResource DtoResource in ResourceList)
      {
        Bundle.EntryComponent oResEntry = new Bundle.EntryComponent();
        if (DtoResource.IsDeleted == false)
        {
          try
          {
            oResEntry.Resource = FhirResourceSerializationSupport.Serialize(DtoResource.Xml);
            var FullUrlUriBuilder = new UriBuilder(FhirRequestUri.FhirUri.ServiceRootUrl);
            FullUrlUriBuilder.Path = string.Join("/", oResEntry.Resource.TypeName, DtoResource.FhirId);
            oResEntry.FullUrl = FullUrlUriBuilder.ToString();
          }
          catch (Exception oExec)
          {
            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
            OpOutComeIssueComp.Diagnostics = String.Format("Internal Server Error: Serialization of a Resource retrieved from the servers database failed. The record details were: Key: {0}, ResourceVersion: {1}, Received: {2}. The parser exception error was '{3}", DtoResource.FhirId, DtoResource.Version, DtoResource.Received.ToString(), oExec.Message);
            var OpOutcome = new OperationOutcome();
            OpOutcome.Issue = new List<Hl7.Fhir.Model.OperationOutcome.IssueComponent>() { OpOutComeIssueComp };
            throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, OpOutComeIssueComp.Diagnostics);
          }
        }
        if (BundleType == Bundle.BundleType.History)
        {
          if (DtoResource.ResourceType.HasValue && DtoResource.ResourceType.HasValue)
          {
            oResEntry.Request = new Bundle.RequestComponent();
            oResEntry.Request.Method = DtoResource.Method;
            switch (DtoResource.Method)
            {
              case Bundle.HTTPVerb.GET:
                oResEntry.Request.Url = string.Join("/", ModelInfo.FhirTypeToFhirTypeName(DtoResource.ResourceType.Value), DtoResource.FhirId);
                break;
              case Bundle.HTTPVerb.POST:
                oResEntry.Request.Url = ModelInfo.FhirTypeToFhirTypeName(DtoResource.ResourceType.Value);
                break;
              case Bundle.HTTPVerb.PUT:
                oResEntry.Request.Url = string.Join("/", ModelInfo.FhirTypeToFhirTypeName(DtoResource.ResourceType.Value), DtoResource.FhirId);
                break;
              case Bundle.HTTPVerb.DELETE:
                oResEntry.Request.Url = string.Join("/", ModelInfo.FhirTypeToFhirTypeName(DtoResource.ResourceType.Value), DtoResource.FhirId);
                break;
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(DtoResource.Method.ToString(), (int)DtoResource.Method, typeof(Bundle.HTTPVerb));
            }
          }
        }
        if (BundleType == Bundle.BundleType.Searchset)
        {
          oResEntry.Search = new Bundle.SearchComponent();
          oResEntry.Search.Mode = Bundle.SearchEntryMode.Match;
          oResEntry.Link = new List<Bundle.LinkComponent>();
        }

        FhirBundle.Entry.Add(oResEntry);
      }
      return FhirBundle;
    }
  }
}
