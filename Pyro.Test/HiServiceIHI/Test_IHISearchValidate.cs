using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using Pyro.ADHA.Api;
using Pyro.Common.CompositionRoot;
using Pyro.Common.FhirOperation;
using Pyro.Common.Global;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Service.ResourceService;
using Pyro.Test.IntergrationTest;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;
using Pyro.Common.FhirOperation.IhiSearch;
using Pyro.Identifiers.Australian.MedicareNumber;
using Pyro.Identifiers.Australian.NationalHealthcareIdentifier;
using Pyro.Identifiers.Australian.DepartmentVeteransAffairs;
using Pyro.Identifiers.Support.StandardsInformation.Australian;
using Pyro.Common.RequestMetadata;

namespace Pyro.Test.HiServiceIHI
{
  [TestFixture]
  [Category("Hi Service Tests")]
  public class Test_IHISearchValidate
  {
    private string UrnUuidPrefix = "urn:uuid:";
    private string SoapRequestId = Guid.NewGuid().ToString(); //Not scoped to be a FHIR GUID as it comes from the HI Service
    private string SoapResponseId = Guid.NewGuid().ToString(); //Not scoped to be a FHIR GUID as it comes from the HI Service

    private string HiPatientFamily = "MARCELLE";
    private string HiPatientGiven = "JUANITA";
    private char HiPatientSexChar = 'F';
    private DateTime HiPatientDob = new DateTime(1982, 01, 24);
    private string HiPatientMedicareNumber = "2950156481";
    private string HiPatientIHINumber = "1234567890123456"; //Not a real IHI but fine for mock testing 
    private string HiPatientIHIRecordStatus = "Verified"; 
    private string HiPatientIHIStatus = "Active";


    /// <summary>
    /// Setup the HIServiceAPI mock and the response it will reply with
    /// </summary>
    /// <returns></returns>
    private IHiServiceApi GetMokIHiServiceApi()
    {
      //Mock<IHiServiceMessage> MokIHiServiceMessage = new Mock<IHiServiceMessage>();
      //MokIHiServiceMessage.Setup(x => x.Code).Returns("");
      //MokIHiServiceMessage.Setup(x => x.).Returns("");

      Moq.Mock<IIhiQueryMetadata> MokIIhiQueryMetadata = new Moq.Mock<IIhiQueryMetadata>();
      MokIIhiQueryMetadata.Setup(x => x.ErrorMessge).Returns(string.Empty);
      MokIIhiQueryMetadata.Setup(x => x.SoapRequest).Returns("SoapRequestData");
      MokIIhiQueryMetadata.Setup(x => x.SoapRequestMessageId).Returns($"{UrnUuidPrefix}{SoapRequestId}");
      MokIIhiQueryMetadata.Setup(x => x.SoapResponseMessageId).Returns($"{UrnUuidPrefix}{SoapResponseId}");
      MokIIhiQueryMetadata.Setup(x => x.SoapResponse).Returns("SoapResponseData");
      MokIIhiQueryMetadata.Setup(x => x.ServiceMessage).Returns(new List<IHiServiceMessage>());

      Moq.Mock<IIhiRequestData> MokIIhiRequestData = new Moq.Mock<IIhiRequestData>();
      MokIIhiRequestData.Setup(x => x.Dob).Returns(new DateTime(1973, 09, 30));
      MokIIhiRequestData.Setup(x => x.SexChar).Returns(HiPatientSexChar);
      MokIIhiRequestData.Setup(x => x.Family).Returns(HiPatientFamily);
      MokIIhiRequestData.Setup(x => x.Given).Returns(HiPatientGiven);
      MokIIhiRequestData.Setup(x => x.DVANumber).Returns(string.Empty);
      MokIIhiRequestData.Setup(x => x.MedicareNumber).Returns(HiPatientMedicareNumber);
      MokIIhiRequestData.Setup(x => x.IHINumber).Returns(HiPatientIHINumber);
      
      Moq.Mock<IIhiResponseData> MokIIhiResponseData = new Moq.Mock<IIhiResponseData>();
      MokIIhiResponseData.Setup(x => x.Dob).Returns(new DateTime(1973, 09, 30));
      MokIIhiResponseData.Setup(x => x.SexChar).Returns(HiPatientSexChar);
      MokIIhiResponseData.Setup(x => x.Family).Returns(HiPatientFamily);
      MokIIhiResponseData.Setup(x => x.Given).Returns(HiPatientGiven);
      MokIIhiResponseData.Setup(x => x.DVANumber).Returns(string.Empty);
      MokIIhiResponseData.Setup(x => x.MedicareNumber).Returns(HiPatientMedicareNumber);
      MokIIhiResponseData.Setup(x => x.IHINumber).Returns(HiPatientIHINumber);
      MokIIhiResponseData.Setup(x => x.IHIRecordStatus).Returns(HiPatientIHIRecordStatus);
      MokIIhiResponseData.Setup(x => x.IHIStatus).Returns(HiPatientIHIStatus);

      Moq.Mock<IIhiSearchValidateOutcome> MokIIhiSearchValidateOutcome = new Moq.Mock<IIhiSearchValidateOutcome>();
      MokIIhiSearchValidateOutcome.Setup(x => x.QueryMetadata).Returns(MokIIhiQueryMetadata.Object);
      MokIIhiSearchValidateOutcome.Setup(x => x.RequestData).Returns(MokIIhiRequestData.Object);
      MokIIhiSearchValidateOutcome.Setup(x => x.ResponseData).Returns(MokIIhiResponseData.Object);
      MokIIhiSearchValidateOutcome.Setup(x => x.SuccessfulQuery).Returns(true);

      Moq.Mock<IHiServiceApi> MokIHiServiceApi = new Moq.Mock<IHiServiceApi>();
      MokIHiServiceApi.SetReturnsDefault<IIhiSearchValidateOutcome>(MokIIhiSearchValidateOutcome.Object);

      return MokIHiServiceApi.Object;
    }

    /// <summary>
    /// Setup the mocked pyro ResourceService which mocks the response from the Pyro database when commiting the 
    /// SoapRequest and SoapResponse FHIR Binary resources 
    /// </summary>
    /// <returns></returns>
    private IResourceServices GetIResourceServices()
    {
      var FhirRequestUriForBinaryRequestPut = CommonTestSetup.TestSetupMocks.GetIPyroRequestUriFactory().CreateFhirRequestUri().FhirRequestUri = new Pyro.Common.Tools.UriSupport.PyroFhirUri(CommonTestSetup.TestSetupMocks.GetIPrimaryServiceRootCache());
      FhirRequestUriForBinaryRequestPut.Parse($"{StaticTestData.FhirEndpoint()}/{ResourceType.Binary.GetLiteral()}/{SoapRequestId}");

      Mock<IResourceServiceOutcome> MokIResourceServiceOutcomeOne = new Mock<IResourceServiceOutcome>();
      MokIResourceServiceOutcomeOne.Setup(x => x.FhirResourceId).Returns(SoapRequestId);
      MokIResourceServiceOutcomeOne.Setup(x => x.FormatMimeType).Returns((string)null);
      MokIResourceServiceOutcomeOne.Setup(x => x.HttpStatusCode).Returns(System.Net.HttpStatusCode.Created);
      MokIResourceServiceOutcomeOne.Setup(x => x.IsDeleted).Returns(false);
      MokIResourceServiceOutcomeOne.Setup(x => x.LastModified).Returns(DateTimeOffset.Now);
      MokIResourceServiceOutcomeOne.Setup(x => x.OperationType).Returns(RestEnum.CrudOperationType.Create);
      MokIResourceServiceOutcomeOne.Setup(x => x.RequestUri).Returns(FhirRequestUriForBinaryRequestPut);
      MokIResourceServiceOutcomeOne.Setup(x => x.ResourceResult).Returns(new Binary());
      MokIResourceServiceOutcomeOne.Setup(x => x.ResourceVersionNumber).Returns("1");
      MokIResourceServiceOutcomeOne.Setup(x => x.SuccessfulTransaction).Returns(true);
      MokIResourceServiceOutcomeOne.Setup(x => x.SummaryType).Returns((Hl7.Fhir.Rest.SummaryType?)null);

      var FhirRequestUriForBinaryResponsePut = CommonTestSetup.TestSetupMocks.GetIPyroRequestUriFactory().CreateFhirRequestUri().FhirRequestUri = new Pyro.Common.Tools.UriSupport.PyroFhirUri(CommonTestSetup.TestSetupMocks.GetIPrimaryServiceRootCache());
      FhirRequestUriForBinaryRequestPut.Parse($"{StaticTestData.FhirEndpoint()}/{ResourceType.Binary.GetLiteral()}/{SoapResponseId}");

      Mock<IResourceServiceOutcome> MokIResourceServiceOutcomeTwo = new Mock<IResourceServiceOutcome>();
      MokIResourceServiceOutcomeTwo.Setup(x => x.FhirResourceId).Returns(SoapResponseId);
      MokIResourceServiceOutcomeTwo.Setup(x => x.FormatMimeType).Returns((string)null);
      MokIResourceServiceOutcomeTwo.Setup(x => x.HttpStatusCode).Returns(System.Net.HttpStatusCode.Created);
      MokIResourceServiceOutcomeTwo.Setup(x => x.IsDeleted).Returns(false);
      MokIResourceServiceOutcomeTwo.Setup(x => x.LastModified).Returns(DateTimeOffset.Now);
      MokIResourceServiceOutcomeTwo.Setup(x => x.OperationType).Returns(RestEnum.CrudOperationType.Create);
      MokIResourceServiceOutcomeTwo.Setup(x => x.RequestUri).Returns(FhirRequestUriForBinaryResponsePut);
      MokIResourceServiceOutcomeTwo.Setup(x => x.ResourceResult).Returns(new Binary());
      MokIResourceServiceOutcomeTwo.Setup(x => x.ResourceVersionNumber).Returns("1");
      MokIResourceServiceOutcomeTwo.Setup(x => x.SuccessfulTransaction).Returns(true);
      MokIResourceServiceOutcomeTwo.Setup(x => x.SummaryType).Returns((Hl7.Fhir.Rest.SummaryType?)null);

      Mock<IResourceServices> MokIResourceServices = new Mock<IResourceServices>();
      MokIResourceServices.SetupSequence(x => x.Put(It.IsAny<string>(), It.IsAny<Binary>(), It.IsAny<IRequestMeta>()))
        .Returns(MokIResourceServiceOutcomeOne.Object)
        .Returns(MokIResourceServiceOutcomeTwo.Object);
      MokIResourceServices.SetReturnsDefault<IResourceServiceOutcome>(MokIResourceServiceOutcomeOne.Object);
      return MokIResourceServices.Object;
    }


    /// <summary>
    /// A Positive test performing a HI Service IHI lookup based on a Medicare number and a single Patient name 
    /// </summary>
    [Test]
    public void Test_HISearchMedicareNumber()
    {      
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory = CommonTestSetup.TestSetupMocks.GetIResourceServiceOutcomeFactory();
      IPyroFhirUriFactory IPyroFhirUriFactory = CommonTestSetup.TestSetupMocks.GetIPyroFhirUriFactory();
      IResourceServices IResourceServices = GetIResourceServices();
      IGlobalProperties IGlobalProperties = CommonTestSetup.TestSetupMocks.GetIGlobalProperties();
      IHiServiceApi IHiServiceApi = GetMokIHiServiceApi();      
      IMedicareNumberParser IMedicareNumberParser = new MedicareNumberParser();
      IIndividualHealthcareIdentifierParser IIndividualHealthcareIdentifierParser = new IndividualHealthcareIdentifierParser();
      IDVANumberParser IDVANumberParser = new DVANumberParser();
      IRequestMetaFactory RequestMetaFactory = CommonTestSetup.TestSetupMocks.GetIRequestMetaFactory();
      INationalHealthcareIdentifierInfo INationalHealthcareIdentifierInfo = new NationalHealthcareIdentifierInfo();
      IMedicareNumberInfo IMedicareNumberInfo = new MedicareNumberInfo();


      IHISearchOrValidateOperation IHISearchOrValidateOperationService = new IHISearchOrValidateOperation(        
        IResourceServiceOutcomeFactory,
        IResourceServices, 
        IGlobalProperties, 
        IHiServiceApi,         
        RequestMetaFactory,
        IMedicareNumberParser,
        IIndividualHealthcareIdentifierParser, 
        IDVANumberParser,
        INationalHealthcareIdentifierInfo,
        IMedicareNumberInfo);

      OperationClass OperationClass = new OperationClass()
      {
        Scope = Common.Enum.FhirOperationEnum.OperationScope.Resource,
        Type = Common.Enum.FhirOperationEnum.OperationType.xIHISearchOrValidate
      };

      //var SearchParameterGeneric = new Common.Search.SearchParameterGeneric();

      var PyroRequestUri = CommonTestSetup.TestSetupMocks.GetIPyroRequestUriFactory().CreateFhirRequestUri();
      PyroRequestUri.FhirRequestUri = CommonTestSetup.TestSetupMocks.GetIPyroRequestUriFactory().CreateFhirRequestUri().FhirRequestUri = new Pyro.Common.Tools.UriSupport.PyroFhirUri(CommonTestSetup.TestSetupMocks.GetIPrimaryServiceRootCache());
      PyroRequestUri.FhirRequestUri.Parse($"{StaticTestData.FhirEndpoint()}/{ResourceType.Patient.GetLiteral()}/{Common.Enum.FhirOperationEnum.OperationType.xIHISearchOrValidate.GetPyroLiteral()}");
      IRequestMeta RequestMeta = RequestMetaFactory.CreateRequestMeta();
      RequestMeta.PyroRequestUri = PyroRequestUri;
      RequestMeta.RequestHeader = CommonTestSetup.TestSetupMocks.GetIRequestHeaderFactory().CreateRequestHeader();
      RequestMeta.SearchParameterGeneric = CommonTestSetup.TestSetupMocks.GetISearchParameterGenericFactory().CreateDtoSearchParameterGeneric();

      Parameters ParametersResource = GenerateRequestParametersResource();

      IResourceServiceOutcome ResourceServiceOutcome = IHISearchOrValidateOperationService.IHISearchOrValidate(
        OperationClass,
        ParametersResource,
        RequestMeta
        );

      Assert.NotNull(ResourceServiceOutcome.ResourceResult);
      Assert.AreEqual(ResourceType.Parameters.GetLiteral(), ResourceServiceOutcome.ResourceResult.TypeName);
    }

    /// <summary>
    /// Generate the FHIR Operation Parameter Resource for the HI Service operation call
    /// </summary>
    /// <returns></returns>
    private Parameters GenerateRequestParametersResource()
    {
      var ParametersResource = new Parameters();

      ParametersResource.Parameter = new List<Parameters.ParameterComponent>();

      var UserParam = new Parameters.ParameterComponent();
      UserParam.Name = "UserId";
      UserParam.Value = new FhirString("UserABC");
      ParametersResource.Parameter.Add(UserParam);

      var UserIdQualifierParam = new Parameters.ParameterComponent();
      UserIdQualifierParam.Name = "UserIdQualifier";
      UserIdQualifierParam.Value = new FhirUri("http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0");
      ParametersResource.Parameter.Add(UserIdQualifierParam);

      var ReturnAuditEventParam = new Parameters.ParameterComponent();
      ReturnAuditEventParam.Name = "ReturnAuditEvent";
      ReturnAuditEventParam.Value = new FhirBoolean(true);
      ParametersResource.Parameter.Add(ReturnAuditEventParam);

      var RequestPatientParam = new Parameters.ParameterComponent();
      RequestPatientParam.Name = "RequestPatient";
      RequestPatientParam.Resource = GetRequestPatientResource();
      ParametersResource.Parameter.Add(RequestPatientParam);
      return ParametersResource;
    }

    /// <summary>
    /// The Patient FHIR Resource used for the Request to the HI Service FHIR Operation
    /// </summary>
    /// <returns></returns>
    private Patient GetRequestPatientResource()
    {
      Patient Pat = new Patient();
      //Name
      Pat.Name = new List<HumanName>();
      HumanName HumanName = new HumanName();
      HumanName.Family = HiPatientFamily;
      HumanName.Given = new List<string>() { HiPatientGiven };
      Pat.Name.Add(HumanName);

      //Sex
      Pat.Gender = AdministrativeGender.Female;

      //Dob
      Pat.BirthDateElement = new Date(HiPatientDob.Year, HiPatientDob.Month, HiPatientDob.Day);


      Pat.Identifier = new List<Identifier>();

      Identifier MedicareIdentifier = new Identifier();
      Pat.Identifier.Add(MedicareIdentifier);
      MedicareIdentifier.Value = HiPatientMedicareNumber;
      MedicareIdentifier.System = "http://ns.electronichealth.net.au/id/medicare-number";
      MedicareIdentifier.Type = new CodeableConcept();
      MedicareIdentifier.Type.Coding = new List<Coding>();
      MedicareIdentifier.Type.Text = "Medicare Number";
      Coding MedicareTypeCoding = new Coding();
      MedicareIdentifier.Type.Coding.Add(MedicareTypeCoding);
      MedicareTypeCoding.System = "http://hl7.org/fhir/v2/0203";
      MedicareTypeCoding.Code = "MC";
      MedicareTypeCoding.Display = "Patient's Medicare Number";


      //DVA
      //if (Pat.Identifier == null)
      //  Pat.Identifier = new List<Identifier>();

      //Identifier DVAIdentifier = new Identifier();
      //Pat.Identifier.Add(DVAIdentifier);
      //DVAIdentifier.Value = "";
      //DVAIdentifier.System = ""
      //  DVAIdentifier.Type = new CodeableConcept();
      //DVAIdentifier.Type.Coding = new List<Coding>();
      //DVAIdentifier.Type.Text = "Department of Veterans' Affairs Number";
      //Coding DVATypeCoding = new Coding();
      //DVAIdentifier.Type.Coding.Add(DVATypeCoding);
      //DVATypeCoding.System = "http://hl7.org.au/fhir/v2/0203";
      //DVATypeCoding.Code = "DVA";
      //DVATypeCoding.Display = "DVA Number";

      return Pat;
    }
  }
}
