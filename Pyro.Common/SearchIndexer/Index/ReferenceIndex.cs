using Pyro.Common.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.SearchIndexer.Index
{
  public class ReferenceIndex : IndexBase, IReferenceIndex
  {
    public ReferenceIndex(IServiceSearchParameterLight ServiceSearchParameterLight)
      : base(ServiceSearchParameterLight) { }
    new int ServiceSearchParameterId { get; }

    public string VersionId { get; set; }
    public string FhirId { get; set; }
    public string ResourceType { get; set; }
    public string BaseUrl { get; set; }
    public bool IsRelativeToServer { get; set; }    
  }
}
