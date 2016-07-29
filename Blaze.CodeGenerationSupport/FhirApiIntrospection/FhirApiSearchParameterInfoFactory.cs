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
          //bool testbool = false;
          //if (SearchParameterDef.Resource == "Bundle" && SearchParameterDef.Name == "composition")
          //{
          //  testbool = true;
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
        foreach (var CompositeSearchParameter in CompositeSearchParameterList)
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


        var RootElementMetaProfile = new FhirSearchParameterSearchPathElement();
        RootElementMetaProfile.IsCollection = false;
        RootElementMetaProfile.PropertyName = ResourceName;
        RootElementMetaProfile.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(RootElementMetaProfile);

        var ChildPathElementMetaProfile = new FhirSearchParameterSearchPathElement();
        ChildPathElementMetaProfile.IsCollection = false;
        ChildPathElementMetaProfile.PropertyName = "Meta";
        ChildPathElementMetaProfile.DataType = ModelInfo.GetTypeForFhirType("Meta");
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(ChildPathElementMetaProfile);

        var ChildPathElementMetaProfile2 = new FhirSearchParameterSearchPathElement();
        ChildPathElementMetaProfile2.IsCollection = true;
        ChildPathElementMetaProfile2.PropertyName = "profile";
        ChildPathElementMetaProfile2.DataType = ModelInfo.GetTypeForFhirType("uri");
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(ChildPathElementMetaProfile2);

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


        var RootElementMetaSecurity = new FhirSearchParameterSearchPathElement();
        RootElementMetaSecurity.IsCollection = false;
        RootElementMetaSecurity.PropertyName = ResourceName;
        RootElementMetaSecurity.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(RootElementMetaSecurity);

        var ChildPathElementMetaSecurity = new FhirSearchParameterSearchPathElement();
        ChildPathElementMetaSecurity.IsCollection = false;
        ChildPathElementMetaSecurity.PropertyName = "Meta";
        ChildPathElementMetaSecurity.DataType = ModelInfo.GetTypeForFhirType("Meta");
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(ChildPathElementMetaSecurity);

        var ChildPathElementMetaSecurity2 = new FhirSearchParameterSearchPathElement();
        ChildPathElementMetaSecurity2.IsCollection = true;
        ChildPathElementMetaSecurity2.PropertyName = "security";
        ChildPathElementMetaSecurity2.DataType = ModelInfo.GetTypeForFhirType("Coding");
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(ChildPathElementMetaSecurity2);

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


        var RootElementMetaTag = new FhirSearchParameterSearchPathElement();
        RootElementMetaTag.IsCollection = false;
        RootElementMetaTag.PropertyName = ResourceName;
        RootElementMetaTag.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(RootElementMetaTag);

        var ChildPathElementMetaTag = new FhirSearchParameterSearchPathElement();
        ChildPathElementMetaTag.IsCollection = false;
        ChildPathElementMetaTag.PropertyName = "Meta";
        ChildPathElementMetaTag.DataType = ModelInfo.GetTypeForFhirType("Meta");
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(ChildPathElementMetaTag);

        var ChildPathElementMetaTag2 = new FhirSearchParameterSearchPathElement();
        ChildPathElementMetaTag2.IsCollection = true;
        ChildPathElementMetaTag2.PropertyName = "tag";
        ChildPathElementMetaTag2.DataType = ModelInfo.GetTypeForFhirType("Coding");
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(ChildPathElementMetaTag2);

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


    public static List<FhirApiSearchParameterInfo> RemoveDuplicatesOld(List<FhirApiSearchParameterInfo> InboundList)
    {
      List<FhirApiSearchParameterInfo> TempList = new List<FhirApiSearchParameterInfo>(InboundList);
      Dictionary<string, List<FhirApiSearchParameterInfo>> Dic = new Dictionary<string, List<FhirApiSearchParameterInfo>>();
      var FinalList = new List<FhirApiSearchParameterInfo>();

      foreach (var Item in TempList)
      {
        //Group each in a Dictionary where Search name is the key and possibility many SearchParameterInfos  
        var y = (from x in InboundList where x.SearchName == Item.SearchName select x);
        if (!Dic.ContainsKey(Item.SearchName))
        {
          Dic.Add(Item.SearchName, y.ToList());
        }
      }

      foreach (var item in Dic)
      {
        FinalList.Add(item.Value[0]);
      }
      return FinalList;
    }

    public static List<FhirApiSearchParameterInfo> RemoveDuplicates(List<FhirApiSearchParameterInfo> InboundList)
    {
      List<FhirApiSearchParameterInfo> TempList = new List<FhirApiSearchParameterInfo>(InboundList);
      Dictionary<string, List<FhirApiSearchParameterInfo>> Dic = new Dictionary<string, List<FhirApiSearchParameterInfo>>();
      var FinalList = new List<FhirApiSearchParameterInfo>();

      foreach (var Item in TempList)
      {
        //Group each in a Dictionary where Search name is the key and possibility many SearchParameterInfos  
        var y = (from x in InboundList where x.SearchName == Item.SearchName select x);
        if (!Dic.ContainsKey(Item.SearchName))
        {
          Dic.Add(Item.SearchName, y.ToList());
        }
      }

      foreach (var item in Dic)
      {
        //If there is only one for the Search name then there is no duplicate so add to final list
        if (item.Value.Count == 1)
        {
          FinalList.Add(item.Value[0]);
        }
        else
        {
          //Group each that have the same SearchParamType and  TargetFhirLogicalType for the given Search name                             
          var DistinctItemsInfoList = item.Value.GroupBy(x => new { x.SearchParamType, x.TargetFhirLogicalType.Name }).ToList();
          FhirApiSearchParameterInfo HasFhirDateTime = null;
          FhirApiSearchParameterInfo HasPeriod = null;
          FhirApiSearchParameterInfo HasQuantity = null;
          FhirApiSearchParameterInfo HasQuantityRange = null;

          //Loop through the contents of each group checking for the types that need to be split as they are stored in different index Types
          //'FhirDateTime' & 'Period' are both searched for using the search type of 'Date', yet each is stored differently, so we can not remove one or the other as duplicates
          //Same goes for 'Quantity' and 'Range'  
          foreach (var Distinct in DistinctItemsInfoList)
          {
            if (Distinct.ElementAt(0).SearchParamType == SearchParamType.Date)
            {
              if (Distinct.ElementAt(0).TargetFhirLogicalType.Name == "FhirDateTime")
              {
                HasFhirDateTime = item.Value.Where(x => x.SearchParamType == Distinct.ElementAt(0).SearchParamType && x.TargetFhirLogicalType.Name == Distinct.ElementAt(0).TargetFhirLogicalType.Name).ToList()[0];
              }
              if (Distinct.ElementAt(0).TargetFhirLogicalType.Name == "Period")
              {
                HasPeriod = item.Value.Where(x => x.SearchParamType == Distinct.ElementAt(0).SearchParamType && x.TargetFhirLogicalType.Name == Distinct.ElementAt(0).TargetFhirLogicalType.Name).ToList()[0];
              }
            }
            if (Distinct.ElementAt(0).SearchParamType == SearchParamType.Quantity)
            {
              if (Distinct.ElementAt(0).TargetFhirLogicalType.Name == "Quantity")
              {
                HasQuantity = item.Value.Where(x => x.SearchParamType == Distinct.ElementAt(0).SearchParamType && x.TargetFhirLogicalType.Name == Distinct.ElementAt(0).TargetFhirLogicalType.Name).ToList()[0];
              }
              if (Distinct.ElementAt(0).TargetFhirLogicalType.Name == "Range")
              {
                HasQuantityRange = item.Value.Where(x => x.SearchParamType == Distinct.ElementAt(0).SearchParamType && x.TargetFhirLogicalType.Name == Distinct.ElementAt(0).TargetFhirLogicalType.Name).ToList()[0];
              }
            }
          }

          //Detect that we had both for the same Search name so add both so that indexes are built for each 
          if (HasFhirDateTime != null)
          {
            if (HasPeriod != null)
            {
              FinalList.Add(HasFhirDateTime);
              FinalList.Add(HasPeriod);
            }
          }
          //Detect that we had both for the same Search name so add both so that indexes are built for each 
          else if (HasQuantity != null)
          {
            if (HasQuantityRange != null)
            {
              FinalList.Add(HasQuantity);
              FinalList.Add(HasQuantityRange);
            }
          }
          //Otherwise just add the first as they all need the same index type and the others are ducplicates
          else
          {
            FinalList.Add(item.Value[0]);
          }
        }
      }
      return FinalList;
    }


    /// <summary>
    /// Corrections to the search parameters prior to building the repositories
    /// </summary>
    /// <param name="InboundList"></param>
    public static void FHIRApiCorrectionsForRepository(List<FhirApiSearchParameterInfo> InboundList)
    {
      //##FHIRAPIBUG## Due to a bug in the FHIR API. The 'Claim' resource's 'Use' property has an underscore 
      //after it for no apparent reason. e.g 'Claim.Use_'. This correction below needs to be called before the repository setter is build.

      var ResourceClaimSearchParameterList = (from x in InboundList
                                              where x.Resource == "Claim"
                                              select x).ToList();

      if (ResourceClaimSearchParameterList.Count > 0)
      {
        var ResourceClaimSearchParameterUse = ResourceClaimSearchParameterList.ToList().Where(x => x.Resource == "Claim" && x.SearchName == "use").SingleOrDefault();
        if (ResourceClaimSearchParameterUse != null)
        {
          if (ResourceClaimSearchParameterUse.SearchParameterNavigationPathList[ResourceClaimSearchParameterUse.SearchParameterNavigationPathList.Count - 1].PropertyName == "use")
          {
            ResourceClaimSearchParameterUse.SearchParameterNavigationPathList[ResourceClaimSearchParameterUse.SearchParameterNavigationPathList.Count - 1].PropertyName = "use_";
          }
        }
      }
      //##FHIRAPIBUG## Due to a bug in the FHIR API. The 'OrderResponse' resource's 'orderStatus' property has an underscore 
      //after it for no apparent reason. e.g 'OrderResponse.orderStatus_'. This correction below needs to be called before the repository setter is build.
      var ResourceOrderResponseSearchParameterList = (from x in InboundList
                                                      where x.Resource == "OrderResponse"
                                                      select x).ToList();
      if (ResourceOrderResponseSearchParameterList.Count > 0)
      {
        var ResourceOrderResponseSearchParameterOrderStatus = ResourceOrderResponseSearchParameterList.ToList().Where(x => x.Resource == "OrderResponse" && x.SearchName == "code").SingleOrDefault();
        if (ResourceOrderResponseSearchParameterOrderStatus != null)
        {
          if (ResourceOrderResponseSearchParameterOrderStatus.SearchParameterNavigationPathList[ResourceOrderResponseSearchParameterOrderStatus.SearchParameterNavigationPathList.Count - 1].PropertyName == "orderStatus")
          {
            ResourceOrderResponseSearchParameterOrderStatus.SearchParameterNavigationPathList[ResourceOrderResponseSearchParameterOrderStatus.SearchParameterNavigationPathList.Count - 1].PropertyName = "orderStatus_";
          }
        }
      }

      //##FHIRAPIBUG## The Condition resource has two search properties 'onset' and 'onset-info' which appear to have the esact same
      // targets in to the resource. They also seem to match the incorrect search types to Fhir types
      //i.e Date, Booleans, Range to String and others. Appears to be a bug in the FHIR API which for now I 
      //will just ignore by removing the search parameters from the index setting code gen.
      var ResourceConditionSearchParameterList = (from x in InboundList
                                                  where x.Resource == "Condition"
                                                  select x).ToList();
      if (ResourceConditionSearchParameterList.Count > 0)
      {
        var ResourceConditionSearchParameterOnSetList = ResourceConditionSearchParameterList.ToList().Where(x => x.Resource == "Condition" && x.SearchName == "onset");
        foreach (var item in ResourceConditionSearchParameterOnSetList)
        {
          InboundList.Remove(item);
        }

        var ResourceConditionSearchParameterOnSetInfoList = ResourceConditionSearchParameterList.ToList().Where(x => x.Resource == "Condition" && x.SearchName == "onset-info");
        foreach (var item in ResourceConditionSearchParameterOnSetInfoList)
        {
          InboundList.Remove(item);
        }

      }



    }

    #endregion

    #region Private Methods

    private static void ResolveSearchParameter(string ResourceName)
    {
      string[] FhirXPathChoiceList = _CurrentSearchParameterDef.XPath.Split('|');
      foreach (string SearchXPath in FhirXPathChoiceList)
      {
        FhirXPath oFhirXpath = FhirXPathFactory.FhirXPathFactoryParse(SearchXPath);
        //reset the Collection counter before we start iterating a resource's properties for this search property
        _CollectionCounter = 0;
        _SearchParameterInfo = new FhirApiSearchParameterInfo();

        var RootElement = new FhirSearchParameterSearchPathElement();
        RootElement.IsCollection = false;
        RootElement.PropertyName = ResourceName;
        RootElement.DataType = ModelInfo.GetTypeForFhirType(ResourceName);
        _SearchParameterInfo.SearchParameterNavigationPathList.Add(RootElement);

        RecursivelyNavigatePropertyPath(oFhirXpath, 1, ModelInfo.GetTypeForFhirType(ResourceName));

        _SearchParameterInfo.IsCollection = (_CollectionCounter > 0);
        _SearchParameterInfo.Resource = ResourceName;
        _SearchParameterInfo.SearchParamType = _CurrentSearchParameterDef.Type;
        _SearchParameterInfo.SearchName = _CurrentSearchParameterDef.Name;
        _SearchParameterInfo.IsChoice = (_CurrentSearchParameterDef.Path.Count() > 1);
        _SearchParameterInfo.SearchPath = SearchXPath;
        _ResourceSearchInfoList.Add(_SearchParameterInfo);
      }
    }

    private static void RecursivelyNavigatePropertyPath(FhirXPath oFhirXPath, int CurrentElement, Type Type)
    {
      SearchChoiceProperty SearchChoiceProperty = null;
      ClassMapping ClassMap = ClassMapping.Create(Type);
      foreach (var Property in ClassMap.PropertyMappings)
      {
        if (Property.Name == oFhirXPath.FhirXPathComponentList[CurrentElement].Name || (Property.Choice == ChoiceType.DatatypeChoice && oFhirXPath.FhirXPathComponentList[CurrentElement].Name.StartsWith(Property.Name)))
        {
          bool CorrectPropertyFound = false;
          if (Property.Choice == ChoiceType.DatatypeChoice && Property.ElementType == typeof(Element))
          {
            SearchChoiceProperty = FhirApiSearchSupport.ResolvePropertyNameMiniusDataType(oFhirXPath.FhirXPathComponentList[CurrentElement].Name);
            if (SearchChoiceProperty.Name == Property.Name)
            {
              CorrectPropertyFound = true;
            }
            else
            {
              CorrectPropertyFound = false;
            }
          }
          else
          {
            CorrectPropertyFound = true;
          }

          if (CorrectPropertyFound)
          {
            var ChildPathElement = new FhirSearchParameterSearchPathElement();
            ChildPathElement.IsCollection = Property.IsCollection;
            ChildPathElement.PropertyName = Property.Name;
            ChildPathElement.DataType = Property.ElementType;
            if (SearchChoiceProperty != null)
              ChildPathElement.ChoiceDataType = SearchChoiceProperty.Type;

            _SearchParameterInfo.SearchParameterNavigationPathList.Add(ChildPathElement);

            if (Property.IsCollection)
            {
              SetCollectionCountUsingElementIndexInfo(oFhirXPath.FhirXPathComponentList[CurrentElement]);
            }

            if (oFhirXPath.FhirXPathComponentList.Count() == CurrentElement + 1)
            {
              //We have reached the end of the path.
              //Check if the final target Fhir type (Not search type) to see if it contains collections , e.g CodableConcept has many Coding           
              //We only need to check the complex types. Each below has been manually added after inspecting 
              //How search works on each, if search has to deal with many for these types then they are added here.

              //This may have overhead as the search names could be on a property of the complex type that does not repeat, for instance 
              //the 'RelatedPerson' resource has  on 0..1 HumanName and only a search parameter of 'name' and 'phonetic' which do not repeat within 
              //a single HumanName.

              if (Property.ElementType == typeof(CodeableConcept) ||
                Property.ElementType == typeof(Timing) ||
                Property.ElementType == typeof(Address) ||
                Property.ElementType == typeof(HumanName))
              {
                //ChildPathElement.IsCollection = true;   
                //Don't set the Child elements to true (as above) as this hides List's of these types such as List<CodeableConcept>
                //We only need set the parent collection bool so that we get a index for the collection while also being able to detect
                //collection of collections such as List<CodeableConcept> which houses many coding. This is required knowledge to build the 
                //correct repository setters. 
                SetCollectionCountUsingElementIndexInfo(oFhirXPath.FhirXPathComponentList[CurrentElement]);

                //use this to inspect the properties of the Type when debugging
                //ClassMapping ClassMap2 = ClassMapping.Create(Property.ElementType);
              }

              if (Property.Choice == ChoiceType.DatatypeChoice && Property.ElementType == typeof(Element))
              {
                if (SearchChoiceProperty.Type == typeof(CodeableConcept) ||
                    SearchChoiceProperty.Type == typeof(Timing) ||
                    SearchChoiceProperty.Type == typeof(HumanName) ||
                    SearchChoiceProperty.Type == typeof(Address))
                {
                  SetCollectionCountUsingElementIndexInfo(oFhirXPath.FhirXPathComponentList[CurrentElement]);
                }
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
              RecursivelyNavigatePropertyPath(oFhirXPath, CurrentElement, Property.ElementType);
              return;
            }
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
        //In this case for that example we still need a collection because there maybe many in the list labelled as 'email'. Yet sometimes 
        //the choice specifier is an integer, such as this example: "f:Bundle/f:entry[0]/f:fullUrl". Here their is no collection because
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

      //List, ResourceName, SearchParameterName
      //These two search parameters I assume are an error in the API, they both are not documented in FHIR and their paths are garbage  
      RemoveSearchParameterFromList(SearchParameterList, "DataElement", "objectClass");
      RemoveSearchParameterFromList(SearchParameterList, "DataElement", "objectClassProperty");

      //The 'race' parameter on the Patient Resource is a US-Realm extension and shooudl not really be listed in the FHIR API 
      RemoveSearchParameterFromList(SearchParameterList, "Patient", "race");

      //The 'ethnicity' parameter on the Patient Resource is a US-Realm extension and should not really be listed in the FHIR API 
      RemoveSearchParameterFromList(SearchParameterList, "Patient", "ethnicity");



      //--- Correction to search parameters -----------------------------------------------------------------

      //Correction as a Bundle has many Entries and each entry only has one resource, this modification aligns correctly with the FHIR web site unlike the API  
      var ResourceBundleSearchParameterList = (from x in SearchParameterList
                                               where x.Resource == "Bundle"
                                               select x);

      var ResourceCompositionSearchParameter = ResourceBundleSearchParameterList.ToList().Where(x => x.Name == "composition").SingleOrDefault();
      if (ResourceCompositionSearchParameter != null)
      {
        if (ResourceCompositionSearchParameter.Path.Count() == 1)
        {
          if (ResourceCompositionSearchParameter.Path[0] == "Bundle.entry.resource[0]" &&
            ResourceCompositionSearchParameter.XPath == "f:Bundle/f:entry/f:resource[0]" &&
            ResourceCompositionSearchParameter.Expression == "Bundle.entry.resource[0]")
          {
            //ResourceCompositionSearchParameter.Path[0] = "Bundle.entry[0].resource";
            //ResourceCompositionSearchParameter.XPath = "f:Bundle/f:entry[0]/f:resource";
            //ResourceCompositionSearchParameter.Expression = "Bundle.entry.item(0).resource";

            ResourceCompositionSearchParameter.Path[0] = "Bundle.entry[0].fullUrl";
            ResourceCompositionSearchParameter.XPath = "f:Bundle/f:entry[0]/f:fullUrl";
            ResourceCompositionSearchParameter.Expression = "Bundle.entry[0].fullUrl";

          }
        }
      }

      var ResourceMessageSearchParameter = ResourceBundleSearchParameterList.ToList().Where(x => x.Name == "message").SingleOrDefault();
      if (ResourceMessageSearchParameter != null)
      {
        if (ResourceMessageSearchParameter.Path.Count() == 1)
        {
          if (ResourceMessageSearchParameter.Path[0] == "Bundle.entry.resource[0]" &&
            ResourceMessageSearchParameter.XPath == "f:Bundle/f:entry/f:resource[0]" &&
            ResourceMessageSearchParameter.Expression == "Bundle.entry.resource[0]")
          {
            //ResourceMessageSearchParameter.Path[0] = "Bundle.entry[0].resource";
            //ResourceMessageSearchParameter.XPath = "f:Bundle/f:entry[0]/f:resource";
            //ResourceMessageSearchParameter.Expression = "Bundle.entry.item(0).resource";

            ResourceMessageSearchParameter.Path[0] = "Bundle.entry[0].fullUrl";
            ResourceMessageSearchParameter.XPath = "f:Bundle/f:entry[0]/f:fullUrl";
            ResourceMessageSearchParameter.Expression = "Bundle.entry[0].fullUrl";

          }
        }
      }

      //Correction as a Condition resource has two search parameters of 'onset' and 'onset-info' yet both have the very same targets.
      //They should be seperated by there search parameter type where 'onset' = date types and 'onset-info' = string types.
      //I am removing and not supporting Range because it is a token and there is no standard way to express a range as a string.


      var ResourceConditionSearchParameterList = (from x in SearchParameterList
                                                  where x.Resource == "Condition"
                                                  select x);

      //Work on 'onset' search parameter
      var ResourceOnsetSearchParameter = ResourceConditionSearchParameterList.ToList().Where(x => x.Name == "onset").SingleOrDefault();
      if (ResourceOnsetSearchParameter != null)
      {
        if (ResourceOnsetSearchParameter.Path.Count() == 5)
        {
          if (ResourceOnsetSearchParameter.Path[1] == "Condition.onsetAge" &&
              ResourceOnsetSearchParameter.Path[4] == "Condition.onsetString" &&
              ResourceOnsetSearchParameter.XPath == "f:Condition/f:onsetDateTime | f:Condition/f:onsetAge | f:Condition/f:onsetPeriod | f:Condition/f:onsetRange | f:Condition/f:onsetString" &&
              ResourceOnsetSearchParameter.Expression == "Condition.onset")
          {
            string[] NewPath = { ResourceOnsetSearchParameter.Path[0],
                                 ResourceOnsetSearchParameter.Path[2]};

            ResourceOnsetSearchParameter.Path = NewPath;
            ResourceOnsetSearchParameter.XPath = "f:Condition/f:onsetDateTime | f:Condition/f:onsetPeriod";
            ResourceOnsetSearchParameter.Expression = "Condition.onset";

          }
        }
      }

      //Work on 'onset-info' search parameter
      var ResourceOnsetInfoSearchParameter = ResourceConditionSearchParameterList.ToList().Where(x => x.Name == "onset-info").SingleOrDefault();
      if (ResourceOnsetInfoSearchParameter != null)
      {
        if (ResourceOnsetInfoSearchParameter.Path.Count() == 5)
        {
          if (ResourceOnsetInfoSearchParameter.Path[1] == "Condition.onsetAge" &&
              ResourceOnsetInfoSearchParameter.Path[4] == "Condition.onsetString" &&
              ResourceOnsetInfoSearchParameter.XPath == "f:Condition/f:onsetDateTime | f:Condition/f:onsetAge | f:Condition/f:onsetPeriod | f:Condition/f:onsetRange | f:Condition/f:onsetString" &&
              ResourceOnsetInfoSearchParameter.Expression == "Condition.onset")
          {
            string[] NewPath = { ResourceOnsetInfoSearchParameter.Path[1],
                                 ResourceOnsetInfoSearchParameter.Path[4]};

            ResourceOnsetInfoSearchParameter.Path = NewPath;
            ResourceOnsetInfoSearchParameter.XPath = "f:Condition/f:onsetAge | f:Condition/f:onsetString";
            ResourceOnsetInfoSearchParameter.Expression = "Condition.onset";

          }
        }
      }




    }

    private static void RemoveSearchParameterFromList(List<ModelInfo.SearchParamDefinition> SearchParameterList, string ResourceNameForRemoval, string ParameterNameForRemoval)
    {
      ModelInfo.SearchParamDefinition SearchParamDefinitionForRemoval = SearchParameterList.SingleOrDefault(x => x.Resource == ResourceNameForRemoval && x.Name == ParameterNameForRemoval);
      if (SearchParamDefinitionForRemoval == null)
        throw new ApplicationException(string.Format("Code Generation of the database model was expecting to correct a search parameter which was in error in the FHIR API. That parameter was for Resource name: '{0}' search parameter: '{1}'. The parameter could not be found. Maybe it has been corrected and this process can be removed?", ResourceNameForRemoval, ParameterNameForRemoval));
      SearchParameterList.Remove(SearchParamDefinitionForRemoval);
    }
    #endregion
  }

}
