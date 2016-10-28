using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterTokenValue : DtoSearchParameterValueBase
  {
    public enum TokenSearchType
    {
      /// <summary>
      /// Nothing, Enum not set.
      /// </summary>
      None,
      /// <summary>
      /// [parameter]=[code]: the value of [code] matches a Coding.code or 
      /// Identifier.value irrespective of the value of the system property
      /// </summary>
      MatchCodeOnly,
      /// <summary>
      /// [parameter]=[system]|: any element where the value of [system] 
      /// matches the system property of the Identifier or Coding
      /// </summary>
      MatchSystemOnly,
      /// <summary>
      /// [parameter]=[system]|[code]: the value of [code] matches a Coding.code 
      /// or Identifier.value, and the value of [system] matches the system property 
      /// of the Identifier or Coding
      /// </summary>
      MatchCodeAndSystem,
      /// <summary>
      /// [parameter]=|[code]: the value of [code] matches a Coding.code or 
      /// Identifier.value, and the Coding/Identifier has no system property
      /// </summary>
      MatchCodeWithNullSystem
    };

    public TokenSearchType SearchType { get; set; }
    public string Code { get; set; }
    public string System { get; set; }
  }
}
