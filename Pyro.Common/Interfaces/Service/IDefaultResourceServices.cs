using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Service
{
  /// <summary>
  /// This Interface is here to handle any Resource but only supports the basic REST CRUD operations.  
  /// </summary>
  public interface IDefaultResourceServices : IResourceServices, ICommonServices
  {    
    FHIRAllTypes SetCurrentResourceType { set; }   
  }
}
