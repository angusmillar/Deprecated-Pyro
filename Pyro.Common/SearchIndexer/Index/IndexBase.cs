using Pyro.Common.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.SearchIndexer.Index
{
  public abstract class IndexBase : IIndexBase
  {
    public IndexBase(IServiceSearchParameterLight ServiceSearchParameterLight)
    {
      this.ServiceSearchParameterLight = ServiceSearchParameterLight;
    }

    public IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }
    public int ServiceSearchParameterId
    {
      get
      {
        return ServiceSearchParameterLight.Id;
      }
    }
  }
}
