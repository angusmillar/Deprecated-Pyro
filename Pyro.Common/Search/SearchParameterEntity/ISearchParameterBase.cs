using Hl7.Fhir.Model;
using Pyro.Common.DtoEntity;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Clone;
using System.Collections.Generic;

namespace Pyro.Common.Search.SearchParameterEntity
{
  public interface ISearchParameterBase : IServiceSearchParameterLight, ICloneDeep
  {    
    ISearchParameterBase ChainedSearchParameter { get; set; }
    bool HasLogicalOrProperties { get; set; }
    string InvalidMessage { get; set; }
    bool IsValid { get; set; }
    SearchParameter.SearchModifierCode? Modifier { get; set; }
    IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    string RawValue { get; set; }
    string TypeModifierResource { get; set; }

    bool TryParseValue(string Value);
    bool ValidatePrefixes(DtoServiceSearchParameterLight DtoSupportedSearchParameters);
  }
}