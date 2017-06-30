namespace Pyro.Common.BusinessEntities.Global
{
  public interface IGlobalProperties
  {
    string ServiceRootUrl { get; }
    bool ApplicationCacheServicesActive { get; }
  }
}