using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools
{
  public static class ReflectionHelper
  {
    /// <summary>
    /// Gets an attribute on an enum field value
    /// </summary>
    /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
    /// <param name="enumVal">The enum value</param>
    /// <returns>The attribute of type T that exists on the enum value</returns>
    public static T GetAttributeOnEnum<T>(this System.Enum enumVal) where T : System.Attribute
    {
      var type = enumVal.GetType();
      var memInfo = type.GetTypeInfo().GetDeclaredField(enumVal.ToString());
      var attributes = memInfo.GetCustomAttributes(typeof(T), false);
      return (attributes.Count() > 0) ? (T)attributes.First() : null;
    }
  }
}
