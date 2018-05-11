using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;


namespace Pyro.Common.Search
{
  public interface IServiceSearchParameter
  {
    string Resource { get; set; }
    string Name { get; set; }
    string Url { get; set; }
    string Description { get; set; }
    SearchParamType Type { get; set; }
    string XPath { get; set; }
    string Expression { get; set; }
    bool IsIndexed { get; set; }
    PublicationStatus Status { get; set; }
    DateTimeOffset LastUpdated { get; set; }
    string SearchParameterResourceId { get; set; }
    string SearchParameterResourceVersion { get; set; }
    List<IServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
  }
}