using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    /// <summary>
    /// This Interface is here to handle any unique methods required for ConceptMap resource beyond the basic REST operations implemented by the IResourceService.
    /// These might be FHIR operations on the resource such as '$expand' in the ConceptMap Resource.
    /// </summary>
    public interface IConceptMapResourceServices : IBaseResourceServices
    {
    }
}
