using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class ResourceIdentity
  {
    public int Id { get; set; }
    public string FhirResourceId { get; set; }

    //BackLinks
    public ICollection<Resource> Resource { get; set; }
    public ICollection<PatientResource> PatientResource { get; set; }
    public ICollection<ValueSetResource> ValueSetResource { get; set; }
    public ICollection<ConceptMapResource> ConceptMapResource { get; set; }
    
    public ResourceIdentity()
    {
      Resource = new HashSet<Resource>();
      PatientResource = new HashSet<PatientResource>();
      ValueSetResource = new HashSet<ValueSetResource>();
    }
  }

  public static partial class DbInfo
  {
    public static partial class ResourceIdentity
    {
      public static readonly string TableNameIs = "ResourceIdentity";

      public static readonly string Id = "Id";
      public static readonly string FhirResourceId = "FhirResourceId";

      public static readonly string List_Resource = "Resource";
      public static readonly string List_PatientResource = "PatientResource";
      public static readonly string List_ValueSetResource = "ValueSetResource";
    }
  }
}
