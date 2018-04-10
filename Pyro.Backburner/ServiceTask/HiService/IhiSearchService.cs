using Pyro.Backburner.Tools;
using Pyro.Common.BackgroundTask.Task;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Backburner.ServiceTask.HiService
{
  public class IhiSearchService : IIhiSearchService
  {
    private readonly IUnitOfWork IUnitOfWork;
    private readonly IResourceServices IResourceApiServices;    
    private readonly IRequestMetaFactory IRequestMetaFactory;

    public IhiSearchService(IUnitOfWork IUnitOfWork, IResourceServices IResourceApiServices, IRequestMetaFactory IRequestMetaFactory)
    {
      this.IUnitOfWork = IUnitOfWork;      
      this.IResourceApiServices = IResourceApiServices;
      this.IRequestMetaFactory  = IRequestMetaFactory;      
    }


    public void Run(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {

      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {
          //IRequestServiceRootValidate.Validate(BaseRequestUri);
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set("Patient/IHIStatusExample");
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.GetRead("IHIStatusExample", RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          
          Transaction.Commit();
          ConsoleSupport.ConsoleWriteLine($"Http Status Code: {ResourceServiceOutcome.HttpStatusCode.ToString()}");

        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          //ILog.Error(Exec, "PyroService.Get");
          //throw new PyroException(System.Net.HttpStatusCode.InternalServerError,
          //  Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Exec.Message), Exec.Message);
        }
      }
      
      //ConsoleSupport.ConsoleWriteLine($"Task Sleeep 10 Sec");
      //IOtherThing.Thing();
      //System.Threading.Thread.Sleep(10000);
      //ConsoleSupport.ConsoleWriteLine($"In the task");
      //ConsoleSupport.ConsoleWriteLine($"Task Recived: Hi Service IHI Search ");
      //ConsoleSupport.ConsoleWriteLine($"HI Test PayloadId: {TaskPayloadHiServiceIHISearch.Payloadid}");
      //ConsoleSupport.ConsoleWriteLine($"HI Test PatientId: {TaskPayloadHiServiceIHISearch.PatientId}");
      //ConsoleSupport.ConsoleWriteLine($"HI Test TaskId: {TaskPayloadHiServiceIHISearch.TaskId}");
     // throw new NullReferenceException("My exception ANgus");
    }
  }
}
