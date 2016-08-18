using System;
using System.Collections.Generic;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.Enum;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.CodeGenerationSupport.RepositoryCodeGeneration
{
  public class RepositoryCodeGenModel
  {
    public List<RepositoryItem> RepositoryItemList { get; set; }
  }

  public class RepositoryItem
  {
    public string RepositoryClassName { get; set; }

    public string ResourceName { get; set; }

    public string ResourceEntityName { get; set; }
    public string ResourceHistoryEntityName { get; set; }
    public string ResourceHistoryEntityListName { get; set; }
    public string EntitySetterLogic { get; set; }

    public List<string> ResourceEntityIncludesList { get; set; }
    public List<CollectionIndexEntity> ResourceEntityCollectionPropertiesInfoList { get; set; }
    public List<NonCollectionIndexEntity> ResourceEntityNonCollectionPropertiesInfoList { get; set; }


    public RepositoryItem()
    {
      this.EntitySetterLogic = string.Empty;
      this.ResourceEntityIncludesList = new List<string>();
      this.ResourceEntityCollectionPropertiesInfoList = new List<CollectionIndexEntity>();
      this.ResourceEntityNonCollectionPropertiesInfoList = new List<NonCollectionIndexEntity>();
    }

  }

  public class CollectionIndexEntity
  {
    public string ClassName { get; set; }
    public string PropertyName { get; set; }
    public SearchParameterInfo SearchParameterInfo { get; set; }
  }

  public class NonCollectionIndexEntity
  {
    //Need here to add a new Object List that tells the indexsetter prop type, Code, System ..etc
    public List<string> PropertyNameList { get; set; }
    public SearchParameterInfo SearchParameterInfo { get; set; }

    public NonCollectionIndexEntity()
    {
      this.PropertyNameList = new List<string>();
    }
  }

  public class SearchParameterInfo
  {
    public string SearchParameterName { get; set; }
    public DatabaseEnum.DbIndexType DbIndexType { get; set; }
  }

}
