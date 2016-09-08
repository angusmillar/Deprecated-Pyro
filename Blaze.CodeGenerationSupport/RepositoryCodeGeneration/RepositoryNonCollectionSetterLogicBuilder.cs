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
          //if (CollectionParameter.Resource == "Observation")
          //{
          //  if (CollectionParameter.SearchName == "value-string")
          //  {
          //    //Debug only
          //  }
          //}

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
      Type TargetChoiceDataTypeTest = NonCollectionParameter.TargetFhirChoiceType;
      Type Test = NonCollectionParameter.TargetFhirLogicalType;
      Type CurrentTargetDataType = NonCollectionParameter.SearchParameterNavigationPathList[NonCollectionParameter.SearchParameterNavigationPathList.Count - 1].DataType;
      if (Test != CurrentTargetDataType)
      {
        //throw new Exception();
      }
      ElementString = "Element";


      if ((CurrentTargetDataType == typeof(FhirBoolean) ||
           CurrentTargetDataType == typeof(Code) ||
           CurrentTargetDataType == typeof(Id) ||
           CurrentTargetDataType == typeof(PositiveInt)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.TokenIndex);
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
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.TokenIndex);
      }
      else if ((CurrentTargetDataType == typeof(FhirDateTime) ||                
                CurrentTargetDataType == typeof(Instant)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.DateTimeIndex);
      }
      else if (CurrentTargetDataType == typeof(Date))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.DateIndex);
      }

      else if ((CurrentTargetDataType == typeof(Period)))
      {
        StandardIndexStetter(NonCollectionParameter);
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.DateTimePeriodIndex);
      }
      else if ((CurrentTargetDataType == typeof(ResourceReference)))
      {
        ResourceReferenceIndexStetter(NonCollectionParameter, "");
      }
      else if ((CurrentTargetDataType == typeof(Integer)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.NumberIndex);
      }
      else if ((CurrentTargetDataType == typeof(Duration)))
      {
        StandardIndexStetter(NonCollectionParameter);
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.NumberIndex);
      }
      else if ((CurrentTargetDataType == typeof(FhirUri) ||
                CurrentTargetDataType == typeof(Oid)))
      {
        if (NonCollectionParameter.SearchParamType == SearchParamType.Reference)
        {
          ResourceReferenceIndexStetter(NonCollectionParameter, ElementString);
        }
        else if (NonCollectionParameter.SearchParamType == SearchParamType.Uri)
        {
          StandardIndexStetter(NonCollectionParameter, ElementString);
          DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.UriIndex);
        }
        else
        {
          throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a FhirUri or Oid DataType of: '{0}' with a Fhir SearchParamType of: '{1}' ", CurrentTargetDataType.ToString(), NonCollectionParameter.SearchParamType.ToString()));
        }
      }
      else if (CurrentTargetDataType == typeof(Money) ||
               CurrentTargetDataType == typeof(Quantity))
      {
        StandardIndexStetter(NonCollectionParameter);
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex);
      }
      else if ((CurrentTargetDataType == typeof(FhirString)))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        if (NonCollectionParameter.SearchParamType == SearchParamType.Token)
        {
          DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.TokenIndex);
        }
        else if (NonCollectionParameter.SearchParamType == SearchParamType.String)
        {
          DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.StringIndex);
        }
        else
        {
          throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a FhirString DataType of: '{0}' with a Fhir SearchParamType of: '{1}' ", CurrentTargetDataType.ToString(), NonCollectionParameter.SearchParamType.ToString()));
        }
      }
      else if (GenericCodeDataTypeEnums.GenericCodeDataTypeCodeGen.IsSubclassOfRawGeneric(typeof(Code<>), CurrentTargetDataType))
      {
        StandardIndexStetter(NonCollectionParameter, ElementString);
        DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.TokenIndex);
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
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.TokenIndex);
          }
          else if (TargetChoiceDataType == typeof(FhirBoolean))
          {
            StandardIndexStetter(NonCollectionParameter, ElementString);
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.TokenIndex);
          }
          else if (TargetChoiceDataType == typeof(Identifier))
          {
            StandardIndexStetter(NonCollectionParameter);
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.TokenIndex);
          }
          else if (TargetChoiceDataType == typeof(FhirDateTime))
          {
            StandardIndexStetter(NonCollectionParameter, ElementString);
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.TokenIndex);
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
            ResourceReferenceIndexStetter(NonCollectionParameter, ElementString);
          }
          else if (TargetChoiceDataType == typeof(FhirUri))
          {
            ResourceReferenceIndexStetter(NonCollectionParameter, ElementString);
          }
          else
          {
            throw new ApplicationException(String.Format("The NonCollection BuildIndexSetterLogic was given a ChoiceDataType of '{0}' with a SearchIndex of {1} for the Resource '{2}' it can not handle", TargetChoiceDataType.ToString(), NonCollectionParameter.SearchParamType.ToString(), NonCollectionParameter.Resource));
          }
        }
        else if (NonCollectionParameter.SearchParamType == SearchParamType.Date)
        {
          if (TargetChoiceDataType == typeof(FhirDateTime))
          {
            StandardIndexStetter(NonCollectionParameter, ElementString);
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.DateTimeIndex);
          }
          else if (TargetChoiceDataType == typeof(Period))
          {
            StandardIndexStetter(NonCollectionParameter);
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.DateTimePeriodIndex);
          }
          else if (TargetChoiceDataType == typeof(Date) ||
                   TargetChoiceDataType == typeof(Age))
          {
            StandardIndexStetter(NonCollectionParameter);
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.DateIndex);
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
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.QuantityIndex);
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
            DynamicIndexStetter(NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType.StringIndex);
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

      _Sb.AppendLine(String.Format("{0}if ({1}{2} is {3})", DepthSpace(_BracketDepthCounter), _CurrentChainName, ElementNamePostFix, NonCollectionParameter.TargetFhirLogicalType.NameGenericType()));

      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GetServerSearchIndexTypeString(NonCollectionParameter)));

      string DbIndexType = DatabaseModelInfo.GetServerSearchIndexTypeString(NonCollectionParameter);
      string ReturnType = DatabaseModelInfo.GetServerSearchIndexTypeString(NonCollectionParameter);
      _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName + ElementNamePostFix, DbIndexType, ReturnType)));

      _Sb.AppendLine(String.Format("{0}if (Index != null)", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
    }

    private static void DynamicIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter, Common.Enum.DatabaseEnum.DbIndexType DbIndexType)
    {
      foreach (string PropertyName in DatabaseModelInfo.BlazeIndexTypeToDbPropertyNameStringList_Dictonary[DbIndexType])
      {
        _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_{2} = Index.{2};",
        DepthSpace(_BracketDepthCounter),
        DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName),
        PropertyName));
      }
    }

    private static void ResourceReferenceIndexStetter(FhirApiSearchParameterInfo NonCollectionParameter, string ElementNamePostFix)
    {
      BundleResourceCustomLogic(NonCollectionParameter);

      _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;

      _Sb.AppendLine(String.Format("{0}if ({1}{2} is {3})", DepthSpace(_BracketDepthCounter), _CurrentChainName, ElementNamePostFix, NonCollectionParameter.TargetFhirLogicalType.NameGenericType()));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GetServerSearchIndexTypeString(NonCollectionParameter)));
      string DbIndexType = DatabaseModelInfo.GetServerSearchIndexTypeString(NonCollectionParameter);
      string ReturnType = DatabaseModelInfo.GetServerSearchIndexTypeString(NonCollectionParameter);
      _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName + ElementNamePostFix, DbIndexType, ReturnType, true)));

      _Sb.AppendLine(String.Format("{0}if (Index != null)", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_{2} = Index.{2};",
        DepthSpace(_BracketDepthCounter),
        DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName),
        DatabaseModelInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Type));
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_{2} = Index.{2};",
        DepthSpace(_BracketDepthCounter),
        DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName),
        DatabaseModelInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId));
      _Sb.AppendLine(String.Format("{0}if (Index.{1} != null)",
        DepthSpace(_BracketDepthCounter),
        DatabaseModelInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Url));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_{2} = Index.{2};",
        DepthSpace(_BracketDepthCounter),
        DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName),
        DatabaseModelInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Url));
      _BracketDepthCounter--;
      _Sb.AppendLine(String.Format("{0}}}", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}else", DepthSpace(_BracketDepthCounter)));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}ResourseEntity.{1}_{2} = Index.{2};",
        DepthSpace(_BracketDepthCounter),
        DatabaseModelInfo.ContructSearchParameterName(NonCollectionParameter.SearchName),
        DatabaseModelInfo.DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ServiceRootURL_StoreID));

      _BracketDepthCounter--;
      _Sb.AppendLine(String.Format("{0}}}", DepthSpace(_BracketDepthCounter)));

    }

    private static void BundleResourceCustomLogic(FhirApiSearchParameterInfo NonCollectionParameter)
    {
      if (NonCollectionParameter.Resource == ModelInfo.GetFhirTypeNameForType(typeof(Bundle)) && NonCollectionParameter.SearchName == "composition")
      {
        _Sb.AppendLine(String.Format("{0}if (ResourceTyped.Type == Bundle.BundleType.Document)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
      }

      if (NonCollectionParameter.Resource == ModelInfo.GetFhirTypeNameForType(typeof(Bundle)) && NonCollectionParameter.SearchName == "message")
      {
        _Sb.AppendLine(String.Format("{0}if (ResourceTyped.Type == Bundle.BundleType.Message)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
      }
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
            bool IsProcessed = false;
            if (!IsProcessed)
            {
              if (CollectionParameter.SearchParameterNavigationPathList[_ChainCounter].XPathComponent != null && CollectionParameter.SearchParameterNavigationPathList[_ChainCounter].XPathComponent.HasChoiceSpecifier)
              {
                FhirXPathComponent XPathComponent = CollectionParameter.SearchParameterNavigationPathList[_ChainCounter].XPathComponent;
                if (XPathComponent.ChoiceSpecifier.AttributeName == null && XPathComponent.ChoiceSpecifier.ElementName == null)
                {
                  int ItemIndex = 0;
                  if (int.TryParse(XPathComponent.ChoiceSpecifier.Value, out ItemIndex))
                  {
                    _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
                    _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
                    _BracketDepthCounter++;

                    _Sb.AppendLine(String.Format("{0}if ({1}[{2}] != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName, ItemIndex));
                    _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));

                    _BracketDepthCounter++;
                    string TempChainName = _CurrentChainName;
                    _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());

                    _Sb.AppendLine(String.Format("{0}var {1} = {2}[{3}];", DepthSpace(_BracketDepthCounter), _CurrentChainName, TempChainName, ItemIndex));

                    IsProcessed = true;
                  }
                }
              }
            }
            if (!IsProcessed)
            {
              _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2})", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName));
              _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
              _BracketDepthCounter++;
              _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());
            }
          }
          else
          {
            _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
            _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
            _BracketDepthCounter++;

            if (CollectionParameter.SearchParameterNavigationPathList[_ChainCounter].XPathComponent != null && CollectionParameter.SearchParameterNavigationPathList[_ChainCounter].XPathComponent.HasChoiceSpecifier)
            {
              FhirXPathComponent XPathComponent = CollectionParameter.SearchParameterNavigationPathList[_ChainCounter].XPathComponent;
              if (XPathComponent.ChoiceSpecifier.AttributeName == null && XPathComponent.ChoiceSpecifier.ElementName == null)
              {
                int ItemIndex = 0;
                if (int.TryParse(XPathComponent.ChoiceSpecifier.Value, out ItemIndex))
                {
                  _Sb.AppendLine(String.Format("{0}if ({1}[{2}] != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName, ItemIndex));
                  _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));

                  _BracketDepthCounter++;
                  string TempChainName = _CurrentChainName;
                  _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());

                  _Sb.AppendLine(String.Format("{0}var {1} = {2}[{3}];", DepthSpace(_BracketDepthCounter), _CurrentChainName, TempChainName, ItemIndex));
                }
              }
            }

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
