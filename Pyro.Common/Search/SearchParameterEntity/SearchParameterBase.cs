using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.DtoEntity;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.ServiceRoot;

namespace Pyro.Common.Search.SearchParameterEntity
{

  public abstract class SearchParameterBase : DtoServiceSearchParameterLight, ISearchParameterBase
  {
    protected const char OrDelimiter = ',';
    public string RawValue { get; set; }
    public SearchParameter.SearchModifierCode? Modifier { get; set; }
    public string TypeModifierResource { get; set; }
    public List<ISearchParameterBase> ChainedSearchParameterList { get; set; }
    public bool HasLogicalOrProperties { get; set; }
    public bool IsValid { get; set; }
    public string InvalidMessage { get; set; }
    public IDtoRootUrlStore PrimaryRootUrlStore { get; set; }

    public abstract bool TryParseValue(string Value);
    public abstract bool ValidatePrefixes(DtoServiceSearchParameterLight DtoSupportedSearchParameters);
    public abstract object CloneDeep();
    public virtual object CloneDeep(SearchParameterBase Clone)
    {
      Clone.ChainedSearchParameterList = new List<ISearchParameterBase>();
      Clone.ChainedSearchParameterList.AddRange(this.ChainedSearchParameterList);
      Clone.Expression = this.Expression;
      Clone.HasLogicalOrProperties = this.HasLogicalOrProperties;
      Clone.Id = this.Id;
      Clone.InvalidMessage = this.InvalidMessage;
      Clone.IsValid = this.IsValid;
      Clone.Modifier = this.Modifier;
      Clone.Name = this.Name;
      Clone.PrimaryRootUrlStore = this.PrimaryRootUrlStore;
      Clone.RawValue = this.RawValue;
      Clone.Resource = this.Resource;
      if (this.TargetResourceTypeList != null)
      {
        Clone.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
        Clone.TargetResourceTypeList.AddRange(this.TargetResourceTypeList);
      }
      Clone.Type = this.Type;
      Clone.TypeModifierResource = this.TypeModifierResource;
      return Clone;
    }

    public SearchParameterBase()
    {
      this.HasLogicalOrProperties = false;
      this.IsValid = true;
      this.ChainedSearchParameterList = new List<ISearchParameterBase>();
    }
  }
}
