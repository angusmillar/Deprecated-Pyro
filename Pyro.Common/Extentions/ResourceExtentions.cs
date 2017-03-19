using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.Common.Extentions
{
  static class ResourceExtentions
  {
    public static List<ResourceReference> AllReferences(this Base resource)
    {
      List<ResourceReference> results = new List<ResourceReference>();
      if (resource == null)
        return results;
      var mapping = Hl7.Fhir.Introspection.ClassMapping.Create(resource.GetType());
      foreach (var item in mapping.PropertyMappings.Where(t => t.ElementType.Name == "ResourceReference" || t.ElementType.BaseType.Name == "BackboneElement"))
      {
        if (item.ElementType.BaseType.Name == "BackboneElement")
        {
          if (item.IsCollection)
          {
            System.Collections.IEnumerable col = item.GetValue(resource) as System.Collections.IEnumerable;
            foreach (var e in col)
            {
              BackboneElement be = e as BackboneElement;
              results.AddRange(be.AllReferences());
            }
          }
          else
          {
            BackboneElement be = item.GetValue(resource) as BackboneElement;
            results.AddRange(be.AllReferences());
          }
        }
        else
        {
          ResourceReference rr = item.GetValue(resource) as ResourceReference;
          if (rr != null)
            results.Add(rr);
        }
      }
      return results;
    }

  }
}
