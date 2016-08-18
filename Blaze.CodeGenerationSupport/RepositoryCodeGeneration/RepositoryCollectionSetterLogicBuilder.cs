using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.Enum;
using Hl7.Fhir.Model;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;

namespace Blaze.CodeGenerationSupport.RepositoryCodeGeneration
{
  static class RepositoryCollectionSetterLogicBuilder
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
          BuildPropertyTargetChainLogic(CollectionParameter);
          BuildIndexSetterLogic(CollectionParameter);
          _Sb.AppendLine(String.Format("{0}{1}.{2}{3}.Add(Index);", DepthSpace(_BracketDepthCounter), _ResourceTypedName, CollectionParameter.SearchName.Replace("-", "_").ToLower(), DatabaseModelInfo.ListPostfixText));
          CloseBrackets();
          _Sb.AppendLine("");
          var debugOnlyString = _Sb.ToString();
        }
      }
      return _Sb;
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

    private static void BuildIndexSetterLogic(FhirApiSearchParameterInfo CollectionParameter)
    {
      if (CollectionParameter.Resource == "CarePlan")
      {
        if (CollectionParameter.SearchName == "activitydate")
        {
          //Debug only
        }
      }


      string ElementString = "Element";
      Type CurrentTargetDataType = CollectionParameter.TargetFhirType;

      if ((CurrentTargetDataType == typeof(PositiveInt) ||
           CurrentTargetDataType == typeof(Integer) ||
           CurrentTargetDataType == typeof(Markdown) ||
           CurrentTargetDataType == typeof(FhirDateTime) ||
           CurrentTargetDataType == typeof(FhirBoolean) ||
           CurrentTargetDataType == typeof(Annotation)))
      {
        StandardIndexStetter(CollectionParameter, string.Empty, ElementString);
      }
      else if ((CurrentTargetDataType == typeof(FhirUri) ||
                CurrentTargetDataType == typeof(FhirString) ||
                CurrentTargetDataType == typeof(Code) ||
                CurrentTargetDataType == typeof(Oid)))
      {
        StandardIndexStetter(CollectionParameter, ElementString, ElementString);
      }
      else if (GenericCodeDataTypeEnums.GenericCodeDataTypeCodeGen.IsSubclassOfRawGeneric(typeof(Code<>), CurrentTargetDataType))
      {
        StandardIndexStetter(CollectionParameter, ElementString, ElementString);
      }
      else if ((CurrentTargetDataType == typeof(CodeableConcept)))
      {
        CodableConceptIndexStetter(CollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(HumanName)))
      {
        HumanNameIndexStetter(CollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(Address)))
      {
        AddressIndexStetter(CollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(ContactPoint)))
      {
        ContactPointIndexStetter(CollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(ResourceReference) ||
                CurrentTargetDataType == typeof(Resource)))
      {
        ReferenceIndexStetter(CollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(Period) ||
                CurrentTargetDataType == typeof(Timing)))
      {
        DateIndexStetter(CollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(SimpleQuantity) ||
                CurrentTargetDataType == typeof(Coding) ||
                CurrentTargetDataType == typeof(Quantity) ||
                CurrentTargetDataType == typeof(Range) ||
                CurrentTargetDataType == typeof(Identifier)))
      {
        StandardIndexStetter(CollectionParameter);
      }
      else if ((CurrentTargetDataType == typeof(Element)))
      {
        ElementString = string.Empty;
        Type TargetChoiceDataType = CollectionParameter.TargetFhirChoiceType;

        if (CollectionParameter.SearchParamType == SearchParamType.Token)
        {
          if (CollectionParameter.TargetFhirChoiceType == typeof(CodeableConcept))
          {
            CodableConceptIndexStetter(CollectionParameter);
          }
          else if (CollectionParameter.TargetFhirChoiceType == typeof(FhirBoolean))
          {
            StandardIndexStetter(CollectionParameter, string.Empty, ElementString);
          }
          else if (CollectionParameter.TargetFhirChoiceType == typeof(Quantity))
          {
            StandardIndexStetter(CollectionParameter);
          }
          else if (CollectionParameter.TargetFhirChoiceType == typeof(Range))
          {
            StandardIndexStetter(CollectionParameter);
          }
          else
          {
            throw new ApplicationException(String.Format("The Collection search parameter type {0} could not handle the Logical element type of {1}", CollectionParameter.SearchParamType.ToString(), CollectionParameter.TargetFhirLogicalType.ToString()));
          }
        }
        else if (CollectionParameter.SearchParamType == SearchParamType.Reference)
        {
          if (CollectionParameter.TargetFhirChoiceType == typeof(ResourceReference))
          {
            ReferenceIndexStetter(CollectionParameter);
          }
          else if (CollectionParameter.TargetFhirChoiceType == typeof(FhirUri))
          {
            StandardIndexStetter(CollectionParameter, ElementString, ElementString);
          }
          else
          {
            throw new ApplicationException(String.Format("The Collection search parameter type {0} could not handle the Logical element type of {1}", CollectionParameter.SearchParamType.ToString(), CollectionParameter.TargetFhirLogicalType.ToString()));
          }
        }
        else if (CollectionParameter.SearchParamType == SearchParamType.Date)
        {
          if (CollectionParameter.TargetFhirChoiceType == typeof(Timing))
          {
            DateIndexStetter(CollectionParameter);
          }
          else if (CollectionParameter.TargetFhirChoiceType == typeof(Period))
          {
            DateIndexStetter(CollectionParameter);
          }
          else if (CollectionParameter.TargetFhirChoiceType == typeof(FhirString))
          {
            DateIndexStetter(CollectionParameter);
          }
          else
          {
            throw new ApplicationException(String.Format("The Collection search parameter type {0} could not handle the Logical element type of {1}", CollectionParameter.SearchParamType.ToString(), CollectionParameter.TargetFhirLogicalType.ToString()));
          }
        }
        else if (CollectionParameter.SearchParamType == SearchParamType.Quantity)
        {
          if (CollectionParameter.TargetFhirChoiceType == typeof(Quantity))
          {
            StandardIndexStetter(CollectionParameter);
          }
          else
          {
            throw new ApplicationException(String.Format("The Collection search parameter type {0} could not handle the Logical element type of {1}", CollectionParameter.SearchParamType.ToString(), CollectionParameter.TargetFhirLogicalType.ToString()));
          }
        }
        else if (CollectionParameter.SearchParamType == SearchParamType.String)
        {
          if (CollectionParameter.TargetFhirChoiceType == typeof(FhirString))
          {
            StandardIndexStetter(CollectionParameter, ElementString, ElementString);
          }
          else
          {
            throw new ApplicationException(String.Format("The Collection search parameter type {0} could not handle the Logical element type of {1}", CollectionParameter.SearchParamType.ToString(), CollectionParameter.TargetFhirLogicalType.ToString()));
          }
        }
        else if (CollectionParameter.SearchParamType == SearchParamType.Number)
        {
          throw new ApplicationException(String.Format("The Collection search parameter type {0} could not handle the Logical element type of {1}", CollectionParameter.SearchParamType.ToString(), CollectionParameter.TargetFhirLogicalType.ToString()));
        }
        else if (CollectionParameter.SearchParamType == SearchParamType.Uri)
        {
          throw new ApplicationException(String.Format("The Collection search parameter type {0} could not handle the Logical element type of {1}", CollectionParameter.SearchParamType.ToString(), CollectionParameter.TargetFhirLogicalType.ToString()));
        }
        else if (CollectionParameter.SearchParamType == SearchParamType.Composite)
        {
          throw new ApplicationException(String.Format("The Collection search parameter type {0} could not handle the Logical element type of {1}", CollectionParameter.SearchParamType.ToString(), CollectionParameter.TargetFhirLogicalType.ToString()));
        }
        else
        {
          throw new ApplicationException(String.Format("The Collection search parameter type is unknown: {0}", CollectionParameter.SearchParamType.ToString()));
        }
      }
      else
      {
        throw new ApplicationException(String.Format("The Collection BuildIndexSetterLogic was given a DataType it can not handle for the resource {0}, DataType was: {1}", CollectionParameter.Resource, CurrentTargetDataType.ToString()));
      }
    }

    private static void StandardIndexStetter(FhirApiSearchParameterInfo CollectionParameter, string LoopTargetPostFix = "", string IndexSetterNamePostFix = "")
    {
      if (CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1].IsCollection)
      {
        _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _ChainCounter++;

        _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2}{3})", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName, LoopTargetPostFix));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;

        _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());

        _Sb.AppendLine(String.Format("{0}if ({1} is {2})", DepthSpace(_BracketDepthCounter), _CurrentChainName, CollectionParameter.TargetFhirLogicalType.NameGenericType()));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;

        _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));


        string DbIndexType = DatabaseModelInfo.GetServerSearchIndexTypeString(CollectionParameter);
        string ReturnType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
        _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName, DbIndexType, ReturnType)));


      }
      else
      {
        _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _Sb.AppendLine(String.Format("{0}if ({1}{2} is {3})", DepthSpace(_BracketDepthCounter), _CurrentChainName, IndexSetterNamePostFix, CollectionParameter.TargetFhirLogicalType.NameGenericType()));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;

        _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));

        string DbIndexType = DatabaseModelInfo.GetServerSearchIndexTypeString(CollectionParameter);
        string ReturnType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
        _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName + IndexSetterNamePostFix, DbIndexType, ReturnType)));

      }
    }

    private static void CodableConceptIndexStetter(FhirApiSearchParameterInfo CollectionParameter)
    {
      if (CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1].IsCollection)
      {
        _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _ChainCounter++;

        _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2})", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());
      }
      _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _ChainCounter++;

      if (CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1].DataType == typeof(Element))
      {
        _Sb.AppendLine(String.Format("{0}if ({1} is CodeableConcept)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _Sb.AppendLine(String.Format("{0}CodeableConcept CodeableConcept = {1} as CodeableConcept;", DepthSpace(_BracketDepthCounter), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}foreach (var item{1} in CodeableConcept.Coding)", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString()));
      }
      else
      {
        _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2}.Coding)", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName));
      }
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());

      _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));

      string DbIndexType = DatabaseModelInfo.GetServerSearchIndexTypeString(CollectionParameter);
      string ReturnType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
      _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName, DbIndexType, ReturnType)));

    }


    private static void HumanNameIndexStetter(FhirApiSearchParameterInfo CollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _ChainCounter++;

      if (CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1].IsCollection)
      {
        _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2})", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());
      }

      _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));
      string DbIndexType = DatabaseModelInfo.GetServerSearchIndexTypeString(CollectionParameter);
      string ReturnType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
      _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName, DbIndexType, ReturnType)));
      
    }

    private static void ContactPointIndexStetter(FhirApiSearchParameterInfo CollectionParameter)
    {
      FhirXPath XFhirPath = FhirXPathFactory.FhirXPathFactoryParse(CollectionParameter.SearchPath);
      if (CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1].IsCollection)
      {
        _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2})", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());
      }
      if (XFhirPath.FhirXPathComponentList[XFhirPath.FhirXPathComponentList.Count - 1].HasChoiceSpecifier)
      {
        FhirXPathComponent FhirXPathComponent = XFhirPath.FhirXPathComponentList[XFhirPath.FhirXPathComponentList.Count - 1];
        _Sb.AppendLine(String.Format("{0}if ({1}.{2} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName, RepositoryCodeGenSupport.UppercaseFirst(FhirXPathComponent.ChoiceSpecifier.ElementName)));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _Sb.AppendLine(String.Format("{0}if ((ContactPoint.ContactPointSystem){1}.{2} == ContactPoint.ContactPointSystem.{3})", DepthSpace(_BracketDepthCounter), _CurrentChainName, RepositoryCodeGenSupport.UppercaseFirst(FhirXPathComponent.ChoiceSpecifier.ElementName), RepositoryCodeGenSupport.UppercaseFirst(FhirXPathComponent.ChoiceSpecifier.Value)));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
      }

      _Sb.AppendLine(String.Format("{0}if ({1} is {2})", DepthSpace(_BracketDepthCounter), _CurrentChainName, CollectionParameter.TargetFhirLogicalType.Name));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;

      _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));
      
      string DbIndexType = DatabaseModelInfo.GetServerSearchIndexTypeString(CollectionParameter);
      string ReturnType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
      _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName, DbIndexType, ReturnType)));

    }

    private static void AddressIndexStetter(FhirApiSearchParameterInfo CollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;

      if (CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1].IsCollection)
      {
        _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2})", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());
      }

      _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));     

      string DbIndexType = DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.StringIndex];
      string ReturnType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
      _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName, DbIndexType, ReturnType)));

    }

    private static void ReferenceIndexStetter(FhirApiSearchParameterInfo CollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;

      if (CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1].IsCollection)
      {
        _Sb.AppendLine(String.Format("{0}foreach (var item in {1})", DepthSpace(_BracketDepthCounter), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;

        _Sb.AppendLine(String.Format("{0}if (item is {1})", DepthSpace(_BracketDepthCounter), CollectionParameter.TargetFhirLogicalType.Name));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));

        string DbIndexType = DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.ReferenceIndex];
        string ReturnIndexType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
        _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter("item", DbIndexType, ReturnIndexType, true)));        

        _Sb.AppendLine(String.Format("{0}if (Index != null)", DepthSpace(_BracketDepthCounter)));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
      }
      else
      {
        _Sb.AppendLine(String.Format("{0}if ({1} is {2})", DepthSpace(_BracketDepthCounter), _CurrentChainName, CollectionParameter.TargetFhirLogicalType.Name));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));
                
        string DbIndexType = DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.ReferenceIndex];
        string ReturnIndexType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
        _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName, DbIndexType, ReturnIndexType, true)));



        _Sb.AppendLine(String.Format("{0}if (Index != null)", DepthSpace(_BracketDepthCounter)));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
      }
    }

    private static void DateIndexStetter(FhirApiSearchParameterInfo CollectionParameter)
    {
      _Sb.AppendLine(String.Format("{0}if ({1} != null)", DepthSpace(_BracketDepthCounter), _CurrentChainName));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _ChainCounter++;

      if (CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1].IsCollection)
      {
        _Sb.AppendLine(String.Format("{0}foreach (var item{1} in {2})", DepthSpace(_BracketDepthCounter), _ChainCounter.ToString(), _CurrentChainName));
        _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
        _BracketDepthCounter++;
        _CurrentChainName = String.Format("item{0}", _ChainCounter.ToString());
      }
      _Sb.AppendLine(String.Format("{0}if ({1} is {2})", DepthSpace(_BracketDepthCounter), _CurrentChainName, CollectionParameter.TargetFhirLogicalType.Name));
      _Sb.AppendLine(String.Format("{0}{{", DepthSpace(_BracketDepthCounter)));
      _BracketDepthCounter++;
      _Sb.AppendLine(String.Format("{0}var Index = new {1}();", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter)));
      
      string DbIndexType = DatabaseModelInfo.GetServerSearchIndexTypeString(CollectionParameter);
      string ReturnType = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(_ResourceName, CollectionParameter);
      _Sb.AppendLine(String.Format("{0}{1}", DepthSpace(_BracketDepthCounter), DatabaseModelInfo.GenerateIndexSetter(_CurrentChainName, DbIndexType, ReturnType)));
      
    }

    private static void ResolvePropertyChainNames(int i, FhirSearchParameterSearchPathElement CurrentItem)
    {
      if (i > 1)
      {
        //_PropertyNameChain = RepositoryCodeGenSupport.ResolvePropertyChainNames(i, CurrentItem, _PropertyNameChain);        
        RepositoryCodeGenSupport.ResolvePropertyNameChainList(i, CurrentItem, _PropertyNameChainList);
      }
      else
      {
        //_PropertyNameChain = RepositoryCodeGenSupport.UppercaseFirst(CurrentItem.PropertyName);
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