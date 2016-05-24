using System;
using System.Collections.Generic;
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

    public List<string> ResourceEntityIncludesList { get; set; }
    public List<string> ResourceEntityNonCollectionProperties { get; set; }
    public List<IndexEntity> ResourceEntityCollectionPropertiesInfo { get; set; }

    public RepositoryItem()
    {
      this.ResourceEntityIncludesList = new List<string>();
      this.ResourceEntityNonCollectionProperties = new List<string>();
      this.ResourceEntityCollectionPropertiesInfo = new List<IndexEntity>();
    }
    
  }

  public class IndexEntity
  {
    public string IndexEntityClassName { get; set; }
    public string IndexEntityPropertyName { get; set; }
  }

}
