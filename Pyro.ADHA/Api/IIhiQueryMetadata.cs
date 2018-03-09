namespace Pyro.ADHA.Api
{
  public interface IIhiQueryMetadata
  {
    string ErrorMessge { get; set; }
    string SoapRequest { get; set; }
    string SoapRequestMessageId { get; set; }
    string SoapResponse { get; set; }
    string SoapResponseMessageId { get; set; }
  }
}