using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;
using Hl7.Fhir.Model;

namespace Blaze.CodeGenerationSupport.RepositoryCodeGeneration
{
  public class RepositoryCodeGeneration
  {
    private List<string> _ResourceList;
    private List<FhirApiSearchParameterInfo> _SearchParametersList;

    public RepositoryCodeGenModel Generate()
    {
      _ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      _SearchParametersList = FhirApiSearchParameterInfoFactory.GetApiSearchParameterInfo();
      
      var RepositoryCodeGenModel = new RepositoryCodeGenModel();
      RepositoryCodeGenModel.RepositoryItemList = new List<RepositoryItem>();
      
      foreach (var ResourceName in _ResourceList)
      {
        List<FhirApiSearchParameterInfo> SearchParametersForResource = (from x in _SearchParametersList
                                                                        where x.Resource == ResourceName
                                                                        select x).ToList();

        List<FhirApiSearchParameterInfo> CollectionParameters = (from x in SearchParametersForResource
                                                                 where x.IsCollection == true
                                                                 select x).ToList();

        List<FhirApiSearchParameterInfo> NonCollectionParameters = (from x in SearchParametersForResource
                                                                    where x.IsCollection == false
                                                                    select x).ToList();
        
        FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(CollectionParameters,false);
        FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(NonCollectionParameters, false);
        
        FhirApiSearchParameterInfoFactory.FHIRApiCorrectionsForRepository(NonCollectionParameters);
        FhirApiSearchParameterInfoFactory.FHIRApiCorrectionsForRepository(CollectionParameters);
        
        var RepositoryItem = new RepositoryItem();
        RepositoryCodeGenModel.RepositoryItemList.Add(RepositoryItem);

        RepositoryItem.RepositoryClassName = String.Format("{0}{1}", ResourceName, "Repository");
        RepositoryItem.ResourceEntityName = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
        RepositoryItem.ResourceName = ResourceName;
        RepositoryItem.ResourceHistoryEntityName = DatabaseModelInfo.ConstructClassNameForResourceHistory(ResourceName);
        RepositoryItem.ResourceHistoryEntityListName = DatabaseModelInfo.ConstructClassNameForResourceHistoryList(ResourceName);

        foreach (FhirApiSearchParameterInfo CollectionParameter in CollectionParameters)
        {
          RepositoryItem.ResourceEntityIncludesList.Add(DatabaseModelInfo.ConstructCollectionListName(CollectionParameter));
          IndexEntity oIndexEntity = new IndexEntity();
          RepositoryItem.ResourceEntityCollectionPropertiesInfo.Add(oIndexEntity);
          oIndexEntity.IndexEntityClassName = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(ResourceName, CollectionParameter);
          oIndexEntity.IndexEntityPropertyName = DatabaseModelInfo.ConstructCollectionListName(CollectionParameter);
        }

        foreach(FhirApiSearchParameterInfo NonCollectionParameter in NonCollectionParameters)
        {
          List<string> Propertylist = new List<string>();
          DatabaseModelInfo.GenerateNonCollectionPropertiesNames(Propertylist, NonCollectionParameter);
          RepositoryItem.ResourceEntityNonCollectionProperties.AddRange(Propertylist);          
        }
        RepositoryItem.ResourceEntityNonCollectionProperties.Add(DatabaseModelInfo.XmlBlobPropertyText);

        //ToDo: Sort out how to generate the setters for the bundle resource
        if (ResourceName != "Bundle")    
        //if (ResourceName == "ConceptMap")
        {
          List<string> LogicList = new List<string>();
          //Non Collection search parameter logic
          //---------------------------------------------------------------------------------------
          foreach (FhirApiSearchParameterInfo NonCollectionParameter in NonCollectionParameters)
          {
            StringBuilder Sb = new StringBuilder();                                     
            Sb = RepositoryNonCollectionSetterLogicBuilder.Build(NonCollectionParameter, ResourceName, "ResourceTyped", "ResourseEntity");                                
            LogicList.Add(Sb.ToString());                       
          }

          //Collection search parameter logic
          //---------------------------------------------------------------------------------------
          foreach (FhirApiSearchParameterInfo CollectionParameter in CollectionParameters)
          {
            StringBuilder Sb = new StringBuilder();                        
            Sb = RepositoryCollectionSetterLogicBuilder.Build(CollectionParameter, ResourceName, "ResourceTyped", "ResourseEntity");            
            LogicList.Add(Sb.ToString());
          }

          
          string CompileAllLogic = string.Empty;
          LogicList.ForEach(x => CompileAllLogic = CompileAllLogic + x);
          RepositoryItem.EntitySetterLogic = CompileAllLogic;                         
        }
      }
      
      return RepositoryCodeGenModel;
    }

    static string UppercaseFirst(string s)
    {
      // Check for empty string.
      if (string.IsNullOrEmpty(s))
      {
        return string.Empty;
      }
      // Return char and concat substring.
      return char.ToUpper(s[0]) + s.Substring(1);
    }

    static string DepthSpace(int DepthCounter)
    {
      string Result = string.Empty;
      for (int i = 0; i < DepthCounter; i++)
      {
        Result = Result + " ";
      }
      return Result;
    }

  }
}
