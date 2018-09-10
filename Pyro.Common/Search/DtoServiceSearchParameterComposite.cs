using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Search
{
  public class DtoServiceSearchParameterComposite
  {
    public int Id { get; set; }

    public string Url { get; set; }
    public string Expression { get; set; }
    public int SequentialOrder { get; set; }

    public int ParentServiceSearchParameterId { get; set; }    
    public int ChildServiceSearchParameterId { get; set; }    
  }
}
