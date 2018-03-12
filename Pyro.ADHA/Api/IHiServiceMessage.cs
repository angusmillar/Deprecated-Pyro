namespace Pyro.ADHA.Api
{
  public interface IHiServiceMessage
  {
    string Code { get; set; } 
    string Reason { get; set; }
    string SeverityType { get; set; }
  }
}