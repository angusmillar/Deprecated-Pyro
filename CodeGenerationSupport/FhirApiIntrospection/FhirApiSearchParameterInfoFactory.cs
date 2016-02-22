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
    #endregion

    #region Public Methods

    public static List<FhirApiSearchParameterInfo> GetApiSearchParameterInfo()
    {      
      var ResourceSearchInfoList = new List<FhirApiSearchParameterInfo>();
      var ResourceList = ModelInfo.SupportedResources;
      var SearchParameterList = ModelInfo.SearchParameters;
      ApiSearchParameterCorrections(SearchParameterList);
      List<string> oResourceSearchInfo = new List<string>();

      foreach (string ResourceName in ResourceList)
      {
        ClassMapping ResourceMap = ClassMapping.Create(ModelInfo.GetTypeForFhirType(ResourceName));

        var ResourceSearchParameterList = (from x in SearchParameterList
                                           where x.Resource == ResourceName
                                           select x);

        foreach (var SearchParameterDef in ResourceSearchParameterList)
        {          
          //Some Search parameters have many paths due to the property being a choice type.
          List<string> SearchPathChoice = SearchParameterDef.Path.ToList();
          foreach (string SearchPath in SearchPathChoice)
          {
            //reset the Collection counter before we start iterating a resource's properties for this search property
            _CollectionCounter = 0;
            string[] PathElements = SearchPath.Split('.');
            //PathElement[0] is the Resource it's self.
            //Info: Turple<string,Bool, int> RemoveIndexesFromSearchPathElement
            //item1 = string (the Element with no index info)
            //item2 = Bool (true if an index was found n the element)
            //item3 = int (The index integer found, only relevant if item2 is true, will be zero if false)              
            var ElementIndexParse = RemoveIndexesFromSearchPathElement(PathElements[1]);

            //these are the properties directly off the root resource 
            foreach (var Property in ResourceMap.PropertyMappings)
            {
              if (Property.Name == ElementIndexParse.Item1)
              {
                var info = new FhirApiSearchParameterInfo();

                if (Property.IsCollection)
                {
                  SetCollectionCountUsingElementIndexInfo(ElementIndexParse);                  
                }                
                //The path is n deep so recursively travel the path and increment 'CollectionCounter' 
                //for any elements property along the path that are have IsCollection set to true.
                if (PathElements.Count() > 2)
                {
                  RecursivelySearchForIsColectionOnPropertyPath(PathElements, 2, Property.ElementType);                                  
                }                
                info.IsCollection = (_CollectionCounter > 0);
                info.Resource = ResourceName;
                info.SearchParamType = SearchParameterDef.Type;
                info.SearchName = SearchParameterDef.Name;
                info.IsChoice = (SearchParameterDef.Path.Count() > 1);
                info.SearchPath = SearchPath;
                ResourceSearchInfoList.Add(info);               
              }
            }
          }
        }
      }
      int TotalCount = ResourceSearchInfoList.Count();
      int CollectionCount = ResourceSearchInfoList.Where(x => x.IsCollection == true).Count();
      int NonCollectionCount = ResourceSearchInfoList.Where(x => x.IsCollection == false).Count();

      var StringBuild = new StringBuilder();
      StringBuild.AppendLine(String.Format("ResourceName, SearchParameterName, IsCollection, Type, Path "));
      foreach(var item in ResourceSearchInfoList)
      {
        StringBuild.AppendLine(String.Format("{0},{1},{2},{3},{4}", item.Resource, item.SearchName, item.IsCollection, item.SearchParamType.ToString(), item.SearchPath));
      }
      System.IO.File.WriteAllText(@"C:\temp\FHIRSearchParameters.csv",StringBuild.ToString());
      return ResourceSearchInfoList;
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
    public static string ConstructClassNameForResourceSearchClass(string ResourceName, string SearchParameterName)
    {      
      return String.Format("Resource_{0}_Search_{1}", ResourceName, SearchParameterName.Replace('-','_'));
    }

    /// <summary>
    /// Construct the property name string for the Collection lists of the Resource classes
    /// </summary>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ConstructCollectionListName(string SearchParameterName)
    {      
      return SearchParameterName.Replace('-','_') + "_List";
    }



    #endregion

    #region Private Methods
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
        if (Property.Choice == ChoiceType.DatatypeChoice)
        {

        }

        if (Property.Name == ElementIndexParse.Item1 || (Property.Choice == ChoiceType.DatatypeChoice && ElementIndexParse.Item1.StartsWith(Property.Name)))
        {
          if (Property.IsCollection)
          {
            SetCollectionCountUsingElementIndexInfo(ElementIndexParse);                              
          }

          if (PathElements.Count() == CurrentElement + 1)
          {
            //We have reached the end of the path.
            return;
          }
          else
          {
            //Move to the next element in the path and recursively call this method again until path end reached.
            CurrentElement = CurrentElement + 1 ;
            RecursivelySearchForIsColectionOnPropertyPath(PathElements, CurrentElement, Property.ElementType);
            return;
          }
        }        
      }
      throw new Exception("The search path did not match the API Model. Do we have an incorrect search path or an incorrect API Model?");
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

      //--- Remove these from the search parameter list  -----------------------------------------------------

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
