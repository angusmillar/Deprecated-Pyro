using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dip.Interfaces.Services;
using Dip.Interfaces;

namespace Blaze.Engine.Services
{
  /// <summary>
  /// This Class is here to handle any unique methods required for Patient resource beyond the basic REST operations.
  /// These might be FHIR operations on the resource such as '$expand' in the ValueSet Resource.
  /// </summary>
  public class ValueSetResourceServices: BaseResourceServices, IValueSetResourceServices, IBaseResourceServices
  {
    //Constructor for dependency injection
    public ValueSetResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork){}
  }
}
