using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Common.Interfaces.Repositories
{
    public interface IConceptMapRepository : IBaseRepository
    {
        void Search();

        string AddResource(ConceptMap ConceptMap);
        string UpdateResource(int ResourceVersion, ConceptMap ConceptMap);
        void UpdateResouceAsDeleted(string FhirResourceId);
    }
}
