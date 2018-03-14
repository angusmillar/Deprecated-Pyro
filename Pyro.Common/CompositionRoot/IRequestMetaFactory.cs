using Pyro.Common.RequestMetadata;

namespace Pyro.Common.CompositionRoot
{
  public interface IRequestMetaFactory
  {
    IRequestMeta CreateRequestMeta();
  }
}