using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataModel.DatabaseModel.Base
{
  public class ReferenceIndex : ModelBase
  {
    public string FhirId { get; set; }
    public string Type { get; set; }
    public string VersionId { get; set; }
    public ServiceRootURL_Store Url { get; set; }
    public int? ServiceRootURL_StoreID { get; set; }
  }
}
