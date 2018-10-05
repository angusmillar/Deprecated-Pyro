using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.DtoEntity
{
  public abstract class DtoConfigEntityBase : DtoModelBase
  {
    public DateTime CreatedDate { get; set; }
    public string CreatedUser { get; set; }
    public DateTime LastUpdated { get; set; }
    public string LastUpdatedUser { get; set; }
  }
}
