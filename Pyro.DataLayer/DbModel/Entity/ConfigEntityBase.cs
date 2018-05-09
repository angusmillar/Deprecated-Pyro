using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.Entity
{
  public abstract class ConfigEntityBase : EntityBase.ModelBase, IConfigEntityBase
  {
    public DateTimeOffset CreatedDate { get; set; }
    public string CreatedUser { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public string LastUpdatedUser { get; set; }
  }
}
