namespace Pyro.Identifiers.Support.StandardsInformation.Australian
{
  public interface INationalHealthcareIdentifierInfo
  {
    string HPIIAssigningAuthority { get; }
    string HPIIAssigningAuthorityName { get; }
    string HPIIIdentifierTypeCode { get; }
    string HPIOAssigningAuthorityName { get; }
    string HPIOAssigningFacilityID { get; }
    string HPIOIdentifierTypeCode { get; }
    string IHIAssigningAuthority { get; }
    string IHIAssigningAuthorityName { get; }
    string IHIIdentifierTypeCode { get; }
    string IHIRecordStatusFhirSystem { get; }
    string IHIStatusFhirSystem { get; }
    string IHIValueFhirSystem { get; }
    string RootHealthcareIdentifierOid { get; }
  }
}