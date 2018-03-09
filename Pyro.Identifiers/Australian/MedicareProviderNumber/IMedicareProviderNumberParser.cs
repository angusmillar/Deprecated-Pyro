namespace Pyro.Identifiers.Australian.MedicareProviderNumber
{
  public interface IMedicareProviderNumberParser
  {
    bool TryParse(string MedicareProviderNumberString, out IMedicareProviderNumber MedicareProviderNumber);
  }
}