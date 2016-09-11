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
using Blaze.DataModel.Search;
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
      //MyPredicate = MyPredicate.And(Search.StringPropertyEqualTo("FhirId", "96d6d5a3-d3da-493a-b4f2-e8ec1241f8d7"));
      //MyPredicate = MyPredicate.And(Search.StringCollectionEqualToAny("given_List", "Angus"));
      //MyPredicate = MyPredicate.And(Search.StringCollectionAnyStartsWith("family_List", "héllo"));  //"héllo UPPER"
      //MyPredicate = MyPredicate.And(Search.StringCollectionEqualToAny("address_state_List", "Vic"));
      //MyPredicate = MyPredicate.And(x => x.given_List.Any(c => string.Equals(c.String, "Angus", StringComparison.OrdinalIgnoreCase)));
      //MyPredicate = MyPredicate.And(x => x.family_List.Any(c => c.String.StartsWith("hello")));
      //MyPredicate = MyPredicate.And(Search.StringPropertyStartsWith("FhirId", "96d6d5a3-d3da-493a-b4f2"));
      //MyPredicate = MyPredicate.And(Search.StringPropertyEqualTo("FhirId", "96d6d5a3-d3da-493a-b4f2-e8ec1241f8d7"));
      //MyPredicate = MyPredicate.And(x => x.FhirId.StartsWith("a99b5c95-b546-46ee-8992-19a7ca703d4a"));
      //MyPredicate = MyPredicate.And(x => x.FhirId.Contains("d3da-493a-b4f2"));
      //MyPredicate = MyPredicate.And(Search.StringPropertyContains("FhirId", "d3da-493a-b4f2"));
      //MyPredicate = MyPredicate.And(x => x.family_List.Any(c => c.String.Contains("llo")));
      //MyPredicate = MyPredicate.And(Search.StringCollectionAnyContains("family_List", "llo"));
      //MyPredicate = MyPredicate.And(Search.StringPropertyStartsOrEndsWith("FhirId", "e8ec1241f8d7"));
      //MyPredicate = MyPredicate.And(Search.StringCollectionAnyStartsOrEndsWith("family_List", "per"));
      //MyPredicate = MyPredicate.Or(x => x.FhirId == "a99b5c95-b546-46ee-8992-19a7ca703d4a");
      //MyPredicate = MyPredicate.Or(x => x.active_Code == "Code" && x.active_System == "System");
      //MyPredicate = MyPredicate.And(Search.TokenPropertyEqualTo("gender_Code", new DtoSearchParameterToken.TokenValue() { Code = "female", System = "" }));

      ////MyPredicate = MyPredicate.Or(MyExpression);




      var Predicate = PredicateGenerator<Res_Patient>(DtoSearchParameters);

      // DateTimeOffset TestDate = DateTimeOffset.Now;
      //Predicate = Predicate.Or(x => x.birthdate_DateTimeOffset == TestDate);



      int TotalRecordCount = DbGetALLCount<Res_Patient>(Predicate);
      var Query = DbGetAll<Res_Patient>(Predicate);

      //Todo: Sort not implemented just defaulting to last update order
      Query = Query.OrderBy(x => x.lastUpdated);
      //if (DtoSearchParameters.SortList != null)
      //  Query = Query.Ordering<Res_Patient>(DtoSearchParameters);
      int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);

      var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
      Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x)));


      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.PagesTotal = PaginationSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = TotalRecordCount;
      DatabaseOperationOutcome.ResourcesMatchingSearchList = DtoResourceList;


      return DatabaseOperationOutcome;
    }





  }
}



