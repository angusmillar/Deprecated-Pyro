using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;

namespace CodeGenerationSupport.FhirApiIntrospection
{  
  public static class FhirApiSearchParameterInfoFactory
  {
    #region Private Properties
    private static int _CollectionCounter = 0;
    private static List<FhirApiSearchParameterInfo> _ResourceSearchInfoList;
    private static FhirApiSearchParameterInfo _SearchParameterInfo;
    private static ModelInfo.SearchParamDefinition _CurrentSearchParameterDef;
    private static List<FhirXPath> oFhirXPathList;
    #endregion

    #region Public Methods

    public static List<FhirApiSearchParameterInfo> GetApiSearchParameterInfo()
    {
      oFhirXPathList = new List<FhirXPath>();
      _ResourceSearchInfoList = new List<FhirApiSearchParameterInfo>();
      var ResourceList = ModelInfo.SupportedResources;
      var SearchParameterList = ModelInfo.SearchParameters;
      ApiSearchParameterCorrections(SearchParameterList);
      List<string> oResourceSearchInfo = new List<string>();

      foreach (string ResourceName in ResourceList)
      {
        List<ModelInfo.SearchParamDefinition> ResourceSearchParameterList = (from x in SearchParameterList
                                           where x.Resource == ResourceName
                                           select x).ToList();

        List<ModelInfo.SearchParamDefinition> CompositeSearchParameterList = new List<ModelInfo.SearchParamDefinition>();
    
        foreach (ModelInfo.SearchParamDefinition SearchParameterDef in ResourceSearchParameterList)
        {
          _CurrentSearchParameterDef = SearchParameterDef;
          if (SearchParameterDef.Resource == "Basic")
          {


          }
          //##Issue## We are skipping search parameters that have no paths at all, what good are they if they have no path?
          if (_CurrentSearchParameterDef.XPath != null && _CurrentSearchParameterDef.Path.Count() > 0)
          {
            if (SearchParameterDef.Type == SearchParamType.Composite)
            {
              //Composite are added to this list and processed after all other search parameters for the resource are processed
              CompositeSearchParameterList.Add(_CurrentSearchParameterDef);
            }
            else
            {
              ResolveSearchParameter(ResourceName);
            }
          }
        }
        foreach(var CompositeSearchParameter in CompositeSearchParameterList)
        {
          //For each Composite we collect the sub search parameters that this composite is a composition of and add them to the
          //CompositeSearchParameterList. This is why it is processed last.
          _SearchParameterInfo = new FhirApiSearchParameterInfo();
          _SearchParameterInfo.IsCollection = true;
          _SearchParameterInfo.Resource = ResourceName;
          _SearchParameterInfo.SearchParamType = CompositeSearchParameter.Type;
          _SearchParameterInfo.SearchName = CompositeSearchParameter.Name;
          _SearchParameterInfo.IsChoice = false;
          _SearchParameterInfo.SearchPath = string.Empty;
          _SearchParameterInfo.CompositeSearchParameterList = ResolveCompositeSearchParameterList(ResourceName, CompositeSearchParameter);
          _ResourceSearchInfoList.Add(_SearchParameterInfo);
        }
      }
      #region Debugging Purpose
      //OutPut For Debugging purpose only
      //var StringBuild = new StringBuilder();
      //StringBuild.AppendLine(String.Format("ResourceName, SearchParameterName, IsCollection, Type, Path "));
      //foreach(var item in ResourceSearchInfoList)
      //{
      //  StringBuild.AppendLine(String.Format("{0},{1},{2},{3},{4}", item.Resource, item.SearchName, item.IsCollection, item.SearchParamType.ToString(), item.SearchPath));
      //}
      //System.IO.File.WriteAllText(@"C:\temp\FHIRSearchParameters.csv",StringBuild.ToString());
      #endregion
      int test = oFhirXPathList.Count();
      return _ResourceSearchInfoList;
    }
    
    /// <summary>
    /// This removes all the duplicate search parameters that are found when the search parameter is part of a choice in the FHIR resource structure.
    /// It checks that the duplicates all have the same data type as if they didn't then their would be a problem with our storage policy of an index for each search parameter.
    /// </summary>
    /// <param name="InboundList"></param>
    /// <returns></returns>
    public static List<FhirApiSearchParameterInfo> CheckAndRemoveDuplicates(List<FhirApiSearchParameterInfo> InboundList)
    {
      var TempList = new List<FhirApiSearchParameterInfo>();
      foreach(var Item in InboundList)
      {          
        var DuplicateFoundList = from x in TempList where x.SearchName == Item.SearchName select x;
        if (DuplicateFoundList.Count() > 0)
        {
          foreach (var DuplicateItem in DuplicateFoundList)
          {
            if (DuplicateItem.SearchParamType != Item.SearchParamType)
              throw new ApplicationException("There are duplicate search parameter names with different data types for the same resource.");
          }
        }
        else
        {
          TempList.Add(Item);
        }
      }
      return TempList;
    }

    /// <summary>
    /// Construct the class name string for the Resource classes
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceClass(string ResourceName)
    {          
      return String.Format("Resource_{0}", ResourceName);
    }

    /// <summary>
    /// Construct the class name string for the Resource Search Classes
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceSearchClass(string ResourceName, FhirApiSearchParameterInfo SearchParameterInfo)
    {
      if (SearchParameterInfo.SearchParamType == SearchParamType.Composite)
        return String.Format("Resource_{0}_Search_{1}", ResourceName, SearchParameterInfo.SearchName.Replace('-', '_').Replace("_[x]",""));
      else
        return String.Format("Resource_{0}_Search_{1}", ResourceName, SearchParameterInfo.SearchName.Replace('-', '_'));
    }

    /// <summary>
    /// Construct the property name string for the Collection lists of the Resource classes
    /// </summary>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ConstructCollectionListName(FhirApiSearchParameterInfo oFhirApiSearchParameterInfo)
    {
      if (oFhirApiSearchParameterInfo.SearchParamType == SearchParamType.Composite)
        return oFhirApiSearchParameterInfo.SearchName.Replace('-', '_').Replace("_[x]", "") + "_List";
      else
        return oFhirApiSearchParameterInfo.SearchName.Replace('-', '_') + "_List";
    }

    #endregion

    #region Private Methods
    
    private static void ResolveSearchParameter(string ResourceName)
    {
      //ClassMapping ResourceMap = ClassMapping.Create(ModelInfo.GetTypeForFhirType(ResourceName));
      //Some Search parameters have many paths due to the property being a choice type.

      //New work on Xpath no Path

      try
      {
        foreach (var Test in _CurrentSearchParameterDef.XPath.Split('|'))
        {
          FhirXPath oFhirXpath = FhirXPathFactory.FhirXPathFactoryParse(Test);
          oFhirXPathList.Add(oFhirXpath);
        }
      }
      catch (Exception Exec)
      { 
      }

      List<string> SearchPathChoice = _CurrentSearchParameterDef.Path.ToList();
      foreach (string SearchPath in SearchPathChoice)
      {
        //reset the Collection counter before we start iterating a resource's properties for this search property
        _CollectionCounter = 0;
        _SearchParameterInfo = new FhirApiSearchParameterInfo();          
        string[] PathElements = SearchPath.Split('.');
 
        var RootElement = new FhirSearchParameterSearchPathElement(null);
        RootElement.IsCollection = false;
        RootElement.PropertyName = ResourceName;
        RootElement.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        RootElement.ParentElement = null;        
        _SearchParameterInfo.SearchParameterNavigationPath = RootElement;

        RecursivelySearchForIsColectionOnPropertyPath(PathElements, 1, ModelInfo.GetTypeForFhirType(ResourceName));

        _SearchParameterInfo.IsCollection = (_CollectionCounter > 0);
        _SearchParameterInfo.Resource = ResourceName;
        _SearchParameterInfo.SearchParamType = _CurrentSearchParameterDef.Type;
        _SearchParameterInfo.SearchName = _CurrentSearchParameterDef.Name;
        _SearchParameterInfo.IsChoice = (_CurrentSearchParameterDef.Path.Count() > 1);
        _SearchParameterInfo.SearchPath = SearchPath;
        _ResourceSearchInfoList.Add(_SearchParameterInfo);
      }
    }

    private static void RecursivelySearchForIsColectionOnPropertyPath(string[] PathElements, int CurrentElement, Type Type)
    {
      ClassMapping ClassMap = ClassMapping.Create(Type);
      //Info: Turple<string,Bool, int> RemoveIndexesFromSearchPathElement
      //item1 = string (the Element with no index info)
      //item2 = Bool (true if an index was found n the element)
      //item3 = int (The index integer found, only relevant if item2 is true, will be zero if false)              
      var ElementIndexParse = RemoveIndexesFromSearchPathElement(PathElements[CurrentElement]);
      
      foreach (var Property in ClassMap.PropertyMappings)
      {
        if (Property.Name == ElementIndexParse.Item1 || (Property.Choice == ChoiceType.DatatypeChoice && ElementIndexParse.Item1.StartsWith(Property.Name)))
        {
          FhirSearchParameterSearchPathElement ChildPathElement = _SearchParameterInfo.SearchParameterNavigationPath.CreateChildElement();
          ChildPathElement.IsCollection = Property.IsCollection;
          ChildPathElement.PropertyName = Property.Name;
          ChildPathElement.DataType = Property.ElementType;
          
          if (Property.IsCollection)
          {
            SetCollectionCountUsingElementIndexInfo(ElementIndexParse);
          }


          if (PathElements.Count() == CurrentElement + 1)
          {
            //We have reached the end of the path.
            //Check is the final target type is that which has collections , e.g CodableConcept has many Coding            
            //_SearchParameterInfo.TargetFhirElementType = typeof(CodeableConcept);
            if (Property.ElementType == typeof(CodeableConcept))
            {
              ClassMapping ClassMap2 = ClassMapping.Create(Property.ElementType);
            }
            return;
          }
          else
          {
            //Move to the next element in the path and recursively call this method again until path end reached.
            CurrentElement = CurrentElement + 1;
            RecursivelySearchForIsColectionOnPropertyPath(PathElements, CurrentElement, Property.ElementType);
            return;
          }
        }
      }
      throw new Exception("The search path did not match the API Model. Do we have an incorrect search path or an incorrect API Model?");
    }

    private static void SetCollectionCountUsingElementIndexInfo(Tuple<string, bool, int> ElementIndexParse)
    {
      if (ElementIndexParse.Item2)
      {
        //If we are here we must have a single integer for the index of this element which implies that although
        //We have a collection we are only to store one item of that collection, that item being the one found 
        //at the collection index equal to the integer in ElementIndexParse.Item3.
        //In this case there is no need to increment _CollectionCounter .
      }
      else
      {
        _CollectionCounter = _CollectionCounter + 1;
      }
    }

    /// <summary>
    /// The Composite search parameters are actually made up of a set of non-composite parameters, thus why they are called Composites.
    /// They are also not able to be resolved by inspecting the FHIR API as it is only the description that explains what non-composites make
    /// up a given composite. For this reason they are hard coded here. There are only 8 of these in the whole FHIR standard to date, FHIR DSTU 2.1
    /// If new ones are in countered with a new FHIR API version this code will throw an exception telling the user that this code needs updating.
    /// This should only happen on T4 template code generation not when the application is running.
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <param name="CompositeSearchParameterDef"></param>
    /// <returns></returns>
    private static List<FhirApiSearchParameterInfo> ResolveCompositeSearchParameterList(string ResourceName, ModelInfo.SearchParamDefinition CompositeSearchParameterDef)
    {
      var oList = new List<FhirApiSearchParameterInfo>();
      switch (String.Format("{0}_{1}", ResourceName, CompositeSearchParameterDef.Name))
      {
        case "CarePlan_related":
          {
            //FHIR Spec DSTU 2.1: related,	composite,	A combination of the type of relationship and the related plan
            FhirApiSearchParameterInfo SearchParameterOne = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "relatedcode" select x).SingleOrDefault();
            oList.Add(SearchParameterOne);
            FhirApiSearchParameterInfo SearchParameterTwo = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "relatedplan" select x).SingleOrDefault();
            oList.Add(SearchParameterTwo);
            return oList;
          }
        case "DiagnosticOrder_event-status-date":
          {
            //FHIR Spec DSTU 2.1: event-status-date,	composite,	A combination of past-status and date
            FhirApiSearchParameterInfo SearchParameterOne = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "event-status" select x).SingleOrDefault();
            oList.Add(SearchParameterOne);
            FhirApiSearchParameterInfo SearchParameterTwo = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "event-date" select x).SingleOrDefault();
            oList.Add(SearchParameterTwo);
            return oList;
          }
        case "DiagnosticOrder_item-status-date":
          {
            //FHIR Spec DSTU 2.1: item-status-date,	composite,	A combination of item-past-status and item-date
            FhirApiSearchParameterInfo SearchParameterOne = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "item-past-status" select x).SingleOrDefault();
            oList.Add(SearchParameterOne);
            FhirApiSearchParameterInfo SearchParameterTwo = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "item-date" select x).SingleOrDefault();
            oList.Add(SearchParameterTwo);
            return oList;
          }
        case "Group_characteristic-value":
          {
            //FHIR Spec DSTU 2.1: characteristic-value,	composite,	A composite of both characteristic and value	
            FhirApiSearchParameterInfo SearchParameterOne = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "characteristic" select x).SingleOrDefault();
            oList.Add(SearchParameterOne);
            //It does not mater which value we add as all are of the same search datatype, i.e Token 
            FhirApiSearchParameterInfo SearchParameterTwo = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "value" select x).First();
            oList.Add(SearchParameterTwo);
            return oList;
          }
        case "Observation_code-value-[x]":
          {
            //FHIR Spec DSTU 2.1: code-value-[x],	composite,	Both code and one of the value parameters
            FhirApiSearchParameterInfo SearchParameterOne = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "code" select x).SingleOrDefault();
            oList.Add(SearchParameterOne);
            FhirApiSearchParameterInfo SearchParameterTwo = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "value-concept" select x).Single();
            oList.Add(SearchParameterTwo);
            //It does not mater which value we add as all are of the same search datatype.
            FhirApiSearchParameterInfo SearchParameterThree = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "value-date" select x).First();
            oList.Add(SearchParameterThree);
            FhirApiSearchParameterInfo SearchParameterFour = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "value-quantity" select x).Single();
            oList.Add(SearchParameterFour);
            FhirApiSearchParameterInfo SearchParameterFive = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "value-string" select x).Single();
            oList.Add(SearchParameterFive);
            return oList;
          }
        case "Observation_component-code-value-[x]":
          {
            //FHIR Spec DSTU 2.1: component-code-value-[x],	composite,	Both component code and one of the component value parameters
            FhirApiSearchParameterInfo SearchParameterOne = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "component-code" select x).SingleOrDefault();
            oList.Add(SearchParameterOne);
            FhirApiSearchParameterInfo SearchParameterTwo = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "component-value-concept" select x).Single();
            oList.Add(SearchParameterTwo);
            //It does not mater which value we add as all are of the same search datatype.
            FhirApiSearchParameterInfo SearchParameterThree = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "component-value-quantity" select x).Single();
            oList.Add(SearchParameterThree);
            FhirApiSearchParameterInfo SearchParameterFour = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "component-value-string" select x).Single();
            oList.Add(SearchParameterFour);
            return oList;
          }
        case "Observation_related":
          {
            //FHIR Spec DSTU 2.1: related,	composite,	Related Observations - search on related-type and related-target together
            FhirApiSearchParameterInfo SearchParameterOne = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "related-type" select x).SingleOrDefault();
            oList.Add(SearchParameterOne);
            FhirApiSearchParameterInfo SearchParameterTwo = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "related-target" select x).Single();
            oList.Add(SearchParameterTwo);
            return oList;
          }

        case "DocumentReference_relationship":
          {
            //FHIR Spec DSTU 2.1: relationship,	composite	Combination of relation and relatesTo
            FhirApiSearchParameterInfo SearchParameterOne = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "relation" select x).SingleOrDefault();
            oList.Add(SearchParameterOne);
            FhirApiSearchParameterInfo SearchParameterTwo = (from x in _ResourceSearchInfoList where x.Resource == ResourceName && x.SearchName == "relatesto" select x).SingleOrDefault();
            oList.Add(SearchParameterTwo);
            return oList;
          }

        default:
          throw new ApplicationException(String.Format("A composite search parameter was found in the FHIR API search parameters which has not been catered for. This will need to be analysed and programmed for to proceed. The Resource was: {0}, and the parameter was: {1}", ResourceName, CompositeSearchParameterDef.Name));
      }
    }

    /// <summary>
    /// Strip out any index i the search path elements, e.g resource[0]
    /// </summary>
    /// <param name="Element"></param>
    /// <returns></returns>
    private static Tuple<string, bool, int> RemoveIndexesFromSearchPathElement(string Element)
    {
      string ReturnString = string.Empty;
      if (Element.Contains('[') && Element.Contains(']'))
      {
        string IndexNumberString = string.Empty;
        bool open = false;
        foreach(var Char in Element.ToArray())
        {
          if (Char == '[')
          {
            open = true;
          }
          else if (Char == ']')
          {
            open = false;
          }
          else if (open)
          {
            IndexNumberString = IndexNumberString + Char;
          }
          else if (!open)
          {
            ReturnString = ReturnString + Char;
          }
        }        
        int ReturnIndexNumber = 0; 
        if (int.TryParse(IndexNumberString,out ReturnIndexNumber))
        {
          return new Tuple<string, bool, int>(ReturnString, true, ReturnIndexNumber);
        }
        else
        {
          throw new FormatException("A search path appeared to have a index on one element yet the integer in the brackets [] was not able to be converted to an integer. The "); 
        }        
      }
      return new Tuple<string, bool, int>(Element, false, 0);
    }

    /// <summary>
    /// These are a few correction I make to the search parameters found in the FHIR API to align correctly with the FHIR spec
    /// </summary>
    /// <param name="SearchParameterList"></param>
    private static void ApiSearchParameterCorrections(List<ModelInfo.SearchParamDefinition> SearchParameterList)
    {

      //--- Remove these from the FHIR API search parameter list  -----------------------------------------------------

      //These two search parameters I assume are an error in the API, they both are not documented in FHIR and their paths are garbage  
      var DataElement_objectClass = SearchParameterList.SingleOrDefault(x => x.Resource == "DataElement" && x.Name == "objectClass");
      if (DataElement_objectClass == null)
        throw new ApplicationException("Code Generation of the database model was expecting to correct a search parameter which was in error in the FHIR API. That parameter was for Resource name: DataElement search parameter: objectClass. The parameter could not be found. Maybe it has been corrected and this process can be removed?");
      SearchParameterList.Remove(DataElement_objectClass);
      var DataElement_objectClassProperty = SearchParameterList.SingleOrDefault(x => x.Resource == "DataElement" && x.Name == "objectClassProperty");
      if (DataElement_objectClassProperty == null)
        throw new ApplicationException("Code Generation of the database model was expecting to correct a search parameter which was in error in the FHIR API. That parameter was for Resource name: DataElement search parameter: objectClassProperty. The parameter could not be found. Maybe it has been corrected and this process can be removed?");
      SearchParameterList.Remove(DataElement_objectClassProperty);


      //--- Correction to search parameters -----------------------------------------------------------------

      //Correction as a Bundle has many Entries and each entry only has one resource, this modification aligns correctly with the FHIR web site unlike the API  
      var ResourceSearchParameterList = (from x in SearchParameterList
                                         where x.Resource == "Bundle"
                                         select x);

      var ResourceCompositionSearchParameter = ResourceSearchParameterList.ToList().Where(x => x.Name == "composition").SingleOrDefault();
      if (ResourceCompositionSearchParameter != null)
      {
        if (ResourceCompositionSearchParameter.Path.Count() == 1)
        {
          if (ResourceCompositionSearchParameter.Path[0] == "Bundle.entry.resource[0]" &&
            ResourceCompositionSearchParameter.XPath == "f:Bundle/f:entry/f:resource[0]" &&
            ResourceCompositionSearchParameter.Expression == "Bundle.entry.resource.item(0)")
          {
            ResourceCompositionSearchParameter.Path[0] = "Bundle.entry[0].resource";
            ResourceCompositionSearchParameter.XPath = "f:Bundle/f:entry[0]/f:resource";
            ResourceCompositionSearchParameter.Expression = "Bundle.entry.item(0).resource";

          }
        }
      }

      var ResourceMessageSearchParameter = ResourceSearchParameterList.ToList().Where(x => x.Name == "message").SingleOrDefault();
      if (ResourceMessageSearchParameter != null)
      {
        if (ResourceMessageSearchParameter.Path.Count() == 1)
        {
          if (ResourceMessageSearchParameter.Path[0] == "Bundle.entry.resource[0]" &&
            ResourceMessageSearchParameter.XPath == "f:Bundle/f:entry/f:resource[0]" &&
            ResourceMessageSearchParameter.Expression == "Bundle.entry.resource.item(0)")
          {
            ResourceMessageSearchParameter.Path[0] = "Bundle.entry[0].resource";
            ResourceMessageSearchParameter.XPath = "f:Bundle/f:entry[0]/f:resource";
            ResourceMessageSearchParameter.Expression = "Bundle.entry.item(0).resource";
          }
        }
      }

    }
    #endregion
  }

}
