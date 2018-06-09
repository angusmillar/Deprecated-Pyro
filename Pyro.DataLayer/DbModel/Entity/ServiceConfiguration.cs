using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.EntityBase;

namespace Pyro.DataLayer.DbModel.Entity
{
  public class _ServiceConfiguration : ConfigEntityBase
  {
    public string Parameter { get; set; }
    public string Value { get; set; }

    public _ServiceConfiguration()
    {
    }
  }
}
