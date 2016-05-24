using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;

namespace Blaze.CodeGenerationSupport.FhirApiIntrospection
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
          
          //For debugging a specific resource
          //if (SearchParameterDef.Resource == "Patient")
          //{
          //}

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

        //MetaProfile
        _SearchParameterInfo = new FhirApiSearchParameterInfo();
        _SearchParameterInfo.IsCollection = true;
        _SearchParameterInfo.Resource = ResourceName;
        _SearchParameterInfo.SearchParamType = SearchParamType.Uri;
        _SearchParameterInfo.SearchName = "profile";
        _SearchParameterInfo.IsChoice = false;
        _SearchParameterInfo.SearchPath = "f:Account/f:meta/f:profile";
        _SearchParameterInfo.CompositeSearchParameterList = null;                


         var RootElementMetaProfile = new FhirSearchParameterSearchPathElement(null);
        RootElementMetaProfile.IsCollection = false;
        RootElementMetaProfile.PropertyName = ResourceName;
        RootElementMetaProfile.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        RootElementMetaProfile.ParentElement = null;
        _SearchParameterInfo.SearchParameterNavigationPath = RootElementMetaProfile;

        FhirSearchParameterSearchPathElement ChildPathElementMetaProfile = _SearchParameterInfo.SearchParameterNavigationPath.CreateChildElement();
        ChildPathElementMetaProfile.IsCollection = false;
        ChildPathElementMetaProfile.PropertyName = "Meta";
        ChildPathElementMetaProfile.DataType = ModelInfo.GetTypeForFhirType("Meta");

        FhirSearchParameterSearchPathElement ChildPathElementMetaProfile2 = _SearchParameterInfo.SearchParameterNavigationPath.ChildElement.CreateChildElement();
        ChildPathElementMetaProfile2.IsCollection = true;
        ChildPathElementMetaProfile2.PropertyName = "profile";
        ChildPathElementMetaProfile2.DataType = ModelInfo.GetTypeForFhirType("uri");

        _ResourceSearchInfoList.Add(_SearchParameterInfo);


        //MetaSecurity
        _SearchParameterInfo = new FhirApiSearchParameterInfo();
        _SearchParameterInfo.IsCollection = true;
        _SearchParameterInfo.Resource = ResourceName;
        _SearchParameterInfo.SearchParamType = SearchParamType.Token;
        _SearchParameterInfo.SearchName = "security";
        _SearchParameterInfo.IsChoice = false;
        _SearchParameterInfo.SearchPath = "f:Account/f:meta/f:security";
        _SearchParameterInfo.CompositeSearchParameterList = null;


        var RootElementMetaSecurity = new FhirSearchParameterSearchPathElement(null);
        RootElementMetaSecurity.IsCollection = false;
        RootElementMetaSecurity.PropertyName = ResourceName;
        RootElementMetaSecurity.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        RootElementMetaSecurity.ParentElement = null;
        _SearchParameterInfo.SearchParameterNavigationPath = RootElementMetaSecurity;

        FhirSearchParameterSearchPathElement ChildPathElementMetaSecurity = _SearchParameterInfo.SearchParameterNavigationPath.CreateChildElement();
        ChildPathElementMetaSecurity.IsCollection = false;
        ChildPathElementMetaSecurity.PropertyName = "Meta";
        ChildPathElementMetaSecurity.DataType = ModelInfo.GetTypeForFhirType("Meta");

        FhirSearchParameterSearchPathElement ChildPathElementMetaSecurity2 = _SearchParameterInfo.SearchParameterNavigationPath.ChildElement.CreateChildElement();
        ChildPathElementMetaSecurity2.IsCollection = true;
        ChildPathElementMetaSecurity2.PropertyName = "security";
        ChildPathElementMetaSecurity2.DataType = ModelInfo.GetTypeForFhirType("Coding");
        
        _ResourceSearchInfoList.Add(_SearchParameterInfo);

        //MetaTag
        _SearchParameterInfo = new FhirApiSearchParameterInfo();
        _SearchParameterInfo.IsCollection = true;
        _SearchParameterInfo.Resource = ResourceName;
        _SearchParameterInfo.SearchParamType = SearchParamType.Token;
        _SearchParameterInfo.SearchName = "tag";
        _SearchParameterInfo.IsChoice = false;
        _SearchParameterInfo.SearchPath = "f:Account/f:meta/f:tag";
        _SearchParameterInfo.CompositeSearchParameterList = null;


        var RootElementMetaTag = new FhirSearchParameterSearchPathElement(null);
        RootElementMetaTag.IsCollection = false;
        RootElementMetaTag.PropertyName = ResourceName;
        RootElementMetaTag.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        RootElementMetaTag.ParentElement = null;
        _SearchParameterInfo.SearchParameterNavigationPath = RootElementMetaTag;

        FhirSearchParameterSearchPathElement ChildPathElementMetaTag = _SearchParameterInfo.SearchParameterNavigationPath.CreateChildElement();
        ChildPathElementMetaTag.IsCollection = false;
        ChildPathElementMetaTag.PropertyName = "Meta";
        ChildPathElementMetaTag.DataType = ModelInfo.GetTypeForFhirType("Meta");

        FhirSearchParameterSearchPathElement ChildPathElementMetaTag2 = _SearchParameterInfo.SearchParameterNavigationPath.ChildElement.CreateChildElement();
        ChildPathElementMetaTag2.IsCollection = true;
        ChildPathElementMetaTag2.PropertyName = "tag";
        ChildPathElementMetaTag2.DataType = ModelInfo.GetTypeForFhirType("Coding");

        _ResourceSearchInfoList.Add(_SearchParameterInfo);



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

    #endregion

    #region Private Methods
    
    private static void ResolveSearchParameter(string ResourceName)
    {
      
      //Testing FhirXPath parser over all search paths
      //try
      //{
      //  foreach (var Test in _CurrentSearchParameterDef.XPath.Split('|'))
      //  {
      //    if (oFhirXPathList.Count() == 662)
      //    {

      //    }
      //    FhirXPath oFhirXpath = FhirXPathFactory.FhirXPathFactoryParse(Test);
      //    oFhirXPathList.Add(oFhirXpath);
      //  }
      //}
      //catch (Exception Exec)
      //{ 
      //}

      string[] FhirXPathChoiceList = _CurrentSearchParameterDef.XPath.Split('|');
      foreach (string SearchXPath in FhirXPathChoiceList)
      {
        FhirXPath oFhirXpath = FhirXPathFactory.FhirXPathFactoryParse(SearchXPath);
        //reset the Collection counter before we start iterating a resource's properties for this search property
        _CollectionCounter = 0;
        _SearchParameterInfo = new FhirApiSearchParameterInfo();                  
 
        var RootElement = new FhirSearchParameterSearchPathElement(null);
        RootElement.IsCollection = false;
        RootElement.PropertyName = ResourceName;
        RootElement.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        RootElement.ParentElement = null;        
        _SearchParameterInfo.SearchParameterNavigationPath = RootElement;

        RecursivelySearchForIsColectionOnPropertyPath(oFhirXpath, 1, ModelInfo.GetTypeForFhirType(ResourceName));

        _SearchParameterInfo.IsCollection = (_CollectionCounter > 0);
        _SearchParameterInfo.Resource = ResourceName;
        _SearchParameterInfo.SearchParamType = _CurrentSearchParameterDef.Type;
        _SearchParameterInfo.SearchName = _CurrentSearchParameterDef.Name;
        _SearchParameterInfo.IsChoice = (_CurrentSearchParameterDef.Path.Count() > 1);
        _SearchParameterInfo.SearchPath = SearchXPath;
        _ResourceSearchInfoList.Add(_SearchParameterInfo);
      }
    }

    private static void RecursivelySearchForIsColectionOnPropertyPath(FhirXPath oFhirXPath, int CurrentElement, Type Type)
    {
      ClassMapping ClassMap = ClassMapping.Create(Type);      
      foreach (var Property in ClassMap.PropertyMappings)
      {
        if (Property.Name == oFhirXPath.FhirXPathComponentList[CurrentElement].Name || (Property.Choice == ChoiceType.DatatypeChoice && oFhirXPath.FhirXPathComponentList[CurrentElement].Name.StartsWith(Property.Name)))
        {
          FhirSearchParameterSearchPathElement ChildPathElement = _SearchParameterInfo.SearchParameterNavigationPath.CreateChildElement();
          ChildPathElement.IsCollection = Property.IsCollection;
          ChildPathElement.PropertyName = Property.Name;
          ChildPathElement.DataType = Property.ElementType;
          
          if (Property.IsCollection)
          {
            SetCollectionCountUsingElementIndexInfo(oFhirXPath.FhirXPathComponentList[CurrentElement]);
          }


          if (oFhirXPath.FhirXPathComponentList.Count() == CurrentElement + 1)
          {
            //We have reached the end of the path.
            //Check is the final target Fhir type (Not search type) to see if it contains collections , e.g CodableConcept has many Coding           
            //We only need to check the complextypes. Each below has been manually added after inspecting 
            //How search works on each, if search has to deal with many for these types then they are added here.
            
            if (Property.ElementType == typeof(CodeableConcept) || 
              Property.ElementType == typeof(Timing) ||
              Property.ElementType == typeof(Address) ||
              Property.ElementType == typeof(HumanName))
            {
              ChildPathElement.IsCollection = true;              
              SetCollectionCountUsingElementIndexInfo(oFhirXPath.FhirXPathComponentList[CurrentElement]);
              
              //use this to inspect the properties of the Type when debugging
              //ClassMapping ClassMap2 = ClassMapping.Create(Property.ElementType);
            }
            if (Property.ElementType == typeof(Signature))
            {
              throw new ApplicationException("Type 'Signature' has not been used as a search parameter before. Need to check if the search path using this type need to be a collection. Signature/Type is 1..*. Does the search intend to index Signature/Type?");
            }            
            return;
          }
          else
          {
            //Move to the next element in the path and recursively call this method again until path end reached.
            CurrentElement = CurrentElement + 1;
            RecursivelySearchForIsColectionOnPropertyPath(oFhirXPath, CurrentElement, Property.ElementType);
            return;
          }
        }
      }
      throw new Exception("The search path did not match the API Model. Do we have an incorrect search path or an incorrect API Model?");
    }

    private static void SetCollectionCountUsingElementIndexInfo(FhirXPathComponent oFhirXPathComponent)
    {
      if (oFhirXPathComponent.HasChoiceSpecifier)
      {
        //If we are here we must have a Choice Specifier for the element component. Something like this example: "f:Patient/f:telecom[system/@value='email']"
        //In this case of that example we still need a collection because there maybe many in the list labelled as 'email'. Yet sometimes 
        //the choice specifier is an integer, such as this example: "f:Bundle/f:entry/f:resource[0]". Here their is not collection because
        //we have an index = 0 meaning the first entry of the collection and only the first entry.
        //In this 'index' case there is no need to increment _CollectionCounter, yet in the other case their is a need too.
        if (oFhirXPathComponent.ChoiceSpecifier.AttributeName == null && oFhirXPathComponent.ChoiceSpecifier.ElementName == null)
        {          
          int temp = 0;
          if (int.TryParse(oFhirXPathComponent.ChoiceSpecifier.Value, out temp))
          {
            //do nothing, don't increment the counter.
          }
          else
          {
            _CollectionCounter = _CollectionCounter + 1;
          }
        }
        else
        {
          _CollectionCounter = _CollectionCounter + 1;
        }

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
