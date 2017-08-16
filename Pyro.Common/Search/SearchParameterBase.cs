using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Service;

namespace Pyro.Common.Search
{

  public abstract class SearchParameterBase : ServiceSearchParameterLight, ISearchParameterBase
  {
    protected const char OrDelimiter = ',';
    public string RawValue { get; set; }
    public SearchParameter.SearchModifierCode? Modifier { get; set; }
    public string TypeModifierResource { get; set; }
    public ISearchParametersServiceOutcome ChainedSearchParameter { get; set; }
    public bool HasLogicalOrProperties { get; set; }
    public bool IsValid { get; set; }
    public string InvalidMessage { get; set; }
    public Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore { get; set; }

    public abstract bool TryParseValue(string Value);
    public abstract bool ValidatePrefixes(ServiceSearchParameterLight DtoSupportedSearchParameters);


    public SearchParameterBase()
    {
      this.HasLogicalOrProperties = false;
      this.IsValid = true;
    }
  }
}
