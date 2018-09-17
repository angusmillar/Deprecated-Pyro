using Hl7.Fhir.Model;

namespace Pyro.Common.Tools.FhirSpecCorrections
{
  public interface IFhirSpecificationCorrections
  {
    void SearchParameterCorrections(SearchParameter SearchParameter);
  }
}