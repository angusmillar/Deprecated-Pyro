namespace Pyro.Common.PyroHealthInformation.Tasks
{
  public interface ILoadFhirSpecificationDefinitions
  {
    Hl7.Fhir.Model.Task GetTask();
    string GetResourceId();
    string GetName();
  }
}