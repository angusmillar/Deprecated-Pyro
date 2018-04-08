using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Backburner.ServiceTask.HiService
{
  public class OtherThing : IOtherThing
  {
    public OtherThing()
    {

    }

    public bool Thing()
    {
      Console.WriteLine("OtherThing");
      return true;
    }
  }
}
