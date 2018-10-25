using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.DtoEntity
{
  public class DtoBackburnerConnection : DtoConfigEntityBase
  {
    public string ConnectionId { get; set; }
    public bool IsConnected { get; set; }
  }
}
