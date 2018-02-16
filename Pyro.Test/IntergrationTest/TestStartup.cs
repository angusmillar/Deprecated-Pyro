using Pyro.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Pyro.Test.IntergrationTest
{
  public class TestStartup : Pyro.WebApi.Startup
  {
    public override void RegisterRoutes()
    {
      //Needed to override this as in the 
      //integration tests as we create a dispose of the server
      //the RouteCollection was being registered each time and causing a duplicate
      //route issue.
      //Now we just check if any have been registered and if so don't do it again.
      //This only happen on integration test cases
      //if (this._RouteCollection.Count == 0)
      //  RouteConfig.RegisterRoutes(this._RouteCollection);
    }
    //Need this empty to not RegisterAllAreas, we only do that on Pyro.Web
    public override void RegisterAllAreas() { }

  }
}
