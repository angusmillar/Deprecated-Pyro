using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.Interfaces.Repositories
{
  public interface IUnitOfWork
  {
    IResourceRepository PatientRepository { get; }
    ICommonRepository CommonRepository { get; }
    //IValueSetRepository ValueSetRepository { get; }    
    //IConceptMapRepository ConceptMapRepository { get; }  
  }
}

