using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.DataModel.Repository.Interfaces;
using Blaze.Common.BusinessEntities.UriSupport;

namespace Blaze.DataModel.IndexSetter
{
  public class ReferanceIndexSetter : IReferenceIndexSetter
  {
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null)
    {
      if (ModelBase == null)
        throw new ArgumentNullException("ModelBase cannot be null for method.");

      if (FhirElement == null)
        throw new ArgumentNullException("FhirElement cannot be null for method.");

      if (ModelBase is ReferenceIndex)
      {
        var ReferenceIndex = ModelBase as ReferenceIndex;
        if (FhirElement is FhirUri)
        {
          return SetFhirUri(FhirElement as FhirUri, ReferenceIndex, FhirRequestUri, CommonRepository);
        }
        //else if (FhirElement is Resource)
        //{
        //  return SetResource(FhirElement as Resource, ReferenceIndex);
        //}
        else if (FhirElement is ResourceReference)
        {
          return SetResourceReference(FhirElement as ResourceReference, ReferenceIndex, FhirRequestUri, CommonRepository);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for ReferanceIndexSetter, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("ReferanceIndexSetter expected typeof {0} yet was passed typeof {1}", typeof(ReferanceIndexSetter).Name, ModelBase.GetType().Name));
      }
    }

    public ReferenceIndex SetFhirUri(FhirUri FhirUri, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository)
    {
      if (FhirUri == null)
        throw new ArgumentNullException("ResourceReference cannot be null for method.");

      if (ReferenceIndex == null)
        throw new ArgumentNullException("ReferenceIndex cannot be null for method.");

      if (FhirRequestUri == null)
        throw new ArgumentNullException("FhirRequestUri cannot be null for method.");

      if (CommonRepository == null)
        throw new ArgumentNullException("CommonRepository cannot be null for method.");

      //Check this logic works, do we need to check for absolute.  
      if (string.IsNullOrWhiteSpace(FhirUri.Value))
        return null;
      //Check the Uri is actual a Fhir resource reference 
      if (!Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(FhirUri.Value))
        return null;

      if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Relative))
      {
        var ReferanceUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(FhirUri.Value);
        SetResourceIndentityElements(ReferenceIndex, ReferanceUri);
        ReferenceIndex.Url_Blaze_RootUrlStoreID = FhirRequestUri.PrimaryRootUrlStore.Blaze_RootUrlStoreID;
        return ReferenceIndex;

      }
      else if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Absolute))
      {
        Uri Uri = new System.Uri(FhirUri.Value);
        var ReferanceUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(Uri);
        SetResourceIndentityElements(ReferenceIndex, ReferanceUri);
        if (FhirRequestUri.FhirUri.ServiceRootUrlForComparison == ReferanceUri.ServiceRootUrlForComparison)
        {
          ReferenceIndex.Url_Blaze_RootUrlStoreID = FhirRequestUri.PrimaryRootUrlStore.Blaze_RootUrlStoreID;
        }
        else
        {
          ReferenceIndex.Url = CommonRepository.GetAndOrAddBlaze_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
        }
        return ReferenceIndex;
      }
      else
      {
        return null;
      }
    }

    public ReferenceIndex SetResourceReference(ResourceReference ResourceReference, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, ICommonRepository CommonRepository)
    {
      if (ResourceReference == null)
        throw new ArgumentNullException("ResourceReference cannot be null for method.");

      if (ReferenceIndex == null)
        throw new ArgumentNullException("ReferenceIndex cannot be null for method.");

      if (FhirRequestUri == null)
        throw new ArgumentNullException("FhirRequestUri cannot be null for method.");

      if (CommonRepository == null)
        throw new ArgumentNullException("CommonRepository cannot be null for method.");

      //Check the Uri is actual a Fhir resource reference 
      if (!Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(ResourceReference.Reference))
        return null;

      if (!ResourceReference.IsContainedReference && ResourceReference.Url != null)
      {
        var ReferanceUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ResourceReference.Url);
        SetResourceIndentityElements(ReferenceIndex, ReferanceUri);
        if (ResourceReference.Url.IsAbsoluteUri)
        {
          if (FhirRequestUri.FhirUri.ServiceRootUrlForComparison == ReferanceUri.ServiceRootUrlForComparison)
          {
            ReferenceIndex.Url_Blaze_RootUrlStoreID = FhirRequestUri.PrimaryRootUrlStore.Blaze_RootUrlStoreID;
          }
          else
          {
            ReferenceIndex.Url = CommonRepository.GetAndOrAddBlaze_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
          }
        }
        else
        {
          ReferenceIndex.Url_Blaze_RootUrlStoreID = FhirRequestUri.PrimaryRootUrlStore.Blaze_RootUrlStoreID;
        }
        return ReferenceIndex;
      }
      else
      {
        return null;
      }
    }

    private static void SetResourceIndentityElements(ReferenceIndex ReferenceIndex, DtoFhirUri ReferanceUri)
    {
      ReferenceIndex.Type = ReferanceUri.ResourseType;
      ReferenceIndex.VersionId = ReferanceUri.VersionId;
      ReferenceIndex.FhirId = ReferanceUri.Id;
    }

  }
}
