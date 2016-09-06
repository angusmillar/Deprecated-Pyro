using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Enum;

namespace Blaze.Common.BusinessEntities.Search
{

  public abstract class DtoSearchParameterBase
  {
    protected const char OrDelimiter = ',';
    public FhirSearchEnum.SearchParameterNameType Name { get; set; }
    public FHIRDefinedType Resource { get; set; }
    public string RawValue { get; set; }
    public DatabaseEnum.DbIndexType DbSearchParameterType { get; set; }
    public FhirSearchEnum.SearchModifierType Modifier { get; set; }
    public FHIRDefinedType? TypeModifierResource { get; set; }    
    public bool HasLogicalOrProperties { get; set; }    
    public string DbPropertyName { get; set; }
    public bool IsDbCollection { get; set; }
    public bool IsValid { get; set; }
    public string InvalidMessage { get; set; }

    public abstract bool TryParseValue(string Value);
    public abstract bool ValidatePrefixes(DtoSupportedSearchParameters DtoSupportedSearchParameters);


    public DtoSearchParameterBase()
    {
      this.HasLogicalOrProperties = false;
    }
  }
}
