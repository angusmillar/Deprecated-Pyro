using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.DataModel.DatabaseModel.Base
{
  public class ReferenceIndex : ModelBase
  {
    public string FhirId { get; set; }
    public string Type { get; set; }
    public string VersionId { get; set; }
    public Blaze_RootUrlStore Url { get; set; }
    public int? Url_Blaze_RootUrlStoreID { get; set; }
  }
}
