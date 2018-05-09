namespace Pyro.Common.FhirRelease
{
  public interface IFhirReleaseCache
  {
    void ClearFhirReleaseForFhirVersion(string FhirVersion);
    DtoFhirRelease GetFhirReleaseByFhirVersion(string FhirVersion);
  }
}