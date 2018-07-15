using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.ServiceRoot;
using Pyro.DataLayer.DbModel.EntityBase;

namespace Pyro.DataLayer.DbModel.Entity
{
  public class _ServiceBaseUrl : ModelBase, IDtoRootUrlStore
  {
    public string Url { get; set; }
    public bool IsServersPrimaryUrlRoot { get; set; }

    public _ServiceBaseUrl()
    {
    }
  }
}


