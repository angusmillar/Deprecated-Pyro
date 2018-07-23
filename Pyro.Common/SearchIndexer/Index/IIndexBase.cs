using Pyro.Common.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.SearchIndexer.Index
{
  public interface IIndexBase
  {
    IServiceSearchParameterLight ServiceSearchParameterLight { get; set; }
    int ServiceSearchParameterId { get; }  
  }
}
