using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.ADHA.Api
{
  internal class IhiRequestData : IhiDemographicsBase, IIhiRequestData
  {
    public string UserId { get; set; }
    public string UserIdQualifier { get; set; }
    public bool ReturnSoapRequestAndResponseData { get; set; }
  }
}
