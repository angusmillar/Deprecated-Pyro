using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools
{
  public static class ResourceVersionNumber
  {
    public static string FirstVersion()
    {
      return "1";
    }

    public static string Increment(string VersionNumber, int ValueToAdd = 1)
    {
      int j = AsInterger(VersionNumber);
      return Convert.ToString(j + ValueToAdd);
    }

    public static string Decrement(string VersionNumber, int ValueToSubtract = 1)
    {
      int j = AsInterger(VersionNumber);
      if ((j - ValueToSubtract) > -1)
      {
        return Convert.ToString(j - ValueToSubtract);
      }
      else
      {
        throw new ArgumentOutOfRangeException("Resource Version Number was zero and could not be decremented. Value was: " + VersionNumber);
      }
    }

    public static int AsInterger(string VersionNumber)
    {
      int j;
      if (Int32.TryParse(VersionNumber, out j))
        return j;
      else
        throw new FormatException("Resource Version Number could not be converted to an int32 integer. Value was: " + VersionNumber);
    }
  }
}
