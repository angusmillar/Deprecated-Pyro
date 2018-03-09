using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public class IndividualHealthcareIdentifierGenerator : IIndividualHealthcareIdentifierGenerator
  {
    public string Generate()
    {
      return NationalHealthcareIdentifierGenerator.GenerateRandomHealthcareIdentifier(NationalHealthcareIdentifierParser.NationalHealthcareIdentifierType.Individual);      
    }
  }
}
