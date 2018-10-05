using Pyro.Common.ServiceConfigration;
using System.Collections.Generic;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IServiceConfigurationRepository
  {    
    DtoServiceConfigration GetDtoServiceConfigrationByParameter(string Parameter);
    DtoServiceConfigration UpdateServiceConfigration(DtoServiceConfigration DtoServiceConfigration);
    bool UpdateIfNewOrModifiedServiceConfigration(string Parameter, string Value, string UserUpdating, System.DateTime UpdateingDateTime);
    Dictionary<string, string> GetServiceConfigrationDictionary();
  }
}