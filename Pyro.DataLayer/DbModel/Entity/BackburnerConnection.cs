using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.Entity
{
  public class _BackburnerConnection : ConfigEntityBase
  {
    public string ConnectionId { get; set; }
    public bool IsConnected { get; set; }
  }
}
