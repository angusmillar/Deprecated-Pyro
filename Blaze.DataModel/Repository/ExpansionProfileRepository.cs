using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.Support;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class ExpansionProfileRepository : CommonRepository, IResourceRepository
  {

    public ExpansionProfileRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      throw new NotImplementedException();
    }

    public string UpdateResource(int ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      throw new NotImplementedException();
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, int ResourceVersionNumber)
    {
      throw new NotImplementedException();
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId)
    {
      throw new NotImplementedException();
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, int ResourceVersion)
    {
      throw new NotImplementedException();
    }

  }
} 

