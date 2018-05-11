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
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.SearchParameters;

namespace Pyro.Common.FhirOperation.ConnectathonAnswer
{
  public class ConnectathonAnswerOperation : IConnectathonAnswerOperation
  {
    private readonly IResourceServices IResourceServices;        
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;    
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;    
    private readonly IRequestMetaFactory IRequestMetaFactory;

    private string _OperationName = FhirOperationEnum.OperationType.ConnectathonAnswer.GetPyroLiteral();
    private readonly string _ParameterName = "answers";
    private readonly string _PrimaryQuestionnaireResponseAnswerResourceId = "AngusA1";
    private readonly string _QuestionnaireResourceId = "PerthQuestions";

    public ConnectathonAnswerOperation(IResourceServices IResourceServices, IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory, ISearchParameterServiceFactory ISearchParameterServiceFactory, IRequestMetaFactory IRequestMetaFactory)
    {
      this.IResourceServices = IResourceServices;                
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;    
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IRequestMetaFactory = IRequestMetaFactory;
    }

    public IResourceServiceOutcome Process(
          IPyroRequestUri RequestUri,
          ISearchParameterGeneric SearchParameterGeneric,
          Resource Resource)
    {

      IResourceServiceOutcome ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();
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
                               
                if (QuestionnaireResponse.Id == null || string.IsNullOrWhiteSpace(QuestionnaireResponse.Id))
                {
                  IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.QuestionnaireResponse.GetLiteral()}");                                    
                  ResourceServiceOutcome = this.IResourceServices.Post(QuestionnaireResponse, RequestMeta);
                }
                else
                {
                  IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.QuestionnaireResponse.GetLiteral()}/{QuestionnaireResponse.Id}");
                  ResourceServiceOutcome = this.IResourceServices.Put(QuestionnaireResponse.Id, QuestionnaireResponse, RequestMeta);
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

                  IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.QuestionnaireResponse.GetLiteral()}/{_PrimaryQuestionnaireResponseAnswerResourceId}");                  
                  var Answers = this.IResourceServices.GetRead("AngusA1", RequestMeta);

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
      IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.QuestionnaireResponse.GetLiteral()}/{_PrimaryQuestionnaireResponseAnswerResourceId}");            
      var Answers = this.IResourceServices.GetRead(_PrimaryQuestionnaireResponseAnswerResourceId, RequestMeta);

      if (Answers.SuccessfulTransaction && Answers.ResourceResult != null && Answers.ResourceResult is QuestionnaireResponse QuestionnaireResponseAnswers)
      {
        //Now get the Attendee's answers
        string SearchQuery = $"questionnaire=Questionnaire/{_QuestionnaireResourceId}";
        IRequestMeta RequestMetaQuestionnaireResource = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.QuestionnaireResponse.GetLiteral()}?{SearchQuery}");        
        var AttendeeAnswers = this.IResourceServices.GetSearch(RequestMetaQuestionnaireResource);
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

