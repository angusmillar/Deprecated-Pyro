using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.Enum;

namespace Blaze.Common.BusinessEntities.Search
{

  public abstract class DtoSearchParameterBase
  {
    protected const char OrDelimiter = ',';
    public FhirSearchEnum.SearchParameterNameType Name { get; set; }
    public FHIRDefinedType Resource { get; set; }
    public string RawValue { get; set; }
    public DatabaseEnum.BlazeIndexType DbSearchParameterType { get; set; }
    public FhirSearchEnum.SearchModifierType Modifier { get; set; }
    public ResourceType? TypeModifierResource { get; set; }
    public FhirSearchEnum.SearchPrefixType Prefix { get; set; }
    public bool HasLogicalOrProperties { get; set; }
    public abstract bool TryParseValue(string Value);
    public DtoSearchParameterBase()
    {
      this.HasLogicalOrProperties = false;
    }
  }
}
