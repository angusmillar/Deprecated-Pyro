using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.BusinessEntities
{
  public class DtoResource
  {    
    public int Id { get; set; }
    public string Xml { get; set; }
    public int Version { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset Received { get; set; }
    public DtoEnums.SupportedFhirResource FhirResourceType { get; set; }
  }
}
