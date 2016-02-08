using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

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
    public DtoEnums.SupportedFhirResource ResourceType { get; set; }
    public int ResourceIdentity_Id { get; set; }
    public int? PatientResource_Id { get; set; }
    public int? ValueSetResource_Id { get; set; }

    //BackLinks   
    public ResourceIdentity ResourceIdentity { get; set; }
    public virtual PatientResource PatientResource { get; set; }
    public virtual ValueSetResource ValueSetResource { get; set; }    
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
      public static readonly string ResourceType = "ResourceType";

      public static readonly string ResourceIdentity_Id = "ResourceIdentity_Id";      
      public static readonly string PatientResource_Id = "PatientResource_Id";
      public static readonly string ValueSetResource_Id = "ValueSetResource_Id";
      
    }
  }
}
