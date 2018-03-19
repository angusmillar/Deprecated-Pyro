using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pyro.Common.Interfaces.Service
{
  //public interface IServiceNegotiator
  //{    
  //  DbContextTransaction BeginTransaction();
  //  IResourceServices GetResourceService(string ResourceName);    
  //  IResourceServicesBase GetResourceServiceBase(string type);
  //  ICommonServices GetCommonService();
  //}

  public interface IServiceNegotiator
  {
    T Create<T>() where T : IResourceServices;
  }
}
