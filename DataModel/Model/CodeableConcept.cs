using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  public class CodeableConcept
  {
    public int Id { get; set; }        
    public string Text { get; set; }
    public ICollection<Coding> Coding { get; set; }
    
    //BackLinks
    public virtual Identifier Identifier { get; set; }
    
    //Keyed
    public virtual ValueSetResource ValueSetResource { get; set; } 
    
    public CodeableConcept()
    {
      Coding = new HashSet<Coding>();
    }
  }

  public static partial class DbInfo
  {
    public static partial class CodeableConcept
    {
      public static readonly string TableNameIs = "CodeableConcept";

      public static readonly string Id = "Id";            
      public static readonly string Text = "Text";
      public static readonly string ValueSetResource_Id = "ValueSetResource_Id";
      public static readonly string List_Codeing = "Coding";
          
    }
  }
}
