using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pyro.Common.Interfaces.Service
{
  public interface IServiceNegotiator
  {
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
    bool IsTransactional { get; }
    IResourceServices GetTransactionalResourceService(string ResourceName);
    IResourceServices GetResourceService(string type);
    IResourceServicesBase GetResourceServiceBase(string type);
    ICommonServices GetCommonService();
  }
}
