namespace Pyro.ADHA.Api
{
  public interface IIhiSearchValidateConfig
  {
    /// <summary>
    /// The serial number of the HI Service Medicare Austrlia certificate.
    /// This certificate MUST be loaded into the windows certificate manager 
    /// withhin the windows user account's personal store. 
    /// The same user account must be accosiated with the Application pool in IIS 
    /// used to run the services to allow the service to access that store.
    /// Do not copy and paste the serial number from the store as it contains
    /// hidden charaters, manualy type the number to the config file. 
    /// </summary>   
    string CertificateSerialNumber { get; set; }

    /// <summary>
    /// The HI Service endpoint to be called
    /// </summary>
    string HiServiceEndpoint { get; set; }

    /// <summary>
    /// The HI Service certified product name, as provided by Medicare
    /// </summary>
    string ProductName { get; set; }

    /// <summary>
    /// The HI Service certified product version, as provided by Medicare
    /// </summary>
    string ProductVersion { get; set; }

    /// <summary>
    /// The HI Service certified product vendor id, as provided by Medicare
    /// </summary>
    string VendorId { get; set; }

    /// <summary>
    /// The HI Service certified product vendor id qualifier, as provided by Medicare
    /// </summary>
    string VendorIdQualifier { get; set; }


  }
}