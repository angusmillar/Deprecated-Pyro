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
    public static class DataLayerIndexPropertyConstatnts
    {

      public static class BaseResourceConstatnts
      {
        public static string Id { get { return "Id"; } }
        public static string IsCurrent { get { return "IsCurrent"; } }
        public static string FhirId { get { return "FhirId"; } }
        public static string IsDeleted { get { return "IsDeleted"; } }
        public static string LastUpdated { get { return "LastUpdated"; } }
        public static string VersionId { get { return "VersionId"; } }
        public static string XmlBlob { get { return "XmlBlob"; } }
        public static string Method { get { return "Method"; } }
        public static string IndexList { get { return "IndexList"; } }
      }

      public static class BaseResourceIndexConstatnts
      {
        public static string Id { get { return "Id"; } }

        public static string ServiceSearchParameter { get { return "ServiceSearchParameter"; } }
        public static string ServiceSearchParameterId { get { return "ServiceSearchParameterId"; } }

        public static string String { get { return "String"; } }
        
        public static string DateTimeOffsetLow { get { return "DateTimeOffsetLow"; } }
        public static string DateTimeOffsetHigh { get { return "DateTimeOffsetHigh"; } }

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
    }    
  }
}
