using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Tools.Connectathon;
using System.Collections.Generic;

namespace Pyro.Common.Service
{
  public interface IConnectathonAnswerService
  {
    IResourceServiceOutcome Process(IPyroRequestUri RequestUri, ISearchParameterGeneric SearchParameterGeneric, Resource Resource);
    List<QuestionnaireResults> ProcessAttendeeResults();
  }
}