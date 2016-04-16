using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces.Repositories;

namespace Blaze.Engine.Search
{
  public abstract class SearchPlanBase
  {
    protected IUnitOfWork _UnitOfWork;
    public IUnitOfWork UnitOfWork
    {
      set
      {
        _UnitOfWork = value;
      }
    }
    public Uri RequestUri { get; set; }
  }
}
