namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public interface IHealthcareProviderIdentifierIndividualParser
  {
    bool TryParse(string HealthcareProviderIdentifierIndividualString, out IHealthcareProviderIdentifierIndividual HealthcareProviderIdentifierIndividual);
  }
}