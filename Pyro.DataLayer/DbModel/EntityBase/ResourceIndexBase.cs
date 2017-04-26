using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.EntityBase
{
  public abstract class ResourceIndexBase : ModelBase
  {
    public ServiceSearchParameter ServiceSearchParameter { get; set; }
    public int ServiceSearchParameterId { get; set; }

    public string String { get; set; }

    public int? Date { get; set; }

    public DateTimeOffset? DateTimeOffsetLow { get; set; }
    public DateTimeOffset? DateTimeOffsetHigh { get; set; }

    public string Uri { get; set; }

    public Quantity.QuantityComparator? Comparator { get; set; }
    public decimal? Quantity { get; set; }
    public string System { get; set; }
    public string Code { get; set; }
    public string Unit { get; set; }

    public Quantity.QuantityComparator? ComparatorHigh { get; set; }
    public decimal? QuantityHigh { get; set; }
    public string SystemHigh { get; set; }
    public string CodeHigh { get; set; }
    public string UnitHigh { get; set; }

    public string ReferenceFhirId { get; set; }
    public string ReferenceResourceType { get; set; }
    public string ReferenceVersionId { get; set; }
    public ServiceBaseUrl ReferenceUrl { get; set; }
    public int? ReferenceServiceBaseUrlId { get; set; }    
  }
}
