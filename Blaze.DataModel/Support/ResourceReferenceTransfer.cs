using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel;

namespace Blaze.DataModel.Support
{
  public class ResourceReferenceTransfer
  {
    public string Type { get; set; }
    public string FhirId { get; set; }
    public Blaze_RootUrlStore Url { get; set; }
    public int? Blaze_RootUrlStoreID { get; set; }
  }
}
