using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{  
  public abstract class NationalHealthcareIdentifierParser
  {

    /// <summary>
    /// Australian Healthcare Identifier Types (IHI, HPI-I, HPI-O)
    /// </summary>
    internal enum NationalHealthcareIdentifierType
    {
      /// <summary>
      /// Individual Healthcare Identifier (IHI)
      /// </summary>
      Individual,
      /// <summary>
      /// Healthcare Provider Identifier-Individual (HPI-I)
      /// </summary>
      Provider,
      /// <summary>
      /// Healthcare Provider Identifier-Orginisation (HPI-O)
      /// </summary>
      Orginisation,

    }

    internal static readonly string _ValidIndustryCode = "80";
    internal static readonly string _ValidCountryCode = "036";

    internal bool BaseTryParse(string NationalHealthcareIdentifierString, NationalHealthcareIdentifierType IdentifierType, out INationalHealthcareIdentifierBase NationalHealthcareIdentifierBase)
    {
      NationalHealthcareIdentifierBase = null;
      NationalHealthcareIdentifierBase Id = null;
      switch (IdentifierType)
      {
        case NationalHealthcareIdentifierType.Individual:
          Id = new IndividualHealthcareIdentifier();
          break;
        case NationalHealthcareIdentifierType.Provider:
          Id = new HealthcareProviderIdentifierIndividual();
          break;
        case NationalHealthcareIdentifierType.Orginisation:
          Id = new HealthcareProviderIdentifierOrganisation();
          break;
        default:
          break;
      }

      NationalHealthcareIdentifierString = Identifiers.Support.StringSupport.RemoveWhitespace(NationalHealthcareIdentifierString.Trim());

      if (NationalHealthcareIdentifierString.Length != 16)
      {
        return false;
      }

      Id.Value = NationalHealthcareIdentifierString;

      if (Id.NumberIssuerCode != NationalHealthcareIdentifierString.Substring(5, 1))
      {
        return false;
      }

      Id.IndustryCode = NationalHealthcareIdentifierString.Substring(0, 2);
      if (Id.IndustryCode != _ValidIndustryCode)
      {
        return false;
      }

      Id.CountryCode = NationalHealthcareIdentifierString.Substring(2, 3);
      if (Id.CountryCode != _ValidCountryCode)
      {
        return false;
      }

      Id.UniqueReference = NationalHealthcareIdentifierString.Substring(6, 9);

      Id.CheckDigit = NationalHealthcareIdentifierString.Substring(15, 1);
      if (Id.CheckDigit != CheckDigitAlgorithm.Luhn.GetCheckDigit(Id.Value.Substring(0, Id.Value.Length - 1)))
      {
        return false;
      }

      NationalHealthcareIdentifierBase = Id;
      return true;
    }
  }
}
