using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Interfaces.DataLayer
{
  public interface IConfigEntityBase
  {
    DateTime CreatedDate { get; set; }
    string CreatedUser { get; set; }
    DateTime LastUpdated { get; set; }
    string LastUpdatedUser { get; set; }
  }
}
