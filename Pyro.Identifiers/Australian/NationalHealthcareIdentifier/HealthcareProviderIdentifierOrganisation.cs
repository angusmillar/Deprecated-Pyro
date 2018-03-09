using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public class HealthcareProviderIdentifierOrganisation : NationalHealthcareIdentifierBase, IHealthcareProviderIdentifierOrganisation
  {
    public override string NumberIssuerCode { get { return "2"; } }
  }
}
