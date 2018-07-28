using Pyro.Common.ServiceConfigration;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using Pyro.Common.Global;
using Pyro.Common.Tools;
using System.Reflection;

namespace Pyro.Engine.Services.ServiceConfiguration
{
  public class ServiceConfigurationService : IServiceConfigurationService
  {
    private readonly IServiceConfigurationRepository IServiceConfigurationRepository;

    public ServiceConfigurationService(IServiceConfigurationRepository IServiceConfigurationRepository)       
    {
      this.IServiceConfigurationRepository = IServiceConfigurationRepository;
    }

    public DtoServiceConfigration GetServiceConfigrationByParameter(string Parameter)
    {
      return IServiceConfigurationRepository.GetDtoServiceConfigrationByParameter(Parameter);
    }

    public DtoServiceConfigration UpdateServiceConfigrationByParameter(DtoServiceConfigration DtoServiceConfigration)
    {
      return IServiceConfigurationRepository.UpdateServiceConfigration(DtoServiceConfigration);
    }

    public Dictionary<string, string> GetServiceConfigrationDictionary()
    {
      return IServiceConfigurationRepository.GetServiceConfigrationDictionary();
    }

    public bool SynchronizeServiceConfigrationWithGlobalProperties(IGlobalProperties GlobalProperties)
    {
      var DateNow = System.DateTimeOffset.Now;
      bool Result = false;
      Type type = typeof(IGlobalProperties);
      PropertyInfo[] properties = type.GetProperties();
      foreach (PropertyInfo property in properties)
      {        
        if (IServiceConfigurationRepository.UpdateIfNewOrModifiedServiceConfigration(property.Name, property.GetValue(GlobalProperties, null).ToString(), Pyro.Common.PyroHealthFhirResource.PyroHealthSystemUser.User, DateNow))
        {
          Result = true;
        }
      }
      return Result;      
    }    

  }
}
