using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using BusinessEntities.Search;

namespace Dip.Interfaces.Repositories
{
  public interface IValueSetRepository : IBaseRepository
  {
    Dip.Interfaces.IDatabaseOperationOutcome Search(DtoSearchParameters oSearchParameters);

    string AddResource(ValueSet ValueSet);
    string UpdateResource(int ResourceVersion, ValueSet ValueSet);
    void UpdateResouceAsDeleted(string FhirResourceId);
  }
}
