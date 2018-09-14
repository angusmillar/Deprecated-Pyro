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
      cmd.CommandText = $"SELECT \"Id\" FROM public.\"_FhirRelease\" 	where \"FhirVersion\" = '{Hl7.Fhir.Model.ModelInfo.Version}'";
      var scriptBuilder = new StringBuilder();
      //Check it is not already added;
      bool UpdateReqired = false;
      using (var reader = cmd.ExecuteReader())
      {
        UpdateReqired = !reader.Read();
      }
      if (UpdateReqired)
      {
        //Lasted updated to be FHIR (R4) Version 3.5.0 
        string FhirVersion = Hl7.Fhir.Model.ModelInfo.Version;
        string Description = "R4 Ballot #2 : Mixed Normative/Trial use (Second Normative ballot + Baltimore Connectathon)";
        string User = "PyroServerSystem";
        string DateNowString = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss zzz");
        string FhirVerDate = new DateTime(2018, 08, 21).ToString("yyyy-MM-dd hh:mm:ss");

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
