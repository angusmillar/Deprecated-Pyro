using Pyro.Common.Global;
using Pyro.Common.ServiceConfigration;
using System.Collections.Generic;

namespace Pyro.Common.Interfaces.Service
{
  public interface IServiceConfigurationService
  {
    DtoServiceConfigration GetServiceConfigrationByParameter(string Parameter);
    DtoServiceConfigration UpdateServiceConfigrationByParameter(DtoServiceConfigration DtoServiceConfigration);
    bool SynchronizeServiceConfigrationWithGlobalProperties(IGlobalProperties GlobalProperties);
    Dictionary<string, string> GetServiceConfigrationDictionary();
  }
}