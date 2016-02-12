using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using System.Linq.Expressions;

namespace DataModel.DynamicExpression
{
  public static class ExpressionForge
  {
    public static class Resource
    {

      public static Expression<Func<Model.Resource, bool>> ResourceFalse()
      {
        return PredicateBuilder.False<Model.Resource>();
      }

      public static Expression<Func<Model.Resource, bool>> ResourceTrue()
      {
        return PredicateBuilder.True<Model.Resource>();
      }

      public static class ValueSet
      {

        /// <summary>
        /// Description.Contains("Text1") or Description.Contains("Text2") or Description.Contains("Text3")..etc
        /// </summary>
        /// <param name="Keywords"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> Contains_Description(params string[] Keywords)
        {
          var Predicate = PredicateBuilder.False<Model.Resource>();
          foreach (string item in Keywords)
          {
            string temp = item;
            Predicate = Predicate.Or(x => x.ValueSetResource.Description.Contains(temp));
          }
          return Predicate;
        }

        /// <summary>
        /// x => x.ValueSetResource.Description == "Description"
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> Equals_Description(string Description)
        {
          var Predicate = PredicateBuilder.True<Model.Resource>();              
          return Predicate.And(x => x.ValueSetResource.Description == Description);          
        }

        /// <summary>
        /// ((Concept.CodeSystem.System == "MyCodeSystem1" and Concept.Code == "MyCode1") or (Concept.CodeSystem.System == "MyCodeSystem1" and Concept.Code == "MyCode1") or ...etc
        /// </summary>
        /// <param name="CodeSystemAndCode"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> Any_ConceptCodeSystemAndCode(List<Tuple<string, string>> CodeSystemAndCode)
        {
          var ResourcePredicate = PredicateBuilder.False<Model.Resource>();
          foreach (var Code in CodeSystemAndCode)
          {
            var ConceptPredicate = PredicateBuilder.True<Model.Concept>();
            if (Code.Item1 == null)
            {              
              ConceptPredicate = ConceptPredicate.And(x => x.Code == Code.Item2);
            }
            else 
            {
              ConceptPredicate = ConceptPredicate.And(x => x.Code == Code.Item2 || x.Code == null);
              ConceptPredicate = ConceptPredicate.And(x => x.CodeSystem.System == Code.Item1);
            }            
            ResourcePredicate = ResourcePredicate.Or(x => x.ValueSetResource.CodeSystem.Concept.Any(ConceptPredicate.Compile()));
          }
          return ResourcePredicate;
        }
        /// <summary>
        /// (Date == DateGiven)
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> Equals_Date(DateTime Date)
        {
          var Predicate = PredicateBuilder.True<Model.Resource>();
          return Predicate.And(x => x.ValueSetResource.Date == Date);
        }

        /// <summary>
        /// (Date > DateGiven)
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> GreaterThan_Date(DateTime Date)
        {
          var Predicate = PredicateBuilder.True<Model.Resource>();
          return Predicate.And(x => x.ValueSetResource.Date > Date);
        }

        /// <summary>
        /// (Date >= DateGiven)
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> GreaterThanEqualTo_Date(DateTime Date)
        {
          var Predicate = PredicateBuilder.True<Model.Resource>();
          return Predicate.And(x => x.ValueSetResource.Date >= Date);
        }

        /// <summary>
        /// (Date < DateGiven)
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> LessThan_Date(DateTime Date)
        {
          var Predicate = PredicateBuilder.True<Model.Resource>();
          return Predicate.And(x => x.ValueSetResource.Date < Date);
        }

        /// <summary>
        /// (Date <= DateGiven)
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> LessThanEqualTo_Date(DateTime Date)
        {
          var Predicate = PredicateBuilder.True<Model.Resource>();
          return Predicate.And(x => x.ValueSetResource.Date <= Date);
        }

        /// <summary>
        /// (Date != DateGiven)
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static Expression<Func<Model.Resource, bool>> NotEqualTo_Date(DateTime Date)
        {
          var Predicate = PredicateBuilder.True<Model.Resource>();
          return Predicate.And(x => x.ValueSetResource.Date != Date);
        }

        public static Expression<Func<Model.Resource, bool>> Any_UserContext(List<Tuple<string, string>> CodeSystemAndCode)
        {
          var ResourcePredicate = PredicateBuilder.False<Model.Resource>();

          var test = Any_Coding(CodeSystemAndCode);
          ResourcePredicate = ResourcePredicate.Or(x => x.ValueSetResource.UseContext.Any(test.Compile()));
          return ResourcePredicate;
        }

        public static Expression<Func<Model.CodeableConcept, bool>> Any_Coding(List<Tuple<string, string>> CodeSystemAndCode)
        {
          var CodeableConceptPredicate = PredicateBuilder.False<Model.CodeableConcept>();

          foreach (var Code in CodeSystemAndCode)
          {
            var CodingPredicate2 = PredicateBuilder.True<Model.Coding>();
            if (Code.Item1 == null)
            {
              CodingPredicate2 = CodingPredicate2.And(x => x.Code == Code.Item2);
            }
            else
            {
              CodingPredicate2 = CodingPredicate2.And(x => x.Code == Code.Item2 || x.Code == null);
              CodingPredicate2 = CodingPredicate2.And(x => x.System == Code.Item1);
            }
            CodeableConceptPredicate = CodeableConceptPredicate.Or(x => x.Coding.Any(CodingPredicate2.Compile()));
          }
          return CodeableConceptPredicate;
        }





      }     
    }   
  }
}
