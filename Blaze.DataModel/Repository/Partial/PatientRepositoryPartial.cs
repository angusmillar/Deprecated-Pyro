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
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;

      ResourceSearch<Res_Patient> Search = new ResourceSearch<Res_Patient>();


      var MyPredicate = PredicateBuilder.New<Res_Patient>();


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

      //      MyPredicate = MyPredicate.Or(x => x.active_Code == "Code" && x.active_System == "System");
      MyPredicate = MyPredicate.And(Search.TokenPropertyEqualTo("gender_Code", new DtoSearchParameterToken.TokenValue() { Code = "female", System = "" }));

      ////MyPredicate = MyPredicate.Or(MyExpression);

      //foreach (DtoSearchParameterBase SearchItem in DtoSearchParameters.SearchParametersList)
      //{
      //  if (SearchItem.Name == Common.BusinessEntities.Dto.DtoEnums.Search.SearchParameterName.Given)
      //  {

      //  }
      //  var DtoSearchParameterString = SearchItem as DtoSearchParameterString;
      //  foreach (string Item in DtoSearchParameterString.Values)
      //  {
      //    //MyPredicate = MyPredicate.Or(x => x.given_List.Any(c => c.String == Item));

      //  }
      //}


      var ResourceList = DbGetALL<Res_Patient>(MyPredicate);


      string testId = string.Empty;

      List<Common.BusinessEntities.Dto.DtoResource> ReturnList = new List<Common.BusinessEntities.Dto.DtoResource>();
      foreach (var test in ResourceList)
      {
        ReturnList.Add(IndexSettingSupport.SetDtoResource(test));
      }

      DatabaseOperationOutcome.NumberOfRecordsPerPage = 5;
      DatabaseOperationOutcome.PageRequested = 1;
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = ResourceList.Count();
      DatabaseOperationOutcome.ResourcesMatchingSearchList = ReturnList;


      return DatabaseOperationOutcome;
    }


    //private Expression<Func<T, bool>> StringPropertyEqualTo<T>(string Property, string Value) where T : ResourceIndexBase
    //{
    //  var type = typeof(T);
    //  var ParameterReferance = Expression.Parameter(type, "x");
    //  var propertyReference = Expression.Property(ParameterReferance, Property);
    //  var constantReference = Expression.Constant(Value);
    //  var BinaryExpression = Expression.Equal(propertyReference, constantReference);
    //  return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    //}

  }
}



