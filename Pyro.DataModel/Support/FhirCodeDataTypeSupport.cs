using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

namespace Blaze.DataModel.Support
{
  public static partial class FhirCodeDataTypeSupport
  {
    public static bool IsGenericCodeDataType(Element FhirElement)
    {
      var type = FhirElement.GetType();
      if (IsSubclassOfRawGeneric(typeof(Code<>), type))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private static bool IsSubclassOfRawGeneric(Type rawGeneric, Type subclass)
    {
      while (subclass != typeof(object))
      {
        var cur = subclass.IsGenericType ? subclass.GetGenericTypeDefinition() : subclass;
        if (rawGeneric == cur)
        {
          return true;
        }
        subclass = subclass.BaseType;
      }
      return false;
    }

  }
}
