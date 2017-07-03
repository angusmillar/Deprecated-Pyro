using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Common.BusinessEntities.Search
{

  public abstract class DtoSearchParameterBase : DtoServiceSearchParameterLight, IDtoSearchParameterBase
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
    public abstract bool ValidatePrefixes(DtoServiceSearchParameterLight DtoSupportedSearchParameters);


    public DtoSearchParameterBase()
    {
      this.HasLogicalOrProperties = false;
      this.IsValid = true;
    }
  }
}
