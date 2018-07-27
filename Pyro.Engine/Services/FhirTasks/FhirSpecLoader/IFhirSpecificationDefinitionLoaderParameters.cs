using System.Collections.Generic;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Engine.Services.FhirTasks.FhirSpecLoader
{
  public interface IFhirSpecificationDefinitionLoaderParameters
  {
    FhirModel.Task.TaskStatus? TaskStatus { get; set; }
    string ErrorMessage { get; set; }
    List<string> FileCompletedList { get; set; }
    string FileInError { get; set; }
    string FileInProgress { get; set; }
  }
}