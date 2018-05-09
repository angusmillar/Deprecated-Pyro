using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.FhirRelease
{
  public class DtoFhirRelease
  {
    public int Id { get; set; }
    public string FhirVersion { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public string CreatedUser { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public string LastUpdatedUser { get; set; }
  }
}
