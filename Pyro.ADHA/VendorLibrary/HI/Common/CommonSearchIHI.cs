using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.ADHA.VendorLibrary.HI.Common
{
    public partial class CommonSearchIHIRequestType
    {
        private CommonSearchIHI searchIHIField;

        private string requestIdentifierField;

        public CommonSearchIHI searchIHI
        {
            get
            {
                return this.searchIHIField;
            }
            set
            {
                this.searchIHIField = value;
            }
        }

        public string requestIdentifier
        {
            get
            {
                return this.requestIdentifierField;
            }
            set
            {
                this.requestIdentifierField = value;
            }
        }
    }

    public partial class CommonSearchIHI
    {
        private string ihiNumberField;

        private string medicareCardNumberField;

        private string medicareIRNField;

        private string dvaFileNumberField;

        private System.DateTime dateOfBirthField;

        private bool dateOfBirthFieldSpecified;

        private CommonSexType sexField;

        private bool sexFieldSpecified;

        private string familyNameField;

        private string givenNameField;

        private CommonAustralianPostalAddressType australianPostalAddressField;

        private CommonAustralianStreetAddressType australianStreetAddressField;

        private CommonInternationalAddressType internationalAddressField;

        private CommonAustralianUnstructuredStreetAddressType australianUnstructuredStreetAddressField;

        private CommonTrueFalseType historyField;

        private bool historyFieldSpecified;

        public string ihiNumber
        {
            get
            {
                return this.ihiNumberField;
            }
            set
            {
                this.ihiNumberField = value;
            }
        }

        public string medicareCardNumber
        {
            get
            {
                return this.medicareCardNumberField;
            }
            set
            {
                this.medicareCardNumberField = value;
            }
        }

        public string medicareIRN
        {
            get
            {
                return this.medicareIRNField;
            }
            set
            {
                this.medicareIRNField = value;
            }
        }

        public string dvaFileNumber
        {
            get
            {
                return this.dvaFileNumberField;
            }
            set
            {
                this.dvaFileNumberField = value;
            }
        }

        public System.DateTime dateOfBirth
        {
            get
            {
                return this.dateOfBirthField;
            }
            set
            {
                this.dateOfBirthField = value;
            }
        }

        public bool dateOfBirthSpecified
        {
            get
            {
                return this.dateOfBirthFieldSpecified;
            }
            set
            {
                this.dateOfBirthFieldSpecified = value;
            }
        }

        public CommonSexType sex
        {
            get
            {
                return this.sexField;
            }
            set
            {
                this.sexField = value;
            }
        }

        public bool sexSpecified
        {
            get
            {
                return this.sexFieldSpecified;
            }
            set
            {
                this.sexFieldSpecified = value;
            }
        }

        public string familyName
        {
            get
            {
                return this.familyNameField;
            }
            set
            {
                this.familyNameField = value;
            }
        }

        public string givenName
        {
            get
            {
                return this.givenNameField;
            }
            set
            {
                this.givenNameField = value;
            }
        }

        public CommonAustralianPostalAddressType australianPostalAddress
        {
            get
            {
                return this.australianPostalAddressField;
            }
            set
            {
                this.australianPostalAddressField = value;
            }
        }

        public CommonAustralianStreetAddressType australianStreetAddress
        {
            get
            {
                return this.australianStreetAddressField;
            }
            set
            {
                this.australianStreetAddressField = value;
            }
        }

        public CommonInternationalAddressType internationalAddress
        {
            get
            {
                return this.internationalAddressField;
            }
            set
            {
                this.internationalAddressField = value;
            }
        }

        public CommonAustralianUnstructuredStreetAddressType australianUnstructuredStreetAddress
        {
            get
            {
                return this.australianUnstructuredStreetAddressField;
            }
            set
            {
                this.australianUnstructuredStreetAddressField = value;
            }
        }

        public CommonTrueFalseType history
        {
            get
            {
                return this.historyField;
            }
            set
            {
                this.historyField = value;
            }
        }

        public bool historySpecified
        {
            get
            {
                return this.historyFieldSpecified;
            }
            set
            {
                this.historyFieldSpecified = value;
            }
        }
    }

    public enum CommonSexType
    {

        /// <remarks/>
        F,

        /// <remarks/>
        I,

        /// <remarks/>
        M,

        /// <remarks/>
        N,
    }

    public partial class CommonAustralianPostalAddressType
    {

        private CommonStateType stateField;

        private bool stateFieldSpecified;

        private string postcodeField;

        private string suburbField;

        private CommonPostalDeliveryGroupType postalDeliveryGroupField;

        public CommonStateType state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        public bool stateSpecified
        {
            get
            {
                return this.stateFieldSpecified;
            }
            set
            {
                this.stateFieldSpecified = value;
            }
        }

        public string postcode
        {
            get
            {
                return this.postcodeField;
            }
            set
            {
                this.postcodeField = value;
            }
        }

        public string suburb
        {
            get
            {
                return this.suburbField;
            }
            set
            {
                this.suburbField = value;
            }
        }

        public CommonPostalDeliveryGroupType postalDeliveryGroup
        {
            get
            {
                return this.postalDeliveryGroupField;
            }
            set
            {
                this.postalDeliveryGroupField = value;
            }
        }
    }

    public partial class CommonAustralianStreetAddressType
    {
        private CommonStateType stateField;

        private bool stateFieldSpecified;

        private string postcodeField;

        private string suburbField;

        private string addressSiteNameField;

        private CommonUnitGroupType unitGroupField;

        private CommonLevelGroupType levelGroupField;

        private string lotNumberField;

        private string streetNumberField;

        private string streetNameField;

        private CommonStreetType streetTypeField;

        private bool streetTypeFieldSpecified;

        private CommonStreetSuffixType streetSuffixField;

        private bool streetSuffixFieldSpecified;

        public CommonStateType state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        public bool stateSpecified
        {
            get
            {
                return this.stateFieldSpecified;
            }
            set
            {
                this.stateFieldSpecified = value;
            }
        }

        public string postcode
        {
            get
            {
                return this.postcodeField;
            }
            set
            {
                this.postcodeField = value;
            }
        }

        public string suburb
        {
            get
            {
                return this.suburbField;
            }
            set
            {
                this.suburbField = value;
            }
        }

        public string addressSiteName
        {
            get
            {
                return this.addressSiteNameField;
            }
            set
            {
                this.addressSiteNameField = value;
            }
        }

        public CommonUnitGroupType unitGroup
        {
            get
            {
                return this.unitGroupField;
            }
            set
            {
                this.unitGroupField = value;
            }
        }

        public CommonLevelGroupType levelGroup
        {
            get
            {
                return this.levelGroupField;
            }
            set
            {
                this.levelGroupField = value;
            }
        }

        public string lotNumber
        {
            get
            {
                return this.lotNumberField;
            }
            set
            {
                this.lotNumberField = value;
            }
        }

        public string streetNumber
        {
            get
            {
                return this.streetNumberField;
            }
            set
            {
                this.streetNumberField = value;
            }
        }

        public string streetName
        {
            get
            {
                return this.streetNameField;
            }
            set
            {
                this.streetNameField = value;
            }
        }

        public CommonStreetType streetType
        {
            get
            {
                return this.streetTypeField;
            }
            set
            {
                this.streetTypeField = value;
            }
        }

        public bool streetTypeSpecified
        {
            get
            {
                return this.streetTypeFieldSpecified;
            }
            set
            {
                this.streetTypeFieldSpecified = value;
            }
        }

        public CommonStreetSuffixType streetSuffix
        {
            get
            {
                return this.streetSuffixField;
            }
            set
            {
                this.streetSuffixField = value;
            }
        }

        public bool streetSuffixSpecified
        {
            get
            {
                return this.streetSuffixFieldSpecified;
            }
            set
            {
                this.streetSuffixFieldSpecified = value;
            }
        }
    }

    public partial class CommonAustralianUnstructuredStreetAddressType
    {

        private string addressLineOneField;

        private string addressLineTwoField;

        private string suburbField;

        private CommonStateType stateField;

        private string postcodeField;

        public string addressLineOne
        {
            get
            {
                return this.addressLineOneField;
            }
            set
            {
                this.addressLineOneField = value;
            }
        }

        public string addressLineTwo
        {
            get
            {
                return this.addressLineTwoField;
            }
            set
            {
                this.addressLineTwoField = value;
            }
        }

        public string suburb
        {
            get
            {
                return this.suburbField;
            }
            set
            {
                this.suburbField = value;
            }
        }

        public CommonStateType state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        public string postcode
        {
            get
            {
                return this.postcodeField;
            }
            set
            {
                this.postcodeField = value;
            }
        }
    }

    public enum CommonStateType
    {

        /// <remarks/>
        ACT,

        /// <remarks/>
        NSW,

        /// <remarks/>
        NT,

        /// <remarks/>
        QLD,

        /// <remarks/>
        SA,

        /// <remarks/>
        TAS,

        /// <remarks/>
        VIC,

        /// <remarks/>
        WA,
    }

    public enum CommonStreetType
    {

        /// <remarks/>
        ACCS,

        /// <remarks/>
        ALLY,

        /// <remarks/>
        ALWY,

        /// <remarks/>
        AMBL,

        /// <remarks/>
        ANCG,

        /// <remarks/>
        APP,

        /// <remarks/>
        ARC,

        /// <remarks/>
        ART,

        /// <remarks/>
        AVE,

        /// <remarks/>
        BASN,

        /// <remarks/>
        BCH,

        /// <remarks/>
        BEND,

        /// <remarks/>
        BLK,

        /// <remarks/>
        BWLK,

        /// <remarks/>
        BVD,

        /// <remarks/>
        BRCE,

        /// <remarks/>
        BRAE,

        /// <remarks/>
        BRK,

        /// <remarks/>
        BDGE,

        /// <remarks/>
        BDWY,

        /// <remarks/>
        BROW,

        /// <remarks/>
        BYPA,

        /// <remarks/>
        BYWY,

        /// <remarks/>
        CAUS,

        /// <remarks/>
        CTR,

        /// <remarks/>
        CNWY,

        /// <remarks/>
        CH,

        /// <remarks/>
        CIR,

        /// <remarks/>
        CLT,

        /// <remarks/>
        CCT,

        /// <remarks/>
        CRCS,

        /// <remarks/>
        CL,

        /// <remarks/>
        CLDE,

        /// <remarks/>
        CMMN,

        /// <remarks/>
        CON,

        /// <remarks/>
        CPS,

        /// <remarks/>
        CNR,

        /// <remarks/>
        CSO,

        /// <remarks/>
        CT,

        /// <remarks/>
        CTYD,

        /// <remarks/>
        COVE,

        /// <remarks/>
        CRES,

        /// <remarks/>
        CRST,

        /// <remarks/>
        CRSS,

        /// <remarks/>
        CRSG,

        /// <remarks/>
        CRD,

        /// <remarks/>
        COWY,

        /// <remarks/>
        CUWY,

        /// <remarks/>
        CDS,

        /// <remarks/>
        CTTG,

        /// <remarks/>
        DALE,

        /// <remarks/>
        DELL,

        /// <remarks/>
        DEVN,

        /// <remarks/>
        DIP,

        /// <remarks/>
        DSTR,

        /// <remarks/>
        DR,

        /// <remarks/>
        DRWY,

        /// <remarks/>
        EDGE,

        /// <remarks/>
        ELB,

        /// <remarks/>
        END,

        /// <remarks/>
        ENT,

        /// <remarks/>
        ESP,

        /// <remarks/>
        EST,

        /// <remarks/>
        EXP,

        /// <remarks/>
        EXTN,

        /// <remarks/>
        FAWY,

        /// <remarks/>
        FTRK,

        /// <remarks/>
        FITR,

        /// <remarks/>
        FLAT,

        /// <remarks/>
        FOLW,

        /// <remarks/>
        FTWY,

        /// <remarks/>
        FSHR,

        /// <remarks/>
        FORM,

        /// <remarks/>
        FWY,

        /// <remarks/>
        FRNT,

        /// <remarks/>
        FRTG,

        /// <remarks/>
        GAP,

        /// <remarks/>
        GDN,

        /// <remarks/>
        GDNS,

        /// <remarks/>
        GTE,

        /// <remarks/>
        GTES,

        /// <remarks/>
        GLD,

        /// <remarks/>
        GLEN,

        /// <remarks/>
        GRA,

        /// <remarks/>
        GRN,

        /// <remarks/>
        GRND,

        /// <remarks/>
        GR,

        /// <remarks/>
        GLY,

        /// <remarks/>
        HTS,

        /// <remarks/>
        HRD,

        /// <remarks/>
        HWY,

        /// <remarks/>
        HILL,

        /// <remarks/>
        INTG,

        /// <remarks/>
        INTN,

        /// <remarks/>
        JNC,

        /// <remarks/>
        KEY,

        /// <remarks/>
        LDG,

        /// <remarks/>
        LANE,

        /// <remarks/>
        LNWY,

        /// <remarks/>
        LEES,

        /// <remarks/>
        LINE,

        /// <remarks/>
        LINK,

        /// <remarks/>
        LT,

        /// <remarks/>
        LKT,

        /// <remarks/>
        LOOP,

        /// <remarks/>
        LWR,

        /// <remarks/>
        MALL,

        /// <remarks/>
        MNDR,

        /// <remarks/>
        MEW,

        /// <remarks/>
        MEWS,

        /// <remarks/>
        MWY,

        /// <remarks/>
        MT,

        /// <remarks/>
        NOOK,

        /// <remarks/>
        OTLK,

        /// <remarks/>
        PDE,

        /// <remarks/>
        PARK,

        /// <remarks/>
        PKLD,

        /// <remarks/>
        PKWY,

        /// <remarks/>
        PART,

        /// <remarks/>
        PASS,

        /// <remarks/>
        PATH,

        /// <remarks/>
        PHWY,

        /// <remarks/>
        PIAZ,

        /// <remarks/>
        PL,

        /// <remarks/>
        PLAT,

        /// <remarks/>
        PLZA,

        /// <remarks/>
        PKT,

        /// <remarks/>
        PNT,

        /// <remarks/>
        PORT,

        /// <remarks/>
        PROM,

        /// <remarks/>
        QUAD,

        /// <remarks/>
        QDGL,

        /// <remarks/>
        QDRT,

        /// <remarks/>
        QY,

        /// <remarks/>
        QYS,

        /// <remarks/>
        RMBL,

        /// <remarks/>
        RAMP,

        /// <remarks/>
        RNGE,

        /// <remarks/>
        RCH,

        /// <remarks/>
        RES,

        /// <remarks/>
        REST,

        /// <remarks/>
        RTT,

        /// <remarks/>
        RIDE,

        /// <remarks/>
        RDGE,

        /// <remarks/>
        RGWY,

        /// <remarks/>
        ROWY,

        /// <remarks/>
        RING,

        /// <remarks/>
        RISE,

        /// <remarks/>
        RVR,

        /// <remarks/>
        RVWY,

        /// <remarks/>
        RVRA,

        /// <remarks/>
        RD,

        /// <remarks/>
        RDS,

        /// <remarks/>
        RDSD,

        /// <remarks/>
        RDWY,

        /// <remarks/>
        RNDE,

        /// <remarks/>
        RSBL,

        /// <remarks/>
        RTY,

        /// <remarks/>
        RND,

        /// <remarks/>
        RTE,

        /// <remarks/>
        ROW,

        /// <remarks/>
        RUE,

        /// <remarks/>
        RUN,

        /// <remarks/>
        SWY,

        /// <remarks/>
        SHUN,

        /// <remarks/>
        SDNG,

        /// <remarks/>
        SLPE,

        /// <remarks/>
        SND,

        /// <remarks/>
        SPUR,

        /// <remarks/>
        SQ,

        /// <remarks/>
        STRS,

        /// <remarks/>
        SHWY,

        /// <remarks/>
        STPS,

        /// <remarks/>
        STRA,

        /// <remarks/>
        ST,

        /// <remarks/>
        STRP,

        /// <remarks/>
        SBWY,

        /// <remarks/>
        TARN,

        /// <remarks/>
        TCE,

        /// <remarks/>
        THOR,

        /// <remarks/>
        TLWY,

        /// <remarks/>
        TOP,

        /// <remarks/>
        TOR,

        /// <remarks/>
        TWRS,

        /// <remarks/>
        TRK,

        /// <remarks/>
        TRL,

        /// <remarks/>
        TRLR,

        /// <remarks/>
        TRI,

        /// <remarks/>
        TKWY,

        /// <remarks/>
        TURN,

        /// <remarks/>
        UPAS,

        /// <remarks/>
        UPR,

        /// <remarks/>
        VALE,

        /// <remarks/>
        VDCT,

        /// <remarks/>
        VIEW,

        /// <remarks/>
        VLLS,

        /// <remarks/>
        VSTA,

        /// <remarks/>
        WADE,

        /// <remarks/>
        WALK,

        /// <remarks/>
        WKWY,

        /// <remarks/>
        WAY,

        /// <remarks/>
        WHRF,

        /// <remarks/>
        WYND,

        /// <remarks/>
        YARD,
    }

    public enum CommonStreetSuffixType
    {

        /// <remarks/>
        CN,

        /// <remarks/>
        E,

        /// <remarks/>
        EX,

        /// <remarks/>
        LR,

        /// <remarks/>
        N,

        /// <remarks/>
        NE,

        /// <remarks/>
        NW,

        /// <remarks/>
        S,

        /// <remarks/>
        SE,

        /// <remarks/>
        SW,

        /// <remarks/>
        UP,

        /// <remarks/>
        W,
    }

    public partial class CommonPostalDeliveryGroupType
    {

        private CommonPostalDeliveryType postalDeliveryTypeField;

        private string postalDeliveryNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public CommonPostalDeliveryType postalDeliveryType
        {
            get
            {
                return this.postalDeliveryTypeField;
            }
            set
            {
                this.postalDeliveryTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string postalDeliveryNumber
        {
            get
            {
                return this.postalDeliveryNumberField;
            }
            set
            {
                this.postalDeliveryNumberField = value;
            }
        }
    }

    public enum CommonPostalDeliveryType
    {
        CarePO,

        /// <remarks/>
        CMA,

        /// <remarks/>
        CMB,
        GPOBox,
        LockedBag,

        /// <remarks/>
        MS,
        POBox,

        /// <remarks/>
        POR,
        PrivateBag,

        /// <remarks/>
        RSD,

        /// <remarks/>
        RMB,

        /// <remarks/>
        RMS,
    }

    public partial class CommonInternationalAddressType
    {

        private string internationalStateProvinceField;

        private CommonCountryType countryField;

        private string internationalPostcodeField;

        private string internationalAddressLineField;

        public string internationalStateProvince
        {
            get
            {
                return this.internationalStateProvinceField;
            }
            set
            {
                this.internationalStateProvinceField = value;
            }
        }

        public CommonCountryType country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        public string internationalPostcode
        {
            get
            {
                return this.internationalPostcodeField;
            }
            set
            {
                this.internationalPostcodeField = value;
            }
        }

        public string internationalAddressLine
        {
            get
            {
                return this.internationalAddressLineField;
            }
            set
            {
                this.internationalAddressLineField = value;
            }
        }
    }

    public enum CommonCountryType
    {
        Item1601,
        Item7201,
        Item3201,
        Item4101,
        Item3101,
        Item9201,
        Item8401,
        Item8402,
        Item8201,
        Item1602,
        Item7202,
        Item8403,
        Item1101,
        Item1603,
        Item1199,
        Item2301,
        Item7203,
        Item8404,
        Item4201,
        Item7101,
        Item8405,
        Item3301,
        Item2302,
        Item8301,
        Item9101,
        Item8101,
        Item7102,
        Item8202,
        Item3202,
        Item9202,
        Item8203,
        Item1604,
        Item5201,
        Item3203,
        Item9102,
        Item5101,
        Item9203,
        Item5102,
        Item9103,
        Item8102,
        Item9104,
        Item8406,
        Item9105,
        Item9106,
        Item2101,
        Item8204,
        Item1605,
        Item6101,
        Item8205,
        Item9204,
        Item9107,
        Item9108,
        Item1501,
        Item8302,
        Item9111,
        Item3204,
        Item8407,
        Item3205,
        Item3302,
        Item2401,
        Item9205,
        Item8408,
        Item8411,
        Item5206,
        Item8206,
        Item4102,
        Item8303,
        Item2102,
        Item9112,
        Item9206,
        Item3303,
        Item9207,
        Item2402,
        Item8207,
        Item1502,
        Item2403,
        Item3206,
        Item2303,
        Item8208,
        Item1503,
        Item9113,
        Item9114,
        Item4202,
        Item7204,
        Item2304,
        Item9115,
        Item3102,
        Item3207,
        Item2404,
        Item8412,
        Item8413,
        Item1401,
        Item8304,
        Item9116,
        Item9117,
        Item8211,
        Item8414,
        Item3103,
        Item8305,
        Item6102,
        Item3304,
        Item2405,
        Item7103,
        Item5202,
        Item4203,
        Item4204,
        Item2103,
        Item4205,
        Item3104,
        Item8415,
        Item6201,
        Item4206,
        Item7205,
        Item9208,
        Item1402,
        Item6202,
        Item6203,
        Item4207,
        Item7206,
        Item5103,
        Item3305,
        Item4208,
        Item9211,
        Item9118,
        Item4103,
        Item2305,
        Item3306,
        Item2306,
        Item6103,
        Item9212,
        Item9213,
        Item5203,
        Item7104,
        Item9121,
        Item3105,
        Item1403,
        Item8416,
        Item9122,
        Item9214,
        Item9215,
        Item8306,
        Item1404,
        Item3208,
        Item2307,
        Item6104,
        Item8417,
        Item4104,
        Item9216,
        Item9217,
        Item1405,
        Item7105,
        Item2308,
        Item8418,
        Item1301,
        Item1201,
        Item8307,
        Item9123,
        Item9124,
        Item1504,
        Item1102,
        Item4199,
        Item2104,
        Item1406,
        Item2406,
        Item4211,
        OTHE,
        Item7106,
        Item1407,
        Item8308,
        Item1302,
        Item8212,
        Item8213,
        Item5204,
        Item3307,
        Item1599,
        Item3106,
        Item8421,
        Item4212,
        Item1606,
        Item2201,
        Item9218,
        Item3211,
        Item1607,
        Item3308,
        Item9221,
        Item1505,
        Item1506,
        Item3107,
        Item9125,
        Item4213,
        Item2105,
        Item9126,
        Item9223,
        Item9127,
        Item5205,
        Item3311,
        Item3212,
        Item1303,
        Item9224,
        Item9225,
        Item8299,
        Item9299,
        Item3108,
        Item7107,
        Item9222,
        Item8422,
        Item8423,
        Item8103,
        Item8424,
        Item4105,
        Item8214,
        Item9226,
        Item2407,
        Item2311,
        Item4214,
        Item6105,
        Item7207,
        Item9227,
        Item5104,
        Item9128,
        Item1507,
        Item1508,
        Item8425,
        Item4106,
        Item4215,
        Item7208,
        Item8426,
        Item1511,
        Item9228,
        Item3312,
        Item4216,
        Item8104,
        Item8215,
        Item7211,
        Item1304,
        Item8216,
        Item5105,
        Item8427,
        Item8428,
        Item2106,
        Item1512,
        Item4107,
        Item4217,
        Item3213,
        Item9231,
        Item9232
    }

    public partial class CommonLevelGroupType
    {
        private CommonLevelType levelTypeField;

        private string levelNumberField;

        public CommonLevelType levelType
        {
            get
            {
                return this.levelTypeField;
            }
            set
            {
                this.levelTypeField = value;
            }
        }

        public string levelNumber
        {
            get
            {
                return this.levelNumberField;
            }
            set
            {
                this.levelNumberField = value;
            }
        }
    }

    public enum CommonLevelType
    {

        /// <remarks/>
        B,

        /// <remarks/>
        FL,

        /// <remarks/>
        G,

        /// <remarks/>
        L,

        /// <remarks/>
        LG,

        /// <remarks/>
        M,

        /// <remarks/>
        OD,

        /// <remarks/>
        P,

        /// <remarks/>
        PTHS,

        /// <remarks/>
        PLF,

        /// <remarks/>
        PLZA,

        /// <remarks/>
        PDM,

        /// <remarks/>
        RT,

        /// <remarks/>
        SB,

        /// <remarks/>
        UG,
    }

    public partial class CommonUnitGroupType
    {

        private CommonUnitType unitTypeField;

        private string unitNumberField;

        public CommonUnitType unitType
        {
            get
            {
                return this.unitTypeField;
            }
            set
            {
                this.unitTypeField = value;
            }
        }

        public string unitNumber
        {
            get
            {
                return this.unitNumberField;
            }
            set
            {
                this.unitNumberField = value;
            }
        }
    }

    public enum CommonUnitType
    {

        /// <remarks/>
        ANT,

        /// <remarks/>
        APT,

        /// <remarks/>
        ATM,

        /// <remarks/>
        BBQ,

        /// <remarks/>
        BTSD,

        /// <remarks/>
        BLDG,

        /// <remarks/>
        BNGW,

        /// <remarks/>
        CAGE,

        /// <remarks/>
        CARP,

        /// <remarks/>
        CARS,

        /// <remarks/>
        CLUB,

        /// <remarks/>
        COOL,

        /// <remarks/>
        CTGE,

        /// <remarks/>
        DUP,

        /// <remarks/>
        FY,

        /// <remarks/>
        F,

        /// <remarks/>
        GRGE,

        /// <remarks/>
        HALL,

        /// <remarks/>
        HSE,

        /// <remarks/>
        KSK,

        /// <remarks/>
        LSE,

        /// <remarks/>
        LBBY,

        /// <remarks/>
        LOFT,

        /// <remarks/>
        LOT,

        /// <remarks/>
        MSNT,

        /// <remarks/>
        MB,

        /// <remarks/>
        OFF,

        /// <remarks/>
        PTHS,

        /// <remarks/>
        RESV,

        /// <remarks/>
        RM,

        /// <remarks/>
        SHED,

        /// <remarks/>
        SHOP,

        /// <remarks/>
        SIGN,

        /// <remarks/>
        SITE,

        /// <remarks/>
        SL,

        /// <remarks/>
        STOR,

        /// <remarks/>
        STR,

        /// <remarks/>
        STU,

        /// <remarks/>
        SUBS,

        /// <remarks/>
        SE,

        /// <remarks/>
        TNCY,

        /// <remarks/>
        TWR,

        /// <remarks/>
        TNHS,

        /// <remarks/>
        U,

        /// <remarks/>
        VLLA,

        /// <remarks/>
        WARD,

        /// <remarks/>
        WE,

        /// <remarks/>
        WKSH,
    }

    public enum CommonTrueFalseType
    {
        F,
        T,
    }
}
