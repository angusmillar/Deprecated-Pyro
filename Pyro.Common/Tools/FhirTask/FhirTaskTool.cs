using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Logging;
using Pyro.Common.Service.ResourceService;
using Pyro.Common.Service.Trigger;

namespace Pyro.Common.Tools.FhirTask
{
  public class FhirTaskTool : IFhirTaskTool
  {
    private readonly IResourceServices IResourceServices;
    private readonly IRequestHeaderFactory IRequestHeaderFactory;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IResourceTriggerService IResourceTriggerService;
    private readonly ILog ILog;

    public FhirTaskTool(IResourceServices IResourceServices, 
      IRequestHeaderFactory IRequestHeaderFactory, 
      IRequestMetaFactory IRequestMetaFactory,      
      IResourceTriggerService IResourceTriggerService,
      ILog ILog)
    {
      this.IResourceServices = IResourceServices;
      this.IRequestHeaderFactory = IRequestHeaderFactory;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IResourceTriggerService = IResourceTriggerService;
      this.ILog = ILog;
    }


    public bool UpdateTaskAsStatus(Task.TaskStatus TaskStatus, Task Task)
    {
      try
      {
        //Set the task status only if it has not been updated since we got it from the server, using the IfMatch hearder and the VersionId
        var RequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{Task.ResourceType.GetLiteral()}/{Task.Id}");
        RequestMeta.RequestHeader = IRequestHeaderFactory.CreateRequestHeader();
        RequestMeta.RequestHeader.IfMatch = Common.Tools.HttpHeaderSupport.GetETagString(Task.VersionId);

        //Update the Tasl Properties
        Task.Status = TaskStatus;
        Task.LastModifiedElement = new FhirDateTime(DateTimeOffset.Now);

        this.IResourceTriggerService.TriggersActive = false;
        IResourceServiceOutcome PutResourceServiceOutcome = IResourceServices.Put(Task.Id, Task, RequestMeta);
        this.IResourceTriggerService.TriggersActive = true;
        if (PutResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
          Task = PutResourceServiceOutcome.ResourceResult as Task;
          return true;
        }
        else if (PutResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.Conflict)
        {
          ILog.Error($"Internal Server Error: UpdateTaskAsStatus failed due to Version Conflict, Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}/_history/{Task.VersionId}.");
          return true;
        }
        else if (PutResourceServiceOutcome.HttpStatusCode == System.Net.HttpStatusCode.Created)
        {
          ILog.Error($"Internal Server Error: UpdateTaskAsStatus failed due to 201 Create being returned when OK Update was expected, Transaction was rolled back. Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}");
          return false;
        }
        else
        {
          ILog.Error($"Internal Server Error: UpdateTaskAsStatus failed due to unexpected HTTP status code return, code was {PutResourceServiceOutcome.HttpStatusCode.ToString()}. Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}/_history/{Task.VersionId}");
          return false;
        }
      }
      catch (Exception Exec)
      {
        ILog.Error(Exec, $"ResourceSeeding on Startup, PUT operations failed with exception. Task reference was: {Task.ResourceType.GetLiteral()}/{Task.Id}/_history/{Task.VersionId}");
        return false;
      }
    }
  }
}
