using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class Given
  {
    public int Id { get; set; }
    public string Value { get; set; }
    
    //Keyed
    public virtual HumanName HumanName { get; set; }   
  }

  public static partial class DbInfo
  {    
    public static class Given
    {
      public static readonly string TableNameIs = "Given";
      
      public static readonly string Id = "Id";
      public static readonly string Value = "Value";
      public static readonly string HumanName_Id = "HumanName_Id";
     
    }
  }
}
