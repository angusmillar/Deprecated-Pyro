using Pyro.Common.Tools;
using Pyro.Common.Attributes;

namespace Pyro.Common.Enum
{
  public static class EnumUtility
  {
    public static string GetPyroLiteral(this System.Enum e)
    {
      var attr = e.GetAttributeOnEnum<EnumLiteralAttribute>();

      if (attr != null)
        return attr.Literal;
      else
        return null;
    }
  }
}
