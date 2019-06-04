using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Enum
{
  public enum AllResourceSearchParameterType
  {
    [EnumLiteral("_id")]
    _id,
    [EnumLiteral("_LastUpdate")]
    _LastUpdate,
    [EnumLiteral("_profile")]
    _profile,
    [EnumLiteral("_security")]
    _security,
    [EnumLiteral("_tag")]
    _tag,    
  }
}
