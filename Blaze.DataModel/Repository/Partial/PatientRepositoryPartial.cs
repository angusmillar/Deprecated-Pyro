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
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;
using LinqKit;

namespace Blaze.DataModel.Repository
{
  public partial class PatientRepository : CommonRepository, IResourceRepository
  {
    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;


      //IEnumerable<Res_Patient> ResourceList = DbGetALL<Res_Patient>(x => x.given_List.Any(c => c.String == "Angus"));

      var MyPredicate = PredicateBuilder.True<Res_Patient>();
      
      foreach (DtoSearchParameterBase SearchItem in DtoSearchParameters.SearchParametersList)
      {
        var DtoSearchParameterString = SearchItem as DtoSearchParameterString;
        foreach(string Item in DtoSearchParameterString.Values)
        {
          MyPredicate = MyPredicate.Or<Res_Patient>(x => x.given_List.Any(c => c.String == Item));
        }        
      }

      var ResourceList = _Context.Set<Res_Patient>().Where(MyPredicate);


      //ResourceList = ResourceList.Where(x => x.gender_Code == "female");
      ResourceList = ResourceList.Where(x => x.FhirId == "a99b5c95-b546-46ee-8992-19a7ca703d4a");
      //ResourceList = ResourceList.Where(x => x.given_List.Any(c => c.String == "Angus"));
      //ResourceList = ResourceList.ToList();
      string testId = string.Empty;

      List<Common.BusinessEntities.Dto.DtoResource> ReturnList = new List<Common.BusinessEntities.Dto.DtoResource>();
      foreach (var test in ResourceList)
      {        
        ReturnList.Add(IndexSettingSupport.SetDtoResource(test));       
      }

      DatabaseOperationOutcome.ResourcesMatchingSearchList = ReturnList;
      

      return DatabaseOperationOutcome;
    }
  }
}



