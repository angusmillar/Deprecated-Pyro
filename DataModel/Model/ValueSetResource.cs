using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class ValueSetResource
  {
    public int Id { get; set; }
    public int ResourceIdentity_Id { get; set; }

    public ICollection<Resource> Resources { get; set; }

    public ResourceIdentity ResourceIdentity { get; set; }
    
  }

  public static partial class DbInfo
  {
    public static partial class ValueSetResource
    {
      public static readonly string TableNameIs = "ValueSetResource";

      public static readonly string Id = "Id";
      public static readonly string ResourceIdentity_Id = "ResourceIdentity_Id";      

      public static readonly string List_Resources = "Resources";      
    }
  }
}
