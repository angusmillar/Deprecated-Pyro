using Hl7.Fhir.ElementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools.FhirPathSupport
{
  public class PyroElementNavigator : IElementNavigator
  {
    public string Name { get; set; }

    public string Type { get; set; }

    public object Value { get; set; }

    public string Location { get; set; }

    public IElementNavigator Clone()
    {
      throw new NotImplementedException();
    }

    public bool MoveToFirstChild(string nameFilter = null)
    {
      throw new NotImplementedException();
    }

    public bool MoveToNext(string nameFilter = null)
    {
      throw new NotImplementedException();
    }
  }
}
