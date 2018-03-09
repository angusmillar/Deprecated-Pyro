namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public interface IIndividualHealthcareIdentifierParser
  {
    bool TryParse(string IIndividualHealthcareIdentifierString, out IIndividualHealthcareIdentifier IndividualHealthcareIdentifier);
  }
}