using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.EntityBase;

namespace Pyro.DataLayer.DbModel.Entity
{
  public class _ServiceSearchParameterCompositePivot : ModelBase
  {
    public int SequentialOrder { get; set; }
    public string Url { get; set; }
    public string Expression { get; set; }

    public int ParentServiceSearchParameterId { get; set; }
    public _ServiceSearchParameter ParentServiceSearchParameter { get; set; }

    public int ChildServiceSearchParameterId { get; set; }
    public _ServiceSearchParameter ChildServiceSearchParameter { get; set; }

  }
}
