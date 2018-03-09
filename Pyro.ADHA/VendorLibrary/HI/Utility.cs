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
                Mapper.CreateMap<CommonSearchIHIRequestType, Async.SearchIHIRequestType>();
                Mapper.CreateMap<CommonAustralianPostalAddressType, Async.AustralianPostalAddressType>();
                Mapper.CreateMap<CommonAustralianStreetAddressType, Async.AustralianStreetAddressType>();
                Mapper.CreateMap<CommonCountryType, Async.CountryType>();
                Mapper.CreateMap<CommonInternationalAddressType, Async.InternationalAddressType>();
                Mapper.CreateMap<CommonAustralianUnstructuredStreetAddressType, Async.AustralianUnstructuredStreetAddressType>();
                Mapper.CreateMap<CommonLevelGroupType, Async.LevelGroupType>();
                Mapper.CreateMap<CommonLevelType, Async.LevelType>();
                Mapper.CreateMap<CommonPostalDeliveryGroupType, Async.PostalDeliveryGroupType>();
                Mapper.CreateMap<CommonPostalDeliveryType, Async.PostalDeliveryType>();
                Mapper.CreateMap<CommonSearchIHI, Async.searchIHI>();
                Mapper.CreateMap<CommonSexType, Async.SexType>();
                Mapper.CreateMap<CommonStateType, Async.StateType>();
                Mapper.CreateMap<CommonStreetSuffixType, Async.StreetSuffixType>();
                Mapper.CreateMap<CommonStreetType, Async.StreetType>();
                Mapper.CreateMap<CommonTrueFalseType, Async.TrueFalseType>();
                Mapper.CreateMap<CommonUnitGroupType, Async.UnitGroupType>();
                Mapper.CreateMap<CommonUnitType, Async.UnitType>();

                // Set up mappings for sync search
                Mapper.CreateMap<CommonSearchIHIRequestType, Sync.SearchIHIRequestType>();
                Mapper.CreateMap<CommonAustralianPostalAddressType, Sync.AustralianPostalAddressType>();
                Mapper.CreateMap<CommonAustralianStreetAddressType, Sync.AustralianStreetAddressType>();
                Mapper.CreateMap<CommonCountryType, Sync.CountryType>();
                Mapper.CreateMap<CommonInternationalAddressType, Sync.InternationalAddressType>();
                Mapper.CreateMap<CommonAustralianUnstructuredStreetAddressType, Sync.AustralianUnstructuredStreetAddressType>();
                Mapper.CreateMap<CommonLevelGroupType, Sync.LevelGroupType>();
                Mapper.CreateMap<CommonLevelType, Sync.LevelType>();
                Mapper.CreateMap<CommonPostalDeliveryGroupType, Sync.PostalDeliveryGroupType>();
                Mapper.CreateMap<CommonPostalDeliveryType, Sync.PostalDeliveryType>();
                Mapper.CreateMap<CommonSearchIHI, Sync.searchIHI>();
                Mapper.CreateMap<CommonSexType, Sync.SexType>();
                Mapper.CreateMap<CommonStateType, Sync.StateType>();
                Mapper.CreateMap<CommonStreetSuffixType, Sync.StreetSuffixType>();
                Mapper.CreateMap<CommonStreetType, Sync.StreetType>();
                Mapper.CreateMap<CommonTrueFalseType, Sync.TrueFalseType>();
                Mapper.CreateMap<CommonUnitGroupType, Sync.UnitGroupType>();
                Mapper.CreateMap<CommonUnitType, Sync.UnitType>();
            }
        }
    }
}
