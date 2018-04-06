using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BackgroundTask
{
  public abstract class BackgroundTaskPayloadBase : IBackgroundTaskPayloadBase
  {
    public BackgroundTaskPayloadBase()
    {
      this.Payloadid = Common.Tools.FhirGuid.FhirGuid.NewFhirGuid();
    }
    public abstract string Payloadid { get; set; }
  }
}
