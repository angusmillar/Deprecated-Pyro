using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System.Runtime.Serialization;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.BusinessEntities.Dto
{
  [Serializable]
  public class DtoServiceSearchParameterLight
  {
    public int Id { get; set; }
    public string Resource { get; set; }
    public string Name { get; set; }
    public SearchParamType Type { get; set; }
    public string Expression { get; set; }
    //public ICollection<DtoServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
    public List<IServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
    
    public DtoServiceSearchParameterLight(){ }

    public DtoServiceSearchParameterLight(SerializationInfo info, StreamingContext context)
    {
      Id = info.GetInt32("Id");
      Resource = info.GetString("Resource");
      Name = info.GetString("Name");
      Type = (SearchParamType)info.GetInt32("Type");
      Expression = info.GetString("Expression");
    }

    //Implemented Serializable as this object goes into Cache
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Id", Id);
      info.AddValue("Resource", Resource);
      info.AddValue("Name", Name);
      info.AddValue("Type", (int)Type);
      info.AddValue("Expression", Expression);
    }
  }
}
