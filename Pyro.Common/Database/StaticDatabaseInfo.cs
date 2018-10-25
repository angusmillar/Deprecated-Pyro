using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;

namespace Pyro.Common.Database
{
  public static class StaticDatabaseInfo
  {
    public static class DatabaseCreateSwitches
    {
      public static bool DevelopmentOnlyGenerateMigrations { get { return false; } }
      public static bool CaseSensitiveColumnAnnotationOn { get { return true; } }
    }

    public static class BaseDatabaseFieldLength
    {
      public static int ResourceTypeStringMaxLength { get { return 50; } }
      public static int FhirIdMaxLength { get { return 128; } }
      public static int StringMaxLength { get { return 450; } }
      public static int NameMaxLength { get { return 128; } }
      public static int DescriptionMaxLength { get { return 256; } }
      public static byte QuantityPrecision { get { return 28; } }
      public static byte QuantityScale { get { return 14; } }
      public static int CodeMaxLength { get { return 128; } }
      public static int UnitMaxLength { get { return 64; } }
      public static byte DateTimeOffsetPrecision { get { return 3; } }
    }


    public static class BaseResourceConstatnts
    {
      public static string Id { get { return "Id"; } }
      public static string IsCurrent { get { return "IsCurrent"; } }    
      public static string FhirId { get { return "FhirId"; } }
      public static string IsDeleted { get { return "IsDeleted"; } }
      public static string LastUpdated { get { return "LastUpdated"; } }
      public static string VersionId { get { return "VersionId"; } }
      //public static string XmlBlob { get { return "XmlBlob"; } }
      public static string Method { get { return "Method"; } }

      public static string IndexStringList { get { return "IndexStringList"; } }
      public static string IndexTokenList { get { return "IndexTokenList"; } }
      public static string IndexUriList { get { return "IndexUriList"; } }
      public static string IndexReferenceList { get { return "IndexReferenceList"; } }
      public static string IndexQuantityList { get { return "IndexQuantityList"; } }
      public static string IndexDateTimeList { get { return "IndexDateTimeList"; } }

    }

    public static class BaseResourceIndexConstatnts
    {
      public static string Id { get { return "Id"; } }

      public static string ServiceSearchParameter { get { return "ServiceSearchParameter"; } }
      public static string ServiceSearchParameterId { get { return "ServiceSearchParameterId"; } }

      public static string String { get { return "String"; } }      

      //public static string DateTimeOffsetLow { get { return "DateTimeOffsetLow"; } }
      //public static string DateTimeOffsetHigh { get { return "DateTimeOffsetHigh"; } }

      public static string LowUtcDateTime { get { return "LowUtcDateTime"; } }
      public static string HighUtcDateTime { get { return "HighUtcDateTime"; } }


      public static string Uri { get { return "Uri"; } }      

      public static string Comparator { get { return "Comparator"; } }
      public static string Quantity { get { return "Quantity"; } }
      public static string System { get { return "System"; } }      
      public static string Code { get { return "Code"; } }      
      public static string Unit { get { return "Unit"; } }      

      public static string ComparatorHigh { get { return "ComparatorHigh"; } }
      public static string QuantityHigh { get { return "QuantityHigh"; } }
      public static string SystemHigh { get { return "SystemHigh"; } }
      public static string CodeHigh { get { return "CodeHigh"; } }
      public static string UnitHigh { get { return "UnitHigh"; } }

      public static string ReferenceFhirId { get { return "ReferenceFhirId"; } }
      public static string ReferenceResourceType { get { return "ReferenceResourceType"; } }      
      public static string ReferenceVersionId { get { return "ReferenceVersionId"; } }
      public static string ReferenceUrl { get { return "ReferenceUrl"; } }
      public static string ReferenceServiceBaseUrlId { get { return "ReferenceServiceBaseUrlId"; } }
    }

    public static class ServiceBaseUrlConstatnts
    {
      public static string Id { get { return "Id"; } }
      public static string Url { get { return "Url"; } }
      public static string IsServersPrimaryUrlRoot { get { return "IsServersPrimaryUrlRoot"; } }
    }

    public static class ServiceSearchParameterConstatnts
    {
      public static string Id { get { return "Id"; } }
      public static string Resource { get { return "Resource"; } }
      public static string Name { get { return "Name"; } }      
      public static string Url { get { return "Url"; } }
      public static string Description { get { return "Description"; } }     
      public static string Type { get { return "Type"; } }
      public static string XPath { get { return "XPath"; } }
      public static string Expression { get { return "Expression"; } }
    }

    public static class ServiceCompartmentParameterConstatnts
    {
      public static string Id { get { return "Id"; } }
      public static string CompartmentDefinitionResourceId { get { return "CompartmentDefinitionResourceId"; } }      
      public static string Url { get { return "Url"; } }
      public static string Name { get { return "Name"; } }
      public static string Title { get { return "Title"; } }
      public static string Code { get { return "Code"; } }            
    }

    public static class ServiceCompartmentResourceParameterConstatnts
    {
      public static string Code { get { return "Code"; } }      
      public static string Param { get { return "Param"; } }
    }

  }

}
