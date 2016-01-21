using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Interfaces
{
  public interface IUnitOfWork
  {
    IPatientRepository PatientRepository { get; }
  }
}

