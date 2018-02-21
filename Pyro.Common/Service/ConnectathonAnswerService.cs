using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Enum;
using Pyro.Common.Search;
using Pyro.Common.Global;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Tools.Connectathon;
using System;
using System.Collections.Generic;
using Pyro.Common.Tools.Headers;

namespace Pyro.Common.Service
{
  public class ConnectathonAnswerService : IConnectathonAnswerService
  {
    private readonly IResourceServices IResourceServices;
    private readonly ICommonFactory ICommonFactory;
    private readonly IGlobalProperties IGlobalProperties;
    private readonly ISearchParameterGenericFactory ISearchParameterGenericFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;

    private string _OperationName = FhirOperationEnum.OperationType.ConnectathonAnswer.GetPyroLiteral();
    private readonly string _ParameterName = "answers";
    private readonly string _PrimaryQuestionnaireResponseAnswerResourceId = "AngusA1";
    private readonly string _QuestionnaireResourceId = "PerthQuestions";

    public ConnectathonAnswerService(IResourceServices IResourceServices, ICommonFactory ICommonFactory, ISearchParameterGenericFactory ISearchParameterGenericFactory, ISearchParameterServiceFactory ISearchParameterServiceFactory, IGlobalProperties IGlobalProperties)
    {
      this.IResourceServices = IResourceServices;
      this.ICommonFactory = ICommonFactory;
      this.IGlobalProperties = IGlobalProperties;
      this.ISearchParameterGenericFactory = ISearchParameterGenericFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
    }

    public IResourceServiceOutcome Process(
          IPyroRequestUri RequestUri,
          ISearchParameterGeneric SearchParameterGeneric,
          Resource Resource)
    {

      IResourceServiceOutcome ResourceServiceOutcome = ICommonFactory.CreateResourceServiceOutcome();
      var IssueList = new List<OperationOutcome.IssueComponent>();

      ISearchParameterService SearchService = ISearchParameterServiceFactory.CreateSearchParameterService();
      ISearchParametersServiceOutcome SearchParametersServiceOutcome = SearchService.ProcessBaseSearchParameters(SearchParameterGeneric);
      if (SearchParametersServiceOutcome.FhirOperationOutcome != null)
      {
        ResourceServiceOutcome.ResourceResult = SearchParametersServiceOutcome.FhirOperationOutcome;
        ResourceServiceOutcome.HttpStatusCode = SearchParametersServiceOutcome.HttpStatusCode;
        ResourceServiceOutcome.FormatMimeType = SearchParametersServiceOutcome.SearchParameters.Format;
        return ResourceServiceOutcome;
      }

      if (Resource is Parameters Parameters)
      {
        if (Parameters.Parameter != null && Parameters.Parameter.Count > 0)
        {
          if (Parameters.Parameter[0].Name.ToLower() == _ParameterName)
          {
            if (Parameters.Parameter[0].Resource != null)
            {
              if (Parameters.Parameter[0].Resource is QuestionnaireResponse QuestionnaireResponse)
              {
                if (QuestionnaireResponse.Meta == null)
                  QuestionnaireResponse.Meta = new Meta();
                if (QuestionnaireResponse.Meta.Tag == null)
                  QuestionnaireResponse.Meta.Tag = new List<Coding>();
                QuestionnaireResponse.Meta.Tag.Add(new Coding("https://pyrohealth.net/fhir/CodeSystem/connectathon-answer", "hidden"));

                var RequestHeaders = ICommonFactory.CreateDtoRequestHeaders();
                this.IResourceServices.SetCurrentResourceType(FHIRAllTypes.QuestionnaireResponse);
                if (QuestionnaireResponse.Id == null || string.IsNullOrWhiteSpace(QuestionnaireResponse.Id))
                {
                  IPyroRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri($"https://{RequestUri.PrimaryRootUrlStore.Url}/{FHIRAllTypes.QuestionnaireResponse}");
                  ResourceServiceOutcome = this.IResourceServices.Post(QuestionnaireResponse, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
                }
                else
                {
                  IPyroRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri($"https://{RequestUri.PrimaryRootUrlStore.Url}/{FHIRAllTypes.QuestionnaireResponse}/{QuestionnaireResponse.Id}");
                  ResourceServiceOutcome = this.IResourceServices.Put(QuestionnaireResponse.Id, QuestionnaireResponse, DtoRequestUri, SearchParameterGeneric, RequestHeaders);
                }
                if (ResourceServiceOutcome.SuccessfulTransaction)
                {
                  Parameters ParametersResult = new Parameters();
                  ParametersResult.Parameter = new List<Parameters.ParameterComponent>();
                  var Param = new Parameters.ParameterComponent();
                  Param.Name = "You answers have been submitted.";
                  ParametersResult.Parameter.Add(Param);
                  var Param2 = new Parameters.ParameterComponent();
                  Param2.Name = FHIRAllTypes.QuestionnaireResponse.GetLiteral();
                  Param2.Resource = ResourceServiceOutcome.ResourceResult;
                  ParametersResult.Parameter.Add(Param2);
                  ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.OK;
                  ResourceServiceOutcome.ResourceResult = ParametersResult;
                  ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                  ResourceServiceOutcome.SuccessfulTransaction = true;

                  IPyroRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri($"https://{RequestUri.PrimaryRootUrlStore.Url}/{FHIRAllTypes.QuestionnaireResponse}/{_PrimaryQuestionnaireResponseAnswerResourceId}");
                  var Answers = this.IResourceServices.GetRead("AngusA1", DtoRequestUri, SearchParameterGeneric, RequestHeaders);

                  QuestionnaireResults QuestionnaireResults = QuestionnaireResponseChecker.Check(Answers.ResourceResult as QuestionnaireResponse, QuestionnaireResponse);
                }
                else
                {
                  Parameters ParametersResult = new Parameters();
                  ParametersResult.Parameter = new List<Parameters.ParameterComponent>();
                  var Param = new Parameters.ParameterComponent();
                  Param.Name = "Oh no, there was an error is submitting your answers.";
                  ParametersResult.Parameter.Add(Param);
                  var Param2 = new Parameters.ParameterComponent();
                  Param2.Name = FHIRAllTypes.OperationOutcome.GetLiteral();
                  Param2.Resource = ResourceServiceOutcome.ResourceResult;
                  ParametersResult.Parameter.Add(Param2);
                  ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                  ResourceServiceOutcome.ResourceResult = ParametersResult;
                  ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
                  ResourceServiceOutcome.SuccessfulTransaction = false;
                }
              }
              else
              {
                IssueList.Add(Pyro.Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, $"The ${_OperationName} expects the {FHIRAllTypes.Parameters.GetLiteral()} resource to have one parameter with the 'Name' element equal to '{_ParameterName}' where the Resource element is set to a {FHIRAllTypes.QuestionnaireResponse.GetLiteral()} FHIR Resource. The server found here a Resource of type {Parameters.Parameter[0].Resource.ResourceType}."));
              }
            }
            else
            {
              IssueList.Add(Pyro.Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, $"The ${_OperationName} expects the {FHIRAllTypes.Parameters.GetLiteral()} resource to have one Parameter with the Name element equal to '{_ParameterName}' where the Resource element is set to a {FHIRAllTypes.QuestionnaireResponse.GetLiteral()} FHIR Resource. The server found no {FHIRAllTypes.QuestionnaireResponse.GetLiteral()} Resource"));
            }
          }
          else
          {
            IssueList.Add(Pyro.Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, $"The ${_OperationName} expects the {FHIRAllTypes.Parameters.GetLiteral()} resource to have one Parameter with the Name element equal to '{_ParameterName}'."));
          }
        }
        else
        {
          IssueList.Add(Pyro.Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, $"The ${_OperationName} expects the {FHIRAllTypes.Parameters.GetLiteral()} resource to have one Parameter element."));
        }
      }
      else
      {
        IssueList.Add(Pyro.Common.Tools.FhirOperationOutcomeSupport.CreateIssue(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Invalid, $"The ${_OperationName} expects a FHIR {FHIRAllTypes.Parameters.GetLiteral()} resource as the call body."));
      }

      if (IssueList.Count > 0)
      {
        var Op = Common.Tools.FhirOperationOutcomeSupport.Generate(IssueList);
        ResourceServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
        ResourceServiceOutcome.ResourceResult = Op;
        ResourceServiceOutcome.OperationType = Enum.RestEnum.CrudOperationType.Update;
        ResourceServiceOutcome.SuccessfulTransaction = false;
        return ResourceServiceOutcome;
      }
      else
      {
        return ResourceServiceOutcome;
      }

    }

    public List<QuestionnaireResults> ProcessAttendeeResults()
    {
      var ResultList = new List<QuestionnaireResults>();
      //First get the Primary Answers
      IPyroRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri($"{IGlobalProperties.ServiceRootUrl}/{FHIRAllTypes.QuestionnaireResponse}/{_PrimaryQuestionnaireResponseAnswerResourceId}");
      ISearchParameterGeneric SearchParameterGeneric = ISearchParameterGenericFactory.CreateDtoSearchParameterGeneric();
      IRequestHeader RequestHeaders = ICommonFactory.CreateDtoRequestHeaders();
      var Answers = this.IResourceServices.GetRead(_PrimaryQuestionnaireResponseAnswerResourceId, DtoRequestUri, SearchParameterGeneric, RequestHeaders);

      if (Answers.SuccessfulTransaction && Answers.ResourceResult != null && Answers.ResourceResult is QuestionnaireResponse QuestionnaireResponseAnswers)
      {
        //Now get the Attendee's answers
        string SearchQuery = $"questionnaire=Questionnaire/{_QuestionnaireResourceId}";
        DtoRequestUri = ICommonFactory.CreateDtoRequestUri($"{IGlobalProperties.ServiceRootUrl}/{FHIRAllTypes.QuestionnaireResponse}?{SearchQuery}");
        SearchParameterGeneric = SearchParameterGeneric.Parse(SearchQuery);        
        var AttendeeAnswers = this.IResourceServices.GetSearch(DtoRequestUri, SearchParameterGeneric, RequestHeaders);
        if (AttendeeAnswers.SuccessfulTransaction && AttendeeAnswers.ResourceResult != null && AttendeeAnswers.ResourceResult is Bundle AttendeeAnswersBundle)
        {

          foreach (var Entry in AttendeeAnswersBundle.Entry)
          {
            QuestionnaireResponse QuestionnaireResponseAttendee = Entry.Resource as QuestionnaireResponse;
            if (QuestionnaireResponseAttendee.Source != null && !string.IsNullOrWhiteSpace(QuestionnaireResponseAttendee.Source.Reference))
            {
              if (QuestionnaireResponseAttendee.Source.Url != null)
              {

              }
              else
              {
                string Ref = QuestionnaireResponseAttendee.Source.Reference;
              }
            }

            QuestionnaireResults QuestionnaireResults = QuestionnaireResponseChecker.Check(QuestionnaireResponseAnswers, QuestionnaireResponseAttendee);
            ResultList.Add(QuestionnaireResults);
          }
        }
      }
      else
      {
        throw new Exception($"Could not resolve the primary Answer QuestionnaireResponse resource with id = {_PrimaryQuestionnaireResponseAnswerResourceId}");
      }
      return ResultList;
    }
  }
}

