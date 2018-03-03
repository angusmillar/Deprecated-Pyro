using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework.Constraints;
using NUnit.Framework;
using Pyro.ADHA.Api;
using Pyro.Common.CompositionRoot;
using Pyro.Common.FhirOperation;
using Pyro.Common.Global;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Service;
using Pyro.Common.Tools.Headers;
using Pyro.Test.IntergrationTest;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;

namespace Pyro.Test.HiServiceIHI
{
  [TestFixture]
  [Category("Hi Service Tests")]
  public class Test_IHISearchValidate
  {


    private IHiServiceApi GetMokIHiServiceApi()
    {
      Moq.Mock<IIhiQueryMetadata> MokIIhiQueryMetadata = new Moq.Mock<IIhiQueryMetadata>();
      MokIIhiQueryMetadata.Setup(x => x.ErrorMessge).Returns("Dummy Error Message");
      MokIIhiQueryMetadata.Setup(x => x.SoapRequest).Returns("SoapRequest");
      MokIIhiQueryMetadata.Setup(x => x.SoapRequestMessageId).Returns("1");
      MokIIhiQueryMetadata.Setup(x => x.SoapResponseMessageId).Returns("2");
      MokIIhiQueryMetadata.Setup(x => x.SoapResponse).Returns("SoapResponse");

      Moq.Mock<IIhiRequestData> MokIIhiRequestData = new Moq.Mock<IIhiRequestData>();
      MokIIhiRequestData.Setup(x => x.Dob).Returns(new DateTime(1973, 09, 30));
      MokIIhiRequestData.Setup(x => x.SexChar).Returns('F');
      MokIIhiRequestData.Setup(x => x.Family).Returns("Millar");
      MokIIhiRequestData.Setup(x => x.Given).Returns("Angus");
      MokIIhiRequestData.Setup(x => x.DVANumber).Returns(string.Empty);
      MokIIhiRequestData.Setup(x => x.MedicareNumber).Returns("1234567890");
      MokIIhiRequestData.Setup(x => x.IHINumber).Returns("1234567890123456");

      Moq.Mock<IIhiResponseData> MokIIhiResponseData = new Moq.Mock<IIhiResponseData>();
      MokIIhiResponseData.Setup(x => x.Dob).Returns(new DateTime(1973, 09, 30));
      MokIIhiResponseData.Setup(x => x.SexChar).Returns('F');
      MokIIhiResponseData.Setup(x => x.Family).Returns("Millar");
      MokIIhiResponseData.Setup(x => x.Given).Returns("Angus");
      MokIIhiResponseData.Setup(x => x.DVANumber).Returns(string.Empty);
      MokIIhiResponseData.Setup(x => x.MedicareNumber).Returns("1234567890");
      MokIIhiResponseData.Setup(x => x.IHINumber).Returns("1234567890123456");
      MokIIhiResponseData.Setup(x => x.IHIRecordStatus).Returns("Verified");
      MokIIhiResponseData.Setup(x => x.IHIStatus).Returns("Active");

      Moq.Mock<IIhiSearchValidateOutcome> MokIIhiSearchValidateOutcome = new Moq.Mock<IIhiSearchValidateOutcome>();
      MokIIhiSearchValidateOutcome.Setup(x => x.QueryMetadata).Returns(MokIIhiQueryMetadata.Object);
      MokIIhiSearchValidateOutcome.Setup(x => x.RequestData).Returns(MokIIhiRequestData.Object);
      MokIIhiSearchValidateOutcome.Setup(x => x.ResponseData).Returns(MokIIhiResponseData.Object);
      MokIIhiSearchValidateOutcome.Setup(x => x.SuccessfulQuery).Returns(true);

      Moq.Mock<IHiServiceApi> MokIHiServiceApi = new Moq.Mock<IHiServiceApi>();
      MokIHiServiceApi.SetReturnsDefault<IIhiSearchValidateOutcome>(MokIIhiSearchValidateOutcome.Object);

      return MokIHiServiceApi.Object;
    }

    private IResourceServices GetIResourceServices()
    {
      Moq.Mock<IResourceServiceOutcome> MokIResourceServiceOutcome = new Moq.Mock<IResourceServiceOutcome>();
      MokIResourceServiceOutcome.Setup(x => x.FhirResourceId).Returns("1234");

      Moq.Mock<IResourceServices> MokIResourceServices = new Moq.Mock<IResourceServices>();
      MokIResourceServices.SetReturnsDefault<IResourceServiceOutcome>(MokIResourceServiceOutcome.Object);
      return MokIResourceServices.Object;
    }



    [Test]
    public void Test_HISearchMedicareNumber()
    {
      IRequestHeaderFactory IRequestHeaderFactory = CommonTestSetup.TestSetupMocks.GetIRequestHeaderFactory();
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory = CommonTestSetup.TestSetupMocks.GetIResourceServiceOutcomeFactory();
      IPyroFhirUriFactory IPyroFhirUriFactory = CommonTestSetup.TestSetupMocks.GetIPyroFhirUriFactory();
      IResourceServices IResourceServices = GetIResourceServices();
      IGlobalProperties IGlobalProperties = CommonTestSetup.TestSetupMocks.GetIGlobalProperties();
      IHiServiceApi IHiServiceApi = GetMokIHiServiceApi();
      IPyroRequestUriFactory IPyroRequestUriFactory = CommonTestSetup.TestSetupMocks.GetIPyroRequestUriFactory();

      IHISearchOrValidateOperationService IHISearchOrValidateOperationService = new IHISearchOrValidateOperationService(
        IRequestHeaderFactory,
        IResourceServiceOutcomeFactory,
        IPyroFhirUriFactory, IResourceServices, IGlobalProperties, IHiServiceApi, IPyroRequestUriFactory);

      OperationClass OperationClass = new OperationClass()
      {
        Scope = Common.Enum.FhirOperationEnum.OperationScope.Resource,
        Type = Common.Enum.FhirOperationEnum.OperationType.xIHISearchOrValidate
      };
      var SearchParameterGeneric = new Common.Search.SearchParameterGeneric();

      var PyroRequestUri = CommonTestSetup.TestSetupMocks.GetIPyroRequestUriFactory().CreateFhirRequestUri();
      PyroRequestUri.FhirRequestUri = CommonTestSetup.TestSetupMocks.GetIPyroRequestUriFactory().CreateFhirRequestUri().FhirRequestUri = new Pyro.Common.Tools.UriSupport.PyroFhirUri(CommonTestSetup.TestSetupMocks.GetIPrimaryServiceRootCache());
      PyroRequestUri.FhirRequestUri.Parse($"{StaticTestData.FhirEndpoint()}/{ResourceType.Patient.GetLiteral()}/{Common.Enum.FhirOperationEnum.OperationType.xIHISearchOrValidate.GetPyroLiteral()}");

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

      var ReturnSoapRequestAndResponseDataParam = new Parameters.ParameterComponent();
      ReturnSoapRequestAndResponseDataParam.Name = "ReturnSoapRequestAndResponseData";
      ReturnSoapRequestAndResponseDataParam.Value = new FhirBoolean(true);
      ParametersResource.Parameter.Add(ReturnSoapRequestAndResponseDataParam);

      var RequestPatientParam = new Parameters.ParameterComponent();
      RequestPatientParam.Name = "RequestPatient";
      RequestPatientParam.Resource = GetRequestPatientResource();
      ParametersResource.Parameter.Add(RequestPatientParam);


      IResourceServiceOutcome ResourceServiceOutcome = IHISearchOrValidateOperationService.IHISearchOrValidate(
        OperationClass,
        ParametersResource,
        PyroRequestUri,
        SearchParameterGeneric,
        CommonTestSetup.TestSetupMocks.GetIRequestHeaderFactory().CreateRequestHeader()
        );

      
      Assert.NotNull(ResourceServiceOutcome.ResourceResult);
      Assert.AreEqual(ResourceType.Parameters.GetLiteral(), ResourceServiceOutcome.ResourceResult.TypeName);
    }

    private Patient GetRequestPatientResource()
    {
      Patient Pat = new Patient();
      //Name
      Pat.Name = new List<HumanName>();
      HumanName HumanName = new HumanName();
      HumanName.Family = "MARCELLE";
      HumanName.Given = new List<string>() { "JUANITA" };
      Pat.Name.Add(HumanName);

      //Sex
      Pat.Gender = AdministrativeGender.Female;

      //Dob
      Pat.BirthDateElement = new Date(1982, 01, 24);


      Pat.Identifier = new List<Identifier>();

      Identifier MedicareIdentifier = new Identifier();
      Pat.Identifier.Add(MedicareIdentifier);
      MedicareIdentifier.Value = "2950156481";
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
