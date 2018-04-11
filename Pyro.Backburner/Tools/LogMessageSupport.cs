using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Utility;
using Pyro.Common.BackgroundTask;
using Pyro.Common.Enum;

namespace Pyro.Backburner.Tools
{
  public static class LogMessageSupport
  {

    public static string RegisterTask(string TaskName)
    {
      return $" - {TaskName}";
    }

    public static string TaskReceived(IBackgroundTaskPayloadBase BackgroundTaskPayloadBase)
    {
      return $"{Environment.NewLine}Task received  : {BackgroundTaskPayloadBase.TaskType.GetPyroLiteral()}{Environment.NewLine}Task Reference : Task/{BackgroundTaskPayloadBase.TaskId}";
    }

    public static string TaskOutCome(IBackgroundTaskPayloadBase BackgroundTaskPayloadBase, Hl7.Fhir.Model.Task.TaskStatus TaskStatus)
    {
      return $"{Environment.NewLine}Task processed : {BackgroundTaskPayloadBase.TaskType.GetPyroLiteral()}{Environment.NewLine}Task Status    : {TaskStatus.GetLiteral()}{Environment.NewLine}Task Ref       : Task/{BackgroundTaskPayloadBase.TaskId}";
    }

    public static string TaskException(IBackgroundTaskPayloadBase BackgroundTaskPayloadBase, Hl7.Fhir.Model.Task.TaskStatus TaskStatus, string ExceptionMessage = null)
    {
      string temp = $"{Environment.NewLine}Task's Exception: {BackgroundTaskPayloadBase.TaskType.GetPyroLiteral()}{Environment.NewLine}Task Status      : {TaskStatus.GetLiteral()}{Environment.NewLine} Task Ref        : Task/{BackgroundTaskPayloadBase.TaskId}";
      if (!string.IsNullOrWhiteSpace(ExceptionMessage))
      {
        temp = temp + $"${Environment.NewLine}ExceptionMessage:";
        temp = temp + $"${Environment.NewLine}{ExceptionMessage}";
       
      }
      return temp;
    }
  }
}
