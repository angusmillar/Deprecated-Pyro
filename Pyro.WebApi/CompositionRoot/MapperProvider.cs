using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using AutoMapper;
using AutoMapper.Configuration;
using Pyro.DataLayer.DbModel.AutoMapperProfile;

namespace Pyro.WebApi.CompositionRoot
{
  public class MapperProvider
  {
    private readonly Container _container;

    public MapperProvider(Container container)
    {
      _container = container;
    }

    public IMapper GetMapper()
    {
      var MapperConfigurationExpression = new MapperConfigurationExpression();
      MapperConfigurationExpression.ConstructServicesUsing(_container.GetInstance);
      
      //Register Map Profiles
      MapperConfigurationExpression.AddProfile<ServiceCompartmentProfile>();
      MapperConfigurationExpression.AddProfile<ServiceCompartmentResourceProfile>();
      MapperConfigurationExpression.AddProfile<FhirReleaseProfile>();
      MapperConfigurationExpression.AddProfile<ServiceConfigurationProfile>();
      MapperConfigurationExpression.AddProfile<BackburnerConnectionProfile>();

      var MapperConfiguration = new MapperConfiguration(MapperConfigurationExpression);
      
      //Validates the map profiles
      MapperConfiguration.AssertConfigurationIsValid();

      return new Mapper(MapperConfiguration, t => _container.GetInstance(t));      
    }
    
  }
}