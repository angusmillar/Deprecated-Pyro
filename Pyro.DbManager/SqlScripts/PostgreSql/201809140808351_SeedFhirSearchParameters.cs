using DbUp.Engine;
using Pyro.DbManager.Seeding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DbManager.SqlScripts.PostgreSql
{
  public class _201808171250000_SeedFhirSearchParameters : IScript
  {
    public string ProvideScript(Func<IDbCommand> commandFactory)
    {
      IDbCommand cmd = commandFactory();
      cmd.CommandText = "SELECT 1 FROM public.\"_SearchParam\" LIMIT 1";
      var scriptBuilder = new StringBuilder();
      //Check it is not already added;
      bool UpdateReqired = false;
      using (var reader = cmd.ExecuteReader())
      {
        UpdateReqired = !reader.Read();
      }
      if (UpdateReqired)
      {
        FhirSearchParamters SearchParamters = new FhirSearchParamters();
        return SearchParamters.GetPostgreSQLQuerySearchParameters();
      }
      return string.Empty;      
    }
  }
}
