using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.Common.Interfaces.Repositories
{
  public interface IValueSetRepository : IBaseRepository
  {
    Common.Interfaces.IDatabaseOperationOutcome Search(DtoSearchParameters oSearchParameters);

    string AddResource(ValueSet ValueSet);
    string UpdateResource(int ResourceVersion, ValueSet ValueSet);
    void UpdateResouceAsDeleted(string FhirResourceId);
  }
}
