using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel;

namespace Blaze.DataModel.DatabaseModel.Base
{
  public abstract class ResourceIndexBase : ModelBase
  {
    public string FhirId { get; set; }
    public bool IsDeleted { get; set; }
    public string versionId { get; set; }
    public DateTimeOffset lastUpdated { get; set; }    
    public string XmlBlob { get; set; }
  }
}
