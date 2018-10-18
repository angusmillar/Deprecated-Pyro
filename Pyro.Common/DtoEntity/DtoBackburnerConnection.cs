using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.DtoEntity
{
  public class DtoBackburnerConnection
  {
    public int Id { get; set; }
    public string ConnectionId { get; set; }
    public bool IsConnected { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedUser { get; set; }
    public DateTime LastUpdated { get; set; }
    public string LastUpdatedUser { get; set; }
  }
}
