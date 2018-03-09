using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public class HealthcareProviderIdentifierOrganisationParser : NationalHealthcareIdentifierParser, IHealthcareProviderIdentifierOrganisationParser
  {
    public bool TryParse(string HealthcareProviderIdentifierOrganisationString, out IHealthcareProviderIdentifierOrganisation HealthcareProviderIdentifierOrganisation)
    {
      HealthcareProviderIdentifierOrganisation = null;
      INationalHealthcareIdentifierBase NationalHealthcareIdentifierBase;
      if (this.BaseTryParse(HealthcareProviderIdentifierOrganisationString, NationalHealthcareIdentifierType.Orginisation, out NationalHealthcareIdentifierBase))
      {
        HealthcareProviderIdentifierOrganisation = NationalHealthcareIdentifierBase as IHealthcareProviderIdentifierOrganisation;
        return true;
      }
      return false;
    }
  }
}
