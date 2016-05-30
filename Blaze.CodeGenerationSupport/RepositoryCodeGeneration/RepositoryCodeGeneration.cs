using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;

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

        CollectionParameters = FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(CollectionParameters);
        NonCollectionParameters = FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(NonCollectionParameters);

        
        
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


        if (ResourceName == "Patient")
        {
          foreach (FhirApiSearchParameterInfo NonCollectionParameter in NonCollectionParameters)
          {
            StringBuilder Sb = new StringBuilder();
            foreach (var Element in NonCollectionParameter.SearchParameterNavigationPathList)
            {

            }


              //if (ResourceTyped.Active != null)
              //{
              //  var token = IndexSettingSupport.CreateToken(ResourceTyped.ActiveElement);
              //  ResourseEntity.active_Code = ResourceTyped.Active.ToString();
              //  ResourseEntity.active_System = "http://hl7.org/fhir/ValueSet/special-values";
              //}

            
          }
        }
 

      }
      return RepositoryCodeGenModel;
    }
  }
}
