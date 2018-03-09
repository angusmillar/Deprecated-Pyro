namespace Pyro.ADHA.Api
{
  public interface IHiServiceApi
  {
    IIhiSearchValidateOutcome SearchOrValidateIhi(IIhiRequestData IhiRequestDemographics);
  }
}