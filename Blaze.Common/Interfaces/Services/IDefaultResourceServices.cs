using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Blaze.Common.Interfaces.Services
{
  /// <summary>
  /// This Interface is here to handle any Resource but only supports the basic REST CRUD operations.  
  /// </summary>
  public interface IDefaultResourceServices : IBaseResourceServices
  {
    FHIRAllTypes SetCurrentResourceType { set; }   
  }
}
