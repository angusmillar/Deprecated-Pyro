using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  internal static class NationalHealthcareIdentifierGenerator
  {
    /// <summary>
    /// Generate a random Healthcare Identifier for the type given
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    internal static string GenerateRandomHealthcareIdentifier(NationalHealthcareIdentifierParser.NationalHealthcareIdentifierType type)
    {      
      Random Random = new Random();
      int RandomUniqueReference = Random.Next(0, 999999999);
      string UniqueReferenceNumber = RandomUniqueReference.ToString().PadLeft(9, '0');
      string CheckDigit = CheckDigitAlgorithm.Luhn.GetCheckDigit(NationalHealthcareIdentifierParser._ValidIndustryCode + NationalHealthcareIdentifierParser._ValidCountryCode + GetNumberIssuerCodeForHealthcareIdentifierType(type) + UniqueReferenceNumber);
      return NationalHealthcareIdentifierParser._ValidIndustryCode + NationalHealthcareIdentifierParser._ValidCountryCode + GetNumberIssuerCodeForHealthcareIdentifierType(type) + UniqueReferenceNumber + CheckDigit;       
    }

    /// <summary>
    /// Convertes the HealthcareIdentifierType enum to the apropirate interger required for the Identifier value
    /// </summary>
    /// <param name="Type"></param>
    /// <returns></returns>
    private static string GetNumberIssuerCodeForHealthcareIdentifierType(NationalHealthcareIdentifierParser.NationalHealthcareIdentifierType Type)
    {
      switch (Type)
      {
        case NationalHealthcareIdentifierParser.NationalHealthcareIdentifierType.Individual:
          return "0";
        case NationalHealthcareIdentifierParser.NationalHealthcareIdentifierType.Provider:
          return "1";
        case NationalHealthcareIdentifierParser.NationalHealthcareIdentifierType.Orginisation:
          return "2";
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(Type.ToString(), (int)Type, typeof(NationalHealthcareIdentifierParser.NationalHealthcareIdentifierType));
      }
    }
  }
}
