using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public class IndividualHealthcareIdentifierParser : NationalHealthcareIdentifierParser, IIndividualHealthcareIdentifierParser
  {
    public bool TryParse(string IIndividualHealthcareIdentifierString, out IIndividualHealthcareIdentifier IndividualHealthcareIdentifier)
    {
      IndividualHealthcareIdentifier = null;
      INationalHealthcareIdentifierBase NationalHealthcareIdentifierBase;
      if (this.BaseTryParse(IIndividualHealthcareIdentifierString, NationalHealthcareIdentifierType.Individual, out NationalHealthcareIdentifierBase))
      {
        IndividualHealthcareIdentifier = NationalHealthcareIdentifierBase as IIndividualHealthcareIdentifier;
        return true;
      }
      return false;
    }
  }
}
