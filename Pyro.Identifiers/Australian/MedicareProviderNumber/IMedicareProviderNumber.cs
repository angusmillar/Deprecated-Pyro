namespace Pyro.Identifiers.Australian.MedicareProviderNumber
{
  public interface IMedicareProviderNumber
  {
    string CheckCharacter { get; }
    string LocationCharacter { get; }
    string Stem { get; }
    string Value { get; }

    bool IsValid();
  }
}