using Pyro.Common.BackgroundTask.TaskPayload;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Service.ResourceService;
using System;
using System.Data.Entity;
using Pyro.Common.Logging;
using Pyro.Common.Tools;

namespace Pyro.Common.BackgroundTask.TaskService.HiService
{
  public class IhiSearchService : IIhiSearchService
  {
    private readonly IUnitOfWork IUnitOfWork;
    private readonly IResourceServices IResourceApiServices;    
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly ILog ILog;

    public IhiSearchService(IUnitOfWork IUnitOfWork, IResourceServices IResourceApiServices, IRequestMetaFactory IRequestMetaFactory, ILog ILog)
    {
      this.IUnitOfWork = IUnitOfWork;      
      this.IResourceApiServices = IResourceApiServices;
      this.IRequestMetaFactory  = IRequestMetaFactory;
      this.ILog = ILog;
    }


    public void Run(ITaskPayloadHiServiceIHISearch TaskPayloadHiServiceIHISearch)
    {     
      using (DbContextTransaction Transaction = IUnitOfWork.BeginTransaction())
      {
        try
        {          
          IRequestMeta RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set("Patient/IHIStatusExample");
          IResourceServiceOutcome ResourceServiceOutcome = IResourceApiServices.GetRead("IHIStatusExample", RequestMeta);
          ResourceServiceOutcome.SummaryType = RequestMeta.SearchParameterGeneric.SummaryType;
          
          Transaction.Commit();
         
          
          ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskOutCome(TaskPayloadHiServiceIHISearch, Hl7.Fhir.Model.Task.TaskStatus.Completed));
          
        }
        catch (Exception Exec)
        {
          Transaction.Rollback();
          ConsoleSupport.TimeStampWriteLine(BackgroundTaskLogMessageSupport.TaskException(TaskPayloadHiServiceIHISearch, Hl7.Fhir.Model.Task.TaskStatus.Failed));
          ILog.Error(Exec, $"FHIR Task ID: {TaskPayloadHiServiceIHISearch.TaskId}, FHIR Patient ID: {TaskPayloadHiServiceIHISearch.PatientId}");          
        }
      }
            
    }
  }
}
