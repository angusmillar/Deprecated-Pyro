using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.ADHA.Api;
using Pyro.Common.Global;

namespace Pyro.Common.ADHA.Api
{
  public class IhiSearchValidateConfig : IIhiSearchValidateConfig
  {
    private readonly IGlobalProperties GlobalProperties;
    public IhiSearchValidateConfig(IGlobalProperties GlobalProperties)
    {
      this.GlobalProperties = GlobalProperties;      
      this.CertificateSerialNumber = GlobalProperties.HIServiceCertificateSerialNumber;
      this.HiServiceEndpoint = GlobalProperties.HIServiceEndpoint;
      this.ProductName = GlobalProperties.HIServiceProductName;
      this.ProductVersion = GlobalProperties.HIServiceProductVersion;
      this.VendorId = GlobalProperties.HIServiceVendorId;
      this.VendorIdQualifier = GlobalProperties.HIServiceVendorIdQualifier;      
    }
    
    public string CertificateSerialNumber { get; set; }
    public string HiServiceEndpoint { get; set; }
    public string ProductName { get; set; }
    public string ProductVersion { get; set; }
    public string VendorId { get; set; }
    public string VendorIdQualifier { get; set; }
  }
}
