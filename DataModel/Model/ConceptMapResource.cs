using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir.Model;

namespace DataModel.Model
{
  public class ConceptMapResource
  {
    public int Id { get; set; }
    public int ResourceIdentity_Id { get; set; }
    public DateTime? Date { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Publisher { get; set; }
    public string Version { get; set; }
    public string Url { get; set; }
    public Fhir.ConformanceResourceStatus Status { get; set; }
    public ICollection<Resource> Resource { get; set; }
    public ICollection<CodeableConcept> UseContext { get; set; }
    public string SourceUri { get; set; }
    //public Reference? SourceReference { get; set; }

    //Key Links
    public virtual ResourceIdentity ResourceIdentity { get; set; }
    public virtual Identifier Identifier { get; set; }

    public ConceptMapResource()
    {
      Resource = new HashSet<Resource>();
      UseContext = new HashSet<CodeableConcept>();
    }

  }

  public static partial class DbInfo
  {
    public static partial class ConceptMapResource
    {
      public static readonly string TableNameIs = "ConceptMapResource";

      public static readonly string Id = "Id";
      public static readonly string Date = "Date";
      public static readonly string Name = "Name";
      public static readonly string Description = "Description";
      public static readonly string Publisher = "Publisher";
      public static readonly string Version = "Version";
      public static readonly string Url = "Url";
      public static readonly string Status = "Status";
      public static readonly string SourceUri = "SourceUri";
      public static readonly string SourceReference= "SourceReference";

      public static readonly string ResourceIdentity_Id = "ResourceIdentity_Id";
      public static readonly string Identifier_Id = "Identifier_Id";

      public static readonly string List_Resources = "Resources";
      public static readonly string List_UseContext = "UseContext";

    }
  }
}

