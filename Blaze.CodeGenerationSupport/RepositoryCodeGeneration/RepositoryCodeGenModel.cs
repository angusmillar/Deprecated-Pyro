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
    public string  ClassName { get; set; }
  }

}
