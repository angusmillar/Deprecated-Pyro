using System;
using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;
using System.Collections.Generic;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.DataModel.Repository.Interfaces;

namespace Pyro.DataModel.IndexSetter
{
  public class UriIndexSetter : IUriIndexSetter
  {
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null)
    {
      if (ModelBase == null)
        throw new ArgumentNullException("ModelBase cannot be null for method.");

      if (FhirElement == null)
        throw new ArgumentNullException("FhirElement cannot be null for method.");

      if (ModelBase is UriIndex)
      {
        var StringIndex = ModelBase as UriIndex;
        if (FhirElement is FhirUri)
        {
          return SetFhirUri(FhirElement as FhirUri, StringIndex);
        }
        else if (FhirElement is Oid)
        {
          return SetOid(FhirElement as Oid, StringIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for UriIndex, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("UriIndex expected typeof {0} yet was passed typeof {1}", typeof(UriIndex).Name, ModelBase.GetType().Name));
      }
    }

    public UriIndex SetFhirUri(FhirUri FhirUri, UriIndex UriIndex)
    {
      if (FhirUri == null)
        throw new ArgumentNullException("FhirUri cannot be null for method.");

      if (UriIndex == null)
        throw new ArgumentNullException("UriIndex cannot be null for method.");

      if (string.IsNullOrWhiteSpace(FhirUri.Value))
        return null;

      UriIndex.Uri = FhirUri.Value;
      return UriIndex;
    }

    public UriIndex SetOid(Oid Oid, UriIndex UriIndex)
    {
      if (Oid == null)
        throw new ArgumentNullException("Oid cannot be null for method.");

      if (UriIndex == null)
        throw new ArgumentNullException("UriIndex cannot be null for method.");

      if (string.IsNullOrWhiteSpace(Oid.Value))
        return null;

      UriIndex.Uri = Oid.Value;
      return UriIndex;
    }
  }
}
