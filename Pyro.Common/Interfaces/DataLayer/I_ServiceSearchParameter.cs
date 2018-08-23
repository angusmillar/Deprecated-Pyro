using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.DataLayer
{
  public interface I_ServiceSearchParameter
  {
    string Description { get; set; }
    string Expression { get; set; }
    bool IsIndexed { get; set; }
    DateTimeOffset LastUpdated { get; set; }
    string Name { get; set; }
    string Resource { get; set; }
    string SearchParameterResourceId { get; set; }
    string SearchParameterResourceVersion { get; set; }
    PublicationStatus Status { get; set; }
    //ICollection<_ServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
    SearchParamType Type { get; set; }
    string Url { get; set; }
    string XPath { get; set; }
  }
}