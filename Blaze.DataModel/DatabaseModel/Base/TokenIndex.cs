using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.DataModel.DatabaseModel.Base
{
  public abstract class TokenIndex : ModelBase
  {
    public string Code { get; set; }
    public string System { get; set; }
  }
}
