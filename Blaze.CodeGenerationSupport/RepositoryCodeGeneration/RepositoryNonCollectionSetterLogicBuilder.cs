using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;


namespace Blaze.CodeGenerationSupport.RepositoryCodeGeneration
{
  public static class RepositoryNonCollectionSetterLogicBuilder
  {
    private static StringBuilder _Sb = null;
    private static int _BracketDepthCounter = 0;
    private static int _ChainCounter = 1;
    private static List<string> _PropertyNameChainList = null;
    private static string _CurrentChainName = string.Empty;
    private static string _ResourceName = string.Empty;
    private static string _ResourceTypedName = string.Empty;
    private static string _EntityRootName = string.Empty;
    private const int _BracketIndentDefault = 6;

    public static StringBuilder Build(FhirApiSearchParameterInfo CollectionParameter, string ResourceName, string EntityRootName, string ResourceTypedName)
    {
      _Sb = new StringBuilder();
      _PropertyNameChainList = new List<string>();
      _CurrentChainName = EntityRootName;
      _EntityRootName = EntityRootName;
      _ResourceName = ResourceName;
      _ResourceTypedName = ResourceTypedName;
      _BracketDepthCounter = 0;
      _ChainCounter = 1;

      //Note that this for loop skips the first list item as it is the root resource it's self, i.e 'Patient'
      for (int i = 1; i < CollectionParameter.SearchParameterNavigationPathList.Count; i++)
      {
        var CurrentItem = CollectionParameter.SearchParameterNavigationPathList[i];
        ResolvePropertyChainNames(i, CurrentItem);

        if (i == CollectionParameter.SearchParameterNavigationPathList.Count - 1)
        {
          if (CollectionParameter.Resource == "Observation")
          {
            if (CollectionParameter.SearchName == "value-string")
            {
              //Debug only
            }
          }

          BuildPropertyTargetChainLogic(CollectionParameter);
          BuildIndexSetterLogic(CollectionParameter);
          CloseBrackets();
          _Sb.AppendLine("");
          var debugOnlyString = _Sb.ToString();
        }
      }
      return _Sb;
    }

    private static void BuildIndexSetterLogic(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      if (NonCollectionParameter.Resource == "Observation")
      {
        if (NonCollectionParameter.SearchName == "value-string")
        {
          //Debug only
        }
      }



      string ElementString = string.Empty;
      Type CurrentTargetDataType = NonCollectionParameter.SearchParameterNavigationPathList[NonCollectionParameter.SearchParameterNavigationPathList.Count - 1].DataType;
      ElementString = "Element";

      string ElementNamePostFix = string.Empty;
      if ((CurrentTargetDataType == typeof(FhirBoolean) ||
           CurrentTargetDataType == typeof(Code) ||
           CurrentTargetDataType == typeof(Id) ||
           CurrentTargetDataType == typeof(PositiveInt)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        TokenIndexStetter(NonCollectionParameter);
      }
      else if (CurrentTargetDataType == typeof(Coding) ||
               CurrentTargetDataType == typeof(Identifier) ||
               CurrentTargetDataType == typeof(Age) ||
               CurrentTargetDataType == typeof(Location.PositionComponent))
      {
        if (CurrentTargetDataType == typeof(Location.PositionComponent))
        {

        }
        StandardIndexStetter(NonCollectionParameter);
        TokenIndexStetter(NonCollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(FhirDateTime) ||
                CurrentTargetDataType == typeof(Date) ||
                CurrentTargetDataType == typeof(Instant)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        DateIndexStetter(NonCollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(Period)))
      {
        StandardIndexStetter(NonCollectionParameter);
        DatePeriodIndexStetter(NonCollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(ResourceReference)))
      {
        ResourceReferenceIndexStetter(NonCollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(Integer)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        NumberIndexStetter(NonCollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(Duration)))
      {
        StandardIndexStetter(NonCollectionParameter);
        NumberIndexStetter(NonCollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(FhirUri) ||
                CurrentTargetDataType == typeof(Oid)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        UriIndexStetter(NonCollectionParameter);
      }
      else if (CurrentTargetDataType == typeof(Money) ||
               CurrentTargetDataType == typeof(Quantity))
      {
        StandardIndexStetter(NonCollectionParameter);
        QuantityIndexStetter(NonCollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(FhirString)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        if (NonCollectionParameter.SearchParamType == SearchParamType.Token)
        {
          TokenIndexStetter(NonCollectionParameter);
        }
        else if (NonCollectionParameter.SearchParamType == SearchParamType.String)
        {
          StringIndexStetter(NonCollectionParameter);
        }
        else
        {
          throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a FhirString DataType of: '{0}' with a Fhir SearchParamType of: '{1}' ", CurrentTargetDataType.ToString(), NonCollectionParameter.SearchParamType.ToString()));
        }
      }
      else if (GenericCodeDataTypeEnums.GenericCodeDataTypeCodeGen.IsSubclassOfRawGeneric(typeof(Code<>), CurrentTargetDataType))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        TokenIndexStetter(NonCollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(Element)))
      {
        ElementString = string.Empty;
        Type TargetChoiceDataType = NonCollectionParameter.TargetFhirChoiceType;

        if (NonCollectionParameter.SearchParamType == SearchParamType.Token)
        {
          if (TargetChoiceDataType == typeof(Identifier))
          {
            StandardIndexStetter(NonCollectionParameter);
            TokenIndexStetter(NonCollectionParameter);
          }
          else if (TargetChoiceDataType == typeof(FhirBoolean))
          {
            StandardIndexStetter(NonCollectionParameter, ElementString);
            TokenIndexStetter(NonCollectionParameter);
          }
          else if (TargetChoiceDataType == typeof(Identifier))
          {
            StandardIndexStetter(NonCollectionParameter);
            TokenIndexStetter(NonCollectionParameter);
          }
          else if (TargetChoiceDataType == typeof(FhirDateTime))
          {
            StandardIndexStetter(NonCollectionParameter, ElementString);
            TokenIndexStetter(NonCollectionParameter);
          }
          else
          {
            throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a ChoiceDataType of '{0}' with a SearchIndex of {1} for the Resource '{2}' it can not handle", TargetChoiceDataType.ToString(), NonCollectionParameter.SearchParamType.ToString(), NonCollectionParameter.Resource));
          }
        }
        else if (NonCollectionParameter.SearchParamType == SearchParamType.Reference)
        {
          if (TargetChoiceDataType == typeof(ResourceReference))
          {
            ResourceReferenceIndexStetter(NonCollectionParameter);
          }
          else if (TargetChoiceDataType == typeof(FhirUri))
          {
            ResourceReferenceIndexStetter(NonCollectionParameter);
          }
          else
          {
            throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a ChoiceDataType of '{0}' with a SearchIndex of {1} for the Resource '{2}' it can not handle", TargetChoiceDataType.ToString(), NonCollectionParameter.SearchParamType.ToString(), NonCollectionParameter.Resource));
          }
        }
        else if (NonCollectionParameter.SearchParamType == SearchParamType.Date)
        {
          if (TargetChoiceDataType == typeof(FhirDateTime) ||
            TargetChoiceDataType == typeof(Date))
          {
            StandardIndexStetter(NonCollectionParameter, ElementString);
            DateIndexStetter(NonCollectionParameter);
          }
          else if (TargetChoiceDataType == typeof(Age))
          {
            StandardIndexStetter(NonCollectionParameter);
            DateIndexStetter(NonCollectionParameter);
          }
          else if (TargetChoiceDataType == typeof(Period))
          {
            StandardIndexStetter(NonCollectionParameter);
            DatePeriodIndexStetter(NonCollectionParameter);
          }
          else
          {
            throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a ChoiceDataType of '{0}' with a SearchIndex of {1} for the Resource '{2}' it can not handle", TargetChoiceDataType.ToString(), NonCollectionParameter.SearchParamType.ToString(), NonCollectionParameter.Resource));
          }
        }
        else if (NonCollectionParameter.SearchParamType == SearchParamType.Quantity)
        {
          if (TargetChoiceDataType == typeof(Quantity))
          {
            StandardIndexStetter(NonCollectionParameter);
            QuantityIndexStetter(NonCollectionParameter);
          }
          else
          {
            throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a ChoiceDataType of '{0}' with a SearchIndex of {1} for the Resource '{2}' it can not handle", TargetChoiceDataType.ToString(), NonCollectionParameter.SearchParamType.ToString(), NonCollectionParameter.Resource));
          }
        }
        else if (NonCollectionParameter.SearchParamType == SearchParamType.String)
        {
          if (TargetChoiceDataType == typeof(FhirString))
          {
            StandardIndexStetter(NonCollectionParameter);
            StringIndexStetter(NonCollectionParameter);
          }
          else
          {
            throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a ChoiceDataType of '{0}' with a SearchIndex of {1} for the Resource '{2}' it can not handle", TargetChoiceDataType.ToString(), NonCollectionParameter.SearchParamType.ToString(), NonCollectionParameter.Resource));
          }
        }
        else
        {
          throw new ApplicationException(String.Format("The NonCollection search parameter is type Element yet it's Choice data Type is null? Resource: {0}, Search Parameter: {1}", NonCollectionParameter.Resource, CurrentTargetDataType.ToString()));
        }

      }
      else
      {
        throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a DataType for the Resource '{0}' it can not handle, DataType was: {1}", NonCollectionParameter.Resource, CurrentTargetDataType.ToString()));
      }
    }

    private static void StandardIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter, string ElementNamePostFix = "")
    {
      _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;

      //_Sb.AppendLine(String.Format("{0}if ({1}{2} is {3})", DepthSpace(_BracketDepthCounter), _CurrentChainName, ElementNamePostFix, NonCollectionParameter.TargetFhirLogicalType.NameGenericType()));

      _Sb.AppendLine(String.Format("{0}if ({1}{2} is {3})", DepthSpace(_BracketDepthCounter), _CurrentChainName, ElementNamePostFix, NonCollectionParameter.TargetFhirLogicalType.NameGenericType()));

      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}var Index = new {1}Index();", DepthSpace(_BracketDepthCounter), NonCollectionParameter.SearchParamType.ToString()));
      _Sb.AppendLine(String.Format("{0}Index = IndexSettingSupport.SetIndex(Index, {1}{2}) as {3}Index;", DepthSpace(_BracketDepthCounter), _CurrentChainName, ElementNamePostFix, NonCollectionParameter.SearchParamType.ToString()));
      _Sb.AppendLine(String.Format("{0}if (Index != null)", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
    }


    private static void TokenIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_Code = Index.Code;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_System = Index.System;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
    }

    private static void DateIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_DateTimeOffset = Index.DateTimeOffset;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
    }

    private static void DatePeriodIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_DateTimeOffsetLow = Index.DateTimeOffset;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_DateTimeOffsetHigh = Index.DateTimeOffset;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
    }

    private static void StringIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_String = Index.String;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
    }

    private static void UriIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_Uri = Index.Uri;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
    }

    private static void NumberIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_Number = Index.Number;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
    }

    private static void QuantityIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_Code = Index.Code;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_System = Index.System;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_Quantity = Index.Quantity;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
    }

    private static void ResourceReferenceIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter, bool IsElementDataType = false)
    {
      _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;

      _Sb.AppendLine(String.Format("{0}if ({1} is ResourceReference)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}var Index = new {1}Index();", DepthSpace(_BracketDepthCounter), NonCollectionParameter.SearchParamType.ToString()));
      _Sb.AppendLine(String.Format("{0}Index = IndexSettingSupport.SetIndex(Index, {1}, FhirRequestUri, this) as {2}Index;", DepthSpace(_BracketDepthCounter), _CurrentChainName, NonCollectionParameter.SearchParamType.ToString()));

      //      _Sb.AppendLine(String.Format("{0}var Index = IndexSettingSupport.SetIndex<{1}Index>(new {1}Index(), {2}, FhirRequestUri, this);", DepthSpace(_BracketDepthCounter), NonCollectionParameter.SearchParamType.ToString(), _CurrentChainName));      
      _Sb.AppendLine(String.Format("{0}if (Index != null)", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_Type = Index.Type;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_FhirId = Index.FhirId;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
      _Sb.AppendLine(String.Format("{0}if (Index.Url != null)", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_Url = Index.Url;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
      _BracketDepthCounter--;
      _Sb.AppendLine(String.Format("{0}}}", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}else", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName)));
      _BracketDepthCounter--;
      _Sb.AppendLine(String.Format("{0}}}", DepthSpace(_BracketDepthCounter)));

    }

    private static void BuildPropertyTargetChainLogic(FhirApiSearchParameterInfo CollectionParameter)
    {
      foreach (var NullableItem in _PropertyNameChainList)
      {
        _CurrentChainName = _CurrentChainName + "." + NullableItem;

        if (_ChainCounter < (CollectionParameter.SearchParameterNavigationPathList.Count - 1))
        {
          if (CollectionParameter.SearchParameterNavigationPathList[_ChainCounter].IsCollection)
          {
            _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2})", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName));
            _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
            _BracketDepthCounter++;
            _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());
          }
          else
          {
            _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
            _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
            _BracketDepthCounter++;
          }
        }
        _ChainCounter++;
      }
    }

    private static void ResolvePropertyChainNames(int i, FhirSearchParameterSearchPathElement CurrentItem)
    {
      if (i > 1)
      {
        RepositoryCodeGenSupport.ResolvePropertyNameChainList(i, CurrentItem, _PropertyNameChainList);
      }
      else
      {
        _PropertyNameChainList.Add(RepositoryCodeGenSupport.UppercaseFirst(CurrentItem.PropertyName));
      }
    }

    static string DepthSpace(int DepthCounter)
    {
      return RepositoryCodeGenSupport.DepthSpace(DepthCounter, _BracketIndentDefault);
    }

    private static void CloseBrackets()
    {
      RepositoryCodeGenSupport.CloseBrackets(_Sb, _BracketDepthCounter, _BracketIndentDefault);
    }

  }
}
