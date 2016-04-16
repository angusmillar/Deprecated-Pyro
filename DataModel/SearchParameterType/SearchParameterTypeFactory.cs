using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;


namespace DataModel.SearchParameterType
{
  public static class SearchParameterTypeFactory
  {
    public static Token CreateToken(object Object)
    {
      if (Object is Coding)
      {
        return new Token(Object as Coding);
      }
      else if (Object is Identifier)
      {
        return new Token(Object as Identifier);
      }
      else if (Object is ContactPoint)
      {
        return new Token(Object as ContactPoint);
      }
      else if (Object is Code)
      {
        return new Token(Object as Code);
      }
      else if (Object is FhirBoolean)
      {
        return new Token(Object as FhirBoolean);
      }
      else if (Object is FhirString)
      {
        return new Token(Object as FhirString);
      }
      else
      {
        throw new InvalidCastException("Object type unable to be cast to a search parameter type instance.");
      }
    }
  }
}
