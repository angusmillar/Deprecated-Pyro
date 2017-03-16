namespace Pyro.Common.Interfaces.Dto.Headers
{
  public interface IDtoRequestHeaders
  {
    string IfNoneExist { get; set; }
    string IfModifiedSince { get; set; }
    string IfMatch { get; set; }
    string IfNoneMatch { get; set; }
  }
}