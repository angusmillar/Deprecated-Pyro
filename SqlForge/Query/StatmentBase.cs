using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlForge.Query
{
  public abstract class StatmentBase
  {
    protected string CachedStatment = string.Empty;
    protected void ResetCache()
    {
      CachedStatment = string.Empty;
    }
    public abstract string GetStatment();
  }
}
