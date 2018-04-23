using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Pyro.ADHA.VendorLibrary.HI.Common;
using Async = Pyro.ADHA.mcaR3.ConsumerSearchIHIBatchAsync;
using Sync = Pyro.ADHA.mcaR3.ConsumerSearchIHIBatchSync;

namespace Pyro.ADHA.VendorLibrary.HI
{
  internal class Utility
  {
    public static bool MappingSet { get; set; }

    public static void SetUpMapping()
    {
      if (!MappingSet)
      {

        // Set up mappings for async search
        Mapper.Initialize(cfg => cfg.CreateMap<CommonSearchIHIRequestType, Async.SearchIHIRequestType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonAustralianPostalAddressType, Async.AustralianPostalAddressType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonAustralianStreetAddressType, Async.AustralianStreetAddressType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonCountryType, Async.CountryType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonInternationalAddressType, Async.InternationalAddressType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonAustralianUnstructuredStreetAddressType, Async.AustralianUnstructuredStreetAddressType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonLevelGroupType, Async.LevelGroupType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonLevelType, Async.LevelType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonPostalDeliveryGroupType, Async.PostalDeliveryGroupType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonPostalDeliveryType, Async.PostalDeliveryType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonSearchIHI, Async.searchIHI>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonSexType, Async.SexType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonStateType, Async.StateType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonStreetSuffixType, Async.StreetSuffixType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonStreetType, Async.StreetType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonTrueFalseType, Async.TrueFalseType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonUnitGroupType, Async.UnitGroupType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonUnitType, Async.UnitType>());

        // Set up mappings for sync search
        Mapper.Initialize(cfg => cfg.CreateMap<CommonSearchIHIRequestType, Sync.SearchIHIRequestType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonAustralianPostalAddressType, Sync.AustralianPostalAddressType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonAustralianStreetAddressType, Sync.AustralianStreetAddressType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonCountryType, Sync.CountryType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonInternationalAddressType, Sync.InternationalAddressType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonAustralianUnstructuredStreetAddressType, Sync.AustralianUnstructuredStreetAddressType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonLevelGroupType, Sync.LevelGroupType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonLevelType, Sync.LevelType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonPostalDeliveryGroupType, Sync.PostalDeliveryGroupType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonPostalDeliveryType, Sync.PostalDeliveryType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonSearchIHI, Sync.searchIHI>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonSexType, Sync.SexType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonStateType, Sync.StateType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonStreetSuffixType, Sync.StreetSuffixType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonStreetType, Sync.StreetType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonTrueFalseType, Sync.TrueFalseType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonUnitGroupType, Sync.UnitGroupType>());
        Mapper.Initialize(cfg => cfg.CreateMap<CommonUnitType, Sync.UnitType>());
      }
    }
  }
}
