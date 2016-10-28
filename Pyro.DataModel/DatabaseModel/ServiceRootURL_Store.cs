using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class ServiceRootURL_Store : ModelBase
  {
    public int ServiceRootURL_StoreID {get; set;}
    public string RootUrl {get; set;}
    public bool IsServersPrimaryUrlRoot {get; set;}
   
    public ServiceRootURL_Store()
    {
    }
  }
}

