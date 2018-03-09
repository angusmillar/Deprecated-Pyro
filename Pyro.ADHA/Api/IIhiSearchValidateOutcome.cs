namespace Pyro.ADHA.Api
{
  public interface IIhiSearchValidateOutcome
  {
    IIhiQueryMetadata QueryMetadata { get; set; }
    IIhiRequestData RequestData { get; set; }
    IIhiResponseData ResponseData { get; set; }
    bool SuccessfulQuery { get; set; }
  }
}