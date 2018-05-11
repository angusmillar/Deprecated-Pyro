using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Tools.Connectathon;
using System.Collections.Generic;
using Pyro.Common.Service.ResourceService;

namespace Pyro.Common.FhirOperation.ConnectathonAnswer
{
  public interface IConnectathonAnswerOperation
  {
    IResourceServiceOutcome Process(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
    List<QuestionnaireResults> ProcessAttendeeResults();
  }
}