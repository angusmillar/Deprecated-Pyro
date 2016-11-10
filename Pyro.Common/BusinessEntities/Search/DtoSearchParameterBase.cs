using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;

namespace Pyro.Common.BusinessEntities.Search
{

  public abstract class DtoSearchParameterBase
  {
    protected const char OrDelimiter = ',';
    public FhirSearchEnum.SearchParameterNameType Name { get; set; }
    public FHIRAllTypes? Resource { get; set; }
    public string RawValue { get; set; }
    public DatabaseEnum.DbIndexType DbSearchParameterType { get; set; }
    public FhirSearchEnum.SearchModifierType Modifier { get; set; }
    public string TypeModifierResource { get; set; }
    public Validation.SearchParametersValidationOperationOutcome ChainedSearchParameter { get; set; }
    public bool HasLogicalOrProperties { get; set; }
    public string DbPropertyName { get; set; }
    public bool IsDbCollection { get; set; }
    public bool IsValid { get; set; }
    public string InvalidMessage { get; set; }
    public Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore { get; set; }

    public abstract bool TryParseValue(string Value);
    public abstract bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters);


    public DtoSearchParameterBase()
    {
      this.HasLogicalOrProperties = false;
      this.IsValid = true;
    }
  }
}
