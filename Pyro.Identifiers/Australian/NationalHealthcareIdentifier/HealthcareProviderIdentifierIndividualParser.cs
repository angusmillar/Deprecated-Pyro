using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public class HealthcareProviderIdentifierIndividualParser : NationalHealthcareIdentifierParser, IHealthcareProviderIdentifierIndividualParser
  {
    public bool TryParse(string HealthcareProviderIdentifierIndividualString, out IHealthcareProviderIdentifierIndividual HealthcareProviderIdentifierIndividual)
    {
      HealthcareProviderIdentifierIndividual = null;
      INationalHealthcareIdentifierBase NationalHealthcareIdentifierBase;
      if (this.BaseTryParse(HealthcareProviderIdentifierIndividualString, NationalHealthcareIdentifierType.Provider, out NationalHealthcareIdentifierBase))
      {
        HealthcareProviderIdentifierIndividual = NationalHealthcareIdentifierBase as IHealthcareProviderIdentifierIndividual;
        return true;
      }
      return false;
    }
  }
}
