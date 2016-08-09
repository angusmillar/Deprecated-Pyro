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

      //(x => x.FhirId == "a99b5c95-b546-46ee-8992-19a7ca703d4a")
      //var type = typeof(Res_Patient);
      //var pe = Expression.Parameter(type, "x");
      //var propertyReference = Expression.Property(pe, "FhirId");
      //var constantReference = Expression.Constant("a99b5c95-b546-46ee-8992-19a7ca703d4a");
      //var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      //var MyExpression = Expression.Lambda<Func<Res_Patient, bool>>(BinaryExpression, new[] { pe });




      //MyPredicate = MyPredicate.Or(x => x.given_List.Any(c => c.String == Item));
     
      //Inner
      ParameterExpression InnerParameter = Expression.Parameter(typeof(StringIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, "String");
      ConstantExpression InnerValue = Expression.Constant("Angus");
      BinaryExpression InnerExpression = Expression.Equal(InnerProperty, InnerValue);
      Expression<Func<StringIndex, bool>> InnerFunction = Expression.Lambda<Func<StringIndex, bool>>(InnerExpression, InnerParameter);


      //Outer
      var Method = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(StringIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(Res_Patient), "x");
      var PatientFunc = Expression.Lambda<Func<Res_Patient, bool>>(
          Expression.Call(
              Method,
              Expression.Property(
                  PatientParameter,
                  typeof(Res_Patient).GetProperty("given_List")),
              InnerFunction), PatientParameter);




      var MyPredicate = PredicateBuilder.New<Res_Patient>();
      //MyPredicate.Or(x => x.given_List.Any(c => c.String == "Angus"));

      MyPredicate = MyPredicate.Or(PatientFunc);
      





      //MyPredicate = MyPredicate.Or(x => x.FhirId == "a99b5c95-b546-46ee-8992-19a7ca703d4a");

      //MyPredicate = MyPredicate.Or(MyExpression);

      //foreach (DtoSearchParameterBase SearchItem in DtoSearchParameters.SearchParametersList)
      //{
      //  if (SearchItem.Name == Common.BusinessEntities.Dto.DtoEnums.Search.SearchParameterName.Given)
      //  {

      //  }
      //  var DtoSearchParameterString = SearchItem as DtoSearchParameterString;
      //  foreach(string Item in DtoSearchParameterString.Values)
      //  {
      //    MyPredicate = MyPredicate.Or(x => x.given_List.Any(c => c.String == Item));
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
  }
}



