using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
  public class DatabaseSearchResult
  {
    public List<Model.Resource> ResourceList { get; set; }
    public int TotalResource { get; set; }
  }
}
