using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.ServiceRoot
{
  public class DtoRootUrlStore : IDtoRootUrlStore
  {
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsServersPrimaryUrlRoot { get; set; }
    //public Uri RootUri
    //{
    //  get
    //  {
    //    return new Uri(this.Url);
    //  }
    //}
  }
}
