using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.ADHA.Api
{
  public class IhiQueryMetadata : IIhiQueryMetadata
  {
    public IhiQueryMetadata()
    {
      this.ServiceMessage = new List<IHiServiceMessage>();
    }

    public string ErrorMessge { get; set; }
    public List<IHiServiceMessage> ServiceMessage { get; set; }

    public string SoapRequestMessageId { get; set; }
    public string SoapRequest { get; set; }

    public string SoapResponseMessageId { get; set; }
    public string SoapResponse { get; set; }

  }
}
