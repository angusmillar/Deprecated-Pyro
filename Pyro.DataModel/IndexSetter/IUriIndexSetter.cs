using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.IndexSetter
{
  public interface IUriIndexSetter : IIndexSetter
  {
    UriIndex SetFhirUri(FhirUri FhirUri, UriIndex UriIndex);
    UriIndex SetOid(Oid Oid, UriIndex UriIndex);
      
  }
}

