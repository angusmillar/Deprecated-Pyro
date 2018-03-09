namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public interface INationalHealthcareIdentifierBase
  {
    string CheckDigit { get;  }
    string CountryCode { get; }
    string IndustryCode { get; }
    string NumberIssuerCode { get; }
    string UniqueReference { get; }
    string Value { get; }
  }
}