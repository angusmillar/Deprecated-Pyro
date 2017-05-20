using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pyro.Common.Interfaces.Repositories
{
  public partial interface IUnitOfWork
  {
    DbContextTransaction BeginTransaction();

    IDtoCommonRepository CommonRepository { get; }
  }
}

