using DbUp.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DbManager.SqlScripts.PostgreSql
{
  public class _201808150740000_FhirReleaseSeed : IScript
  {
    public string ProvideScript(Func<IDbCommand> commandFactory)
    {
      IDbCommand cmd = commandFactory();
      cmd.CommandText = "SELECT \"Id\" FROM public.\"_FhirRelease\" 	where \"FhirVersion\" = '3.0.1'";
      var scriptBuilder = new StringBuilder();
      //Check it is not already added;
      bool UpdateReqired = false;
      using (var reader = cmd.ExecuteReader())
      {
        UpdateReqired = !reader.Read();
      }
      if (UpdateReqired)
      {
        //var cmd2 = commandFactory();
        //cmd2.CommandText = "INSERT INTO public.\"_FhirRelease\"(\"FhirVersion\", \"Date\", \"Description\", \"CreatedDate\", \"CreatedUser\", \"LastUpdated\", \"LastUpdatedUser\")" +
        //                  " VALUES(@FhirVersion, @Date, @Description, @CreatedDate, @CreatedUser, @LastUpdated, @LastUpdatedUser); ";

        //IDbDataParameter ParamVer = cmd2.CreateParameter();
        //ParamVer.DbType = DbType.AnsiString;
        //ParamVer.ParameterName = "@FhirVersion";
        //ParamVer.Value = "3.0.1";
        //cmd2.Parameters.Add(ParamVer);

        string FhirVersion = "3.0.1";
        string Description = "FHIR Release 3 (STU) with 1 technical errata (Permanent Home)";
        string User = "PyroServerSystem";
        string DateNowString = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss zzz");
        string FhirVerDate = new DateTime(2017, 08, 19).ToString("yyyy-MM-dd hh:mm:ss");

        string test = $"INSERT INTO public.\"_FhirRelease\" (\"FhirVersion\", \"Date\", \"Description\", \"CreatedDate\", \"CreatedUser\", \"LastUpdated\", \"LastUpdatedUser\")" +
                          $" VALUES('{FhirVersion}', '{FhirVerDate}', '{Description}', '{DateNowString}', '{User}', '{DateNowString}', '{User}');";

        scriptBuilder.AppendLine(test);

        return scriptBuilder.ToString();
      }
      else
      {
        return string.Empty;
      }      
    }
  }
}
