using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ModelBase : IModelBase
  {
    public int Id { get; set; }
  }
}
