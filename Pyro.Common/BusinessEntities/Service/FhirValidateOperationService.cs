using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;
using Pyro.Common.Tools;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.Common.BusinessEntities.Service
{
  public class FhirValidateOperationService : IFhirValidateOperationService
  {
    enum ResourceValidationModeType { None, Create, Update, Delete };
    private IResourceOperationsServiceRequest _ResourceOpServiceRequest;
    List<OperationOutcome.IssueComponent> IssueList = null;
    string FormatMimeType = string.Empty;
    IResourceServiceOutcome ResourceServiceOutcome;

    internal FhirValidateOperationService(IResourceOperationsServiceRequest ResourceOpServiceRequest)
    {
      this._ResourceOpServiceRequest = ResourceOpServiceRequest;
      IssueList = new List<OperationOutcome.IssueComponent>();
    }

    public IResourceServiceOutcome ValidateResource()
    {
      if (string.IsNullOrWhiteSpace(_ResourceOpServiceRequest.OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (_ResourceOpServiceRequest.OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
      if (_ResourceOpServiceRequest.OperationClass.Scope != FhirOperationEnum.OperationScope.Resource)
        throw new NullReferenceException("OperationClass.Scope must be 'Resource' for this method.");
      if (_ResourceOpServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (_ResourceOpServiceRequest.RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (_ResourceOpServiceRequest.RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (_ResourceOpServiceRequest.ResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");
      if (_ResourceOpServiceRequest.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");

      ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      ISearchParametersServiceOutcome SearchParametersServiceOutcome = ParseUrlSearchParameters(_ResourceOpServiceRequest.SearchParameterGeneric, _ResourceOpServiceRequest.OperationClass);
      FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        IssueList.AddRange(SearchParametersServiceOutcome.FhirOperationOutcome.Issue);
        return FinalResourceServiceOutcome(IssueList);
      }

      //Get ValidationOperationItems from URL
      ValidationOperationItems ValidationOperationItemsFromUrl = new ValidationOperationItems();
      ObtainOperationItemsFromSearchParameters(SearchParametersServiceOutcome, ValidationOperationItemsFromUrl);

      //Get ValidationOperationItems from Parameter Resource
      ValidationOperationItems ValidationOperationItemsFromParametersResource = new ValidationOperationItems();
      if (_ResourceOpServiceRequest.Resource.ResourceType == ResourceType.Parameters)
      {
        ValidationOperationItemsFromParametersResource = ValidateParameterResource(_ResourceOpServiceRequest.Resource as Parameters);
      }
      else
      {
        ValidationOperationItemsFromUrl.ResourceToValidate = _ResourceOpServiceRequest.Resource;
      }

      ValidationOperationItems FinalValidationOperationItems = ConsoladateValidationOperationItems(ValidationOperationItemsFromUrl, ValidationOperationItemsFromParametersResource);
      if (FinalValidationOperationItems.OperationOutcome != null)
      {
        IssueList.AddRange(FinalValidationOperationItems.OperationOutcome.Issue);
        return FinalResourceServiceOutcome(IssueList);
      }

      if (FinalValidationOperationItems.ValidationMode == ResourceValidationModeType.Delete)
      {
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
        $"A mode parameter equal to 'delete' can only be used against a Resource instance URL.");
        IssueList.AddRange(OpOutCome.Issue);
        return FinalResourceServiceOutcome(IssueList);
      }
      else if (FinalValidationOperationItems.ResourceToValidate != null)
      {
        if (!CheckResourceEndpointMatchesResourceToBeValidated(FinalValidationOperationItems.ResourceToValidate.ResourceType))
        {
          return FinalResourceServiceOutcome(IssueList);
        }

        if (FinalValidationOperationItems.FhirRequestUriProfileUri != null)
        {
          OperationOutcome ProfileValidationOpOutCome = PerformValidation(FinalValidationOperationItems);
          PerformModeValidation(ProfileValidationOpOutCome, FinalValidationOperationItems);
          IssueList.AddRange(ProfileValidationOpOutCome.Issue);
          return FinalResourceServiceOutcome(IssueList);
        }
        else
        {
          OperationOutcome ModeValidationOpOutCome = new OperationOutcome();
          PerformModeValidation(ModeValidationOpOutCome, FinalValidationOperationItems);
          // There is no profile given to validate against. 
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"The Resource provided for validation '{FinalValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}' must match the resource endpoint in the URL '{_ResourceOpServiceRequest.RequestUri.FhirRequestUri.ResourseName}'");
          IssueList.AddRange(OpOutCome.Issue);
          return FinalResourceServiceOutcome(IssueList);
        }
      }
      else
      {
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
        $"No Resource provided for validation, if mode equal (None, Create or Update) then a Resource must be provided to validate against.");
        IssueList.AddRange(OpOutCome.Issue);
        return FinalResourceServiceOutcome(IssueList);
      }
    }

    public IResourceServiceOutcome ValidateResourceInstance()
    {
      if (string.IsNullOrWhiteSpace(_ResourceOpServiceRequest.OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (_ResourceOpServiceRequest.OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
      if (_ResourceOpServiceRequest.OperationClass.Scope != FhirOperationEnum.OperationScope.Instance)
        throw new NullReferenceException("OperationClass.Scope must be 'Resource' for this method.");
      if (_ResourceOpServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (_ResourceOpServiceRequest.RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (_ResourceOpServiceRequest.RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (_ResourceOpServiceRequest.ResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");
      if (_ResourceOpServiceRequest.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (_ResourceOpServiceRequest.RequestUri == null)
        throw new NullReferenceException("_ResourceOpServiceRequest.RequestUri cannot be null");
      if (_ResourceOpServiceRequest.RequestUri.FhirRequestUri == null)
        throw new NullReferenceException("_ResourceOpServiceRequest.RequestUri.FhirRequestUri cannot be null");
      if (string.IsNullOrWhiteSpace(_ResourceOpServiceRequest.RequestUri.FhirRequestUri.ResourceId))
        throw new NullReferenceException("Resource Id endpoint must be used for ValidateResourceInstance.");

      ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      ISearchParametersServiceOutcome SearchParametersServiceOutcome = ParseUrlSearchParameters(_ResourceOpServiceRequest.SearchParameterGeneric, _ResourceOpServiceRequest.OperationClass);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        IssueList.AddRange(SearchParametersServiceOutcome.FhirOperationOutcome.Issue);
        return FinalResourceServiceOutcome(IssueList);
      }

      //Get ValidationOperationItems from URL
      ValidationOperationItems ValidationOperationItemsFromUrl = new ValidationOperationItems();
      ObtainOperationItemsFromSearchParameters(SearchParametersServiceOutcome, ValidationOperationItemsFromUrl);

      //Get ValidationOperationItems from Parameter Resource
      ValidationOperationItems ValidationOperationItemsFromParametersResource = new ValidationOperationItems();
      if (_ResourceOpServiceRequest.Resource.ResourceType == ResourceType.Parameters)
      {
        ValidationOperationItemsFromParametersResource = ValidateParameterResource(_ResourceOpServiceRequest.Resource as Parameters);
      }
      else
      {
        ValidationOperationItemsFromUrl.ResourceToValidate = _ResourceOpServiceRequest.Resource;
      }

      ValidationOperationItems FinalValidationOperationItems = ConsoladateValidationOperationItems(ValidationOperationItemsFromUrl, ValidationOperationItemsFromParametersResource);
      if (FinalValidationOperationItems.OperationOutcome != null)
      {
        IssueList.AddRange(FinalValidationOperationItems.OperationOutcome.Issue);
        return FinalResourceServiceOutcome(IssueList);
      }

      if (FinalValidationOperationItems.ResourceToValidate != null)
      {
        if (!CheckResourceEndpointMatchesResourceToBeValidated(FinalValidationOperationItems.ResourceToValidate.ResourceType))
        {
          return FinalResourceServiceOutcome(IssueList);
        }

        if (FinalValidationOperationItems.FhirRequestUriProfileUri != null)
        {
          OperationOutcome ProfileValidationOpOutCome = PerformValidation(FinalValidationOperationItems);
          PerformModeValidation(ProfileValidationOpOutCome, FinalValidationOperationItems);
          IssueList.AddRange(ProfileValidationOpOutCome.Issue);
          return FinalResourceServiceOutcome(IssueList);
        }
        else
        {
          // There is no profile given to validate against. 
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"The Resource provided for validation '{FinalValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}' must match the resource endpoint in the URL '{_ResourceOpServiceRequest.RequestUri.FhirRequestUri.ResourseName}'");
          IssueList.AddRange(OpOutCome.Issue);
          return FinalResourceServiceOutcome(IssueList);
        }
      }
      else
      {
        if (FinalValidationOperationItems.ValidationMode != ResourceValidationModeType.Delete)
        {
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"No Resource provided for validation, if mode equal (None, Create or Update) then a Resource must be provided to validate against.");
          IssueList.AddRange(OpOutCome.Issue);
          return FinalResourceServiceOutcome(IssueList);
        }
        else if (FinalValidationOperationItems.ValidationMode == ResourceValidationModeType.Delete)
        {
          OperationOutcome OpOutCome = new OperationOutcome();
          PerformModeValidation(OpOutCome, FinalValidationOperationItems);
          IssueList.AddRange(OpOutCome.Issue);
          return FinalResourceServiceOutcome(IssueList);
        }
        else
        {
          throw new System.ComponentModel.InvalidEnumArgumentException(FinalValidationOperationItems.ValidationMode.ToString(), (int)FinalValidationOperationItems.ValidationMode, typeof(ResourceValidationModeType));
        }
      }
    }


    private ValidationOperationItems ValidateParameterResource(Parameters ParametersResource)
    {
      var ValidationOperationItems = new ValidationOperationItems();
      ValidationOperationItems.ValidationMode = ResourceValidationModeType.None;
      var ModeParameter = ParametersResource.Parameter.SingleOrDefault(x => x.Name.ToLower() == "mode");
      if (ModeParameter != null)
      {
        if (ModeParameter.Value is Code ModeCode)
        {
          switch (ModeCode.Value.ToLower())
          {
            case "create":
              ValidationOperationItems.ValidationMode = ResourceValidationModeType.Create;
              break;
            case "update":
              ValidationOperationItems.ValidationMode = ResourceValidationModeType.Update;
              break;
            case "delete":
              ValidationOperationItems.ValidationMode = ResourceValidationModeType.Delete;
              break;
            default:
              ValidationOperationItems.ValidationMode = null;
              break;
          }
        }
      }
      else
      {
        ValidationOperationItems.ValidationMode = ResourceValidationModeType.None;
      }

      var ProfileParameter = ParametersResource.Parameter.SingleOrDefault(x => x.Name.ToLower() == "profile");
      if (ProfileParameter != null)
      {
        if (ProfileParameter.Value is FhirUri FhirUri)
        {
          ValidationOperationItems.ProfileUri = FhirUri.Value;
        }
      }

      if (ValidationOperationItems.ValidationMode != ResourceValidationModeType.Delete)
      {
        var ResourceParameter = ParametersResource.Parameter.SingleOrDefault(x => x.Name.ToLower() == "resource");
        if (ResourceParameter != null)
        {
          if (ResourceParameter.Resource != null)
          {
            ValidationOperationItems.ResourceToValidate = ResourceParameter.Resource;
          }
        }
      }
      return ValidationOperationItems;
    }

    private void PerformModeValidation(OperationOutcome ModeValidationOpOutCome, ValidationOperationItems ValidationOperationItems)
    {
      if (ValidationOperationItems.ValidationMode == ResourceValidationModeType.Create)
      {
        if (!string.IsNullOrWhiteSpace(ValidationOperationItems.ResourceToValidate.Id))
        {
          var ResourceIdIssue = new OperationOutcome.IssueComponent();
          ResourceIdIssue.Severity = OperationOutcome.IssueSeverity.Warning;
          ResourceIdIssue.Code = OperationOutcome.IssueType.Value;
          ResourceIdIssue.Details = new CodeableConcept("http://hl7.org/fhir/ValueSet/operation-outcome", "MSG_RESOURCE_ID_MISMATCH", $"The create(POST) interaction creates a new resource in a server assigned location. If the client wishes to have control over the id of a newly submitted resource, it should use the update interaction instead.The Resource provide was found to contain the id: { ValidationOperationItems.ResourceToValidate.Id }");
          ResourceIdIssue.Location = new List<string>() { $"{ValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}.id" };
          ModeValidationOpOutCome.Issue.Add(ResourceIdIssue);
        }
      }
      else if (ValidationOperationItems.ValidationMode == ResourceValidationModeType.Update)
      {
        if (string.IsNullOrWhiteSpace(ValidationOperationItems.ResourceToValidate.Id))
        {
          string Message = $"The Resource SHALL contain an {ValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}.id element to perform an update.";
          var ResourceIdIssue = new OperationOutcome.IssueComponent();
          ResourceIdIssue.Severity = OperationOutcome.IssueSeverity.Warning;
          ResourceIdIssue.Code = OperationOutcome.IssueType.Value;
          ResourceIdIssue.Details = new CodeableConcept("http://hl7.org/fhir/ValueSet/operation-outcome", "MSG_RESOURCE_ID_MISSING", Message);
          ResourceIdIssue.Location = new List<string>() { $"{ValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}.id" };
          ModeValidationOpOutCome.Issue.Add(ResourceIdIssue);
        }
      }
      else if (ValidationOperationItems.ValidationMode == ResourceValidationModeType.Delete)
      {
        var ResourceIdToDelete = string.Empty;

        if (_ResourceOpServiceRequest.RequestUri != null
          && _ResourceOpServiceRequest.RequestUri.FhirRequestUri != null
          && !string.IsNullOrWhiteSpace(_ResourceOpServiceRequest.RequestUri.FhirRequestUri.ResourceId))
        {
          ResourceIdToDelete = _ResourceOpServiceRequest.RequestUri.FhirRequestUri.ResourceId;
          IResourceServiceRequestGetRead req = Common.CommonFactory.GetResourceServiceRequestGetRead(ResourceIdToDelete, _ResourceOpServiceRequest.RequestUri, _ResourceOpServiceRequest.SearchParameterGeneric, _ResourceOpServiceRequest.RequestHeaders);
          var result = _ResourceOpServiceRequest.ResourceServices.GetRead(req);
          if (result.ResourceResult != null)
          {
            if (result.IsDeleted.HasValue && result.IsDeleted.Value)
            {
              //We have it but it is deleted
              //There is no resource to delete
              string Message = $"The Resource is in the server's history the most current instance is already deleted, {ValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}/{ValidationOperationItems.ResourceToValidate.Id}";
              var ResourceIdIssue = new OperationOutcome.IssueComponent();
              ResourceIdIssue.Severity = OperationOutcome.IssueSeverity.Warning;
              ResourceIdIssue.Code = OperationOutcome.IssueType.NotFound;
              ResourceIdIssue.Details = new CodeableConcept("http://hl7.org/fhir/ValueSet/operation-outcome", "SG_DELETED_ID", Message);
              ModeValidationOpOutCome.Issue.Add(ResourceIdIssue);
            }
          }
          else
          {
            //There is no resource to delete
            string Message = $"The Resource is not found in the server, their is no resource to delete for {ValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}/{ValidationOperationItems.ResourceToValidate.Id}";
            var ResourceIdIssue = new OperationOutcome.IssueComponent();
            ResourceIdIssue.Severity = OperationOutcome.IssueSeverity.Warning;
            ResourceIdIssue.Code = OperationOutcome.IssueType.NotFound;
            ResourceIdIssue.Details = new CodeableConcept("http://hl7.org/fhir/ValueSet/operation-outcome", "MSG_DELETED", Message);
            ModeValidationOpOutCome.Issue.Add(ResourceIdIssue);
          }
        }
      }
      else if (ValidationOperationItems.ValidationMode == ResourceValidationModeType.None)
      {
        // No Validation required for None.
      }
      else
      {
        throw new System.ComponentModel.InvalidEnumArgumentException(ValidationOperationItems.ValidationMode.ToString(), (int)ValidationOperationItems.ValidationMode, typeof(ResourceValidationModeType));
      }
    }

    private void ObtainOperationItemsFromSearchParameters(ISearchParametersServiceOutcome SearchParametersServiceOutcome, ValidationOperationItems ValidationOperationItems)
    {
      var ProFileSearchParameter = SearchParametersServiceOutcome.SearchParameters.SearchParametersList.SingleOrDefault(x => x.Name == "profile");
      if (ProFileSearchParameter is Search.DtoSearchParameterUri ProfileSearchUri)
      {
        if (ProfileSearchUri.ValueList != null && ProfileSearchUri.ValueList.Count > 0)
        {
          ValidationOperationItems.ProfileUri = ProfileSearchUri.ValueList[0].Value.OriginalString;
        }
      }

      var ModeSearchParameter = SearchParametersServiceOutcome.SearchParameters.SearchParametersList.SingleOrDefault(x => x.Name == "mode");
      if (ModeSearchParameter != null
        && ModeSearchParameter is Search.DtoSearchParameterToken ModeSearchUri)
      {
        if (ModeSearchUri.ValueList != null && ModeSearchUri.ValueList.Count > 0)
        {
          string Mode = ModeSearchUri.ValueList[0].Code;
          switch (Mode.ToLower())
          {
            case "create":
              ValidationOperationItems.ValidationMode = ResourceValidationModeType.Create;
              break;
            case "update":
              ValidationOperationItems.ValidationMode = ResourceValidationModeType.Update;
              break;
            case "delete":
              ValidationOperationItems.ValidationMode = ResourceValidationModeType.Delete;
              break;
            default:
              ValidationOperationItems.ValidationMode = null;
              break;
          }
        }
      }
      else
      {
        ValidationOperationItems.ValidationMode = ResourceValidationModeType.None;
      }
    }

    private ISearchParametersServiceOutcome ParseUrlSearchParameters(Interfaces.Dto.IDtoSearchParameterGeneric SearchParameterGeneric, FhirOperation.OperationClass OperationClass)
    {
      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.CommonServices = null;
      SearchParametersServiceRequest.SearchParameterGeneric = SearchParameterGeneric;
      var SearchParameterService = new SearchParameterService();
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Operation;
      SearchParametersServiceRequest.ResourceType = null;
      SearchParametersServiceRequest.OperationClass = OperationClass;
      return SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
    }

    private ValidationOperationItems ConsoladateValidationOperationItems(ValidationOperationItems FromUrl, ValidationOperationItems FromParameters)
    {
      var OpOutComeIssues = new List<OperationOutcome.IssueComponent>();
      var ReturnValidationOperationItems = new ValidationOperationItems();

      //Profile
      string ServiceBaseURL = new Common.Cache.CacheCommon().WebConfigServiceBaseURL(); ;
      string ErrorMessageFromUrl = string.Empty;
      IFhirRequestUri FhirRequestUriFromUrl = null;
      if (!string.IsNullOrWhiteSpace(FromUrl.ProfileUri))
      {
        if (UriSupport.FhirRequestUri.TryParse(ServiceBaseURL, FromUrl.ProfileUri, out FhirRequestUriFromUrl, out ErrorMessageFromUrl))
        {
          ReturnValidationOperationItems.FhirRequestUriProfileUri = FhirRequestUriFromUrl;
        }
      }

      string ErrorMessageFromParameters = string.Empty;
      IFhirRequestUri FhirRequestUriFromParameters = null;
      if (FhirRequestUriFromUrl == null && !string.IsNullOrWhiteSpace(FromParameters.ProfileUri))
      {
        if (UriSupport.FhirRequestUri.TryParse(ServiceBaseURL, FromParameters.ProfileUri, out FhirRequestUriFromParameters, out ErrorMessageFromParameters))
        {
          ReturnValidationOperationItems.FhirRequestUriProfileUri = FhirRequestUriFromUrl;
        }
      }
      if (FhirRequestUriFromUrl != null)
      {
        ReturnValidationOperationItems.FhirRequestUriProfileUri = FhirRequestUriFromUrl;
        ReturnValidationOperationItems.ProfileUri = FromUrl.ProfileUri;
      }
      else if (FhirRequestUriFromParameters != null)
      {
        ReturnValidationOperationItems.FhirRequestUriProfileUri = FhirRequestUriFromParameters;
        ReturnValidationOperationItems.ProfileUri = FromParameters.ProfileUri;
      }
      else if (!string.IsNullOrWhiteSpace(ErrorMessageFromUrl) || !string.IsNullOrWhiteSpace(ErrorMessageFromParameters))
      {
        var OpOutComeIssue = Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"The Profile URI's provided can not be parsed as FHIR URI's. Parsing error messages are: {ErrorMessageFromUrl}, {ErrorMessageFromParameters} ");
        IssueList.Add(OpOutComeIssue);
      }

      //Mode
      if (!FromUrl.ValidationMode.HasValue && !FromParameters.ValidationMode.HasValue)
      {
        string Message = $"The mode property is not set to a valid value. Must be either (create, update, delete) or not set at all.";
        var OpOutComeIssue = Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, Message);
        IssueList.Add(OpOutComeIssue);
      }
      else if (FromUrl.ValidationMode.HasValue)
      {
        ReturnValidationOperationItems.ValidationMode = FromUrl.ValidationMode.Value;
      }
      else if (FromParameters.ValidationMode.HasValue)
      {
        ReturnValidationOperationItems.ValidationMode = FromParameters.ValidationMode.Value;
      }
      else
      {
        throw new Exception("Server error: Mode parameter not found in Parameter Resource or URL, yet null check failed. ");
      }

      //Resource
      if (FromParameters.ResourceToValidate != null)
      {
        ReturnValidationOperationItems.ResourceToValidate = FromParameters.ResourceToValidate;
      }
      else
      {
        ReturnValidationOperationItems.ResourceToValidate = FromUrl.ResourceToValidate;
      }

      //Report Errors
      if (IssueList.Count > 0)
      {
        ReturnValidationOperationItems.OperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList);
      }

      return ReturnValidationOperationItems;
    }

    private bool CheckResourceEndpointMatchesResourceToBeValidated(ResourceType ResourceType)
    {
      if (_ResourceOpServiceRequest.RequestUri.FhirRequestUri.ResourseName != ResourceType.GetLiteral())
      {
        var OpOutComeIssue = Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
        $"The Resource endpoint of the request URL does not match the Resource provided to be validated in the request body. URL Resource:  {_ResourceOpServiceRequest.RequestUri.FhirRequestUri.ResourseName}, Request body Resource: {ResourceType.GetLiteral()}");
        IssueList.Add(OpOutComeIssue);
        return false;
      }
      return true;
    }

    private OperationOutcome PerformValidation(ValidationOperationItems ValidationOperationItems)
    {
      var ValidationSupport = new Tools.FhirResourceValidation.FhirValidationSupport(_ResourceOpServiceRequest.ResourceServices);
      return ValidationSupport.Validate(ValidationOperationItems.ResourceToValidate, new List<string> { ValidationOperationItems.ProfileUri });
    }

    private OperationOutcome AllOkOperationOutcome()
    {
      return Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Information, OperationOutcome.IssueType.Informational,
        "All OK");
    }

    private IResourceServiceOutcome FinalResourceServiceOutcome(List<OperationOutcome.IssueComponent> IssueList)
    {
      IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      //Success is based on the IssueComponent's Severity where True if 
      //Severity = null, or not IssueSeverity.Information or IssueSeverity.Warning 
      //all other Severity return Success as False 
      //Here is the actual API Code:
      //return Severity != null && (Severity.Value == IssueSeverity.Information || Severity.Value == IssueSeverity.Warning);
      if (IssueList.Count == 0)
      {
        ResourceServiceOutcome.ResourceResult = AllOkOperationOutcome();
        ResourceServiceOutcome.ResourceResult.Id = "allok";
      }
      if (IssueList.Any(x => x.Success == false))
      {
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList); ;
        ResourceServiceOutcome.ResourceResult.Id = "validationfail";
      }
      else
      {
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
        ResourceServiceOutcome.SuccessfulTransaction = true;
        ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList); ;
        ResourceServiceOutcome.ResourceResult.Id = "validationfail";
      }
      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
      ResourceServiceOutcome.FormatMimeType = FormatMimeType;
      return ResourceServiceOutcome;
    }


    private class ValidationOperationItems
    {
      public ResourceValidationModeType? ValidationMode { get; set; }
      public string ProfileUri { get; set; }
      public IFhirRequestUri FhirRequestUriProfileUri { get; set; }
      public Resource ResourceToValidate { get; set; }
      public OperationOutcome OperationOutcome { get; set; }
    }

  }
}
