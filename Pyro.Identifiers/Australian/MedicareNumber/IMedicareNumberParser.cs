namespace Pyro.Identifiers.Australian.MedicareNumber
{
  public interface IMedicareNumberParser
  {
    bool TryParse(string MedicareNumberString, out IMedicareNumber MedicareNumber);
  }
}