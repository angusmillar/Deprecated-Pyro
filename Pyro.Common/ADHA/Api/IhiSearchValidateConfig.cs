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
      string test = GlobalProperties.ApplicationVersionInfo;

      this.CertificateSerialNumber = "063c23";
      this.HiServiceEndpoint = "https://www5.medicareaustralia.gov.au/cert/soap/services/";
      this.ProductName = "NEHTA HIPS";
      this.ProductVersion = "6.1";
      this.VendorId = "HIPS0001";
      this.VendorIdQualifier = "http://ns.electronichealth.net.au/id/hi/vendorid/1.0";
    }
    public string CertificateSerialNumber { get; set; }
    public string HiServiceEndpoint { get; set; }
    public string ProductName { get; set; }
    public string ProductVersion { get; set; }
    public string VendorId { get; set; }
    public string VendorIdQualifier { get; set; }
  }
}
