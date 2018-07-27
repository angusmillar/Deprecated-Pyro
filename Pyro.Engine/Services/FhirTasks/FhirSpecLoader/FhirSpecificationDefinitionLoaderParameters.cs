using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;

namespace Pyro.Engine.Services.FhirTasks.FhirSpecLoader
{
  public class FhirSpecificationDefinitionLoaderParameters : IFhirSpecificationDefinitionLoaderParameters
  {
    public List<string> FileCompletedList { get; set; }
    public string FileInProgress { get; set; }
    public string FileInError { get; set; }
    public string ErrorMessage { get; set; }
    public FhirModel.Task.TaskStatus? TaskStatus { get; set; }
  }
}
