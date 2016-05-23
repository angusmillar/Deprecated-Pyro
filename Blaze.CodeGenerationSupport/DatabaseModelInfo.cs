using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.CodeGenerationSupport
{
  public static class DatabaseModelInfo
  {
    public static string ApplicationName { get { return "Blaze"; } }
    public static string ResourcePrefixText { get { return "Res"; } }
    public static string IndexPrefixText { get { return "Index"; } }
    public static string HistoryPrefixText { get { return "History"; } }

    public static string DatabaseModelBaseClassName { get { return "ModelBase"; } }
    public static string DatabaseModelResourceIndexBaseClassName { get { return "ResourceIndexBase"; } }   
    
    public static string DatabaseModelMetaProfileName { get { return "meta_profile"; } }
    public static string DatabaseModelMetaSecurityName { get { return "meta_security"; } }
    public static string DatabaseModelMetaTagName { get { return "meta_tag"; } } 
    
    
    

  }
}
