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

      IFhirUri ReferanceUri = null;
      if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Relative))
      {        
        if (DtoFhirUri.TryParse(FhirUri.Value.Trim(), out ReferanceUri))
        {
          SetResourceIndentityElements(ReferenceIndex, ReferanceUri);
          ReferenceIndex.ServiceRootURL_StoreID = FhirRequestUri.PrimaryRootUrlStore.ServiceRootUrlStoreID;
          return ReferenceIndex;
        }        
      }
      else if (Uri.IsWellFormedUriString(FhirUri.Value, UriKind.Absolute))
      {
        if (DtoFhirUri.TryParse(FhirUri.Value.Trim(), out ReferanceUri))
        {
          SetResourceIndentityElements(ReferenceIndex, ReferanceUri);
          if (FhirRequestUri.FhirUri.ServiceRootUrlForComparison == ReferanceUri.ServiceRootUrlForComparison)
          {
            ReferenceIndex.ServiceRootURL_StoreID = FhirRequestUri.PrimaryRootUrlStore.ServiceRootUrlStoreID;
          }
          else
          {
            ReferenceIndex.Url = CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
          }
          return ReferenceIndex;
        } 
      }
      return null;
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
        IFhirUri ReferanceUri = null;
        if (DtoFhirUri.TryParse(ResourceReference.Url, out ReferanceUri))
        {
          SetResourceIndentityElements(ReferenceIndex, ReferanceUri);
          if (ResourceReference.Url.IsAbsoluteUri)
          {
            if (FhirRequestUri.FhirUri.ServiceRootUrlForComparison == ReferanceUri.ServiceRootUrlForComparison)
            {
              ReferenceIndex.ServiceRootURL_StoreID = FhirRequestUri.PrimaryRootUrlStore.ServiceRootUrlStoreID;
            }
            else
            {
              ReferenceIndex.Url = CommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
            }
          }
          else
          {
            ReferenceIndex.ServiceRootURL_StoreID = FhirRequestUri.PrimaryRootUrlStore.ServiceRootUrlStoreID;
          }
          return ReferenceIndex;
        }        
      }      
      return null;      
    }

    private static void SetResourceIndentityElements(ReferenceIndex ReferenceIndex, IFhirUri ReferanceUri)
    {
      ReferenceIndex.Type = ReferanceUri.ResourseType;
      ReferenceIndex.VersionId = ReferanceUri.VersionId;
      ReferenceIndex.FhirId = ReferanceUri.Id;
    }

  }
}
