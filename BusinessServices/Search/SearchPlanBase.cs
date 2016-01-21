using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Engine.Search
{
  public abstract class SearchPlanBase
  {
    protected Dip.Interfaces.IUnitOfWork _UnitOfWork;
    public Dip.Interfaces.IUnitOfWork UnitOfWork
    {
      set
      {
        _UnitOfWork = value;
      }
    }
    public Uri RequestUri { get; set; }
  }
}
