using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Specification;

namespace Pyro.Common.Tools.FhirPathSupport
{
  public class PyroElementNavigator : ITypedElement
  {
    public string Name { get; set; }

    public string InstanceType { get; set; }

    public object Value { get; set; }

    public string Location { get; set; }

    public IElementDefinitionSummary Definition { get; set; }

    public IEnumerable<ITypedElement> Children(string name = null)
    {
      throw new NotImplementedException();
    }
  }

  //public class PyroElementNavigator : IElementNavigator
  //{
  //  public string Name { get; set; }

  //  public string Type { get; set; }

  //  public object Value { get; set; }

  //  public string Location { get; set; }

  //  public IElementNavigator Clone()
  //  {
  //    throw new NotImplementedException();
  //  }

  //  public bool MoveToFirstChild(string nameFilter = null)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  public bool MoveToNext(string nameFilter = null)
  //  {
  //    throw new NotImplementedException();
  //  }
  //}
}
