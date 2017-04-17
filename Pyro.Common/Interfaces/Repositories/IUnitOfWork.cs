using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Interfaces.Repositories
{
  public interface IUnitOfWork
  {
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
    bool IsTransactional { get;}

    IDtoCommonRepository CommonRepository { get; }
    IResourceRepository PatientRepository { get; }    
  }
}

