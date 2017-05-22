using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ServerSearchParameterService : IServerSearchParameterService
  {
    public IBaseOperationsServiceRequest _ServiceRequest;
    private const string _ParameterName = "ResourceType";
    private SearchParameter TargetSearchParameter;

    internal ServerSearchParameterService(IBaseOperationsServiceRequest ServiceRequest)
    {
      this._ServiceRequest = ServiceRequest;
    }

    public IResourceServiceOutcome ProcessSet()
    {
      if (string.IsNullOrWhiteSpace(_ServiceRequest.OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (_ServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (_ServiceRequest.RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (_ServiceRequest.RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (_ServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (_ServiceRequest.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (_ServiceRequest.ServiceNegotiator == null)
        throw new NullReferenceException("ServiceNegotiator cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.CommonServices = null;
      SearchParametersServiceRequest.SearchParameterGeneric = _ServiceRequest.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      if (_ServiceRequest.Resource != null && _ServiceRequest.Resource is Parameters Parameters)
      {
        if (Parameters.Parameter != null || Parameters.Parameter.Count() == 0)
        {
          IResourceServicesBase ResourceServicesSearchParameter = _ServiceRequest.ServiceNegotiator.GetResourceServiceBase(ResourceType.SearchParameter.GetLiteral());
          Parameters ReturnParametersResource = new Parameters();
          if (string.IsNullOrWhiteSpace(Parameters.Id))
            ReturnParametersResource.Id = $"{Parameters.Id}_Response";
          else
            ReturnParametersResource.Id = $"{Enum.FhirOperationEnum.BaseOperationType.ServerSearchParameterSet.GetPyroLiteral()}_Response";
          ReturnParametersResource.Parameter = new List<Parameters.ParameterComponent>();

          foreach (var Para in Parameters.Parameter)
          {
            if (Para.Value != null && Para.Value is ResourceReference Ref)
            {
              IFhirRequestUri FhirUri;
              string ErrorMessageFhirUri;
              if (UriSupport.FhirRequestUri.TryParse(_ServiceRequest.RequestUri.FhirRequestUri.PrimaryServiceRootServers.OriginalString, Ref.Reference, out FhirUri, out ErrorMessageFhirUri))
              {
                if (FhirUri.IsRelativeToServer)
                {
                  if (!FhirUri.IsHistoryReferance)
                  {
                    if (!FhirUri.IsContained)
                    {
                      if (!FhirUri.IsOperation)
                      {
                        var ResourceServiceOutcomeGetSearchParameterResource = Common.CommonFactory.GetResourceServiceOutcome();
                        ResourceServiceOutcomeGetSearchParameterResource = ResourceServicesSearchParameter.GetResourceInstance(FhirUri.ResourceId, _ServiceRequest.RequestUri, ResourceServiceOutcomeGetSearchParameterResource);
                        if (ResourceServiceOutcomeGetSearchParameterResource.HttpStatusCode == System.Net.HttpStatusCode.OK)
                        {
                          TargetSearchParameter = ResourceServiceOutcomeGetSearchParameterResource.ResourceResult as SearchParameter;
                          OperationOutcome OperationOutcomeValidation = ValidateSearchParameterResource(TargetSearchParameter);
                          if (OperationOutcomeValidation == null)
                          {
                            foreach(var Base in TargetSearchParameter.Base)
                            {
                              var DbSearchParamListForResource = (ResourceServicesSearchParameter as ICommonServices).GetServiceSearchParametersHeavyForResource(Base.Value.GetLiteral());
                              DbSearchParamListForResource.AddRange((ResourceServicesSearchParameter as ICommonServices).GetServiceSearchParametersHeavyForResource(ResourceType.Resource.GetLiteral()));
                              var CodeAlreadyIndexed= DbSearchParamListForResource.SingleOrDefault(x => x.Name == TargetSearchParameter.Code && x.SearchParameterResourceId != null);
                              if (CodeAlreadyIndexed == null)
                              {
                                CodeAlreadyIndexed = DbSearchParamListForResource.SingleOrDefault(x => x.Name == TargetSearchParameter.Code && x.SearchParameterResourceId == null);
                                if (CodeAlreadyIndexed == null)
                                {
                                  var NewServiceSearchParameter = new Dto.DtoServiceSearchParameterHeavy();
                                  if (TargetSearchParameter.Description != null)
                                    NewServiceSearchParameter.Description = TargetSearchParameter.Description.Value;
                                  NewServiceSearchParameter.Expression = TargetSearchParameter.Expression;
                                  NewServiceSearchParameter.Name = TargetSearchParameter.Code;
                                  NewServiceSearchParameter.Resource = Base.GetLiteral();
                                  NewServiceSearchParameter.SearchParameterResourceId = TargetSearchParameter.Id;
                                  NewServiceSearchParameter.SearchParameterResourceVersion = TargetSearchParameter.Version;
                                  NewServiceSearchParameter.TargetResourceTypeList = new List<Interfaces.Dto.IServiceSearchParameterTargetResource>();
                                  if (TargetSearchParameter.Target != null)
                                  {
                                    foreach (var Target in TargetSearchParameter.Target)
                                    {
                                      if (Target.HasValue)
                                        NewServiceSearchParameter.TargetResourceTypeList.Add(new Dto.DtoServiceSearchParameterTargetResource() { ResourceType = Target.Value });
                                    }
                                  }
                                  NewServiceSearchParameter.Type = TargetSearchParameter.Type.Value;
                                  NewServiceSearchParameter.Url = TargetSearchParameter.Url;
                                  NewServiceSearchParameter.XPath = TargetSearchParameter.Xpath;
                                  NewServiceSearchParameter.Status = TargetSearchParameter.Status.Value;
                                  NewServiceSearchParameter.IsIndexed = false;

                                  //Add the new SearchParameterIndex to the database
                                  (ResourceServicesSearchParameter as ICommonServices).AddServiceSearchParametersHeavy(NewServiceSearchParameter);
                                  
                                }
                                else
                                {
                                  var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The SearchParameter referenced has a Code element that in already indexed. This Code of {CodeAlreadyIndexed.Name} is a base FHIR search parameter and can not be modified. You could try a different Code value and thereby create a separate search parameter index.");
                                  ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                                  ResourceServiceOutcome.ResourceResult = OpOutCome;
                                  ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                                  ResourceServiceOutcome.SuccessfulTransaction = false;
                                  return ResourceServiceOutcome;
                                }
                              }
                              else
                              {
                                var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The SearchParameter referenced in already associated with the servers search indexes. If you wish to modify the SearchParameter then you need only to update the resource id={CodeAlreadyIndexed.SearchParameterResourceId} and then call the Update indexes operation {Enum.FhirOperationEnum.BaseOperationType.serverSearchParameterIndexPending.GetPyroLiteral()}");
                                ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                                ResourceServiceOutcome.ResourceResult = OpOutCome;
                                ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                                ResourceServiceOutcome.SuccessfulTransaction = false;
                                return ResourceServiceOutcome;
                              }
                            }                            
                          }
                          else
                          {                                                        
                            ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                            ResourceServiceOutcome.ResourceResult = OperationOutcomeValidation;
                            ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                            ResourceServiceOutcome.SuccessfulTransaction = false;
                            return ResourceServiceOutcome;
                          }
                        }
                        else
                        {
                          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"No SearchParameter resource found in the server for the ResourceReference: {FhirUri.OriginalString}");
                          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                          ResourceServiceOutcome.ResourceResult = OpOutCome;
                          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                          ResourceServiceOutcome.SuccessfulTransaction = false;
                          return ResourceServiceOutcome;
                        }
                      }
                      else
                      {
                        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must not be an $Operation reference, value was: {FhirUri.OriginalString}");
                        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                        ResourceServiceOutcome.ResourceResult = OpOutCome;
                        ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                        ResourceServiceOutcome.SuccessfulTransaction = false;
                        return ResourceServiceOutcome;
                      }
                    }
                    else
                    {
                      var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must not be a #Contained reference, value was: {FhirUri.OriginalString}");
                      ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                      ResourceServiceOutcome.ResourceResult = OpOutCome;
                      ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                      ResourceServiceOutcome.SuccessfulTransaction = false;
                      return ResourceServiceOutcome;
                    }
                  }
                  else
                  {
                    var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must not be a Version specific reference, value was: {FhirUri.OriginalString}");
                    ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    ResourceServiceOutcome.ResourceResult = OpOutCome;
                    ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                    ResourceServiceOutcome.SuccessfulTransaction = false;
                    return ResourceServiceOutcome;
                  }
                }
                else
                {
                  var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value must be relative to the server, value was: {FhirUri.OriginalString}");
                  ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                  ResourceServiceOutcome.ResourceResult = OpOutCome;
                  ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                  ResourceServiceOutcome.SuccessfulTransaction = false;
                  return ResourceServiceOutcome;
                }
              }
              else
              {
                var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element ResourceReference value was not able to be parsed, Error message: {ErrorMessageFhirUri}");
                ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                ResourceServiceOutcome.ResourceResult = OpOutCome;
                ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                ResourceServiceOutcome.SuccessfulTransaction = false;
                return ResourceServiceOutcome;
              }
            }
            else
            {
              var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource's parameter element either had no value or the value was not a ResourceReference value type.");
              ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
              ResourceServiceOutcome.ResourceResult = OpOutCome;
              ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
              ResourceServiceOutcome.SuccessfulTransaction = false;
              return ResourceServiceOutcome;
            }
          }
          var ReturnParameter = new Parameters.ParameterComponent();
          ReturnParameter.Name = "SearchParameterRegisteredForIndexing";
          ReturnParameter.Resource = TargetSearchParameter;
          ReturnParametersResource.Parameter.Add(ReturnParameter);

          //All good return ParametersResource with the SearchParameter Resource registered.
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
          ResourceServiceOutcome.ResourceResult = ReturnParametersResource;
          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
          ResourceServiceOutcome.SuccessfulTransaction = true;
          return ResourceServiceOutcome;
        }
        else
        {
          var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Parameters resource contains no parameter elements.");
          ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
          ResourceServiceOutcome.ResourceResult = OpOutCome;
          ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
          ResourceServiceOutcome.SuccessfulTransaction = false;
          return ResourceServiceOutcome;
        }
      }
      else
      {
        //The Resource given was not a Parameters resource
        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.NotSupported, $"The Resource given on this operation must be a SearchParameter type FHIR resource.");
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.ResourceResult = OpOutCome;
        ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }
      
    }
    
    public IResourceServiceOutcome ProcessReport()
    {
      if (string.IsNullOrWhiteSpace(_ServiceRequest.OperationName))
        throw new NullReferenceException("OperationName cannot be null.");
      if (_ServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (_ServiceRequest.RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (_ServiceRequest.RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (_ServiceRequest.Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (_ServiceRequest.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (_ServiceRequest.ServiceNegotiator == null)
        throw new NullReferenceException("ServiceNegotiator cannot be null.");

      IResourceServiceOutcome ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();

      ISearchParametersServiceRequest SearchParametersServiceRequest = Common.CommonFactory.GetSearchParametersServiceRequest();
      SearchParametersServiceRequest.CommonServices = null;
      SearchParametersServiceRequest.SearchParameterGeneric = _ServiceRequest.SearchParameterGeneric;
      SearchParametersServiceRequest.SearchParameterServiceType = SearchParameterService.SearchParameterServiceType.Base;
      SearchParametersServiceRequest.ResourceType = null;
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchParameterService.ProcessSearchParameters(SearchParametersServiceRequest);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.SearchParametersServiceOutcome = SearchParametersServiceOutcome;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      ICommonServices oCommonServices = _ServiceRequest.ServiceNegotiator.GetCommonService();

      List<Dto.DtoServiceSearchParameterHeavy> DbSearchParameterList = oCommonServices.GetServiceSearchParametersHeavy(true);
      CalculateDiff(DbSearchParameterList);

      throw new NotImplementedException();
    }

    private void CalculateDiff(List<DtoServiceSearchParameterHeavy> dbSearchParameterList)
    {
      foreach(var Para in dbSearchParameterList)
      {
        var oResService = _ServiceRequest.ServiceNegotiator.GetResourceServiceBase(ResourceType.SearchParameter.GetLiteral());
        var ResourceServiceOutcome = Common.CommonFactory.GetResourceServiceOutcome();
        ResourceServiceOutcome = oResService.GetResourceInstance(Para.SearchParameterResourceId, _ServiceRequest.RequestUri, ResourceServiceOutcome);
        if (ResourceServiceOutcome.ResourceResult != null)
        {
          if (ResourceServiceOutcome.ResourceVersionNumber != Para.SearchParameterResourceVersion)
          {
            //It is a new version so check for diff, unless it is not indexed in which case it is just new but the resource was updated 
            //post registering.
          }
          else
          {
            //it is the very same version, so nothing to changed but still need to check it is already indexed
            //if not it is new and needs to be added. If it is indexed then nothing to do.
          }
        }
        else
        {
          throw new Exception($"Internal Server error: Database misalignment, A custom service search parameter references the SearchParameter Resource wiht the id= {Para.SearchParameterResourceId} and yet that resource does not exist at all.");
        }

      }
      _ServiceRequest.ServiceNegotiator.GetCommonService();
    }

    public IResourceServiceOutcome ProcessIndex()
    {
      throw new NotImplementedException();
    }

    private OperationOutcome ValidateSearchParameterResource(SearchParameter Resource)
    {      
      var IssueList = new List<OperationOutcome.IssueComponent>();

      if (string.IsNullOrWhiteSpace(Resource.Code))
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} must have a Code element that is not empty.";
        IssueList.Add(Issue);
      }

      if (Resource.Base == null || Resource.Base.Count() == 0)
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} must have a least one base element.";
        IssueList.Add(Issue);
      }
      else
      {
        foreach(var Item in Resource.Base)
        {
          if (!Item.HasValue)
          {
            var Issue = new OperationOutcome.IssueComponent();
            Issue.Severity = OperationOutcome.IssueSeverity.Error;
            Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} base element was null or perhaps not a known FHIR Resource type.";
            IssueList.Add(Issue);
          }          
        }
      }



      if (!Resource.Type.HasValue)
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource with the id={Resource.Id} must have a Type element that is not empty.";
        IssueList.Add(Issue);
      }
      

      if (string.IsNullOrWhiteSpace(Resource.Expression))
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} must have an Expression element that is not empty.";
        IssueList.Add(Issue);
      }

      if (!Resource.Status.HasValue)
      {
        var Issue = new OperationOutcome.IssueComponent();
        Issue.Severity = OperationOutcome.IssueSeverity.Error;
        Issue.Diagnostics = $"The SearchParameter Resource  with the id={Resource.Id} must have a Status element that is not empty.";
        IssueList.Add(Issue);
      }

      if (IssueList.Count > 0)
      {
        var OperationOutCome = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList);
        return OperationOutCome;
      }
      else
      {
        return null;
      }
    }

  }
}
