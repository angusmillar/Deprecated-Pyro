using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;
using System.Linq.Expressions;

namespace Blaze.DataModel.Search
{
  public class ResourceSearch<T> where T : ResourceIndexBase
  {        
    public Expression<Func<T, bool>> StringPropertyEqualTo(string Property, string Value)
    {      
      var type = typeof(T);
      var ParameterReferance = Expression.Parameter(type, "x");
      var propertyReference = Expression.Property(ParameterReferance, Property);
      var constantReference = Expression.Constant(Value);
      var BinaryExpression = Expression.Equal(propertyReference, constantReference);
      return Expression.Lambda<Func<T, bool>>(BinaryExpression, new[] { ParameterReferance });
    }


    public Expression<Func<T, bool>> StringCollectionEqualToAny(string Property, string Value)
    {
      var type = typeof(T);
      //Inner
      ParameterExpression InnerParameter = Expression.Parameter(typeof(StringIndex), "c");
      MemberExpression InnerProperty = Expression.Property(InnerParameter, "String");
      ConstantExpression InnerValue = Expression.Constant(Value);
      BinaryExpression InnerExpression = Expression.Equal(InnerProperty, InnerValue);
      Expression<Func<StringIndex, bool>> InnerFunction = Expression.Lambda<Func<StringIndex, bool>>(InnerExpression, InnerParameter);


      //Outer
      var Method = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(StringIndex));

      ParameterExpression PatientParameter = Expression.Parameter(typeof(T), "x");
      var PatientFunc = Expression.Lambda<Func<T, bool>>(
          Expression.Call(
              Method,
              Expression.Property(
                  PatientParameter,
                  typeof(T).GetProperty(Property)),
              InnerFunction), PatientParameter);
      return PatientFunc;
    }

  }
}
