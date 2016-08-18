using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Enum;

namespace Blaze.Common.Interfaces.Dto
{
  public interface IDtoSearchParameterDbInfo
  {
    FhirSearchEnum.SearchParameterNameType NameType { get; set; }    
    DatabaseEnum.DbIndexType BlazeIndexType { get; set; }
    bool IsCollectionIndex { get; set; }
    string DatabasePropertyName { get; set; }
  }
}
