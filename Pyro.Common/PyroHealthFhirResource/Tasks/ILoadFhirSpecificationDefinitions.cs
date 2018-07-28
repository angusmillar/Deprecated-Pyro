namespace Pyro.Common.PyroHealthFhirResource.Tasks
{
  public interface ILoadFhirSpecificationDefinitions
  {
    Hl7.Fhir.Model.Task GetTask();
    string GetResourceId();
    string GetName();
  }
}