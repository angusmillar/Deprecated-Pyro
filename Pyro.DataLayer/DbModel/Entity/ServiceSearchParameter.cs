using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Dto;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.DbModel.Entity
{
  /// <summary>
  /// This class is a one-to-one match to the FHIR API SearchParamDefinition yet some have been excluded, commented out below
  /// </summary>
  public class ServiceSearchParameter : ModelBase
  {
    public string Resource { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public SearchParamType Type { get; set; }
    public string XPath { get; set; }
    public string Expression { get; set; }
    public bool IsIndexed { get; set; }
    public PublicationStatus Status { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public string SearchParameterResourceId { get; set; }
    public string SearchParameterResourceVersion { get; set; }
    public ICollection<ServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }

    public ServiceSearchParameter()
    {
      this.TargetResourceTypeList = new HashSet<ServiceSearchParameterTargetResource>();
    }

    /// <summary>
    /// If this search parameter is a Composite, this array contains 
    /// the list of search parameters the param is a combination of
    /// </summary>
    //public string[] CompositeParams { get; set; }

    /// <summary>
    /// One or more paths into the Resource instance that the search parameter 
    /// uses 
    /// </summary>
    //public string[] Path { get; set; }

  }
}
