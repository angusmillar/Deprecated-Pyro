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
using Pyro.Common.Tools.FhirResourceValidation;
using Pyro.Common.RequestMetadata;

namespace Pyro.Common.Service
{
  public class FhirValidateOperationService : IFhirValidateOperationService
  {
    enum ResourceValidationModeType { None, Create, Update, Delete };
    List<OperationOutcome.IssueComponent> IssueList = null;
    string FormatMimeType = string.Empty;
    IResourceServiceOutcome ResourceServiceOutcome;
    
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IResourceServices IResourceServices;
    private readonly IFhirValidationSupport IFhirValidationSupport;
    private readonly IRequestMetaFactory IRequestMetaFactory;

    public FhirValidateOperationService(
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      IPyroFhirUriFactory IPyroFhirUriFactory,
      ISearchParameterServiceFactory ISearchParameterServiceFactory,
      IResourceServices IResourceServices,
      IFhirValidationSupport IFhirValidationSupport,
      IRequestMetaFactory IRequestMetaFactory)
    {
      //this.ICommonFactory = ICommonFactory;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.IResourceServices = IResourceServices;
      this.IFhirValidationSupport = IFhirValidationSupport;
      this.IRequestMetaFactory = IRequestMetaFactory;
    }

    public IResourceServiceOutcome ValidateResource(OperationClass OperationClass, Resource Resource, IRequestMeta RequestMeta)
    {
      if (OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta cannot be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeader cannot be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null."); 
      if (IFhirValidationSupport == null)
        throw new NullReferenceException("IFhirValidationSupport cannot be null.");


      IssueList = new List<OperationOutcome.IssueComponent>();

      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParametersServiceOutcome SearchParametersServiceOutcome = ParseUrlSearchParameters(RequestMeta.SearchParameterGeneric, OperationClass);
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
      if (Resource.ResourceType == ResourceType.Parameters)
      {
        ValidationOperationItemsFromParametersResource = ValidateParameterResource(Resource as Parameters);
      }
      else
      {
        ValidationOperationItemsFromUrl.ResourceToValidate = Resource;
      }

      ValidationOperationItems FinalValidationOperationItems = ConsoladateValidationOperationItems(ValidationOperationItemsFromUrl, ValidationOperationItemsFromParametersResource);
      if (FinalValidationOperationItems == null)
      {
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
        if (!CheckResourceEndpointMatchesResourceToBeValidated(FinalValidationOperationItems.ResourceToValidate.ResourceType, RequestMeta.PyroRequestUri))
        {
          return FinalResourceServiceOutcome(IssueList);
        }

        if (FinalValidationOperationItems.FhirRequestUriProfileUri != null)
        {
          OperationOutcome ProfileValidationOpOutCome = PerformValidation(FinalValidationOperationItems);
          PerformModeValidation(ProfileValidationOpOutCome, FinalValidationOperationItems, RequestMeta);
          IssueList.AddRange(ProfileValidationOpOutCome.Issue);
          return FinalResourceServiceOutcome(IssueList);
        }
        else
        {
          OperationOutcome ModeValidationOpOutCome = new OperationOutcome();
          PerformModeValidation(ModeValidationOpOutCome, FinalValidationOperationItems, RequestMeta);
          // There is no profile given to validate against. 
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"The Resource provided for validation '{FinalValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}' must match the resource endpoint in the URL '{RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName}'");
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

    public IResourceServiceOutcome ValidateResourceInstance(
      OperationClass OperationClass,
      Resource Resource,
      IRequestMeta RequestMeta)
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
        throw new NullReferenceException("PyroRequestUri cannot be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeader cannot be null.");     
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");      
      if (RequestMeta.PyroRequestUri.FhirRequestUri == null)
        throw new NullReferenceException("(RequestUri.FhirRequestUri cannot be null");
      if (string.IsNullOrWhiteSpace(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId))
        throw new NullReferenceException("Resource Id endpoint must be used for ValidateResourceInstance.");
      if (IFhirValidationSupport == null)
        throw new NullReferenceException("IFhirValidationSupport cannot be null.");

      IssueList = new List<OperationOutcome.IssueComponent>();

      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

      ISearchParametersServiceOutcome SearchParametersServiceOutcome = ParseUrlSearchParameters(RequestMeta.SearchParameterGeneric, OperationClass);
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
      if (Resource.ResourceType == ResourceType.Parameters)
      {
        ValidationOperationItemsFromParametersResource = ValidateParameterResource(Resource as Parameters);
      }
      else
      {
        ValidationOperationItemsFromUrl.ResourceToValidate = Resource;
      }

      ValidationOperationItems FinalValidationOperationItems = ConsoladateValidationOperationItems(ValidationOperationItemsFromUrl, ValidationOperationItemsFromParametersResource);
      if (FinalValidationOperationItems == null)
      {
        return FinalResourceServiceOutcome(IssueList);
      }

      if (FinalValidationOperationItems.ResourceToValidate != null)
      {
        if (!CheckResourceEndpointMatchesResourceToBeValidated(FinalValidationOperationItems.ResourceToValidate.ResourceType, RequestMeta.PyroRequestUri))
        {
          return FinalResourceServiceOutcome(IssueList);
        }

        if (FinalValidationOperationItems.FhirRequestUriProfileUri != null)
        {
          OperationOutcome ProfileValidationOpOutCome = PerformValidation(FinalValidationOperationItems);
          PerformModeValidation(ProfileValidationOpOutCome, FinalValidationOperationItems, RequestMeta);
          IssueList.AddRange(ProfileValidationOpOutCome.Issue);
          return FinalResourceServiceOutcome(IssueList);
        }
        else
        {
          // There is no profile given to validate against. 
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"The Resource provided for validation '{FinalValidationOperationItems.ResourceToValidate.ResourceType.GetLiteral()}' must match the resource endpoint in the URL '{RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName}'");
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
          PerformModeValidation(OpOutCome, FinalValidationOperationItems, RequestMeta);
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

    private void PerformModeValidation(OperationOutcome ModeValidationOpOutCome, ValidationOperationItems ValidationOperationItems, IRequestMeta RequestMeta)
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
        
        if (RequestMeta.PyroRequestUri != null
          && RequestMeta.PyroRequestUri.FhirRequestUri != null
          && !string.IsNullOrWhiteSpace(RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId))
        {
          IResourceServices.SetCurrentResourceType(RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName);
          IRequestMeta RequestMetaGetRead = IRequestMetaFactory.CreateRequestMeta().Set($"{RequestMeta.PyroRequestUri.FhirRequestUri.ResourseName}/{RequestMeta.PyroRequestUri.FhirRequestUri.ResourceId}");          
          var result = IResourceServices.GetRead(RequestMetaGetRead.PyroRequestUri.FhirRequestUri.ResourceId, RequestMetaGetRead);
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
      if (ProFileSearchParameter is SearchParameterUri ProfileSearchUri)
      {
        if (ProfileSearchUri.ValueList != null && ProfileSearchUri.ValueList.Count > 0)
        {
          ValidationOperationItems.ProfileUri = ProfileSearchUri.ValueList[0].Value.OriginalString;
        }
      }

      var ModeSearchParameter = SearchParametersServiceOutcome.SearchParameters.SearchParametersList.SingleOrDefault(x => x.Name == "mode");
      if (ModeSearchParameter != null
        && ModeSearchParameter is SearchParameterToken ModeSearchUri)
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

    private ISearchParametersServiceOutcome ParseUrlSearchParameters(ISearchParameterGeneric SearchParameterGeneric, FhirOperation.OperationClass OperationClass)
    {
      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      return SearchService.ProcessOperationSearchParameters(SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Base | SearchParameterService.SearchParameterServiceType.Operation, OperationClass);
    }

    private ValidationOperationItems ConsoladateValidationOperationItems(ValidationOperationItems FromUrl, ValidationOperationItems FromParameters)
    {
      var OpOutComeIssues = new List<OperationOutcome.IssueComponent>();
      var ReturnValidationOperationItems = new ValidationOperationItems();

      //Profile
      IPyroFhirUri FhirRequestUriFromUrl = null;
      IPyroFhirUri FhirRequestUriFromParameters = null;

      if (string.IsNullOrWhiteSpace(FromUrl.ProfileUri) && string.IsNullOrWhiteSpace(FromParameters.ProfileUri))
      {
        var OpOutComeIssue = Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"No Profile URI found in either the request URL or the Parameter body, Validation cannot be performed with out a profile reference.");
        IssueList.Add(OpOutComeIssue);
      }
      else if (!string.IsNullOrWhiteSpace(FromUrl.ProfileUri))
      {
        FhirRequestUriFromUrl = IPyroFhirUriFactory.CreateFhirRequestUri();
        if (FhirRequestUriFromUrl.Parse(FromUrl.ProfileUri))
        {
          ReturnValidationOperationItems.FhirRequestUriProfileUri = FhirRequestUriFromUrl;
          ReturnValidationOperationItems.ProfileUri = FromUrl.ProfileUri;
        }
        else
        {
          var OpOutComeIssue = Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"Error in parsing the profile URI found in the request URL, parse error is: {FhirRequestUriFromUrl.ParseErrorMessage}");
          IssueList.Add(OpOutComeIssue);
        }
      }
      else if (!string.IsNullOrWhiteSpace(FromParameters.ProfileUri))
      {
        FhirRequestUriFromParameters = IPyroFhirUriFactory.CreateFhirRequestUri();
        if (FhirRequestUriFromParameters.Parse(FromParameters.ProfileUri))
        {
          ReturnValidationOperationItems.FhirRequestUriProfileUri = FhirRequestUriFromParameters;
          ReturnValidationOperationItems.ProfileUri = FromParameters.ProfileUri;
        }
        else
        {
          var OpOutComeIssue = Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
          $"Error in parsing the profile URI found in the Parameters resource, parse error is: {FhirRequestUriFromParameters.ParseErrorMessage}");
          IssueList.Add(OpOutComeIssue);
        }
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
        return null;
      }

      return ReturnValidationOperationItems;
    }

    private bool CheckResourceEndpointMatchesResourceToBeValidated(ResourceType ResourceType, IPyroRequestUri RequestUri)
    {
      if (RequestUri.FhirRequestUri.ResourseName != ResourceType.GetLiteral())
      {
        var OpOutComeIssue = Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported,
        $"The Resource endpoint of the request URL does not match the Resource provided to be validated in the request body. URL Resource:  {RequestUri.FhirRequestUri.ResourseName}, Request body Resource: {ResourceType.GetLiteral()}");
        IssueList.Add(OpOutComeIssue);
        return false;
      }
      return true;
    }

    private OperationOutcome PerformValidation(ValidationOperationItems ValidationOperationItems)
    {
      return IFhirValidationSupport.Validate(ValidationOperationItems.ResourceToValidate, new List<string> { ValidationOperationItems.ProfileUri });
    }

    private OperationOutcome AllOkOperationOutcome()
    {
      return Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Information, OperationOutcome.IssueType.Informational,
        "All OK");
    }

    private IResourceServiceOutcome FinalResourceServiceOutcome(List<OperationOutcome.IssueComponent> IssueList)
    {
      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();

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
      else
      {
        if (IssueList.Any(x => x.Success == false))
        {          
          
          ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList); ;
          ResourceServiceOutcome.ResourceResult.Id = "validationfail";
        }
        else
        {                    
          ResourceServiceOutcome.ResourceResult = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList); ;
          ResourceServiceOutcome.ResourceResult.Id = "InformationOrWarning";
        }
      }
      ResourceServiceOutcome.SuccessfulTransaction = true;
      ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
      ResourceServiceOutcome.FormatMimeType = FormatMimeType;
      return ResourceServiceOutcome;
    }

    private class ValidationOperationItems
    {
      public ResourceValidationModeType? ValidationMode { get; set; }
      public string ProfileUri { get; set; }
      public IPyroFhirUri FhirRequestUriProfileUri { get; set; }
      public Resource ResourceToValidate { get; set; }
    }

  }
}
