using Pyro.Common.Interfaces.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.SearchParameters;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Tools;
using Pyro.Common.Enum;
using Hl7.Fhir.Utility;
using Pyro.Common.PyroHealthFhirResource.CodeSystems;
using Pyro.Common.ServiceRoot;

namespace Pyro.Common.FhirOperation.ProcessMessage
{
  public class ProcessMessageOperation : IProcessMessageOperation
  {
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly IPyroHL7V2MessageTypeEvent IPyroHL7V2MessageTypeEventCodeSystem;
    private MessageHeader _MessageHeader = null;
    private const string _UrnUUID = "urn:uuid";

    public ProcessMessageOperation(IResourceServices IResourceServices,
      IRequestMetaFactory IRequestMetaFactory,
      IPyroFhirUriFactory IPyroFhirUriFactory,
      IPrimaryServiceRootCache IPrimaryServiceRootCache,
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      ISearchParameterServiceFactory ISearchParameterServiceFactory,
      IPyroHL7V2MessageTypeEvent IPyroHL7V2MessageTypeEvent)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.IPyroHL7V2MessageTypeEventCodeSystem = IPyroHL7V2MessageTypeEvent;
    }

    public IResourceServiceOutcome Process(
          IPyroRequestUri RequestUri,
          ISearchParameterGeneric SearchParameterGeneric,
          Resource Resource)
    {
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");

      try
      {
        IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

        ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
        ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchParameterGeneric);
        if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
        {
          ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
          ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
          ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
          return ResourceServiceOutcome;
        }

        if (!IsValidResourceMessageBundle(Resource, out ResourceServiceOutcome))
        {
          return ResourceServiceOutcome;
        }

        if (Resource is Bundle InputBundle)
        {
          if (InputBundle.Entry[0].Resource is MessageHeader MessageHeader)
          {
            if (!IsMessageHeaderProcessable(MessageHeader, out ResourceServiceOutcome))
            {
              return ResourceServiceOutcome;
            }
            _MessageHeader = MessageHeader;
            HashSet<string> SupportedEventCodes = new HashSet<string>();
            SupportedEventCodes.Add(PyroHL7V2MessageTypeEvent.Codes.ADTA01.GetPyroLiteral());

            Coding eventCoding = (_MessageHeader.Event as Coding);
            if (eventCoding.Code.ToUpper() == PyroHL7V2MessageTypeEvent.Codes.ADTA01.GetPyroLiteral().ToUpper())
            {
              return ProcessADTA01(InputBundle);
            }
            else
            {
              string CodeList = string.Empty;
              foreach (string item in SupportedEventCodes)
              {
                CodeList = CodeList + ", " + item;
              }
              var Message = $"The {ResourceType.MessageHeader.GetLiteral()} eventCodeing code of {eventCoding.Code} is currently not supported by the " +
                $"${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation. Supported codes are ({CodeList})";
              ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
              return ResourceServiceOutcome;
            }
          }
          else
          {
            throw new InvalidCastException($"Unable to cast the received ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} {ResourceType.Bundle.GetLiteral()} resource entry one to a {ResourceType.MessageHeader.GetLiteral()} resource.");
          }
        }
        else
        {
          throw new InvalidCastException($"Unable to cast the received ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} resource to a {ResourceType.Bundle.GetLiteral()} resource.");
        }        
      }
      catch (Exception Exec)
      {
        throw new Exception("ServerResourceReport exception thrown", Exec);
      }
    }

    private IResourceServiceOutcome ProcessADTA01(Bundle inputBundle)
    {
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      AdtA01Payload Payload = null;

      if (!IsADTA01BunbdleProcessable(inputBundle, out Payload, out ResourceServiceOutcome))
      {
        return ResourceServiceOutcome;
      }

      Identifier PrimaryMrnIdentifier = null;
      if (!GetPrimaryMrnIdentifer(Payload.Patient.Identifier, out PrimaryMrnIdentifier, out ResourceServiceOutcome))
      {
        return ResourceServiceOutcome;
      }
      
      //## Process Patient Resource ##########################################
      string PatientResourceId = string.Empty;
      var RequestMetaFindPatientResource = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.Patient, $"?identifier={PrimaryMrnIdentifier.System}|{PrimaryMrnIdentifier.Value}");
      IResourceServiceOutcome PatientByIdOutcome = IResourceServices.GetSearch(RequestMetaFindPatientResource);
      if (PatientByIdOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        if (PatientByIdOutcome.ResourceResult is Bundle Resultbundle)
        {
          //## Post(Create) if not found ##########
          if (Resultbundle.Total.HasValue && Resultbundle.Total.Value == 0)
          {
            Payload.Patient.Id = null;
            var RequestMetaPostPatient = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.Patient, string.Empty);
            IResourceServiceOutcome PatientPostOutcome = IResourceServices.Post(Payload.Patient, RequestMetaPostPatient);
            if (PatientPostOutcome.HttpStatusCode == System.Net.HttpStatusCode.Created)
            {
              PatientResourceId = PatientPostOutcome.FhirResourceId;              
              return AllOkResponse();
            }
            else
            {
              if (PatientPostOutcome.ResourceResult is OperationOutcome ReturnOpOut)
              {
                var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to Post the {ResourceType.Patient.GetLiteral()} resource " +
                  $"to the server. Please read the full list of {ResourceType.OperationOutcome.GetLiteral()} resources for more info.";
                var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
                return OperationOutcomeListErrorInvalidResponse(new List<OperationOutcome>() { OpOutcome, ReturnOpOut });                
              }
              else
              {
                throw new ApplicationException($"Server error: The server POST did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 201 Created");
              }
            }
          }
          //## Put(Update) if found ###############
          else if (Resultbundle.Total.HasValue && Resultbundle.Total.Value == 1)
          {

            PatientResourceId = Resultbundle.Entry[0].Resource.Id;
            Payload.Patient.Id = PatientResourceId;
            var RequestMetaPostPatient = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.Patient, PatientResourceId);
            IResourceServiceOutcome PatientPostOutcome = IResourceServices.Put(PatientResourceId, Payload.Patient, RequestMetaPostPatient);
            if (PatientPostOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {            
              return AllOkResponse();
            }
            else
            {
              if (PatientPostOutcome.ResourceResult is OperationOutcome ReturnOpOut)
              {
                var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to Post the {ResourceType.Patient.GetLiteral()} resource " +
                  $"to the server. Please read the full issue list in this {ResourceType.OperationOutcome.GetLiteral()} resource for more info.";
                ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
                return ResourceServiceOutcome;
              }
              else
              {
                throw new ApplicationException($"Server error: The server POST did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 201 Created");
              }
            }
          }
          //## Erorr if more then one #############
          else if (Resultbundle.Total.HasValue && Resultbundle.Total.Value > 1)
          {
            var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation found duplicate {ResourceType.Patient.GetLiteral()} " +
              $"resources with the identifier: (System: '{PrimaryMrnIdentifier.System}' and Value '{PrimaryMrnIdentifier.Value}').";           
            return SimpleErrorInvalidResponse(Message);
          }
          else 
          {
            throw new ApplicationException($"Server error: The server search result for patient has no Bundle.Total property.");
          }          
        }
        else
        {
          throw new ApplicationException($"Server error: The server search result for patient has no Bundle.Total property.");
        }        
      }
      else
      {
        if (PatientByIdOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to perfomed a Search for the {ResourceType.Patient.GetLiteral()} resource " +
            $"in the server. Please read the full list of {ResourceType.OperationOutcome.GetLiteral()} resources for more info.";
          var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);          
          return OperationOutcomeListErrorInvalidResponse(new List<OperationOutcome>() { OpOutcome, ReturnOpOut });         
        }
        else
        {
          throw new ApplicationException($"Server error: The server SEARCH did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 200 OK ");          
        }
      }
    }   
    private bool GetPrimaryMrnIdentifer(List<Identifier> SourceIdentifierList, out Identifier OutIdentifier, out IResourceServiceOutcome ResourceServiceOutcome)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      try
      {
        bool HaveFoundId = false;
        Identifier ResultIdentifier = null;
        foreach (Identifier Id in SourceIdentifierList.Where(x => x.Use == Identifier.IdentifierUse.Official))
        {
          if (Id.Type != null && Id.Type.Coding != null && Id.Type.Coding.SingleOrDefault(c => c.Code == "MR") != null)
          {
            if (!HaveFoundId)
            {
              HaveFoundId = true;
              ResultIdentifier = Id;
            }
            else
            {
              OutIdentifier = null;
              var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources " +
                $"where the focus {ResourceType.Patient.GetLiteral()} resource's identifier list only contains a single identifier with a Use property equal to 'Offical' " +
                $"and a Type coding equal to 'MR' with the System 'http://hl7.org/fhir/v2/0203'. The server found more then one of these identifers when processing this request.";
              ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);              
              return false;
            }
          }
        }
        if (HaveFoundId)
        {
          OutIdentifier = ResultIdentifier;
          return true;
        }
        else
        {
          OutIdentifier = null;
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources " +
            $"where the focus {ResourceType.Patient.GetLiteral()} resource's identifier list contains a single identifier with a Use property equal to 'Offical' " +
            $"and a Type coding equal to 'MR' with the System 'http://hl7.org/fhir/v2/0203'. The server found no identifer of this type when processing this request.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);          
          return false;
        }
      }
      catch
      {
        OutIdentifier = null;
        var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources " +
            $"where the focus {ResourceType.Patient.GetLiteral()} resource's identifier list contains a single identifier with a Use property equal to 'Offical' " +
            $"and a Type coding equal to 'MR' with the System 'http://hl7.org/fhir/v2/0203'. The server encountered an error trying to find the identifer of this type when processing this request.";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);        
        return false;
      }
    }
    private bool IsADTA01BunbdleProcessable(Bundle Bundle, out AdtA01Payload Payload, out IResourceServiceOutcome ResourceServiceOutcome)
    {
      Payload = new AdtA01Payload();
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      if (_MessageHeader.Focus == null)
      {
        var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources " +
          $"where the {ResourceType.MessageHeader.GetLiteral()} resource focus reference property is set.";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }

      if (_MessageHeader.Focus.Count != 1)
      {
        var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources " +
          $"where the {ResourceType.MessageHeader.GetLiteral()} resource focus reference property is only set to a single reference to a Patient resource.";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }

      IPyroFhirUri FhirUri = IPyroFhirUriFactory.CreateFhirRequestUri();
      if (!FhirUri.Parse(_MessageHeader.Focus[0].Reference))
      {
        var Message = $"Unable to parse the {ResourceType.MessageHeader.GetLiteral()} focus reference to a valid FHIR reference";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }
      else
      {
        if (FhirUri.ResourceType != ResourceType.Patient)
        {
          var Message = $"The {ResourceType.MessageHeader.GetLiteral()} focus reference must reference a Patient resource.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        var PatEntry = Bundle.Entry.SingleOrDefault(x => x.FullUrl == ConvertToFullUrl(FhirUri.ResourceId));
        if (PatEntry != null && PatEntry.Resource != null && PatEntry.Resource is Patient Patient)
        {
          Payload.Patient = Patient;
        }
        else
        {
          var Message = $"The {ResourceType.MessageHeader.GetLiteral()} focus reference must reference a Bundle entry FullUrl where that entry as a Patient resource.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
      }
      return true;
    }
    private string ConvertToFullUrl(string resourceId)
    {      
      return $"{_UrnUUID}:{resourceId}";
    }
    private bool IsMessageHeaderProcessable(MessageHeader MessageHeader, out IResourceServiceOutcome ResourceServiceOutcome)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      if (MessageHeader.Event is Coding eventCoding)
      {
        if (eventCoding.System != IPyroHL7V2MessageTypeEventCodeSystem.GetSystem())
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources " +
            $"where the {ResourceType.MessageHeader.GetLiteral()} resource event property eventCoding system is: '{IPyroHL7V2MessageTypeEventCodeSystem.GetSystem()}'.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }

        if (!IPyroHL7V2MessageTypeEventCodeSystem.HasCode(eventCoding.Code))
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation does not recognise " +
            $"the {ResourceType.MessageHeader.GetLiteral()} resource event property eventCoding code of : '{eventCoding.Code}'.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
      }
      else
      {
        var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources of " +
           $"type where the {ResourceType.MessageHeader.GetLiteral()} resource event property is an eventCoding choice type.";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }
      return true;
    }
    private bool IsValidResourceMessageBundle(Resource Resource, out IResourceServiceOutcome ResourceServiceOutcome)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      if (Resource is Bundle Bundle)
      {
        if (Bundle.Type != Bundle.BundleType.Message)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources of " +
            $"type {Bundle.BundleType.Message.GetLiteral()}. Bundle ype found was : {Bundle.Type.GetLiteral()}.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }

        if (Bundle.Entry == null)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources " +
            $"which contain entries";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }

        if (Bundle.Entry.Count < 0)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources with" +
            $"a minimum of two entries, the first must be a MessageHeader resource and the second could be any other resource.";
          var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }

        if (Bundle.Entry[0].Resource == null)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources where the " +
            $"first entry has a populated resource of type {ResourceType.MessageHeader.GetLiteral()}";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }

        if (Bundle.Entry[0].Resource.ResourceType != ResourceType.MessageHeader)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources where the " +
            $"first entry is a resource of type {ResourceType.MessageHeader.GetLiteral()}";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
      }
      else
      {
        var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources. Resource type found was : {Resource.ResourceType.GetLiteral()}.";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);        
        return false;
      }
      return true;
    }
    private Bundle GetRetunBundle(MessageHeader.ResponseType ResponseType, List<OperationOutcome> OperationOutcomeList = null)
    {
      MessageHeader ReturnMessageHeader = new MessageHeader(); ;
      ReturnMessageHeader.Id = Pyro.Common.Tools.FhirGuid.FhirGuid.NewFhirGuid();
      ReturnMessageHeader.Event = _MessageHeader.Event;
      ReturnMessageHeader.Source = new MessageHeader.MessageSourceComponent()
      {
        Endpoint = IPrimaryServiceRootCache.GetPrimaryRootUrlFromWebConfig(),
        Name = "FHIR Server",
        Software = "Pyro Server"
      };
      ContactDetail ContactDetail = Pyro.Common.PyroHealthFhirResource.Elements.PyroHealthContactDetailAngusMillar.GetContactDetail();
      var PyroContactPointEmailList = ContactDetail.Telecom.Where(x => x.System == ContactPoint.ContactPointSystem.Email && x.Use == ContactPoint.ContactPointUse.Work);
      if (PyroContactPointEmailList.Count() > 0)
      {
        ReturnMessageHeader.Source.Contact = PyroContactPointEmailList.First();
      }

      ReturnMessageHeader.Response = new MessageHeader.ResponseComponent()
      {
        Identifier = _MessageHeader.Id,
        Code = MessageHeader.ResponseType.Ok
      };

      Bundle ReturnBundle = new Bundle();
      ReturnBundle.Id = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid();
      ReturnBundle.Total = 1;
      ReturnBundle.Type = Bundle.BundleType.Message;
      ReturnBundle.Timestamp = DateTimeOffset.Now;
      ReturnMessageHeader.Focus = new List<ResourceReference>();
      ReturnBundle.Entry = new List<Bundle.EntryComponent>();
      ReturnBundle.Entry.Add(new Bundle.EntryComponent()
      {
        FullUrl = $"{_UrnUUID}:{ReturnMessageHeader.Id}",
        Resource = ReturnMessageHeader
      });
      if (OperationOutcomeList != null)
      {
        foreach (OperationOutcome Op in OperationOutcomeList)
        {
          Op.Id = Tools.FhirGuid.FhirGuid.NewFhirGuid();
          ReturnMessageHeader.Focus.Add(new ResourceReference($"{ResourceType.OperationOutcome}/{Op.Id}"));
          ReturnBundle.Entry.Add(new Bundle.EntryComponent()
          {
            FullUrl = $"{_UrnUUID}:{Op.Id}",
            Resource = Op
          });
        }
      }
      return ReturnBundle;
    }
    private IResourceServiceOutcome SimpleErrorInvalidResponse(string Message)
    {
      var ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);            
      return OperationOutcomeListErrorInvalidResponse(new List<OperationOutcome>() { OpOutcome }); ;
    }

    private IResourceServiceOutcome OperationOutcomeListErrorInvalidResponse(List<OperationOutcome> OpOutComeList)
    {
      var ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();      
      ResourceServiceOutcome.ResourceResult = GetRetunBundle(MessageHeader.ResponseType.FatalError, OpOutComeList);
      ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
      ResourceServiceOutcome.SuccessfulTransaction = false;
      return ResourceServiceOutcome;
    }

    private IResourceServiceOutcome AllOkResponse()
    {
      var ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      ResourceServiceOutcome.ResourceResult = GetRetunBundle(MessageHeader.ResponseType.Ok);
      ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
      ResourceServiceOutcome.SuccessfulTransaction = true;
      return ResourceServiceOutcome;
    }
    

  }
}

