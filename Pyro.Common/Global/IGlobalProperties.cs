namespace Pyro.Common.Global
{
  public interface IGlobalProperties
  {
    string ServiceRootUrl { get; }
    bool ApplicationCacheServicesActive { get; }
    string ApplicationVersionInfo { get; }
  }
}