using Hl7.Fhir.Model;
using Pyro.DataModel.DatabaseModel.Base;

namespace Pyro.DataModel.IndexSetter
{
  public interface IUriIndexSetter : IIndexSetter
  {
    UriIndex SetFhirUri(FhirUri FhirUri, UriIndex UriIndex);
    UriIndex SetOid(Oid Oid, UriIndex UriIndex);
      
  }
}

