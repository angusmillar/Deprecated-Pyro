using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.ADHA.Api;

namespace Pyro.Common.ADHA.Api
{
  public class IhiRequestData : IIhiRequestData
  {
    public string UserId { get; set; }
    public string UserIdQualifier { get; set; }
    public bool ReturnSoapRequestAndResponseData { get; set; }
    public string Family { get; set; }
    public string Given { get; set; }
    public char SexChar { get; set; }
    public DateTime? Dob { get; set; }
    public string MedicareNumber { get; set; }
    public string MedicareIRN { get; set; }
    public string DVANumber { get; set; }
    public string IHINumber { get; set; }
  }
}
