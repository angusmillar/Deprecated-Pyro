using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Interface
{
  public interface IUnitOfWork
  {
    Interface.IPatientRepository PatientRepository { get; }
  }
}
