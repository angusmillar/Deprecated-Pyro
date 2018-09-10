using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Enum;
using Pyro.Common.DtoEntity;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.CompositionRoot;
using System.Text;

namespace Pyro.Common.Search.SearchParameterEntity
{
  public class SearchParameterComposite : SearchParameterBase
  {

    #region Constructor
    public SearchParameterComposite()
      : base()
    {
      this.Type = Hl7.Fhir.Model.SearchParamType.Composite;      
    }
    #endregion

    public List<SearchParameterCompositeValue> ValueList { get; set; }

    public override object CloneDeep()
    {
      var Clone = new SearchParameterComposite();
      base.CloneDeep(Clone);
      Clone.ValueList = new List<SearchParameterCompositeValue>();
      Clone.ValueList.AddRange(this.ValueList);
      return Clone;
    }

    public bool TryParseCompositeValue(List<ISearchParameterBase> SearchParameterBaseList, string Values)
    {             
      this.ValueList = new List<SearchParameterCompositeValue>();      
      foreach (string Value in Values.Split(OrDelimiter))
      {
        var DtoSearchParameterCompositeValue = new SearchParameterCompositeValue();
        if (this.Modifier.HasValue && this.Modifier == Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing)
        {
          bool? IsMissing = DtoSearchParameterCompositeValue.ParseModifierEqualToMissing(Value);
          if (IsMissing.HasValue)
          {
            DtoSearchParameterCompositeValue.IsMissing = IsMissing.Value;
            this.ValueList.Add(DtoSearchParameterCompositeValue);
          }
          else
          {
            this.InvalidMessage = $"Found the {Hl7.Fhir.Model.SearchParameter.SearchModifierCode.Missing.GetPyroLiteral()} Modifier yet is value was expected to be true or false yet found '{Value}'. ";
            return false;
          }
        }
        else
        {
          var CompositeSplit = Value.Split(CompositeDelimiter);
          if (CompositeSplit.Count() != SearchParameterBaseList.Count())
          {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The SearchParameter {this.Name} is a Composite type search parameter which means it expects more than a single search value where each value must be separated by a '{CompositeDelimiter}' delimiter character. " +
                      $"However, this instance provided had more or less values than is required for the search parameter used. " +
                      $"{this.Name} expects {SearchParameterBaseList.Count()} values yet {CompositeSplit.Count()} found. ");
            sb.Append("The values expected for this parameter are as follows: ");
            int counter = 1;
            foreach (var item in SearchParameterBaseList)
            {
              sb.Append($"Value: {counter.ToString()} is to be a {item.Type} search parameter type as per the single search parameter '{item.Name}' for the resource type {item.Resource}. ");              
              counter++;
            }
            this.InvalidMessage = sb.ToString();
            return false;
          }

          for (int i = 0; i < CompositeSplit.Length; i++)
          {            
            SearchParameterBaseList[i].RawValue = SearchParameterBaseList[i].Name + ParameterValueDelimiter + CompositeSplit[i];
            if (!SearchParameterBaseList[i].TryParseValue(CompositeSplit[i]))
            {
              int ItemCount = i + 1;
              string Error = $"Value: {ItemCount.ToString()} is to be a {SearchParameterBaseList[i].Type} search parameter type as per the single search parameter '{SearchParameterBaseList[i].Name}' for the resource type {SearchParameterBaseList[i].Resource}. " +
                $"However, an error was found in parsing its value. Further information: {SearchParameterBaseList[i].InvalidMessage}";
              this.InvalidMessage = Error;
              return false;
            }
            else
            {
              DtoSearchParameterCompositeValue.SearchParameterBaseList.Add(SearchParameterBaseList[i]);
            }            
          }
          this.ValueList.Add(DtoSearchParameterCompositeValue);
        }
      }
      if (this.ValueList.Count() > 1)
        this.HasLogicalOrProperties = true;
      if (this.ValueList.Count > 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public override bool TryParseValue(string Values)
    {
      throw new ApplicationException("Internal Server Error: Composite Search Parameters values must be parsed with the specialised method 'TryParseCompositeValue'");
    }
    public override bool ValidatePrefixes(DtoServiceSearchParameterLight DtoSupportedSearchParameters)
    {
      //String Search parameter types never have prefixes so always return true.
      return true;
    }
  }
}
