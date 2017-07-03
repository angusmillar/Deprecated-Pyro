using System.Collections.Generic;
using System.Runtime.Serialization;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.BusinessEntities.Dto
{
  public interface IDtoServiceSearchParameterLight
  {
    string Expression { get; set; }
    int Id { get; set; }
    string Name { get; set; }
    string Resource { get; set; }
    List<IServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
    SearchParamType Type { get; set; }

    void GetObjectData(SerializationInfo info, StreamingContext context);
  }
}