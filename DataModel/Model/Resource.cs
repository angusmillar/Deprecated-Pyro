using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
  
  public class Resource
  {
    public int Id { get; set; }
    public string Xml { get; set; }
    public int Version { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset Received { get; set; }
    public int PatientResourceId { get; set; }
    public virtual PatientResource PatientResource { get; set; } 
   
  }

  public static partial class DbInfo
  {
    public static partial class Resource
    {
      public static readonly string TableNameIs = "Resource";

      public static readonly string Id = "Id";
      public static readonly string Xml = "Xml";
      public static readonly string Version = "Version";
      public static readonly string IsCurrent = "IsCurrent";
      public static readonly string IsDeleted = "IsDeleted";
      public static readonly string Received = "Received";
      public static readonly string PatientResourceId = "PatientResourceId";
    }
  }
}
