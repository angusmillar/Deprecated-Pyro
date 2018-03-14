using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Search;
using Pyro.Common.FhirOperation;
using Pyro.Common.Tools.Headers;
using Pyro.Common.Tools;
using Pyro.Common.ADHA.Api;
using Pyro.ADHA.Api;
using Pyro.Common.Global;
using Pyro.Identifiers.Australian.MedicareNumber;
using Pyro.Identifiers.Australian.DepartmentVeteransAffairs;
using Pyro.Identifiers.Australian.NationalHealthcareIdentifier;
using System.Text;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Service
{
  public class IHISearchOrValidateOperationService : IIHISearchOrValidateOperationService
  {
    List<OperationOutcome.IssueComponent> IssueList = null;
    IResourceServiceOutcome ResourceServiceOutcome;
    const string MedicareNumberFhirSystem = "http://ns.electronichealth.net.au/id/medicare-number";
    const string DVANumberFhirSystem = "http://ns.electronichealth.net.au/id/dva";
    const string IHINumberFhirSystem = "http://ns.electronichealth.net.au/id/hi/ihi/1.0";
    private enum IdentiferType { IHI, Medicare, DVA }
    private bool ReturnSoapBinaryResourcesToFHIRCaller = false;
    
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;        
    private readonly IResourceServices IResourceServices;
    private readonly IGlobalProperties GlobalProperties;
    private readonly IHiServiceApi HiServiceApi;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IMedicareNumberParser IMedicareNumberParser;
    private readonly IIndividualHealthcareIdentifierParser IIndividualHealthcareIdentifierParser;
    private readonly IDVANumberParser IDVANumberParser;

    public IHISearchOrValidateOperationService(     
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,      
      IResourceServices IResourceServices,
      IGlobalProperties GlobalProperties,
      IHiServiceApi IHiServiceApi,      
      IRequestMetaFactory IRequestMetaFactory,
      IMedicareNumberParser IMedicareNumberParser,
      IIndividualHealthcareIdentifierParser IIndividualHealthcareIdentifierParser,
      IDVANumberParser IDVANumberParser)
    {      
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;            
      this.IResourceServices = IResourceServices;
      this.GlobalProperties = GlobalProperties;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IMedicareNumberParser = IMedicareNumberParser;
      this.IDVANumberParser = IDVANumberParser;
      this.IIndividualHealthcareIdentifierParser = IIndividualHealthcareIdentifierParser;
      this.HiServiceApi = IHiServiceApi;
    }

    public IResourceServiceOutcome IHISearchOrValidate(OperationClass OperationClass, Resource Resource, IRequestMeta RequestMeta)
    {
      if (OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta cannot be null.");
      if (RequestMeta.PyroRequestUri== null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (HiServiceApi == null)
        throw new NullReferenceException("HiServiceApi cannot be null.");

      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      if (!GlobalProperties.HIServiceConnectivityActive)
      {
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
        $"HI Service connectivity is disabled on this server instance, please contact you system administrator if it is required.");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }

      if (ResourceType.Patient.GetLiteral() != RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName)
      {
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
        $"The server operation x-IHISearchOrValidate is only supported on the {ResourceType.Patient.GetLiteral()} resource endpoint and not on the {RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName} resource endpoint.");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }

      if (Resource.ResourceType != ResourceType.Parameters)
      {
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
        $"The operation x-IHISearchOrValidate only supports an input body FHIR resource of type {ResourceType.Parameters.GetLiteral()}, found type of {Resource.ResourceType.GetLiteral()}");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }

      //Parse the parameter resource and populate the IhiRequestData object or error and return OperationOutcome
      List<IhiRequestData> IhiRequestDataList = new List<IhiRequestData>();
      IssueList = new List<OperationOutcome.IssueComponent>();
      Parameters RequestParameters = Resource as Parameters;

      //Will generate a List of IhiReqiestData in the order the HI Service shoudl be called.
      //This is IHI first, Medicare second and DVA third and the different name combinations as required.
      if (!GetIhiRequestDataList(RequestParameters, IhiRequestDataList))
      {
        ResourceServiceOutcome.ResourceResult = ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList);
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        return ResourceServiceOutcome;
      }


      ////Make the call to HI Service, return any error as operation outcome or return the parameter resource with the results if success
      IIhiSearchValidateOutcome HiServiceOutCome = null;
      bool IsHIServiceFoundIHI = false;
      bool IsHIServiceError = false;
      try
      {
        /// Perform HI Service requests in the order IHI, Medicare then DVA, as soon 
        /// as one is successful in finding a IHI we break, stop

        // Make Hi Service Calls
        foreach (IhiRequestData IhiRequestData in IhiRequestDataList)
        {
          IsHIServiceFoundIHI = false;
          IsHIServiceError = false;
          HiServiceOutCome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);
          //Did a HI Error error occur?
          IsHIServiceError = !HiServiceOutCome.SuccessfulQuery;
          //Did we get an IHI Idneifier?
          IsHIServiceFoundIHI = !String.IsNullOrWhiteSpace(HiServiceOutCome.ResponseData.IHINumber);
          if (IsHIServiceFoundIHI || IsHIServiceError)
            break;
        }

        if (IsHIServiceError)
        {
          //Some error from the HI Service libaray
          ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception,
          $"Error returned from the HI Service call atempt: {HiServiceOutCome.QueryMetadata.ErrorMessge}");
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
        else 
        {
          //Handles both an IHI Found or not found

          // We found a IHI number from HI Service so store the Soap as 
          // Binary resources and form the response
          IResourceServiceOutcome ResourceServiceOutcomeSoapRequestBinary = null;
          IResourceServiceOutcome ResourceServiceOutcomeSoapResponseBinary = null;          
          if (!String.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapRequest) && !String.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapRequestMessageId))
          {
            ResourceServiceOutcomeSoapRequestBinary = CommitBinaryResourceForSoapLogging(HiServiceOutCome.QueryMetadata.SoapRequestMessageId, HiServiceOutCome.QueryMetadata.SoapRequest, RequestMeta.PyroRequestUri, HiServiceOutCome);
          }

          if (!String.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapResponse) && !String.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapResponseMessageId))
          {
            ResourceServiceOutcomeSoapResponseBinary = CommitBinaryResourceForSoapLogging(HiServiceOutCome.QueryMetadata.SoapResponseMessageId, HiServiceOutCome.QueryMetadata.SoapResponse, RequestMeta.PyroRequestUri, HiServiceOutCome);          
          }

          //log all the soap requests, HI Conformance states all errors must be logged
          Parameters ResponseParametersResource = GenerateReturnParametersResource(RequestParameters, HiServiceOutCome, ResourceServiceOutcomeSoapRequestBinary, ResourceServiceOutcomeSoapResponseBinary);

          ResourceServiceOutcome.ResourceResult = ResponseParametersResource;
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          ResourceServiceOutcome.LastModified = ResponseParametersResource.Meta.LastUpdated;
          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
          return ResourceServiceOutcome;
        }        
      }
      catch (Exception exec)
      {
        //Some uncaught exception
        string Message = $"Internal Server error in calling the HI Service, exception was throw. Message: {exec.Message}";
        var OptOut = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported, Message);
        throw new Exceptions.PyroException(System.Net.HttpStatusCode.InternalServerError, OptOut, Message, exec);
      }
    }
   
    private Parameters GenerateReturnParametersResource(
      Parameters RequestParameters, IIhiSearchValidateOutcome IhiServiceOutCome,
      IResourceServiceOutcome ResourceServiceOutcomeSoapRequestBinary, IResourceServiceOutcome ResourceServiceOutcomeSoapResponseBinary)
    {
      //we will use the request parameters to create the response
      RequestParameters.Meta = new Meta();
      RequestParameters.Meta.LastUpdated = DateTimeOffset.Now;

      var HiServiceResponseParameter = new Parameters.ParameterComponent();
      HiServiceResponseParameter.Name = "HiServiceResponse";
      HiServiceResponseParameter.Part = new List<Parameters.ParameterComponent>();
      RequestParameters.Parameter.Add(HiServiceResponseParameter);

      var SuccessParameter = new Parameters.ParameterComponent();
      SuccessParameter.Name = "IHIMatchFound";
      bool IHIMatchFound = false;
      if (IhiServiceOutCome.ResponseData != null)
      {
        IHIMatchFound = !String.IsNullOrWhiteSpace(IhiServiceOutCome.ResponseData.IHINumber);
      }      
      SuccessParameter.Value = new FhirBoolean(IHIMatchFound);            
      HiServiceResponseParameter.Part.Add(SuccessParameter);

      if (!IhiServiceOutCome.SuccessfulQuery)
      {
        var ResponsePatientResourceParameter = new Parameters.ParameterComponent();
        ResponsePatientResourceParameter.Name = "ResponseErrorMessage";
        ResponsePatientResourceParameter.Value = new FhirString(IhiServiceOutCome.QueryMetadata.ErrorMessge);
        HiServiceResponseParameter.Part.Add(ResponsePatientResourceParameter);
      }
      else
      {
        if (IHIMatchFound)
        {
          var ResponsePatientResourceParameter = new Parameters.ParameterComponent();
          ResponsePatientResourceParameter.Name = "ResponsePatient";
          ResponsePatientResourceParameter.Resource = GenerateResponsePatientResource(IhiServiceOutCome);
          HiServiceResponseParameter.Part.Add(ResponsePatientResourceParameter);
        }
      }

      if (IhiServiceOutCome.QueryMetadata.ServiceMessage.Count != 0)
      {
        var HiServiceMessageListParameter = new Parameters.ParameterComponent();
        HiServiceMessageListParameter.Name = "HiServiceMessageList";
        HiServiceMessageListParameter.Part = new List<Parameters.ParameterComponent>();
        HiServiceResponseParameter.Part.Add(HiServiceMessageListParameter);

        foreach(var ServiceMessage in IhiServiceOutCome.QueryMetadata.ServiceMessage)
        {
          var HiServiceMessageParameter = new Parameters.ParameterComponent();
          HiServiceMessageParameter.Name = "HiServiceMessage";
          HiServiceMessageParameter.Part = new List<Parameters.ParameterComponent>();
          HiServiceMessageListParameter.Part.Add(HiServiceMessageParameter);

          if (!String.IsNullOrWhiteSpace(ServiceMessage.Code))
          {
            var CodeParameter = new Parameters.ParameterComponent();
            CodeParameter.Name = "Code";
            CodeParameter.Value = new Code() { Value = ServiceMessage.Code };
            HiServiceMessageParameter.Part.Add(CodeParameter);
          }

          if (!String.IsNullOrWhiteSpace(ServiceMessage.Reason))
          {
            var ReasonParameter = new Parameters.ParameterComponent();
            ReasonParameter.Name = "Reason";
            ReasonParameter.Value = new FhirString() { Value = ServiceMessage.Reason };
            HiServiceMessageParameter.Part.Add(ReasonParameter);
          }

          if (!String.IsNullOrWhiteSpace(ServiceMessage.SeverityType))
          {
            var ReasonParameter = new Parameters.ParameterComponent();
            ReasonParameter.Name = "Reason";
            ReasonParameter.Value = new Code() { Value = ServiceMessage.SeverityType };
            HiServiceMessageParameter.Part.Add(ReasonParameter);
          }
        }
      }

      var HiServiceCallAuditParameter = new Parameters.ParameterComponent();
      HiServiceCallAuditParameter.Name = "HiServiceCallAudit";
      HiServiceCallAuditParameter.Part = new List<Parameters.ParameterComponent>();
      HiServiceResponseParameter.Part.Add(HiServiceCallAuditParameter);

      if (ResourceServiceOutcomeSoapRequestBinary != null && ResourceServiceOutcomeSoapRequestBinary.SuccessfulTransaction)
      {
        var RequestSoapBinaryResourceReferenceParameter = new Parameters.ParameterComponent();
        HiServiceCallAuditParameter.Part.Add(RequestSoapBinaryResourceReferenceParameter);
        RequestSoapBinaryResourceReferenceParameter.Name = "RequestSoapBinaryResourceReference";
        RequestSoapBinaryResourceReferenceParameter.Value = new FhirUri($"{ResourceServiceOutcomeSoapRequestBinary.ResourceResult.TypeName}/{ResourceServiceOutcomeSoapRequestBinary.FhirResourceId}");

        if (ReturnSoapBinaryResourcesToFHIRCaller)
        {
          var RequestSoapBinaryResourceParameter = new Parameters.ParameterComponent();
          HiServiceCallAuditParameter.Part.Add(RequestSoapBinaryResourceParameter);
          RequestSoapBinaryResourceParameter.Name = "RequestSoapBinaryResource";
          RequestSoapBinaryResourceParameter.Value = new FhirUri($"{ResourceServiceOutcomeSoapRequestBinary.ResourceResult.TypeName}/{ResourceServiceOutcomeSoapRequestBinary.FhirResourceId}");
          RequestSoapBinaryResourceParameter.Resource = ResourceServiceOutcomeSoapRequestBinary.ResourceResult;
        }

      }

      if (ResourceServiceOutcomeSoapResponseBinary != null && ResourceServiceOutcomeSoapResponseBinary.SuccessfulTransaction)
      {
        var ResponseSoapBinaryResourceReferenceParameter = new Parameters.ParameterComponent();
        HiServiceCallAuditParameter.Part.Add(ResponseSoapBinaryResourceReferenceParameter);
        ResponseSoapBinaryResourceReferenceParameter.Name = "ResponseSoapBinaryResourceReference";
        ResponseSoapBinaryResourceReferenceParameter.Value = new FhirUri($"{ResourceServiceOutcomeSoapResponseBinary.ResourceResult.TypeName}/{ResourceServiceOutcomeSoapResponseBinary.FhirResourceId}");

        if (ReturnSoapBinaryResourcesToFHIRCaller)
        {
          var ResponseSoapBinaryResourceReferenceParameterx = new Parameters.ParameterComponent();
          HiServiceCallAuditParameter.Part.Add(ResponseSoapBinaryResourceReferenceParameterx);
          ResponseSoapBinaryResourceReferenceParameterx.Name = "ResponseSoapBinaryResource";
          ResponseSoapBinaryResourceReferenceParameterx.Resource = ResourceServiceOutcomeSoapResponseBinary.ResourceResult;
        }
      }

      return RequestParameters;
    }    

    private bool GetIhiRequestDataList(Parameters ParametersResource, List<IhiRequestData> ihiRequestDataList)
    {
      //The ModelRequest only contains the elements that remain unchnaged from here forward.
      IhiRequestData ModelRequest = new IhiRequestData();
      var NowDate = DateTimeOffset.Now.Date;

      //The Order of this list dictates the order the requests will be made to the HI Service
      List<HumanName.NameUse?> NameUseList = new List<HumanName.NameUse?>()
        {
           HumanName.NameUse.Official,
           HumanName.NameUse.Usual,
           null,
           HumanName.NameUse.Maiden,
           HumanName.NameUse.Old,
        };


      const string UserIdParameter = "UserId";
      var UserId = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, UserIdParameter, StringComparison.CurrentCultureIgnoreCase));
      if (UserId != null && UserId.Value is FhirString UserIdString && !String.IsNullOrWhiteSpace(UserIdString.Value))
      {
        ModelRequest.UserId = UserIdString.Value;
      }
      else
      {
        //No suitable Identifers 
        IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
          $"Must supplly a single '{UserIdParameter}' parameter contaiing a User Id of the user making the request to the HI Service."));
        return false;
      }

      const string UserIdQualifierParameter = "UserIdQualifier";
      var UserIdQualifier = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, UserIdQualifierParameter, StringComparison.CurrentCultureIgnoreCase));
      if (UserIdQualifier != null && UserIdQualifier.Value is FhirUri UserQualifierUri && !String.IsNullOrWhiteSpace(UserQualifierUri.Value))
      {
        ModelRequest.UserIdQualifier = UserQualifierUri.Value;
      }
      else
      {
        //No suitable Identifers 
        IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
          $"Must supplly a single '{UserIdQualifierParameter}' parameter contaiing a User Id Qualifier of the user making the request to the HI Service. For example 'http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0'"));
        return false;
      }

      //Return Soap binary Resource to caller
      const string ReturnSoapRequestAndResponseParameter = "ReturnSoapRequestAndResponseData";
      var ReturnSoapRequestAndResponse = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, ReturnSoapRequestAndResponseParameter, StringComparison.CurrentCultureIgnoreCase));
      //Set the Model to true always as this forces the HI Service API cal to return the soap
      ModelRequest.ReturnSoapRequestAndResponseData = true;
      if (ReturnSoapRequestAndResponse != null)
      {
        if (ReturnSoapRequestAndResponse.Value is FhirBoolean temp)
        {
          //Set this global bool to what the user requires at this controls what is returned
          //To the user, 
          ReturnSoapBinaryResourcesToFHIRCaller = temp.Value.Value;
        }
      }

      IEnumerable<HumanName> HumanNameList = null;
      IEnumerable<Identifier> MedicareList = null;
      IEnumerable<Identifier> DVAByList = null;
      IEnumerable<Identifier> IHIList = null;

      //Process the Patient resource
      const string RequestPatientParameter = "RequestPatient";
      var RequestPatient = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, RequestPatientParameter, StringComparison.CurrentCultureIgnoreCase));
      if (RequestPatient != null && RequestPatient.Resource is Patient PatientRequest)
      {
        //Only use valid by period Names where Family not empty and period valid of NameUseList, or if no period at all or no NameUse at all
        HumanNameList = GetHumanNameListByNameUseAndPeriodDateWhereFamilyNotEmpty(PatientRequest.Name, NameUseList, NowDate);
        if (HumanNameList.Count() == 0)
        {
          //No suitable Patient Name 
          StringBuilder sb = new StringBuilder();
          NameUseList.ForEach(x => sb.Append($"{x.GetLiteral()} "));
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
            $"The supplied {ResourceType.Patient.GetLiteral()} resource must have a least one HumanName which contains a Family name and no Use type or a Use type of {sb.ToString()} and the HumanName Period (start & end) must be current or not provided"));
          return false;
        }

        //Only use valid by period Medicare or DVA numbers, or if no period at all
        MedicareList = GetValidByDateIdentifierList(PatientRequest.Identifier, MedicareNumberFhirSystem, NowDate);
        DVAByList = GetValidByDateIdentifierList(PatientRequest.Identifier, DVANumberFhirSystem, NowDate);
        //Get IHI regardless of period as they will mostlikley be unvalid by period because we are trying to revalidate them
        IHIList = GetValidByDateIdentifierList(PatientRequest.Identifier, IHINumberFhirSystem, null);

        //Check we have at least one identifer
        if (IHIList.Count() + MedicareList.Count() + DVAByList.Count() == 0)
        {
          //No suitable Identifers 
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
            $"The supplied {ResourceType.Patient.GetLiteral()} resource must have a least one identifier of type Medicare Number using the system '{MedicareNumberFhirSystem}' or DVA Number using the system '{DVANumberFhirSystem}' or IHI using the system {IHINumberFhirSystem}. The Medicare Number or DVA number identifier Period (start & end) must be current or not provided."));
          return false;
        }

        //Patient Dob
        if (PatientRequest.BirthDateElement != null)
        {
          DateTime TempDateTime;
          if (DateTime.TryParse(PatientRequest.BirthDateElement.Value, out TempDateTime))
          {
            ModelRequest.Dob = TempDateTime.Date;
          }
          else
          {
            IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource date of birth (DoB) element was not able to be parsed to a valid Date. Date of Birth is mandatory for the HI Service IHI call."));
            return false;
          }
        }
        else
        {
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource must have a DateofBirth element not. Date of Birth is mandatory for the HI Service IHI call"));
          return false;
        }

        //Patient Gender (Sex)
        if (!PatientRequest.Gender.HasValue)
        {
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
            $"The supplied {ResourceType.Patient.GetLiteral()} resource must have a patient gender (Sex)."));
          return false;
        }
        else
        {
          ModelRequest.SexChar = AdministrativeGenderToSexChar(PatientRequest.Gender.Value);
        }
      }
      else
      {
        //No Patient Resource
        IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
          $"Must supply a single '{RequestPatientParameter}' parameter contaiing a FHIR {ResourceType.Patient.GetLiteral()} resource."));
        return false;
      }

      return ProcessRequestList(ihiRequestDataList, ModelRequest, HumanNameList, NameUseList, IHIList, MedicareList, DVAByList);
    }

    private bool ProcessRequestList(List<IhiRequestData> ihiRequestDataList, IhiRequestData ModelRequest, IEnumerable<HumanName> HumanNameList, List<HumanName.NameUse?> NameUseList,
      IEnumerable<Identifier> IHIList, IEnumerable<Identifier> MedicareList, IEnumerable<Identifier> DVAByList)
    {
      IhiRequestData Request;
      foreach (HumanName.NameUse? NameUse in NameUseList)
      {
        foreach (HumanName Name in HumanNameList.Where(x => x.Use == NameUse && x.Given.Count() != 0))
        {
          string JoinedGivenNames = string.Empty;
          for (int i = 0; i < Name.Given.Count(); i++)
          {
            JoinedGivenNames = $"{JoinedGivenNames} {Name.Given.ElementAt(i)}";

            /// IHI Idnetifiers
            List<IIndividualHealthcareIdentifier> ValidatedIndividualHealthcareIdentifierNumberList = new List<IIndividualHealthcareIdentifier>();
            foreach (Identifier IHI in IHIList)
            {
              IIndividualHealthcareIdentifier IndividualHealthcareIdentifier;
              if (IIndividualHealthcareIdentifierParser.TryParse(IHI.Value, out IndividualHealthcareIdentifier))
              {
                ValidatedIndividualHealthcareIdentifierNumberList.Add(IndividualHealthcareIdentifier);
                //IHI Request for each single given name
                Request = new IhiRequestData();
                Request.IHINumber = IndividualHealthcareIdentifier.Value;
                Request.Dob = ModelRequest.Dob;
                Request.Family = Name.Family;
                Request.Given = Name.Given.ElementAt(i);
                Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
                Request.SexChar = ModelRequest.SexChar;
                Request.UserId = ModelRequest.UserId;
                Request.UserIdQualifier = ModelRequest.UserIdQualifier; ;
                ihiRequestDataList.Add(Request);
              }
              else
              {
                IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
                $"The supplied IndividualHealthcareIdentifier (IHI) Number value is not correctly formatted according to Individual Healthcare Identifier rules. Value was {IHI.Value}. Correct the value or remove it from the Patient resource request."));
                return false;
              }
            }

            if (i == Name.Given.Count() && Name.Given.Count() > 1)
            {
              foreach (IIndividualHealthcareIdentifier IndividualHealthcareIdentifier in ValidatedIndividualHealthcareIdentifierNumberList)
              {
                //IHI Request for all given names concatinated together e.g Angus Brian John
                Request = new IhiRequestData();
                Request.IHINumber = IndividualHealthcareIdentifier.Value;
                Request.Dob = ModelRequest.Dob;
                Request.Family = Name.Family;
                Request.Given = JoinedGivenNames.Trim();
                Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
                Request.SexChar = ModelRequest.SexChar;
                Request.UserId = ModelRequest.UserId;
                Request.UserIdQualifier = ModelRequest.UserIdQualifier;
                ihiRequestDataList.Add(Request);
              }
            }

            /// Medicare Identifiers
            List<IMedicareNumber> ValidatedMedicareNumberList = new List<IMedicareNumber>();
            foreach (Identifier Medicare in MedicareList)
            {
              IMedicareNumber MedicareNumber;
              if (IMedicareNumberParser.TryParse(Medicare.Value, out MedicareNumber))
              {
                ValidatedMedicareNumberList.Add(MedicareNumber);
                //Medicare Request for each single given name
                Request = new IhiRequestData();
                Request.MedicareNumber = MedicareNumber.Value;
                Request.MedicareIRN = MedicareNumber.IRN;
                Request.Dob = ModelRequest.Dob;
                Request.Family = Name.Family;
                Request.Given = Name.Given.ElementAt(i);
                Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
                Request.SexChar = ModelRequest.SexChar;
                Request.UserId = ModelRequest.UserId;
                Request.UserIdQualifier = ModelRequest.UserIdQualifier;
                ihiRequestDataList.Add(Request);
              }
              else
              {
                IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
                $"The supplied Medicare Number value is not correctly formatted according to Medicare Number rules. Value was {Medicare.Value}. Correct the value or remove it from the Patient resource request."));
                return false;
              }
            }

            if (i == Name.Given.Count() && Name.Given.Count() > 1)
            {
              //use the already validatd MedicareNumber list
              foreach (IMedicareNumber MedicareNumber in ValidatedMedicareNumberList)
              {
                //Medicare Request for all given names concatinated together e.g Angus Brian John
                Request = new IhiRequestData();
                Request.MedicareNumber = MedicareNumber.Value;
                Request.MedicareIRN = MedicareNumber.IRN;
                Request.Dob = ModelRequest.Dob;
                Request.Family = Name.Family;
                Request.Given = JoinedGivenNames.Trim();
                Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
                Request.SexChar = ModelRequest.SexChar;
                Request.UserId = ModelRequest.UserId;
                Request.UserIdQualifier = ModelRequest.UserIdQualifier;
                ihiRequestDataList.Add(Request);
              }
            }

            /// DVA Identifiers
            List<IDVANumber> ValidatedDVANumberList = new List<IDVANumber>();
            foreach (Identifier DVA in DVAByList)
            {
              IDVANumber DVANumber;
              if (IDVANumberParser.TryParse(DVA.Value, out DVANumber))
              {
                ValidatedDVANumberList.Add(DVANumber);
                //DVA Request for each single given name
                Request = new IhiRequestData();
                Request.DVANumber = DVANumber.Value;
                Request.Dob = ModelRequest.Dob;
                Request.Family = Name.Family;
                Request.Given = Name.Given.ElementAt(i);
                Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
                Request.SexChar = ModelRequest.SexChar;
                Request.UserId = ModelRequest.UserId;
                Request.UserIdQualifier = ModelRequest.UserIdQualifier;
                ihiRequestDataList.Add(Request);
              }
              else
              {
                IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
                $"The supplied DVA Number value is not correctly formatted according to DVA Number rules. Value was {DVA.Value}. Correct the value or remove it from the Patient resource request."));
                return false;
              }
            }

            if (i == Name.Given.Count() && Name.Given.Count() > 1)
            {
              //use the already validatd DVANumber list
              foreach (IDVANumber DVANumber in ValidatedDVANumberList)
              {
                //DVA Request for all given names concatinated together e.g Angus Brian John
                Request = new IhiRequestData();
                Request.DVANumber = DVANumber.Value;
                Request.Dob = ModelRequest.Dob;
                Request.Family = Name.Family;
                Request.Given = JoinedGivenNames.Trim();
                Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
                Request.SexChar = ModelRequest.SexChar;
                Request.UserId = ModelRequest.UserId;
                Request.UserIdQualifier = ModelRequest.UserIdQualifier;
                ihiRequestDataList.Add(Request);
              }
            }
          }
        }

        //For HumanNames with no given names at all
        foreach (HumanName Name in HumanNameList.Where(x => x.Use == NameUse && x.Given.Count() == 0))
        {

          /// IHI Idnetifiers
          List<IIndividualHealthcareIdentifier> ValidatedIndividualHealthcareIdentifierNumberList = new List<IIndividualHealthcareIdentifier>();
          foreach (Identifier IHI in IHIList)
          {
            IIndividualHealthcareIdentifier IndividualHealthcareIdentifier;
            if (IIndividualHealthcareIdentifierParser.TryParse(IHI.Value, out IndividualHealthcareIdentifier))
            {
              ValidatedIndividualHealthcareIdentifierNumberList.Add(IndividualHealthcareIdentifier);
              //IHI Request for each single given name
              Request = new IhiRequestData();
              Request.IHINumber = IndividualHealthcareIdentifier.Value;
              Request.Dob = ModelRequest.Dob;
              Request.Family = Name.Family;
              Request.Given = string.Empty;
              Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
              Request.SexChar = ModelRequest.SexChar;
              Request.UserId = ModelRequest.UserId;
              Request.UserIdQualifier = ModelRequest.UserIdQualifier; ;
              ihiRequestDataList.Add(Request);
            }
            else
            {
              IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
              $"The supplied Individual Healthcare Identifier (IHI) number value is not correctly formatted according to Individual Healthcare Identifier rules. Value was {IHI.Value}. Correct the value or remove it from the Patient resource request."));
              return false;
            }
          }

          /// Medicare Identifiers
          List<IMedicareNumber> ValidatedMedicareNumberList = new List<IMedicareNumber>();
          foreach (Identifier Medicare in MedicareList)
          {
            IMedicareNumber MedicareNumber;
            if (IMedicareNumberParser.TryParse(Medicare.Value, out MedicareNumber))
            {
              ValidatedMedicareNumberList.Add(MedicareNumber);
              //Medicare Request for each single given name
              Request = new IhiRequestData();
              Request.MedicareNumber = MedicareNumber.Value;
              Request.MedicareIRN = MedicareNumber.IRN;
              Request.Dob = ModelRequest.Dob;
              Request.Family = Name.Family;
              Request.Given = string.Empty;
              Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
              Request.SexChar = ModelRequest.SexChar;
              Request.UserId = ModelRequest.UserId;
              Request.UserIdQualifier = ModelRequest.UserIdQualifier;
              ihiRequestDataList.Add(Request);
            }
            else
            {
              IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
              $"The supplied Medicare number value is not correctly formatted according to Medicare number rules. Value was {Medicare.Value}. Correct the value or remove it from the Patient resource request."));
              return false;
            }
          }

          /// DVA Identifiers
          List<IDVANumber> ValidatedDVANumberList = new List<IDVANumber>();
          foreach (Identifier DVA in DVAByList)
          {
            IDVANumber DVANumber;
            if (IDVANumberParser.TryParse(DVA.Value, out DVANumber))
            {
              ValidatedDVANumberList.Add(DVANumber);
              //DVA Request for each single given name
              Request = new IhiRequestData();
              Request.DVANumber = DVANumber.Value;
              Request.Dob = ModelRequest.Dob;
              Request.Family = Name.Family;
              Request.Given = string.Empty;
              Request.ReturnSoapRequestAndResponseData = ModelRequest.ReturnSoapRequestAndResponseData;
              Request.SexChar = ModelRequest.SexChar;
              Request.UserId = ModelRequest.UserId;
              Request.UserIdQualifier = ModelRequest.UserIdQualifier;
              ihiRequestDataList.Add(Request);
            }
            else
            {
              IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
              $"The supplied DVA number value is not correctly formatted according to DVA Number rules. Value was {DVA.Value}. Correct the value or remove it from the Patient resource request."));
              return false;
            }
          }
        }

      }
      return true;
    }

    /// <summary>
    /// If a Date is given then only identifiers that are valid for that date, or have no period set
    /// If no date then returns all identifiers of the TargetSystem regardless of period
    /// </summary>
    /// <param name="InputIdentifierList"></param>
    /// <param name="TargetSystem"></param>
    /// <param name="Date"></param>
    /// <returns></returns>
    private IEnumerable<Identifier> GetValidByDateIdentifierList(List<Identifier> InputIdentifierList, string TargetSystem, DateTime? Date = null)
    {
      IEnumerable<Identifier> TempList = InputIdentifierList.Where(x =>
        String.Equals(x.System, TargetSystem, StringComparison.CurrentCultureIgnoreCase) &&
        !String.IsNullOrWhiteSpace(x.Value));

      if (!Date.HasValue)
      {
        return TempList;
      }
      else
      {
        return TempList.Where(x =>
            x.Period == null ||
            (x.Period.Start != null && x.Period.StartElement.ToDateTimeOffset().Date < Date.Value && x.Period.End == null) ||
            (x.Period.End != null && x.Period.EndElement.ToDateTimeOffset().Date > Date.Value && x.Period.Start == null) ||
            (x.Period.Start != null && x.Period.StartElement.ToDateTimeOffset().Date < Date.Value && x.Period.End != null && x.Period.EndElement.ToDateTimeOffset().Date > Date.Value)
          );
      }
    }

    /// <summary>
    /// If a Date is given then only HumanNames that are valid for that date, or have no period set
    /// If no date then returns all HumanNames of the NameUseList type regardless of period
    /// </summary>
    /// <param name="InputHumanNameList"></param>
    /// <param name="TargetSystem"></param>
    /// <param name="Date"></param>
    /// <returns></returns>
    private IEnumerable<HumanName> GetHumanNameListByNameUseAndPeriodDateWhereFamilyNotEmpty(List<HumanName> InputHumanNameList, List<HumanName.NameUse?> NameUseList, DateTime? Date = null)
    {
      IEnumerable<HumanName> TempList = InputHumanNameList.Where(x =>
      !String.IsNullOrWhiteSpace(x.Family) && NameUseList.Contains(x.Use));

      if (!Date.HasValue)
      {
        return TempList;
      }
      else
      {
        return TempList.Where(x =>
            x.Period == null ||
            (x.Period.Start != null && x.Period.StartElement.ToDateTimeOffset().Date < Date.Value && x.Period.End == null) ||
            (x.Period.End != null && x.Period.EndElement.ToDateTimeOffset().Date > Date.Value && x.Period.Start == null) ||
            (x.Period.Start != null && x.Period.StartElement.ToDateTimeOffset().Date < Date.Value && x.Period.End != null && x.Period.EndElement.ToDateTimeOffset().Date > Date.Value)
          );
      }
    }

    private IResourceServiceOutcome CommitBinaryResourceForSoapLogging(string SoapMessageId, string SoapData, IPyroRequestUri RequestUri, IIhiSearchValidateOutcome HiServiceOutCome)
    {
      IResourceServiceOutcome ResourceServiceOutcomeSoapBinary;
      IResourceServices.SetCurrentResourceType(FHIRAllTypes.Binary);
      string BinaryResourceId = StripUrnUuidPrefixFromSoapMessageId(SoapMessageId);
      IRequestMeta RequestMetaPut = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.Binary.GetLiteral()}/{BinaryResourceId}");      
      Binary SoapBinaryResource = GenerateSoapBinaryResource(SoapData, BinaryResourceId);

      ResourceServiceOutcomeSoapBinary = IResourceServices.Put(BinaryResourceId, SoapBinaryResource, RequestMetaPut);
      if (!ResourceServiceOutcomeSoapBinary.SuccessfulTransaction)
      {
        string Message = $"Internal Server error in trying to commit a Binary resource to log a HI Service Soap Message Id: {SoapMessageId}";
        var OptOut = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported, Message);
        throw new Exceptions.PyroException(System.Net.HttpStatusCode.InternalServerError, OptOut, Message);
      }
      return ResourceServiceOutcomeSoapBinary;
    }

    private Binary GenerateSoapBinaryResource(string SoapXml, string SoapMessageId)
    {
      Binary SoapBinary = new Binary();
      SoapBinary.Id = SoapMessageId;
      SoapBinary.ContentType = "application/soap+xml";
      SoapBinary.Content = System.Text.Encoding.UTF8.GetBytes(SoapXml);
      return SoapBinary;
    }

    private static string StripUrnUuidPrefixFromSoapMessageId(string SoapMesageId)
    {
      if (SoapMesageId.StartsWith("urn:uuid:"))
      {
        return SoapMesageId.Split(':')[2];
      }
      else
      {
        return SoapMesageId;
      }
    }

    private Resource GenerateResponsePatientResource(IIhiSearchValidateOutcome ihiServiceOutCome)
    {
      Patient ResponsePatient = new Patient();
      //Name
      if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.Family) || !String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.Given))
      {
        ResponsePatient.Name = new List<HumanName>();
        HumanName HumanName = new HumanName();
        if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.Family))
        {
          HumanName.Family = ihiServiceOutCome.ResponseData.Family;
        }
        if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.Given))
        {
          HumanName.Given = new List<string>() { ihiServiceOutCome.ResponseData.Given };
        }
        ResponsePatient.Name.Add(HumanName);
      }

      //Sex
      if (!Char.IsWhiteSpace(ihiServiceOutCome.ResponseData.SexChar))
      {
        ResponsePatient.Gender = SexCharToAdministrativeGender(ihiServiceOutCome.ResponseData.SexChar);
      }

      //Dob
      if (ihiServiceOutCome.ResponseData.Dob.HasValue)
      {
        ResponsePatient.BirthDateElement = new Date(ihiServiceOutCome.ResponseData.Dob.Value.Year, ihiServiceOutCome.ResponseData.Dob.Value.Month, ihiServiceOutCome.ResponseData.Dob.Value.Day);
      }

      //IHI
      if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.IHINumber))
      {
        if (ResponsePatient.Identifier == null)
          ResponsePatient.Identifier = new List<Identifier>();

        Identifier IhiIdentifier = new Identifier();
        ResponsePatient.Identifier.Add(IhiIdentifier);
        IhiIdentifier.Value = ihiServiceOutCome.ResponseData.IHINumber;
        IhiIdentifier.System = IHINumberFhirSystem;
        var Start = DateTimeOffset.Now;
        //Set the re-validation period based on web config period
        IhiIdentifier.Period = new Period(new FhirDateTime(Start), new FhirDateTime(Start.AddDays(GlobalProperties.HIServiceIHIValidationPeriodDays)));
        IhiIdentifier.Type = new CodeableConcept();
        IhiIdentifier.Type.Coding = new List<Coding>();
        IhiIdentifier.Type.Text = "IHI";
        Coding IhiTypeCoding = new Coding();
        IhiIdentifier.Type.Coding.Add(IhiTypeCoding);
        IhiTypeCoding.System = "http://hl7.org.au/fhir/v2/0203";
        IhiTypeCoding.Code = "NI";
        IhiTypeCoding.Display = "National unique individual identifier";

        //IHI Status
        if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.IHIStatus))
        {
          Coding IhiStatusCoding = new Coding("http://ns.electronichealth.net.au/fhir/CodeSystem/hi/ihi/ihi-status/1.0.0", ihiServiceOutCome.ResponseData.IHIStatus, ihiServiceOutCome.ResponseData.IHIStatus);
          IhiIdentifier.AddExtension("http://hl7.org.au/fhir/StructureDefinition/ihi-status", IhiStatusCoding, false);
        }

        //IHI Record Status
        if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.IHIRecordStatus))
        {
          Coding IhiRecordStatusCoding = new Coding("http://ns.electronichealth.net.au/fhir/CodeSystem/hi/ihi/ihi-record-status/1.0.0", ihiServiceOutCome.ResponseData.IHIRecordStatus, ihiServiceOutCome.ResponseData.IHIRecordStatus);
          IhiIdentifier.AddExtension("http://hl7.org.au/fhir/StructureDefinition/ihi-record-status", IhiRecordStatusCoding, false);
        }
      }

      //Medicare
      if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.MedicareNumber))
      {
        if (ResponsePatient.Identifier == null)
          ResponsePatient.Identifier = new List<Identifier>();

        Identifier MedicareIdentifier = new Identifier();
        ResponsePatient.Identifier.Add(MedicareIdentifier);
        if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.MedicareIRN))
        {
          MedicareIdentifier.Value = ihiServiceOutCome.ResponseData.MedicareNumber + ihiServiceOutCome.ResponseData.MedicareIRN;
        }
        else
        {
          MedicareIdentifier.Value = ihiServiceOutCome.ResponseData.MedicareNumber;
        }
        MedicareIdentifier.System = MedicareNumberFhirSystem;
        MedicareIdentifier.Type = new CodeableConcept();
        MedicareIdentifier.Type.Coding = new List<Coding>();
        MedicareIdentifier.Type.Text = "Medicare Number";
        Coding MedicareTypeCoding = new Coding();
        MedicareIdentifier.Type.Coding.Add(MedicareTypeCoding);
        MedicareTypeCoding.System = "http://hl7.org/fhir/v2/0203";
        MedicareTypeCoding.Code = "MC";
        MedicareTypeCoding.Display = "Patient's Medicare Number";
      }

      //DVA
      if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.DVANumber))
      {
        if (ResponsePatient.Identifier == null)
          ResponsePatient.Identifier = new List<Identifier>();

        Identifier DVAIdentifier = new Identifier();
        ResponsePatient.Identifier.Add(DVAIdentifier);
        DVAIdentifier.Value = ihiServiceOutCome.ResponseData.DVANumber;
        DVAIdentifier.System = DVANumberFhirSystem;
        DVAIdentifier.Type = new CodeableConcept();
        DVAIdentifier.Type.Coding = new List<Coding>();
        DVAIdentifier.Type.Text = "DVA Number";
        Coding DVATypeCoding = new Coding();
        DVAIdentifier.Type.Coding.Add(DVATypeCoding);
        DVATypeCoding.System = "http://hl7.org.au/fhir/v2/0203";
        DVATypeCoding.Code = "DVA";
        DVATypeCoding.Display = "DVA Number";
      }
      return ResponsePatient;
    }

    private char AdministrativeGenderToSexChar(AdministrativeGender AdministrativeGender)
    {
      switch (AdministrativeGender)
      {
        case AdministrativeGender.Female:
          return 'F';
        case AdministrativeGender.Male:
          return 'M';
        case AdministrativeGender.Other:
          return 'I';
        case AdministrativeGender.Unknown:
          return 'N';
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException("AdministrativeGender", (int)AdministrativeGender, typeof(AdministrativeGender));
      }
    }

    private AdministrativeGender SexCharToAdministrativeGender(char SexChar)
    {
      switch (SexChar)
      {
        case 'F':
          return AdministrativeGender.Female;
        case 'M':
          return AdministrativeGender.Male;
        case 'I':
          return AdministrativeGender.Other;
        case 'N':
          return AdministrativeGender.Unknown;
        default:
          throw new System.ArgumentException($"Server Error: Unknown SexChar from HI Service call, SexChar was {SexChar.ToString()}");
      }
    }

  }
}
