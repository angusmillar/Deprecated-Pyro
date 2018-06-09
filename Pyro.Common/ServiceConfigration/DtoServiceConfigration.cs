using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.ServiceConfigration
{
  public class DtoServiceConfigration
  {
    public int Id { get; set; }
    public string Parameter { get; set; }
    public string Value { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
    public string CreatedUser { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public string LastUpdatedUser { get; set; }
  }
}
