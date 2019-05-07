using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Tools;
using Pyro.Common.ADHA.Api;
using Pyro.ADHA.Api;
using Pyro.Common.Global;
using HealthIdentifiers.Identifiers.Australian.MedicareNumber;
using HealthIdentifiers.Identifiers.Australian.DepartmentVeteransAffairs;
using HealthIdentifiers.Identifiers.Australian.NationalHealthcareIdentifier;
using HealthIdentifiers.Identifiers.Support.StandardsInformation.Australian;
using System.Text;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Enum;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.PyroHealthFhirResource;

namespace Pyro.Common.FhirOperation.IhiSearch
{
  public class IHISearchOrValidateOperation : IIHISearchOrValidateOperation
  {
    List<OperationOutcome.IssueComponent> IssueList = null;
    IResourceServiceOutcome ResourceServiceOutcome;
    
    const string DVANumberFhirSystem = "http://ns.electronichealth.net.au/id/dva";   
    
    private enum IdentiferType { IHI, Medicare, DVA }
    private bool ReturnSoapBinaryResourcesToFHIRCaller = false;
    private TimeSpan HiServiceCallTime;

    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly IResourceServices IResourceServices;
    private readonly IGlobalProperties GlobalProperties;
    private readonly IHiServiceApi HiServiceApi;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IMedicareNumberParser IMedicareNumberParser;
    private readonly IIndividualHealthcareIdentifierParser IIndividualHealthcareIdentifierParser;
    private readonly IDVANumberParser IDVANumberParser;
    private readonly INationalHealthcareIdentifierInfo INationalHealthcareIdentifierInfo;
    private readonly IMedicareNumberInfo IMedicareNumberInfo;
    private readonly Common.PyroHealthFhirResource.CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;
    private readonly Common.PyroHealthFhirResource.Devices.IPyroFhirServer IPyroFhirServerDevice;
    private readonly Common.PyroHealthFhirResource.Organizations.IPyroHealth IPyroHealth;

    public IHISearchOrValidateOperation(
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      IResourceServices IResourceServices,
      IGlobalProperties GlobalProperties,
      IHiServiceApi IHiServiceApi,
      IRequestMetaFactory IRequestMetaFactory,
      IMedicareNumberParser IMedicareNumberParser,
      IIndividualHealthcareIdentifierParser IIndividualHealthcareIdentifierParser,
      IDVANumberParser IDVANumberParser,
      INationalHealthcareIdentifierInfo INationalHealthcareIdentifierInfo,
      IMedicareNumberInfo IMedicareNumberInfo,
      Common.PyroHealthFhirResource.CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem,
      Common.PyroHealthFhirResource.Devices.IPyroFhirServer IPyroFhirServerDevice,
      Common.PyroHealthFhirResource.Organizations.IPyroHealth IPyroHealth)
    {
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IResourceServices = IResourceServices;
      this.GlobalProperties = GlobalProperties;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IMedicareNumberParser = IMedicareNumberParser;
      this.IDVANumberParser = IDVANumberParser;
      this.IIndividualHealthcareIdentifierParser = IIndividualHealthcareIdentifierParser;
      this.HiServiceApi = IHiServiceApi;
      this.INationalHealthcareIdentifierInfo = INationalHealthcareIdentifierInfo;
      this.IMedicareNumberInfo = IMedicareNumberInfo;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
      this.IPyroHealth = IPyroHealth;
      this.IPyroFhirServerDevice = IPyroFhirServerDevice;

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
      if (RequestMeta.PyroRequestUri == null)
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

        System.Diagnostics.Stopwatch stopWatchHiServiceCall = new System.Diagnostics.Stopwatch();
        

        // Make Hi Service Calls
        foreach (IhiRequestData IhiRequestData in IhiRequestDataList)
        {
          IsHIServiceFoundIHI = false;
          IsHIServiceError = false;
          stopWatchHiServiceCall.Reset();
          stopWatchHiServiceCall.Start();
          HiServiceOutCome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);          
          stopWatchHiServiceCall.Stop();
          //Did a HI Error error occur?
          IsHIServiceError = !HiServiceOutCome.SuccessfulQuery;
          //Did we get an IHI Idneifier?
          IsHIServiceFoundIHI = !String.IsNullOrWhiteSpace(HiServiceOutCome.ResponseData.IHINumber);
          if (IsHIServiceFoundIHI || IsHIServiceError)
            break;
        }
        HiServiceCallTime = stopWatchHiServiceCall.Elapsed;
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

          //Commit an AuditEvent FHIR resource for HI Service Auditing
          IResourceServiceOutcome ResourceServiceOutcomeAuditEvent = CommitAuditResourceForHiServiceCall(HiServiceOutCome, HiServiceOutCome.SuccessfulQuery);
                    
          //log all the soap requests, HI Conformance states all errors must be logged
          Parameters ResponseParametersResource = GenerateReturnParametersResource(RequestParameters, HiServiceOutCome, ResourceServiceOutcomeAuditEvent);

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

    private IResourceServiceOutcome CommitAuditResourceForHiServiceCall(IIhiSearchValidateOutcome HiServiceOutCome, bool SuccessfulQuery)
    {     
      var AuditCode = IPyroFhirServerCodeSystem.GetCoding(PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes.HiServiceCallAudit);      
      var Audit = new AuditEvent();
      Audit.Type = AuditCode;
      Audit.Action = AuditEvent.AuditEventAction.E;
      Audit.Recorded = DateTimeOffset.Now;
      if (SuccessfulQuery)
      {
        Audit.Outcome = AuditEvent.AuditEventOutcome.N0;
      }
      else
      {
        Audit.Outcome = AuditEvent.AuditEventOutcome.N4;
      }

      if (!string.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.ErrorMessge))
      {
        Audit.OutcomeDesc = $"{HiServiceOutCome.QueryMetadata.ErrorMessge}";
      }
      else if (HiServiceOutCome.QueryMetadata.ServiceMessage.Count > 0)
      {
        StringBuilder sb = new StringBuilder();
        HiServiceOutCome.QueryMetadata.ServiceMessage.ForEach(x => sb.AppendLine($"Code: {x.Code}, Reason: {x.Reason}, SeverityType: {x.SeverityType.ToString()} "));
        Audit.OutcomeDesc = sb.ToString();
      }

      Audit.PurposeOfEvent = new List<CodeableConcept>()
      {
        new CodeableConcept()
        {
           Coding = new List<Coding>()
           {
              new Coding()
              {
                 Code = "RECORDMGT",
                  Display = "records management",
                  System = "http://hl7.org/fhir/v3/ActReason"

              },
              new Coding()
              {
                 Code = "PATADMIN",
                 Display = "patient administration",
                 System = "http://hl7.org/fhir/v3/ActReason"
              },
              new Coding()
              {
                Code = "HSYSADMIN",
                Display = "health system administration",
                System = "http://hl7.org/fhir/v3/ActReason"
              }
           }
        }
      };

      //User Agent (user making request)
      Audit.Agent = new List<AuditEvent.AgentComponent>();
      var AgentRequestUser = new AuditEvent.AgentComponent();
      Audit.Agent.Add(AgentRequestUser);
      AgentRequestUser.Role = new List<CodeableConcept>()
      {
         new CodeableConcept()
         {
           Coding = new List<Coding>()
           {
             new Coding()
             {
                Code ="110152",
                Display="Destination Role ID",
                System="http://dicom.nema.org/resources/ontology/DCM"
             }
           }
         }
      };

      //AgentRequestUser.UserId = new Identifier()
      //{
      //  Value = HiServiceOutCome.RequestData.UserId,
      //  System = HiServiceOutCome.RequestData.UserIdQualifier
      //};
      AgentRequestUser.Name = HiServiceOutCome.RequestData.UserId;
      AgentRequestUser.Requestor = true;

      //System Agent (PyroServer)
      var AgentSystemPyroServer = new AuditEvent.AgentComponent();
      Audit.Agent.Add(AgentSystemPyroServer);
      AgentSystemPyroServer.Role = new List<CodeableConcept>()
      {
         new CodeableConcept()
         {
           Coding = new List<Coding>()
           {
             new Coding()
             {
                Code ="110150",
                Display="Application",
                System ="http://dicom.nema.org/resources/ontology/DCM"
             }
           }
         }
      };

     
      if (string.IsNullOrWhiteSpace(GlobalProperties.ThisServersManagingOrganizationResource))
      {
        AgentSystemPyroServer.Who = new ResourceReference($"{ResourceType.Organization.GetLiteral()}/{IPyroHealth.GetResourceId()}");
      }
      else
      {
        AgentSystemPyroServer.Who = new ResourceReference($"{ResourceType.Organization.GetLiteral()}/{GlobalProperties.ThisServersManagingOrganizationResource}");
      }
      
      AgentSystemPyroServer.Name = "The intermediate system recorded as performing the request to the HI Service";
      AgentSystemPyroServer.Requestor = false;
      AgentSystemPyroServer.Network = new AuditEvent.NetworkComponent()
      {
        Address = GlobalProperties.ServiceBaseURL,
        Type = AuditEvent.AuditEventAgentNetworkType.N5
      };


      //System Agent (HI Service) 
      var AgentSystemHiService = new AuditEvent.AgentComponent();
      Audit.Agent.Add(AgentSystemHiService);
      AgentSystemHiService.Role = new List<CodeableConcept>()
      {
         new CodeableConcept()
         {
           Coding = new List<Coding>()
           {
             new Coding()
             {
                Code ="CN",
                Display="national",
                System = "http://hl7.org/fhir/v3/RoleCode"

             },
             new Coding()
             {
                Code ="110150",
                Display="Application",
                System ="http://dicom.nema.org/resources/ontology/DCM"
             }
           }
         }
      };
      AgentSystemHiService.AltId = "HiService";      
      AgentSystemHiService.Name = "The Australian National Health Identifer service (HI Service) source of identifier truth.";
      AgentSystemHiService.Requestor = false;
      AgentSystemHiService.Network = new AuditEvent.NetworkComponent()
      {
        Address = GlobalProperties.HIServiceEndpoint,
        Type = AuditEvent.AuditEventAgentNetworkType.N5
      };

      Audit.Source = new AuditEvent.SourceComponent()
      {
        Observer = new ResourceReference($"{ResourceType.Device}/{IPyroFhirServerDevice.GetResourceId()}"),        
        Type = new List<Coding>()
        {
          new Coding()
          {
             Code = "4",
             Display = "Application Server",
             System = "http://hl7.org/fhir/security-source-type"
          }
        }
      };

      Audit.Entity = new List<AuditEvent.EntityComponent>();
      
      //Request
      if (!string.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapRequestMessageId) && !string.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapRequest))
      {
        var EntityHiServiceRequest = new AuditEvent.EntityComponent();
        Audit.Entity.Add(EntityHiServiceRequest);
        //EntityHiServiceRequest.Identifier = new Identifier()
        //{
        //  Value = "http://ns.electronichealth.net.au/hi/svc/EsbPing/3.0/EsbPingPortType/esbPingRequest",
        //  System = HiServiceOutCome.QueryMetadata.SoapRequestMessageId,
        //};
        EntityHiServiceRequest.Type = new Coding()
        {
          Code = "2",
          Display = "System Object",
          System = "http://hl7.org/fhir/audit-entity-type"
        };
        EntityHiServiceRequest.Role = new Coding()
        {
          Code = "24",
          Display = "Query",
          System = "http://hl7.org/fhir/object-role"
        };
        EntityHiServiceRequest.SecurityLabel = new List<Coding>()
        {
          new Coding()
          {
             Code = "AUDIT",
             Display = "audit",
             System = "http://hl7.org/fhir/v3/ActCode"
          }
        };
        //FHIR Specification Rule says either 'Name' or 'Query' but not both, so we are using 'Query'.
        //EntityHiServiceRequest.Name = "Hi Service IHI Search SOAP Request";
        EntityHiServiceRequest.Description = "HI Service IHI search or validate request SOAP data, base64 encoded, for the request being audited";
        string MedicareNumberAndIRN = (HiServiceOutCome?.RequestData?.MedicareNumber == null ? string.Empty : HiServiceOutCome.RequestData.MedicareNumber) + (HiServiceOutCome?.RequestData?.MedicareIRN == null ? string.Empty : HiServiceOutCome.RequestData.MedicareIRN);
        string QueryString = $"Family: {((HiServiceOutCome?.RequestData?.Family == null) ? string.Empty : HiServiceOutCome.RequestData.Family)}, Given: {((HiServiceOutCome?.RequestData?.Given == null) ? string.Empty : HiServiceOutCome.RequestData.Given)}, Gender: {((HiServiceOutCome?.RequestData?.SexChar == null) ? string.Empty : HiServiceOutCome.RequestData.SexChar.ToString())}, Dob: {((HiServiceOutCome?.RequestData?.Dob == null) ? string.Empty : HiServiceOutCome.RequestData.Dob.Value.ToString("DD/MM/YYYY"))}, Medicare: {MedicareNumberAndIRN}, DVA: {(HiServiceOutCome?.RequestData?.DVANumber == null ? string.Empty : HiServiceOutCome?.RequestData?.DVANumber)}, IHI: {(HiServiceOutCome?.RequestData?.IHINumber == null ? string.Empty : HiServiceOutCome?.RequestData?.IHINumber)}";
        EntityHiServiceRequest.Query = System.Text.Encoding.Unicode.GetBytes(QueryString);
        EntityHiServiceRequest.Detail = new List<AuditEvent.DetailComponent>()
        {
          new AuditEvent.DetailComponent()
          {
             Type = "Request SOAP",
             Value = new Base64Binary() { Value = System.Text.Encoding.UTF8.GetBytes(HiServiceOutCome.QueryMetadata.SoapRequest) }
           }
        };
      }

      //Response
      if (!string.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapResponseMessageId) && !string.IsNullOrWhiteSpace(HiServiceOutCome.QueryMetadata.SoapResponse))
      {
        var EntityHiServiceResponse = new AuditEvent.EntityComponent();
        Audit.Entity.Add(EntityHiServiceResponse);
        //EntityHiServiceResponse.Identifier = new Identifier()
        //{
        //  Value = "http://ns.electronichealth.net.au/hi/svc/EsbPing/3.0/EsbPingPortType/esbPingResponse",
        //  System = HiServiceOutCome.QueryMetadata.SoapRequestMessageId,
        //};
        EntityHiServiceResponse.Type = new Coding()
        {
          Code = "2",
          Display = "System Object",
          System = "http://hl7.org/fhir/audit-entity-type"
        };
        EntityHiServiceResponse.Role = new Coding()
        {
          Code = "4",
          Display = "Domain Resource",
          System = "http://hl7.org/fhir/object-role"
        };
        EntityHiServiceResponse.SecurityLabel = new List<Coding>()
        {
          new Coding()
          {
             Code = "AUDIT",
             Display = "audit",
             System = "http://hl7.org/fhir/v3/ActCode"
          }
        };
        EntityHiServiceResponse.Name = "Hi Service IHI Search or validate SOAP Response data";
        EntityHiServiceResponse.Description = "HI Service IHI search or validate response SOAP data, base64 encoded, for the request being audited";        
        EntityHiServiceResponse.Detail = new List<AuditEvent.DetailComponent>()
        {
          new AuditEvent.DetailComponent()
          {
             Type = "Response SOAP",
             Value = new Base64Binary() { Value = System.Text.Encoding.UTF8.GetBytes(HiServiceOutCome.QueryMetadata.SoapResponse) }
           }
        };
      }

      IResourceServiceOutcome AuditEventSoapBinaryAuditEvent;
      string AuditEventResourceId = Pyro.Common.Tools.FhirGuid.FhirGuid.NewFhirGuid();
      IRequestMeta RequestMetaPut = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.AuditEvent.GetLiteral()}/{AuditEventResourceId}");
      Audit.Id = AuditEventResourceId;
      AuditEventSoapBinaryAuditEvent = IResourceServices.Put(AuditEventResourceId, Audit, RequestMetaPut);
      if (!AuditEventSoapBinaryAuditEvent.SuccessfulTransaction)
      {
        string Message = $"Internal Server error in trying to commit a AuditEvent resource to log a HI Service call";
        var OptOut = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported, Message);
        throw new Exceptions.PyroException(System.Net.HttpStatusCode.InternalServerError, OptOut, Message);
      }
      return AuditEventSoapBinaryAuditEvent;
    }


    private Parameters GenerateReturnParametersResource(
      Parameters RequestParameters, IIhiSearchValidateOutcome IhiServiceOutCome,
      IResourceServiceOutcome ResourceServiceOutcomeAuditEvent)
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

        foreach (var ServiceMessage in IhiServiceOutCome.QueryMetadata.ServiceMessage)
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
            ReasonParameter.Name = "SeverityType";
            ReasonParameter.Value = new Code() { Value = ServiceMessage.SeverityType };
            HiServiceMessageParameter.Part.Add(ReasonParameter);
          }
        }
      }

      var HiServiceCallAuditParameter = new Parameters.ParameterComponent();
      HiServiceCallAuditParameter.Name = "HiServiceCallAudit";
      HiServiceCallAuditParameter.Part = new List<Parameters.ParameterComponent>();
      HiServiceResponseParameter.Part.Add(HiServiceCallAuditParameter);

      if (ResourceServiceOutcomeAuditEvent != null && ResourceServiceOutcomeAuditEvent.SuccessfulTransaction)
      {
        var RequestAuditEventResourceReferenceParameter = new Parameters.ParameterComponent();
        HiServiceCallAuditParameter.Part.Add(RequestAuditEventResourceReferenceParameter);
        RequestAuditEventResourceReferenceParameter.Name = "AuditEventReference";
        RequestAuditEventResourceReferenceParameter.Value = new FhirUri($"{ResourceServiceOutcomeAuditEvent.ResourceResult.TypeName}/{ResourceServiceOutcomeAuditEvent.FhirResourceId}");
        
        if (ReturnSoapBinaryResourcesToFHIRCaller)
        {
          if (HiServiceCallTime != null)
          {
            var HiServiceRequestTimer = new Parameters.ParameterComponent();
            HiServiceCallAuditParameter.Part.Add(HiServiceRequestTimer);
            HiServiceRequestTimer.Name = "HiServiceCallTimeMilliseconds";
            HiServiceRequestTimer.Value = new Hl7.Fhir.Model.FhirDecimal(System.Decimal.Round(Convert.ToDecimal(HiServiceCallTime.TotalMilliseconds)));
          }

          var RequestAuitEventResourceParameter = new Parameters.ParameterComponent();
          HiServiceCallAuditParameter.Part.Add(RequestAuitEventResourceParameter);
          RequestAuitEventResourceParameter.Name = "AuditEventResource";
          //RequestSoapBinaryResourceParameter.Value = new FhirUri($"{ResourceServiceOutcomeSoapRequestBinary.ResourceResult.TypeName}/{ResourceServiceOutcomeSoapRequestBinary.FhirResourceId}");
          RequestAuitEventResourceParameter.Resource = ResourceServiceOutcomeAuditEvent.ResourceResult;
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
      const string ReturnAuditEventParameter = "ReturnAuditEvent";
      var ReturnSoapRequestAndResponse = ParametersResource.Parameter.SingleOrDefault(x => String.Equals(x.Name, ReturnAuditEventParameter, StringComparison.CurrentCultureIgnoreCase));
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
        MedicareList = GetValidByDateIdentifierList(PatientRequest.Identifier, IMedicareNumberInfo.FhirSystemUri, NowDate);
        DVAByList = GetValidByDateIdentifierList(PatientRequest.Identifier, DVANumberFhirSystem, NowDate);
        //Get IHI regardless of period as they will mostlikley be unvalid by period because we are trying to revalidate them
        IHIList = GetValidByDateIdentifierList(PatientRequest.Identifier, INationalHealthcareIdentifierInfo.IHIValueFhirSystem, null);

        //Check we have at least one identifer
        if (IHIList.Count() + MedicareList.Count() + DVAByList.Count() == 0)
        {
          //No suitable Identifers 
          IssueList.Add(FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Required,
            $"The supplied {ResourceType.Patient.GetLiteral()} resource must have a least one identifier of type Medicare Number using the system '{IMedicareNumberInfo.FhirSystemUri}' or DVA Number using the system '{DVANumberFhirSystem}' or IHI using the system {INationalHealthcareIdentifierInfo.IHIValueFhirSystem}. The Medicare Number or DVA number identifier Period (start & end) must be current or not provided."));
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
        var Now = DateTimeOffset.Now;
        return TempList.Where(x =>
            x.Period == null ||
            (x.Period.Start != null && x.Period.StartElement.ToDateTimeOffset(Now.Offset).Date < Date.Value && x.Period.End == null) ||
            (x.Period.End != null && x.Period.EndElement.ToDateTimeOffset(Now.Offset).Date > Date.Value && x.Period.Start == null) ||
            (x.Period.Start != null && x.Period.StartElement.ToDateTimeOffset(Now.Offset).Date < Date.Value && x.Period.End != null && x.Period.EndElement.ToDateTimeOffset(Now.Offset).Date > Date.Value)
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
        var NowDateTime = DateTimeOffset.Now;
        return TempList.Where(x =>
            x.Period == null ||
            (x.Period.Start != null && x.Period.StartElement.ToDateTimeOffset(NowDateTime.Offset).Date < Date.Value && x.Period.End == null) ||
            (x.Period.End != null && x.Period.EndElement.ToDateTimeOffset(NowDateTime.Offset).Date > Date.Value && x.Period.Start == null) ||
            (x.Period.Start != null && x.Period.StartElement.ToDateTimeOffset(NowDateTime.Offset).Date < Date.Value && x.Period.End != null && x.Period.EndElement.ToDateTimeOffset(NowDateTime.Offset).Date > Date.Value)
          );
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
        IhiIdentifier.System = INationalHealthcareIdentifierInfo.IHIValueFhirSystem;
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
          Coding IhiStatusCoding = new Coding(INationalHealthcareIdentifierInfo.IHIStatusFhirSystem, ihiServiceOutCome.ResponseData.IHIStatus, ihiServiceOutCome.ResponseData.IHIStatus);
          IhiIdentifier.AddExtension("http://hl7.org.au/fhir/StructureDefinition/ihi-status", IhiStatusCoding, false);
        }

        //IHI Record Status
        if (!String.IsNullOrWhiteSpace(ihiServiceOutCome.ResponseData.IHIRecordStatus))
        {
          Coding IhiRecordStatusCoding = new Coding(INationalHealthcareIdentifierInfo.IHIRecordStatusFhirSystem, ihiServiceOutCome.ResponseData.IHIRecordStatus, ihiServiceOutCome.ResponseData.IHIRecordStatus);
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
        MedicareIdentifier.System = IMedicareNumberInfo.FhirSystemUri;
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
