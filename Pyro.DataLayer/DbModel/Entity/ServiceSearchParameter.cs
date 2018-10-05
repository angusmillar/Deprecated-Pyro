using System;
using System.Collections.Generic;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.DataLayer;

namespace Pyro.DataLayer.DbModel.Entity
{
  /// <summary>
  /// This class is a one-to-one match to the FHIR API SearchParamDefinition yet some have been excluded, commented out below
  /// </summary>
  public class _ServiceSearchParameter : ConfigEntityBase, I_ServiceSearchParameter
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
    public string SearchParameterResourceId { get; set; }
    public string SearchParameterResourceVersion { get; set; }
    public ICollection<_ServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
    public ICollection<_ServiceSearchParameterCompositePivot> ServiceSearchParameterCompositePivotList { get; set; }

    public _ServiceSearchParameter()
    {
      this.TargetResourceTypeList = new HashSet<_ServiceSearchParameterTargetResource>();
      this.ServiceSearchParameterCompositePivotList = new HashSet<_ServiceSearchParameterCompositePivot>();
    }

  }
}
