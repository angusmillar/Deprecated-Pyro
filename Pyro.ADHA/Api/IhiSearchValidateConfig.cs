using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.ADHA.Api
{
  internal class IhiSearchValidateConfig : IIhiSearchValidateConfig
  {
    public string CertificateSerialNumber { get; set; }        
    public string HiServiceEndpoint { get; set; }    
    
    public string ProductName { get; set; }
    public string ProductVersion { get; set; }
    public string VendorId { get; set; }
    public string VendorIdQualifier { get; set; }

  }
}
