using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.ADHA.Api
{
  public class IhiQueryMetadata : IIhiQueryMetadata
  {
    public string ErrorMessge { get; set; }
    
    public string SoapRequestMessageId { get; set; }
    public string SoapRequest { get; set; }

    public string SoapResponseMessageId { get; set; }
    public string SoapResponse { get; set; }

  }
}
