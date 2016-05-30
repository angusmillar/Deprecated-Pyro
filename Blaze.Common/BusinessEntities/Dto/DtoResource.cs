using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blaze.Common.BusinessEntities.Dto
{
  public class DtoResource
  {
    public string FhirId { get; set; }
    public string Xml { get; set; }
    public string Version { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset Received { get; set; }    
  }
}
