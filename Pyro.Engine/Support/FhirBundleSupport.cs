using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Tools;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Pyro.Engine.Support
{
  public static class FhirBundleSupport
  {
    public static Bundle CreateBundle(ICollection<DtoResource> ResourceList, Bundle.BundleType BundleType, IDtoRequestUri RequestUri, int SearchTotal, int PagesTotal, int PageRequested, Uri SearchPerformedUri = null)
    {
      var FhirBundle = new Bundle() { Type = Bundle.BundleType.Searchset };
      FhirBundle.Type = BundleType;
      FhirBundle.Total = SearchTotal;

      //Paging           
      PagingSupport.SetBundlePagnation(FhirBundle, RequestUri.FhirRequestUri.OriginalString, PagesTotal, PageRequested, SearchPerformedUri);
      //int LastPageNumber = PagingSupport.GetLastPageNumber(PagesTotal);
      //FhirBundle.FirstLink = PagingSupport.GetPageNavigationUri(RequestUri.FhirRequestUri.OriginalString, PagingSupport.GetFirstPageNumber());
      //FhirBundle.LastLink = PagingSupport.GetPageNavigationUri(RequestUri.FhirRequestUri.OriginalString, LastPageNumber);
      //Uri Next = PagingSupport.GetPageNavigationUri(RequestUri.FhirRequestUri.OriginalString, PagingSupport.GetNextPageNumber(PageRequested, PagesTotal));
      //if (Next != null)
      //  FhirBundle.NextLink = Next;

      //FhirBundle.PreviousLink = PagingSupport.GetPageNavigationUri(RequestUri.FhirRequestUri.OriginalString, PagingSupport.GetPreviousPageNumber(PageRequested));
      //if (SearchPerformedUri != null)
      //  FhirBundle.SelfLink = SearchPerformedUri;

      foreach (DtoResource DtoResource in ResourceList)
      {
        Bundle.EntryComponent oResEntry = new Bundle.EntryComponent();

        if (DtoResource.IsDeleted == false)
        {
          try
          {
            oResEntry.Resource = FhirResourceSerializationSupport.DeSerializeFromXml(DtoResource.Xml);
          }
          catch (Exception oExec)
          {
            string Message = string.Format("Internal Server Error: Serialization of a Resource retrieved from the servers database failed. The record details were: Key: {0}, ResourceVersion: {1}, Received: {2}. The parser exception error was '{3}", DtoResource.FhirId, DtoResource.Version, DtoResource.Received.ToString(), oExec.Message);
            OperationOutcome OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, Message);
            throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutcome, Message);
          }
        }

        oResEntry.FullUrl = string.Join("/", RequestUri.PrimaryRootUrlStore.Url, DtoResource.ResourceType.GetLiteral(), DtoResource.FhirId);

        if (BundleType == Bundle.BundleType.History)
        {
          oResEntry.FullUrl = string.Join("/", oResEntry.FullUrl);
          if (DtoResource.ResourceType.HasValue && DtoResource.ResourceType.HasValue)
          {
            oResEntry.Request = new Bundle.RequestComponent();
            oResEntry.Request.Method = DtoResource.Method;
            switch (DtoResource.Method)
            {
              case Bundle.HTTPVerb.GET:
                oResEntry.Request.Url = string.Join("/", ModelInfo.FhirTypeToFhirTypeName(DtoResource.ResourceType.Value), DtoResource.FhirId, "_history", DtoResource.Version);
                break;
              case Bundle.HTTPVerb.POST:
                oResEntry.Request.Url = string.Join("/", ModelInfo.FhirTypeToFhirTypeName(DtoResource.ResourceType.Value), DtoResource.FhirId, "_history", DtoResource.Version);
                break;
              case Bundle.HTTPVerb.PUT:
                oResEntry.Request.Url = string.Join("/", ModelInfo.FhirTypeToFhirTypeName(DtoResource.ResourceType.Value), DtoResource.FhirId, "_history", DtoResource.Version);
                break;
              case Bundle.HTTPVerb.DELETE:
                oResEntry.Request.Url = string.Join("/", ModelInfo.FhirTypeToFhirTypeName(DtoResource.ResourceType.Value), DtoResource.FhirId, "_history", DtoResource.Version);
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
