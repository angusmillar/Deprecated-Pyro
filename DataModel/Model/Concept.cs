using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class Concept
  {
    public Int64 Id { get; set; }
    public string Code { get; set; }
    public int CodeSystem_Id { get; set; }
    public ICollection<Concept> ConceptChild { get; set; }   

    //BackLink    
    public virtual Concept ConceptParent { get; set; }    

    //Keyed
    public virtual CodeSystem CodeSystem { get; set; }
    

    public Concept()
    {
      ConceptChild = new HashSet<Concept>();
    }
  }

  public static partial class DbInfo
  {
    public static partial class Concept
    {
      public static readonly string TableNameIs = "Concept";

      public static readonly string Id = "Id";
      public static readonly string Code = "Code";
      public static readonly string List_Concept = "Concept";      

      public static readonly string CodeSystem_Id = "CodeSystem_Id";      

    }
  }
}
