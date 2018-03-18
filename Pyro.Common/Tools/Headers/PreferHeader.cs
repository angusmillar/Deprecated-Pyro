using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Tools;

namespace Pyro.Common.Tools.Headers
{
  public class PreferHeader : IPreferHeader
  {    
    public bool IsHandlingStrict
    { get
      {
        //Fhir Spec: http://hl7.org/fhir/STU3/search.html#errors
        //Clients can specify how the server should behave, by using the prefer header        
        //Prefer: handling = strict: Client requests that the server return an error for any unknown or unsupported parameter
        //Prefer: handling = lenient: Client requests that the server ignore any unknown or unsupported parameter
        // Developer: So it is a boolean where HandlingStrict = true when strict and false when lenient where lenient is the default 
        string Strict = "strict";
        var HandlingParameterString = this.PreferParameters.FirstOrDefault(x => StringSupport.RemoveWhitespace(x).ToLower().StartsWith("handling="));
        if (HandlingParameterString != null)
        {
          HandlingParameterString = StringSupport.RemoveWhitespace(HandlingParameterString).ToLower();
          if (HandlingParameterString.Split('=')[1] == Strict)
          {
            return true;
          }
        }
        return false;
      }
    }
    public IEnumerable<string> PreferParameters { get; private set; }
    public void Set(string PreferString)
    {
      this.PreferParameters = PreferString.Split(';').ToList();
    }
    public PreferHeader()
    {
      this.PreferParameters = new List<string>();
    }
  }
}
