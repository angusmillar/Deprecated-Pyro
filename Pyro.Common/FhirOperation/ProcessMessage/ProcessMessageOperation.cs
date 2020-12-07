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
using System.Text;

namespace Pyro.Common.FhirOperation.ProcessMessage
{
  //Notes: Here is a list of what resources are linked to which other resources.
  //  MessageHeader links to Patient, 2 x Organisation
  //  Patient has no links
  //  Encounter links to Patient
  //  AllergyIntolerance link to Patient & Encounter
  //  Organization has no links
  //  Provenance links to all above, MessageHeader, Patient, Encounuter, AllergyIntolerance, Organization
  //Given this we first commit the resource in this order Patient, Encounter, AllergyIntolerance, Provenance so that
  //each reference can be updated with the new Resource id assigned on ADD, id added. Note that Organization will have static 
  //resource ids and will not be added or updated by each new bundle. It will be manualy added to the server on deployment and setup. 
  //Therefore no need to update the references to Organization resources 
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
    private Dictionary<string, string> _ResourceReferenceDictionary;

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
          SupportedEventCodes.Add(PyroHL7V2MessageTypeEvent.Codes.ADTA02.GetPyroLiteral());
          SupportedEventCodes.Add(PyroHL7V2MessageTypeEvent.Codes.ADTA03.GetPyroLiteral());
          SupportedEventCodes.Add(PyroHL7V2MessageTypeEvent.Codes.ADTA08.GetPyroLiteral());
          
          Coding eventCoding = (_MessageHeader.Event as Coding);
          if (SupportedEventCodes.Contains(eventCoding.Code.ToUpper()))
          {
            return ProcessADTUpdate(InputBundle);
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

    private IResourceServiceOutcome ProcessADTUpdate(Bundle inputBundle)
    {
      _ResourceReferenceDictionary = new Dictionary<string, string>();
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      ADTUpdatePayload Payload = null;

      if (!IsADTBundleProcessable(inputBundle, out Payload, out ResourceServiceOutcome))
      {
        return ResourceServiceOutcome;
      }
      //Patient Commit      
      if (!CommitResourceByIdentifier(out ResourceServiceOutcome, out string PatientResourceId, ResourceType.Patient, Payload.Patient, Payload.PrimaryPatientIdentifer))
      {
        return ResourceServiceOutcome;
      }
      else
      {

        //Encounter Commit
        UpdateReference(Payload.Encounter.Subject);
        if (!CommitResourceByIdentifier(out ResourceServiceOutcome, out string EncounterResourceId, ResourceType.Encounter, Payload.Encounter, Payload.PrimaryEncounterIdentifer))
        {
          return ResourceServiceOutcome;
        }
        else
        {
          //AllergyIntolerance Commit
          if (!CommitAllergyIntoleranceResourceList(out ResourceServiceOutcome, Payload.AllergyIntoleranceList, PatientResourceId, EncounterResourceId))
          {
            return ResourceServiceOutcome;
          }
        }
        //MessageHeader Commit
        UpdateReference(Payload.MessageHeader.Focus.First());
        if (!CommitResourceByResourceId(out ResourceServiceOutcome, ResourceType.MessageHeader, Payload.MessageHeader))
        {
          return ResourceServiceOutcome;
        }
        //Provenance Commit
        foreach (var Target in Payload.Provenance.Target)
        {
          UpdateReference(Target);
        }

        if (!CommitResourceByResourceId(out ResourceServiceOutcome, ResourceType.Provenance, Payload.Provenance))
        {
          return ResourceServiceOutcome;
        }

        return AllOkResponse();
      }
    }
    private void UpdateReference(ResourceReference ResourceReference)
    {
      if (!string.IsNullOrEmpty(ResourceReference.Reference))
      {
        if (ResourceReference.Reference.StartsWith(_UrnUUID))
        {
          string UUID = ResourceReference.Reference.Remove(0, _UrnUUID.Length + 1);
          if (_ResourceReferenceDictionary.ContainsKey(UUID))
          {
            ResourceReference.Reference = _ResourceReferenceDictionary[UUID];
          }
          else
          {
            throw new ApplicationException($"Server Error: Failed to find the updated ResourceReference in the ResourceReferenceDictionary of old and new references. The old reference was: {ResourceReference.Reference}");
          }
        }
      }
    }
    private bool CommitAllergyIntoleranceResourceList(out IResourceServiceOutcome ResourceServiceOutcome, List<AllergyIntolerance> AllergyIntoleranceList, string PatientResourceId, string EncounterResourceId)
    {
      //More than one should not have happened, clean up by deleting all and and the new one as a new resource.
      //1. Update if found in old list and then remove from old list
      //2. Add if not in old list
      //3. Once looped through all new then delete the remaining old list 
      List<AllergyIntolerance> OldAllergyIntoleranceList = GetPatientAllergyIntoleranceList(PatientResourceId);
      foreach (var AllergyIntolerance in AllergyIntoleranceList)
      {
        UpdateReference(AllergyIntolerance.Patient);
        UpdateReference(AllergyIntolerance.Encounter);
        string Code = AllergyIntolerance.Code.Coding.First().Code;
        string System = AllergyIntolerance.Code.Coding.First().System;
        var AllergyIntoleranceToUpdateList = OldAllergyIntoleranceList.Where(x => x.Code.Coding.Exists(y => y.Code == Code && y.System == System));
        if (AllergyIntoleranceToUpdateList.Count() > 1)
        {
          //We have foud more then one that matches which shoild really should not happen. Yet, as this in bound message
          //is the latest snapshot view of the patient we wil clean up by deleteting all AllergyIntolerance resources with this code
          // and then add this new single one as a new resource. This is because we don't know which of the two old resources
          //found should be the History of the new resource, so just start afreash.
          foreach (var item in AllergyIntoleranceToUpdateList)
          {
            if (!DeleteResource(out ResourceServiceOutcome, ResourceType.AllergyIntolerance, item.Id))
            {
              return false;
            }
          }
          if (!AddResource(out ResourceServiceOutcome, out string ResourceId, ResourceType.AllergyIntolerance, AllergyIntolerance))
          {
            return false;
          }
        }
        else if (AllergyIntoleranceToUpdateList.Count() == 1)
        {
          //Found a single resource so update it with this new resource and remove the old resource from the toUpdate list as
          // we will delete all left in that list at the very end 
          string OriginalResourceId = AllergyIntolerance.Id;
          AllergyIntolerance.Id = AllergyIntoleranceToUpdateList.First().Id;
          if (!UpdateResource(out ResourceServiceOutcome, ResourceType.AllergyIntolerance, AllergyIntolerance))
          {
            return false;
          }
          _ResourceReferenceDictionary.Add(OriginalResourceId, $"{AllergyIntolerance.ResourceType}/{AllergyIntolerance.Id}");
          OldAllergyIntoleranceList.Remove(AllergyIntoleranceToUpdateList.First());
        }
        else
        {
          //There was no older resource found so just add this new one as new POST /Create
          if (!AddResource(out ResourceServiceOutcome, out string ResourceId, ResourceType.AllergyIntolerance, AllergyIntolerance))
          {
            return false;
          }
        }
      }
      foreach (var Old in OldAllergyIntoleranceList)
      {
        if (!DeleteResource(out ResourceServiceOutcome, ResourceType.AllergyIntolerance, Old.Id))
        {
          return false;
        }
      }
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      return true;
    }
    private List<AllergyIntolerance> GetPatientAllergyIntoleranceList(string PatientResourceId)
    {
      var ResultList = new List<AllergyIntolerance>();
      var RequestMetaSearch = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType.AllergyIntolerance, $"?patient={ResourceType.Patient.GetLiteral()}/{PatientResourceId}");
      IResourceServiceOutcome SearchbyPatientIdOutcome = IResourceServices.GetSearch(RequestMetaSearch);
      if (SearchbyPatientIdOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        if (SearchbyPatientIdOutcome.ResourceResult is Bundle Resultbundle)
        {
          foreach (var Entry in Resultbundle.Entry)
          {
            if (Entry.Resource != null)
            {
              ResultList.Add(Entry.Resource as AllergyIntolerance);
            }
          }
        }
        return ResultList;
      }
      else
      {
        throw new ApplicationException($"Search for {ResourceType.AllergyIntolerance.GetLiteral()} failed to retiurn HTTP status 200 OK.");
      }
    }
    private bool AddResource(out IResourceServiceOutcome ResourceServiceOutcome, out string ResourceId, ResourceType ResourceType, Resource Resource)
    {
      ResourceId = string.Empty;
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      string OriginalResourceId = Resource.Id;

      Resource.Id = null;
      var RequestMetaPost = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, string.Empty);
      IResourceServiceOutcome PostOutcome = IResourceServices.Post(Resource, RequestMetaPost);
      if (PostOutcome.HttpStatusCode == System.Net.HttpStatusCode.Created)
      {
        ResourceId = PostOutcome.FhirResourceId;
        _ResourceReferenceDictionary.Add(OriginalResourceId, $"{ResourceType.GetLiteral()}/{PostOutcome.FhirResourceId}");
        return true;
      }
      else
      {
        if (PostOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to Post the {ResourceType.GetLiteral()} resource " +
            $"to the server. Please read the full list of {ResourceType.OperationOutcome.GetLiteral()} resources for more info.";
          var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
          ResourceServiceOutcome = OperationOutcomeListErrorInvalidResponse(new List<OperationOutcome>() { OpOutcome, ReturnOpOut });
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server POST did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 201 Created when posting the {ResourceType.GetLiteral()} resource.");
        }
      }
    }
    private bool UpdateResource(out IResourceServiceOutcome ResourceServiceOutcome, ResourceType ResourceType, Resource Resource)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      var RequestMetaPut = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, Resource.Id);
      IResourceServiceOutcome PutOutcome = IResourceServices.Put(Resource.Id, Resource, RequestMetaPut);
      if (PutOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        return true;
      }
      else
      {
        if (PutOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to PUT the {ResourceType} resource " +
            $"to the server. Please read the full issue list in this {ResourceType.OperationOutcome.GetLiteral()} resource for more info.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server PUT did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 201 Created when posting the {ResourceType.GetLiteral()} resource.");
        }
      }
    }
    private bool DeleteResource(out IResourceServiceOutcome ResourceServiceOutcome, ResourceType ResourceType, string ResourceId)
    {
      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      var RequestMetaPost = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, ResourceId);
      IResourceServiceOutcome DeleteOutcome = IResourceServices.Delete(ResourceId, RequestMetaPost);
      if (DeleteOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        return true;
      }
      else
      {
        if (DeleteOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to DELETE the {ResourceType} resource wiht the id of {ResourceId} " +
            $"to the server. Please read the full issue list in this {ResourceType.OperationOutcome.GetLiteral()} resource for more info.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server PUT did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 201 Created when posting the {ResourceType.GetLiteral()} resource.");
        }
      }
    }
    private bool CommitResourceByIdentifier(out IResourceServiceOutcome ResourceServiceOutcome, out string ResourceId, ResourceType ResourceType, Resource Resource, Identifier PrimaryIdentifier)
    {
      //First Search for the resource
      var RequestMetaFindResource = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, $"?identifier={PrimaryIdentifier.System}|{PrimaryIdentifier.Value}");
      IResourceServiceOutcome FindByIdOutcome = IResourceServices.GetSearch(RequestMetaFindResource);
      if (FindByIdOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        if (FindByIdOutcome.ResourceResult is Bundle Resultbundle)
        {
          //## Post(Create) if not found ##########
          if (Resultbundle.Total.HasValue && Resultbundle.Total.Value == 0)
          {
            return AddResource(out ResourceServiceOutcome, out ResourceId, ResourceType, Resource);
          }
          //## Put(Update) if found ###############
          else if (Resultbundle.Total.HasValue && Resultbundle.Total.Value == 1)
          {
            _ResourceReferenceDictionary.Add(Resource.Id, $"{ResourceType.GetLiteral()}/{Resultbundle.Entry[0].Resource.Id}");
            Resource.Id = Resultbundle.Entry[0].Resource.Id;
            ResourceId = Resource.Id;
            return UpdateResource(out ResourceServiceOutcome, ResourceType, Resource);
          }
          //## Erorr if more then one #############
          else if (Resultbundle.Total.HasValue && Resultbundle.Total.Value > 1)
          {
            var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation found duplicate {ResourceType.GetLiteral()} " +
              $"resources with the identifier: (System: '{PrimaryIdentifier.System}' and Value '{PrimaryIdentifier.Value}').";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
            ResourceId = string.Empty;
            return false;
          }
          else
          {
            throw new ApplicationException($"Server error: The server search result for {ResourceType.GetLiteral()} has no Bundle.Total property.");
          }
        }
        else
        {
          throw new ApplicationException($"Server error: The server search result for {ResourceType.GetLiteral()} has no Bundle.Total property.");
        }
      }
      else
      {
        if (FindByIdOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to perfomed a Search for the {ResourceType.GetLiteral()} resource " +
            $"in the server. Please read the full list of {ResourceType.OperationOutcome.GetLiteral()} resources for more info.";
          var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
          ResourceServiceOutcome = OperationOutcomeListErrorInvalidResponse(new List<OperationOutcome>() { OpOutcome, ReturnOpOut });
          ResourceId = string.Empty;
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server SEARCH did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 200 OK ");
        }
      }
    }
    private bool CommitResourceByResourceId(out IResourceServiceOutcome ResourceServiceOutcome, ResourceType ResourceType, Resource Resource)
    {
      //Although the Resource reference does mot change here we still want it in the dictonary so it is found later.
      _ResourceReferenceDictionary.Add(Resource.Id, $"{ResourceType.GetLiteral()}/{Resource.Id}");

      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      var RequestMetaPut = IRequestMetaFactory.CreateRequestMeta().Set(ResourceType, string.Empty);
      IResourceServiceOutcome PutOutcome = IResourceServices.Put(Resource.Id, Resource, RequestMetaPut);
      if (PutOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
      {
        return true;
      }
      else if (PutOutcome.HttpStatusCode == System.Net.HttpStatusCode.Created)
      {
        return true;
      }
      else
      {
        if (PutOutcome.ResourceResult is OperationOutcome ReturnOpOut)
        {
          var Message = $"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation was not able to perfomed a PUT for the {ResourceType.GetLiteral()} resource with the resource id {Resource.Id} " +
            $"Please read the full list of {ResourceType.OperationOutcome.GetLiteral()} resources for more info.";
          var OpOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, Message);
          ResourceServiceOutcome = OperationOutcomeListErrorInvalidResponse(new List<OperationOutcome>() { OpOutcome, ReturnOpOut });
          return false;
        }
        else
        {
          throw new ApplicationException($"Server error: The server PUT did not retun a {ResourceType.OperationOutcome.GetLiteral()} resource or HTTP Code 200 OKmor Code 201 Created. ");
        }
      }
    }
    private bool IsPrimaryPatientIdentifier(Identifier Id)
    {
      if (Id.Type != null &&
            Id.Type.Coding != null &&
            Id.Type.Coding.SingleOrDefault(c => c.Code == "MR") != null &&
            Id.Use != null &&
            Id.Use == Identifier.IdentifierUse.Official &&
            !string.IsNullOrWhiteSpace(Id.Value))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool IsPrimaryEncounterIdentifier(Identifier Id)
    {
      if ( Id.Use != null &&
            Id.Use == Identifier.IdentifierUse.Official &&
            !string.IsNullOrWhiteSpace(Id.Value))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private bool GetPrimaryIdentifer(List<Identifier> SourceIdentifierList, ResourceType ResourceType, out Identifier OutIdentifier, out IResourceServiceOutcome ResourceServiceOutcome)
    {
      StringBuilder ErrorMessageBuilder = new StringBuilder();
      ErrorMessageBuilder.Append($"The ${FhirOperationEnum.OperationType.ProcessMessage.GetPyroLiteral()} operation can only process Bundle resources ");
      ErrorMessageBuilder.Append($"where the {ResourceType.GetLiteral()} resource's identifier list only contains a single identifier with a Use property equal to 'Offical'. ");
      if (ResourceType == ResourceType.Patient)
      {
        ErrorMessageBuilder.Append($"And a Type coding equal to 'MR' with the System 'http://hl7.org/fhir/v2/0203'. ");
      }

      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
      if (SourceIdentifierList == null)
      {
        OutIdentifier = null;
        ErrorMessageBuilder.Append($"The server found no {ResourceType.GetLiteral()} identifers when processing this request.");
        ResourceServiceOutcome = SimpleErrorInvalidResponse(ErrorMessageBuilder.ToString());
        return false;
      }

      if (ResourceType == ResourceType.Patient)
      {
        OutIdentifier = SourceIdentifierList.SingleOrDefault(x => IsPrimaryPatientIdentifier(x));
      }
      else
      {
        OutIdentifier = SourceIdentifierList.SingleOrDefault(x => IsPrimaryEncounterIdentifier(x));
      }

      if (OutIdentifier != null)
      {
        return true;
      }
      else
      {
        ErrorMessageBuilder.Append($"The server found either no {ResourceType.GetLiteral()} identifers or more than a single identifier that matched.");
        ResourceServiceOutcome = SimpleErrorInvalidResponse(ErrorMessageBuilder.ToString());
        return false;
      }
    }
    private bool IsADTBundleProcessable(Bundle Bundle, out ADTUpdatePayload Payload, out IResourceServiceOutcome ResourceServiceOutcome)
    {
      Payload = new ADTUpdatePayload();
      Payload.MessageHeader = _MessageHeader;

      //MessageHeader
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

      IPyroFhirUri HeaderFocusFhirUri = IPyroFhirUriFactory.CreateFhirRequestUri();
      if (!HeaderFocusFhirUri.Parse(_MessageHeader.Focus[0].Reference))
      {
        var Message = $"Unable to parse the {ResourceType.MessageHeader.GetLiteral()} focus reference to a valid FHIR reference";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }
      else
      {
        if (HeaderFocusFhirUri.UrnType != UrnType.uuid)
        {
          var Message = $"The {ResourceType.MessageHeader.GetLiteral()} focus reference must be a {_UrnUUID} type reference a Patient resource.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }

        //Patient
        var PatEntry = Bundle.Entry.SingleOrDefault(x => x.FullUrl == HeaderFocusFhirUri.Urn);
        if (PatEntry != null && PatEntry.Resource != null && PatEntry.Resource is Patient Patient)
        {
          Payload.Patient = Patient;
          if (Payload.Patient.Identifier == null)
          {
            var Message = $"The {ResourceType.Patient.GetLiteral()} resource has no identifer, there must be a single idenitfer with a Use code of official. And Type code of MR";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
            return false;
          }
          else
          {
            Identifier PatientNumber = null;
            if (!GetPrimaryIdentifer(Payload.Patient.Identifier, ResourceType.Patient, out PatientNumber, out ResourceServiceOutcome))
            {
              return false;
            }
            else
            {
              Payload.PrimaryPatientIdentifer = PatientNumber;
            }
          }

        }
        else
        {
          var Message = $"The {ResourceType.MessageHeader.GetLiteral()} focus reference must reference a Bundle entry FullUrl where that entry as a Patient resource.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
      }

      //Encounter
      var EncounterEntryList = Bundle.Entry.Where(x => x.Resource.TypeName == ResourceType.Encounter.GetLiteral());
      if (EncounterEntryList.Count() == 0)
      {
        var Message = $"The {ResourceType.Bundle.GetLiteral()} has no {ResourceType.Encounter.GetLiteral()} resource.";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }
      else if (EncounterEntryList.Count() > 1)
      {
        var Message = $"The {ResourceType.Bundle.GetLiteral()} has more than one {ResourceType.Encounter.GetLiteral()} resource.";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }
      else
      {
        Payload.Encounter = EncounterEntryList.First().Resource as Encounter;

        if (Payload.Encounter.Identifier == null)
        {
          var Message = $"The {ResourceType.Encounter.GetLiteral()} resource has no identifer, there must be a single idenitfer wiht a Use code of official.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else
        {
          Identifier EcounterNumber = null;
          if (!GetPrimaryIdentifer(Payload.Encounter.Identifier, ResourceType.AllergyIntolerance, out EcounterNumber, out ResourceServiceOutcome))
          {
            return false;
          }
          else
          {
            Payload.PrimaryEncounterIdentifer = EcounterNumber;
          }
        }
      }

      IPyroFhirUri EncounterSubjectFhirUri = IPyroFhirUriFactory.CreateFhirRequestUri();
      if (!EncounterSubjectFhirUri.Parse(Payload.Encounter.Subject.Reference))
      {
        var Message = $"Unable to parse the {ResourceType.Encounter.GetLiteral()} subject reference to a valid FHIR reference";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }
      else
      {
        if (EncounterSubjectFhirUri.UrnType != UrnType.uuid)
        {
          var Message = $"The {ResourceType.Encounter.GetLiteral()} subject reference must be a {_UrnUUID} type reference to a Patient resource in the Bundle.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }

        if (EncounterSubjectFhirUri.Urn != HeaderFocusFhirUri.Urn)
        {
          var Message = $"The {ResourceType.Encounter.GetLiteral()} subject reference must reference the same Patient resource as the MessageHeader focus reference.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
      }

      //AllergyIntolerance
      var AllergyIntoleranceEntryList = Bundle.Entry.Where(x => x.Resource.TypeName == ResourceType.AllergyIntolerance.GetLiteral());
      foreach (var AllergyIntoleranceEntry in AllergyIntoleranceEntryList)
      {
        var AllergyIntolerance = AllergyIntoleranceEntry.Resource as AllergyIntolerance;

        //Check the Patient reference
        IPyroFhirUri AllergyIntolerancePatientFhirUri = IPyroFhirUriFactory.CreateFhirRequestUri();
        if (!AllergyIntolerancePatientFhirUri.Parse(AllergyIntolerance.Patient.Reference))
        {
          var Message = $"Unable to parse the {ResourceType.AllergyIntolerance.GetLiteral()} patient reference to a valid FHIR reference";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else
        {
          if (AllergyIntolerancePatientFhirUri.Urn != HeaderFocusFhirUri.Urn)
          {
            var Message = $"All of the {ResourceType.AllergyIntolerance.GetLiteral()} patient references must reference the same Patient resource as the MessageHeader focus reference.";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
            return false;
          }
        }
        //Check the Encounter reference
        IPyroFhirUri AllergyIntoleranceEncounterFhirUri = IPyroFhirUriFactory.CreateFhirRequestUri();
        if (!AllergyIntoleranceEncounterFhirUri.Parse(AllergyIntolerance.Encounter.Reference))
        {
          var Message = $"Unable to parse the {ResourceType.AllergyIntolerance.GetLiteral()} encounter reference to a valid FHIR reference";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else
        {
          if (AllergyIntoleranceEncounterFhirUri.UrnType != UrnType.uuid)
          {
            var Message = $"The {ResourceType.AllergyIntolerance.GetLiteral()} Encounter resource references must be a {_UrnUUID} type reference an Encounter resource in the Bundle.";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
            return false;
          }

          if (AllergyIntoleranceEncounterFhirUri.Urn != EncounterEntryList.First().FullUrl)
          {
            var Message = $"All of the {ResourceType.AllergyIntolerance.GetLiteral()} encounter references must reference the MessageHeader's focus a Patient's encounter resource in the Bundle.";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
            return false;
          }
        }
        //Check AlleryIntolerance has a single Code.
        if (AllergyIntolerance.Code == null)
        {
          var Message = $"All of the {ResourceType.AllergyIntolerance.GetLiteral()} resources must have a Code property, none found on {ResourceType.AllergyIntolerance.GetLiteral()} resource id {AllergyIntolerance.Id}";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else if (AllergyIntolerance.Code.Coding == null)
        {
          var Message = $"All of the {ResourceType.AllergyIntolerance.GetLiteral()} resources must have a Code.Coding property, none found on {ResourceType.AllergyIntolerance.GetLiteral()} resource id {AllergyIntolerance.Id}";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else if (AllergyIntolerance.Code.Coding.Count == 0)
        {
          var Message = $"All of the {ResourceType.AllergyIntolerance.GetLiteral()} resources must have a single Code.Coding entry, none found on {ResourceType.AllergyIntolerance.GetLiteral()} resource id {AllergyIntolerance.Id}";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        else if (AllergyIntolerance.Code.Coding.Count > 1)
        {
          var Message = $"All of the {ResourceType.AllergyIntolerance.GetLiteral()} resources must have a single Code.Coding entry, found more then one on {ResourceType.AllergyIntolerance.GetLiteral()} resource id {AllergyIntolerance.Id}";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        Payload.AllergyIntoleranceList.Add(AllergyIntolerance);
      }

      //Provenance
      var ProvenanceEntity = Bundle.Entry.SingleOrDefault(x => x.Resource.TypeName == ResourceType.Provenance.GetLiteral());
      if (ProvenanceEntity != null && ProvenanceEntity.Resource != null && ProvenanceEntity.Resource is Provenance Provenance)
      {
        if (Provenance.Target == null || Provenance.Target.Count() == 0)
        {
          var Message = $"The {ResourceType.Provenance.GetLiteral()} resource must have a Target property that is not empty.";
          ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
          return false;
        }
        foreach (ResourceReference TargetRef in Provenance.Target)
        {
          Bundle.EntryComponent BundleEntity = null;
          try
          {
            BundleEntity = Bundle.Entry.SingleOrDefault(x => x.FullUrl == TargetRef.Reference);
          }
          catch (ArgumentNullException)
          {
            var Message = $"The {ResourceType.Provenance.GetLiteral()} resource Target reference of {TargetRef.Reference} matches more than a single resource in the Bundle, this is mnot allowed.";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
            return false;
          }

          if (BundleEntity == null)
          {
            var Message = $"The {ResourceType.Provenance.GetLiteral()} resource Target reference of {TargetRef.Reference} does not matches any of the entries within the Bundle, this is not allowed.";
            ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
            return false;
          }
        }
        Payload.Provenance = Provenance;
      }
      else
      {
        var Message = $"Unable to locate a single {ResourceType.Provenance.GetLiteral()} resource within the Bundle. There must be at least one and only one {ResourceType.Provenance.GetLiteral()} resource in the Bundle";
        ResourceServiceOutcome = SimpleErrorInvalidResponse(Message);
        return false;
      }

      return true;
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
        Code = ResponseType
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

