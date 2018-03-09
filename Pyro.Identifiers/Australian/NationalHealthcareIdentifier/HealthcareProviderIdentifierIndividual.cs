using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.NationalHealthcareIdentifier
{
  public class HealthcareProviderIdentifierIndividual : NationalHealthcareIdentifierBase, IHealthcareProviderIdentifierIndividual
  {
    public override string NumberIssuerCode { get { return "1"; } }
  }
}
