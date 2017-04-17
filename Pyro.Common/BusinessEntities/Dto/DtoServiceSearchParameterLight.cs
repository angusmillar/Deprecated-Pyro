using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System.Runtime.Serialization;

namespace Pyro.Common.BusinessEntities.Dto
{
  [Serializable]
  public class DtoServiceSearchParameterLight
  {
    public string Resource { get; set; }
    public string Name { get; set; }
    public SearchParamType Type { get; set; }
    public string Expression { get; set; }

    public DtoServiceSearchParameterLight(){ }

    public DtoServiceSearchParameterLight(SerializationInfo info, StreamingContext context)
    {
      Resource = info.GetString("Resource");
      Name = info.GetString("Name");
      Type = (SearchParamType)info.GetInt32("Type");
      Expression = info.GetString("Expression");
    }

    //Implemented Serializable as this object goes into Cache
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Resource", Resource);
      info.AddValue("Name", Name);
      info.AddValue("Type", (int)Type);
      info.AddValue("Expression", Expression);
    }
  }
}
