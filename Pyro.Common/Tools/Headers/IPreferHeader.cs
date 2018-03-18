using System.Collections.Generic;

namespace Pyro.Common.Tools.Headers
{
  public interface IPreferHeader
  {
    bool IsHandlingStrict { get; }
    IEnumerable<string> PreferParameters { get; }
    void Set(string PreferString);
  }
}