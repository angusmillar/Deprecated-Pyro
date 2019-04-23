using Pyro.Common.CompositionRoot;

namespace Pyro.Common.Tools.FhirPathSupport
{
  public class PyroFhirPathResolve : IPyroFhirPathResolve
  {
    private readonly IPyroRequestUriFactory IPyroRequestUriFactory;
    
    public PyroFhirPathResolve(IPyroRequestUriFactory IPyroRequestUriFactory)
    {
      this.IPyroRequestUriFactory = IPyroRequestUriFactory;            
    }

    public Hl7.Fhir.ElementModel.ITypedElement Resolver(string url)
    {

      PyroElementNavigator PyroElementNavigator = new PyroElementNavigator();
      var PyroRequestUri = IPyroRequestUriFactory.CreateFhirRequestUri();
      if (PyroRequestUri.FhirRequestUri.Parse(url))
      {
        if (!string.IsNullOrWhiteSpace(PyroRequestUri.FhirRequestUri.ResourseName))
        {
          PyroElementNavigator.Name = PyroRequestUri.FhirRequestUri.ResourseName;
          //This type property is the key property to set for resolve() as it needs to match the comparison
          //for example 'AuditEvent.agent.who.where(resolve() is Patient)' Patient is Patient
          //PyroElementNavigator.Type = PyroRequestUri.FhirRequestUri.ResourseName;
          PyroElementNavigator.InstanceType = PyroRequestUri.FhirRequestUri.ResourseName;
          PyroElementNavigator.Value = PyroRequestUri.FhirRequestUri.ResourseName;
          PyroElementNavigator.Location = url;
          return PyroElementNavigator;
        }
      }
      return null;      
    }


    //public Hl7.Fhir.ElementModel.IElementNavigator Resolver(string url)
    //{      
    //  PyroElementNavigator PyroElementNavigator = new PyroElementNavigator();
    //  var PyroRequestUri = IPyroRequestUriFactory.CreateFhirRequestUri();
    //  if (PyroRequestUri.FhirRequestUri.Parse(url))
    //  {     
    //    if (!string.IsNullOrWhiteSpace(PyroRequestUri.FhirRequestUri.ResourseName))
    //    {
    //      PyroElementNavigator.Name = PyroRequestUri.FhirRequestUri.ResourseName;
    //      //This type property is the key property to set for resolve() as it needs to match the comparison
    //      //for example 'AuditEvent.agent.who.where(resolve() is Patient)' Patient is Patient
    //      PyroElementNavigator.Type = PyroRequestUri.FhirRequestUri.ResourseName;
    //      PyroElementNavigator.Value = PyroRequestUri.FhirRequestUri.ResourseName;
    //      PyroElementNavigator.Location = url;
    //      return PyroElementNavigator;
    //    }                
    //  }             
    //  return null;                  
    //}
  }
}
