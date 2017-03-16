using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Interfaces.Service
{
  public interface IBundleTransactionService
  {
    IResourceServiceOutcome Transact();
  }
}
