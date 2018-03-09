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

    private readonly IRequestHeaderFactory IRequestHeaderFactory;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IPyroRequestUriFactory IPyroRequestUriFactory;
    private readonly IResourceServices IResourceServices;
    private readonly IGlobalProperties GlobalProperties;
    private readonly IHiServiceApi HiServiceApi;

    public IHISearchOrValidateOperationService(
      IRequestHeaderFactory IRequestHeaderFactory,
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      IPyroFhirUriFactory IPyroFhirUriFactory,
      IResourceServices IResourceServices,
      IGlobalProperties GlobalProperties,
      IHiServiceApi IHiServiceApi,
      IPyroRequestUriFactory IPyroRequestUriFactory)
    {
      this.IRequestHeaderFactory = IRequestHeaderFactory;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.IPyroRequestUriFactory = IPyroRequestUriFactory;
      this.IResourceServices = IResourceServices;
      this.GlobalProperties = GlobalProperties;
      this.HiServiceApi = IHiServiceApi;
    }

    public IResourceServiceOutcome IHISearchOrValidate(
      OperationClass OperationClass,
      Resource Resource,
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      IRequestHeader RequestHeaders)
    {
      if (OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");
      if (SearchParameterGeneric == null)
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

      if (ResourceType.Patient.GetLiteral() != RequestUri.FhirRequestUri.ResourseName)
      {
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported,
        $"The server operation x-IHISearchOrValidate is only supported on the {ResourceType.Patient.GetLiteral()} resource endpoint and not on the {RequestUri.FhirRequestUri.ResourseName} resource endpoint.");
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
      if (!GenerateCollectionOfIhiRequestData(RequestParameters, IhiRequestDataList))
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

        if (IsHIServiceFoundIHI)
        {
          IResourceServiceOutcome ResourceServiceOutcomeSoapRequestBinary = null;
          IResourceServiceOutcome ResourceServiceOutcomeSoapResponseBinary = null;

          IResourceServices.SetCurrentResourceType(FHIRAllTypes.Binary);
          IRequestHeader BinaryHeaders = IRequestHeaderFactory.CreateRequestHeader();
          if (!String.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapRequest) && !String.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapRequestMessageId))
          {
            string BinaryResourceId = StripUrnUuidPrefixFromSoapMessageId(HiServiceOutCome.QueryMetadata.SoapRequestMessageId);
            IPyroRequestUri BinaryRequestUri = IPyroRequestUriFactory.CreateFhirRequestUri();
            BinaryRequestUri.FhirRequestUri.Parse($"{RequestUri.PrimaryRootUrlStore.Url}/{FHIRAllTypes.Binary.GetLiteral()}/{BinaryResourceId}");
            Binary SoapBinaryResource = GenerateSoapBinaryResource(HiServiceOutCome.QueryMetadata.SoapRequest, BinaryResourceId);
            ResourceServiceOutcomeSoapRequestBinary = IResourceServices.Put(BinaryResourceId, SoapBinaryResource, BinaryRequestUri, SearchParameterGeneric, BinaryHeaders);
            //need to handle this operation failing
            //SoapRequestBinaryResourceReferance = new FhirUri($"{BinaryPutOutcome.ResourceResult.TypeName}/{BinaryPutOutcome.FhirResourceId}");            
          }

          if (!String.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapResponse) && !String.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapResponseMessageId))
          {
            string BinaryResourceId = StripUrnUuidPrefixFromSoapMessageId(HiServiceOutCome.QueryMetadata.SoapRequestMessageId);
            IPyroRequestUri BinaryRequestUri = IPyroRequestUriFactory.CreateFhirRequestUri();
            BinaryRequestUri.FhirRequestUri.Parse($"{RequestUri.PrimaryRootUrlStore.Url}/{FHIRAllTypes.Binary.GetLiteral()}/{BinaryResourceId}");
            Binary SoapBinaryResource = GenerateSoapBinaryResource(HiServiceOutCome.QueryMetadata.SoapResponse, BinaryResourceId);
            ResourceServiceOutcomeSoapResponseBinary = IResourceServices.Put(BinaryResourceId, SoapBinaryResource, BinaryRequestUri, SearchParameterGeneric, BinaryHeaders);
            //need to handle this operation failing
            //SoapResponseBinaryResourceReferance = new FhirUri($"{BinaryPutOutcome.ResourceResult.TypeName}/{BinaryPutOutcome.FhirResourceId}");            
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
        else if (IsHIServiceError)
        {
          //Some error from the HI Service libaray
          ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception,
          $"Error returned from the HI Service call atempt: {HiServiceOutCome.QueryMetadata.ErrorMessge}");
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
        else if (!IsHIServiceFoundIHI)
        {
          return null;
          //No Error but also no IHI found
        }
        else
        {
          //shoudl not happen??
          return null;
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
      SuccessParameter.Name = "Success";
      SuccessParameter.Value = new FhirBoolean(IhiServiceOutCome.SuccessfulQuery);
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
        var ResponsePatientResourceParameter = new Parameters.ParameterComponent();
        ResponsePatientResourceParameter.Name = "ResponsePatient";
        ResponsePatientResourceParameter.Resource = GenerateResponsePatientResource(IhiServiceOutCome);
        HiServiceResponseParameter.Part.Add(ResponsePatientResourceParameter);
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

        if (IhiServiceOutCome.RequestData.ReturnSoapRequestAndResponseData)
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

        if (IhiServiceOutCome.RequestData.ReturnSoapRequestAndResponseData)
        {
          var ResponseSoapBinaryResourceReferenceParameterx = new Parameters.ParameterComponent();
          HiServiceCallAuditParameter.Part.Add(ResponseSoapBinaryResourceReferenceParameterx);
          ResponseSoapBinaryResourceReferenceParameterx.Name = "ResponseSoapBinaryResource";
          ResponseSoapBinaryResourceReferenceParameterx.Resource = ResourceServiceOutcomeSoapResponseBinary.ResourceResult;
        }
      }


      return RequestParameters;
    }

    private Binary GenerateSoapBinaryResource(string SoapXml, string SoapMessageId)
    {
      Binary SoapBinary = new Binary();
      SoapBinary.Id = SoapMessageId;
      SoapBinary.ContentType = "application/soap+xml";
      SoapBinary.Content = System.Text.Encoding.UTF8.GetBytes(SoapXml);
      return SoapBinary;
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
        DVAIdentifier.Type.Text = "Department of Veterans' Affairs Number";
        Coding DVATypeCoding = new Coding();
        DVAIdentifier.Type.Coding.Add(DVATypeCoding);
        DVATypeCoding.System = "http://hl7.org.au/fhir/v2/0203";
        DVATypeCoding.Code = "DVA";
        DVATypeCoding.Display = "DVA Number";
      }
      return ResponsePatient;
    }

    private bool GenerateCollectionOfIhiRequestData(Parameters ParametersResource, List<IhiRequestData> IhiRequestDataList)
    {
      IhiRequestDataCollection ModelIhiRequestCollection = new IhiRequestDataCollection();

      List<IhiRequestData> FirstQuerySetIhiRequestDataList = new List<IhiRequestData>();
      List<IhiRequestData> SecondQuerySetIhiRequestDataList = new List<IhiRequestData>();
      List<IhiRequestData> ThirdQuerySetIhiRequestDataList = new List<IhiRequestData>();


      if (ParseRequestPatientResource(ParametersResource, ModelIhiRequestCollection))
      {
        //Generate a IhiRequestData for each seperate HI Service call required in the apropirate order that they should be executed.
        //IHI Identifer search first, then Medicare, then DVA, then 
        var HumanNamesContainingFaimlyNames = ModelIhiRequestCollection.HumanNameList.Select(x => String.IsNullOrWhiteSpace(x.Family));
        if (HumanNamesContainingFaimlyNames == null)
        {
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
            $"The supplied {ResourceType.Patient.GetLiteral()} resource has not Family name in any of the HumanName elements. Family name is mandatory for the HI Service IHI call"));
          return false;
        }
        else
        {
          if (!String.IsNullOrWhiteSpace(ModelIhiRequestCollection.IHINumber))
          {
            foreach (var Name in ModelIhiRequestCollection.HumanNameList)
            {
              if (Name.Given != null || Name.Given.Count() == 0)
              {
                if (Name.Given.Count() == 1)
                {
                  //IHI Number Try only given name 
                  IhiRequestData IhiRequestData1 = new IhiRequestData();
                  SetRequestDataFromModel(IdentiferType.IHI, ModelIhiRequestCollection, IhiRequestData1);
                  IhiRequestData1.Family = Name.Family;
                  IhiRequestData1.Given = Name.Given.ElementAt(0);
                  FirstQuerySetIhiRequestDataList.Add(IhiRequestData1);
                }
                else
                {
                  foreach (var Given in Name.Given)
                  {
                    //IHI Number Try each given name 
                    IhiRequestData IhiRequestData2 = new IhiRequestData();
                    SetRequestDataFromModel(IdentiferType.IHI, ModelIhiRequestCollection, IhiRequestData2);
                    IhiRequestData2.Family = Name.Family;
                    IhiRequestData2.Given = Given; ;
                    SecondQuerySetIhiRequestDataList.Add(IhiRequestData2);
                  }
                  //IHI Number Concatenate all given names into one given name with spaces 'Angus Brian'
                  IhiRequestData IhiRequestData3 = new IhiRequestData();
                  SetRequestDataFromModel(IdentiferType.IHI, ModelIhiRequestCollection, IhiRequestData3);
                  IhiRequestData3.Family = Name.Family;
                  IhiRequestData3.Given = Name.Given.Aggregate((current, next) => current + " " + next);
                  ThirdQuerySetIhiRequestDataList.Add(IhiRequestData3);
                }
              }
              else
              {
                //IHI Number Try with no given name 
                IhiRequestData IhiRequestData1 = new IhiRequestData();
                SetRequestDataFromModel(IdentiferType.IHI, ModelIhiRequestCollection, IhiRequestData1);
                IhiRequestData1.Family = Name.Family;
                IhiRequestData1.Given = Name.Given.ElementAt(0);
                FirstQuerySetIhiRequestDataList.Add(IhiRequestData1);
              }
            }
          }

          if (!String.IsNullOrWhiteSpace(ModelIhiRequestCollection.MedicareNumber))
          {
            foreach (var Name in ModelIhiRequestCollection.HumanNameList)
            {
              if (Name.Given != null || Name.Given.Count() == 0)
              {
                if (Name.Given.Count() == 1)
                {
                  if (!String.IsNullOrWhiteSpace(ModelIhiRequestCollection.MedicareIRN))
                  {
                    //Medicare Try only name with IRN
                    IhiRequestData IhiRequestData1 = new IhiRequestData();
                    SetRequestDataFromModel(IdentiferType.Medicare, ModelIhiRequestCollection, IhiRequestData1);
                    IhiRequestData1.Family = Name.Family;
                    IhiRequestData1.Given = Name.Given.ElementAt(0);
                    FirstQuerySetIhiRequestDataList.Add(IhiRequestData1);
                  }

                  //Medicare Try only name without IRN
                  IhiRequestData IhiRequestData11 = new IhiRequestData();
                  SetRequestDataFromModel(IdentiferType.Medicare, ModelIhiRequestCollection, IhiRequestData11);
                  IhiRequestData11.Family = Name.Family;
                  IhiRequestData11.Given = Name.Given.ElementAt(0);
                  SecondQuerySetIhiRequestDataList.Add(IhiRequestData11);
                }
                else
                {
                  foreach (var Given in Name.Given)
                  {
                    if (!String.IsNullOrWhiteSpace(ModelIhiRequestCollection.MedicareIRN))
                    {
                      //Try each name alone with IRN
                      IhiRequestData IhiRequestData2 = new IhiRequestData();
                      SetRequestDataFromModel(IdentiferType.Medicare, ModelIhiRequestCollection, IhiRequestData2);
                      IhiRequestData2.Family = Name.Family;
                      IhiRequestData2.Given = Given; ;
                      FirstQuerySetIhiRequestDataList.Add(IhiRequestData2);
                    }
                    //Try each name alone without IRN
                    IhiRequestData IhiRequestData1 = new IhiRequestData();
                    SetRequestDataFromModel(IdentiferType.Medicare, ModelIhiRequestCollection, IhiRequestData1);
                    IhiRequestData1.Family = Name.Family;
                    IhiRequestData1.Given = Name.Given.ElementAt(0);
                    SecondQuerySetIhiRequestDataList.Add(IhiRequestData1);
                  }
                  if (!String.IsNullOrWhiteSpace(ModelIhiRequestCollection.MedicareIRN))
                  {
                    //Medicare Concatenate all given names into one given name with spaces 'Angus Brian' with IRN
                    IhiRequestData IhiRequestData3 = new IhiRequestData();
                    SetRequestDataFromModel(IdentiferType.Medicare, ModelIhiRequestCollection, IhiRequestData3);
                    IhiRequestData3.Family = Name.Family;
                    IhiRequestData3.Given = Name.Given.Aggregate((current, next) => current + " " + next);
                    ThirdQuerySetIhiRequestDataList.Add(IhiRequestData3);
                  }

                  //Medicare Concatenate all given names into one given name with spaces 'Angus Brian' without IRN
                  IhiRequestData IhiRequestData4 = new IhiRequestData();
                  SetRequestDataFromModel(IdentiferType.Medicare, ModelIhiRequestCollection, IhiRequestData4);
                  IhiRequestData4.Family = Name.Family;
                  IhiRequestData4.Given = Name.Given.Aggregate((current, next) => current + " " + next);
                  ThirdQuerySetIhiRequestDataList.Add(IhiRequestData4);
                }
              }
              else
              {
                //Medicare Try no given name with IRN
                if (!String.IsNullOrWhiteSpace(ModelIhiRequestCollection.MedicareIRN))
                {
                  //Medicare Try each name alone with IRN
                  IhiRequestData IhiRequestData2 = new IhiRequestData();
                  SetRequestDataFromModel(IdentiferType.Medicare, ModelIhiRequestCollection, IhiRequestData2);
                  IhiRequestData2.Family = Name.Family;
                  //IhiRequestData2.Given = Given; ;
                  FirstQuerySetIhiRequestDataList.Add(IhiRequestData2);
                }

                //Medicare Try no given anme with IRN
                IhiRequestData IhiRequestData1 = new IhiRequestData();
                SetRequestDataFromModel(IdentiferType.Medicare, ModelIhiRequestCollection, IhiRequestData1);
                IhiRequestData1.Family = Name.Family;
                //IhiRequestData1.Given = Name.Given.ElementAt(0);
                FirstQuerySetIhiRequestDataList.Add(IhiRequestData1);
              }
            }
          }

          if (!String.IsNullOrWhiteSpace(ModelIhiRequestCollection.DVANumber))
          {
            foreach (var Name in ModelIhiRequestCollection.HumanNameList)
            {
              if (Name.Given != null || Name.Given.Count() == 0)
              {
                if (Name.Given.Count() == 1)
                {
                  //DVA Try only given name 
                  IhiRequestData IhiRequestData1 = new IhiRequestData();
                  SetRequestDataFromModel(IdentiferType.DVA, ModelIhiRequestCollection, IhiRequestData1);
                  IhiRequestData1.Family = Name.Family;
                  IhiRequestData1.Given = Name.Given.ElementAt(0);
                  FirstQuerySetIhiRequestDataList.Add(IhiRequestData1);
                }
                else
                {
                  foreach (var Given in Name.Given)
                  {
                    //DVA Try each given name 
                    IhiRequestData IhiRequestData2 = new IhiRequestData();
                    SetRequestDataFromModel(IdentiferType.DVA, ModelIhiRequestCollection, IhiRequestData2);
                    IhiRequestData2.Family = Name.Family;
                    IhiRequestData2.Given = Given; ;
                    FirstQuerySetIhiRequestDataList.Add(IhiRequestData2);
                  }
                  //DVA Concatenate all given names into one given name with spaces 'Angus Brian'
                  IhiRequestData IhiRequestData3 = new IhiRequestData();
                  SetRequestDataFromModel(IdentiferType.DVA, ModelIhiRequestCollection, IhiRequestData3);
                  IhiRequestData3.Family = Name.Family;
                  IhiRequestData3.Given = Name.Given.Aggregate((current, next) => current + " " + next);
                  SecondQuerySetIhiRequestDataList.Add(IhiRequestData3);
                }
              }
              else
              {
                //DVA Try with no given name 
                IhiRequestData IhiRequestData1 = new IhiRequestData();
                SetRequestDataFromModel(IdentiferType.DVA, ModelIhiRequestCollection, IhiRequestData1);
                IhiRequestData1.Family = Name.Family;
                //IhiRequestData1.Given = Name.Given.ElementAt(0);
                FirstQuerySetIhiRequestDataList.Add(IhiRequestData1);
              }
            }
          }

          IhiRequestDataList.AddRange(FirstQuerySetIhiRequestDataList);
          IhiRequestDataList.AddRange(SecondQuerySetIhiRequestDataList);
          IhiRequestDataList.AddRange(ThirdQuerySetIhiRequestDataList);
          return true;
        }
      }
      else
      {
        return false;
      }




      ////The User Id , does not need to be registered with Medicare
      //IhiRequestData.UserId = "BobSmith";
      ////The User Id Qualifier, does not need to be registered with Medicare
      //IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      ////If True the Soap Request and Response XML data will be returned for each call
      ////A conformant Hi Service system must keep an audit trail of this data for 7 years
      //IhiRequestData.ReturnSoapRequestAndResponseData = true;

      //IhiRequestData.Dob = new DateTime(1982, 01, 24);
      ////IhiRequestDemographics.DVANumber = "";
      //IhiRequestData.Family = "MARCELLE";
      //IhiRequestData.Given = "JUANITA";
      ////IhiRequestDemographics.IHINumber = "1234567890123456";
      ////IhiRequestDemographics.MedicareIRN = "1";
      //IhiRequestData.MedicareNumber = "2950156481";
      //IhiRequestData.SexChar = 'F';
    }

    private void SetRequestDataFromModel(IdentiferType identiferType, IhiRequestDataCollection IhiRequestDataCollection, IhiRequestData IhiRequestData)
    {
      switch (identiferType)
      {
        case IdentiferType.IHI:
          {
            IhiRequestData.IHINumber = IhiRequestDataCollection.IHINumber;
          }
          break;
        case IdentiferType.Medicare:
          {
            IhiRequestData.MedicareNumber = IhiRequestDataCollection.MedicareNumber;
            IhiRequestData.MedicareIRN = IhiRequestDataCollection.MedicareIRN;
          }
          break;
        case IdentiferType.DVA:
          {
            IhiRequestData.DVANumber = IhiRequestDataCollection.DVANumber;
          }
          break;
        default:
          break;
      }

      IhiRequestData.UserId = IhiRequestDataCollection.UserId;
      IhiRequestData.UserIdQualifier = IhiRequestDataCollection.UserIdQualifier;
      IhiRequestData.SexChar = IhiRequestDataCollection.SexChar;
      IhiRequestData.Dob = IhiRequestDataCollection.Dob;
      IhiRequestData.ReturnSoapRequestAndResponseData = IhiRequestDataCollection.ReturnSoapRequestAndResponseData;
      //IhiRequestData1.Family = Name.Family;
      //IhiRequestData1.Given = Name.Given.ElementAt(0);
    }

    private bool ParseRequestPatientResource(Parameters ParametersResource, IhiRequestDataCollection ModelIhiRequestCollection)
    {
      const string UserIdParameter = "UserId";
      const string UserIdQualifierParameter = "UserIdQualifier";
      const string ReturnSoapRequestAndResponseParameter = "ReturnSoapRequestAndResponseData";
      const string RequestPatientParameter = "RequestPatient";

      var UserId = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, UserIdParameter, StringComparison.CurrentCultureIgnoreCase));
      var UserIdQualifier = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, UserIdQualifierParameter, StringComparison.CurrentCultureIgnoreCase));
      var ReturnSoapRequestAndResponse = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, ReturnSoapRequestAndResponseParameter, StringComparison.CurrentCultureIgnoreCase));
      var RequestPatient = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, RequestPatientParameter, StringComparison.CurrentCultureIgnoreCase));
      List<HumanName> HumanNameList = new List<HumanName>();

      if (UserId != null && UserId.Value is FhirString UserIdValue)
      {
        ModelIhiRequestCollection.UserId = UserIdValue.Value;
      }
      else
      {
        IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"Must supply a parameter of name: {UserIdParameter} with a value of type valueString."));
      }

      if (UserIdQualifier != null && UserIdQualifier.Value is FhirUri UserIdQualifierValue)
      {
        ModelIhiRequestCollection.UserIdQualifier = UserIdQualifierValue.Value;
      }
      else
      {
        IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"Must supply a parameter of name: {UserIdQualifierParameter} with a value of type valueUri."));
      }

      if (ReturnSoapRequestAndResponse != null && ReturnSoapRequestAndResponse.Value is FhirBoolean ReturnSoapRequestAndResponseValue)
      {
        ModelIhiRequestCollection.ReturnSoapRequestAndResponseData = ReturnSoapRequestAndResponseValue.Value.Value;
      }
      else
      {
        IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"Must supply a parameter of name: {ReturnSoapRequestAndResponseParameter} with a value of type valueBoolean."));
      }

      if (RequestPatient != null && RequestPatient.Resource is Patient RequestPatientResource)
      {
        //HumanName
        if (RequestPatientResource.Name != null)
        {
          foreach (var Name in RequestPatientResource.Name)
          {
            ModelIhiRequestCollection.HumanNameList = RequestPatientResource.Name;
          }
        }
        else
        {
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource must only have a single name element not many, found {RequestPatientResource.Name.Count.ToString()} name elements."));
        }

        //Dob
        if (RequestPatientResource.BirthDateElement != null)
        {
          DateTime TempDateTime;
          if (DateTime.TryParse(RequestPatientResource.BirthDateElement.Value, out TempDateTime))
          {
            ModelIhiRequestCollection.Dob = TempDateTime.Date;
          }
          else
          {
            IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource DateofBirth element was not able to be parsed to a Date. Date of Birth is mandatory for the HI Service IHI call"));
          }
        }
        else
        {
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource must have a DateofBirth element not. Date of Birth is mandatory for the HI Service IHI call"));
        }

        //Sex
        if (RequestPatientResource.Gender.HasValue)
        {
          ModelIhiRequestCollection.SexChar = AdministrativeGenderToSexChar(RequestPatientResource.Gender.Value);
        }
        else
        {
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource must have a AdministrativeGender (Sex) of (Male, Female, Other or Unknown). This is mapped to the Hi Service sex concept as follows: Male:Male, Female:Female, Other:Intersex or Indeterminate and Unknown:Not stated/inadequately described. Sex is mandatory for the HI Service IHI call"));
        }

        //Identifier
        if (RequestPatientResource.Identifier != null)
        {
          Identifier MedicareNumberElement = RequestPatientResource.Identifier.SingleOrDefault(x => String.Equals(x.System, MedicareNumberFhirSystem, StringComparison.CurrentCultureIgnoreCase));
          Identifier DVANumberElement = RequestPatientResource.Identifier.SingleOrDefault(x => String.Equals(x.System, DVANumberFhirSystem, StringComparison.CurrentCultureIgnoreCase));
          Identifier IHINumberElement = RequestPatientResource.Identifier.SingleOrDefault(x => String.Equals(x.System, IHINumberFhirSystem, StringComparison.CurrentCultureIgnoreCase));

          if (MedicareNumberElement == null && DVANumberElement == null && IHINumberElement == null)
          {
            IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource contains no Medicare Number, DVA Number or IHI Number, the Hi Service IHI search requires one and only one of these identifers."));
          }
          else if (MedicareNumberElement != null)
          {
            //Medicare
            string WholeMedicareNumber = StringSupport.RemoveWhitespace(MedicareNumberElement.Value);
            if (WholeMedicareNumber.Count() == 10)
              ModelIhiRequestCollection.MedicareNumber = MedicareNumberElement.Value;
            else if (WholeMedicareNumber.Count() == 11)
            {
              ModelIhiRequestCollection.MedicareNumber = WholeMedicareNumber.Substring(0, 10);
              ModelIhiRequestCollection.MedicareIRN = WholeMedicareNumber.Substring(10, 1);
            }
            else
            {
              IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource contains a Medicare Number yet it's length is not correct. The Medicare number must be either 10-digits long or 11-digits long where the 11th digit is the Medicare IRN number. Found length of {WholeMedicareNumber.Count().ToString()}"));
            }
          }
          else if (DVANumberElement != null)
          {
            //DVA Number
            string WholeDVANumber = StringSupport.RemoveWhitespace(DVANumberElement.Value);
            //dvaFileNumber (Page 21 of tech-sis-hi-06-ihi-inquiry-search-via-b2b-v10-0.pdf)
            //xsd:token Min length: 2Max length: 9
            if (WholeDVANumber.Count() > 1 || WholeDVANumber.Count() < 10)
            {
              ModelIhiRequestCollection.DVANumber = WholeDVANumber;
            }
            else
            {
              IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource contains a DVA Number yet it's length is not correct. The DVA number must be betweeen 2 and 9 charaters long for the Hi Service call. Found length of {WholeDVANumber.Count().ToString()}"));
            }
          }
          else if (IHINumberElement != null)
          {
            //IHI Number
            string WholeIHINumber = StringSupport.RemoveWhitespace(IHINumberElement.Value);
            if (WholeIHINumber.Count() == 16)
            {
              ModelIhiRequestCollection.DVANumber = WholeIHINumber;
            }
            else
            {
              IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource contains a IHI Number yet it's length is not correct. The IHI number must be 16 digits long for the Hi Service call. Found length of {WholeIHINumber.Count().ToString()}"));
            }

          }
        }
        else
        {
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"The supplied {ResourceType.Patient.GetLiteral()} resource contains no identifiers. A single identifier of either a Medicare Number, DVA Number or IHI Number is required for the Hi Service IHI search."));
        }

      }
      else
      {
        IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required, $"Must supply a parameter of name: {RequestPatientParameter} with a value of type resource containing a {ResourceType.Patient.GetLiteral()} resource."));
      }

      return (IssueList.Count() == 0);
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
