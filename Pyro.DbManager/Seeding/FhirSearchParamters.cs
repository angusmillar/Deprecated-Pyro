using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;
using Pyro.Common.Service.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DbManager.Seeding
{
  public class FhirSearchParamters
  {

    public string GetMsSQLQuerySearchParameters()
    {
      StringBuilder sb = new StringBuilder();
      var List = GetServiceSearchParameterList();
      foreach (var item in List)
      {
        sb.AppendLine(GenerateMicrosoftSQLServerScriptForSearchParam(item));
      }

      return sb.ToString();
    }

    public string GetMSSQLQuerySearchParameterTargetResources()
    {
      var List = GetServiceSearchParameterList();
      StringBuilder sb = new StringBuilder();
      foreach (var item in List)
      {
        string sql = GenerateMicrosoftSQLServerScriptForTargetResource(item);
        if (!string.IsNullOrWhiteSpace(sql))
          sb.AppendLine(sql);
      }

      return sb.ToString();
    }

    public string GetPostgreSQLQuerySearchParameters()
    {
      StringBuilder sb = new StringBuilder();
      var List = GetServiceSearchParameterList();
      foreach(var item in List)
      {
        sb.AppendLine(GeneratePostgreSQLScriptForSearchParam(item));
      }
     
      return sb.ToString();
    }

    public string GetPostgreSQLQuerySearchParameterTargetResources()
    {
      var List = GetServiceSearchParameterList();
      StringBuilder sb = new StringBuilder();     
      foreach (var item in List)
      {
        string sql = GeneratePostgreSQLScriptForTargetResource(item);
        if (!string.IsNullOrWhiteSpace(sql))
          sb.AppendLine(sql);
      }

      return sb.ToString();
    }

    private string GenerateMicrosoftSQLServerScriptForSearchParam(SearchParam SearchParam)    
    {

      string Resource = SearchParam.Resource;
      string Name = SearchParam.Name;
      string Url = SearchParam.Url;
      string Description = Pyro.DbManager.Tools.StringSupport.EscapePostgreSQL(SearchParam.Description);
      string Type = Convert.ToInt32(SearchParam.Type).ToString();
      string XPath = Pyro.DbManager.Tools.StringSupport.EscapePostgreSQL(SearchParam.XPath);
      string Expression = Pyro.DbManager.Tools.StringSupport.EscapePostgreSQL(SearchParam.Expression);
      string IsIndexed = Pyro.DbManager.Tools.StringSupport.GetBoolToByteString(SearchParam.IsIndexed);
      string Status = Convert.ToInt32(SearchParam.Status).ToString();
      string LastUpdated = Pyro.DbManager.Tools.StringSupport.GetPostgreSQLDateTimeOffSet(SearchParam.LastUpdated);
      string SearchParameterResourceId = SearchParam.SearchParameterResourceId;
      string SearchParameterResourceVersion = SearchParam.SearchParameterResourceVersion;

      string Query = $"INSERT INTO [dbo].[_SearchParam] ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated]) " +
                     $"VALUES ('{Resource}', '{Name}', '{Url}', '{Description}', '{Type}', '{XPath}', '{Expression}', '{IsIndexed}', '{Status}', '{LastUpdated}');";


      return Query;
    }

    private string GeneratePostgreSQLScriptForSearchParam(SearchParam SearchParam)
    {
      string Resource = SearchParam.Resource;
      string Name = SearchParam.Name;
      string Url = SearchParam.Url;
      string Description = Pyro.DbManager.Tools.StringSupport.EscapePostgreSQL(SearchParam.Description);
      string Type = Convert.ToInt32(SearchParam.Type).ToString();
      string XPath = Pyro.DbManager.Tools.StringSupport.EscapePostgreSQL(SearchParam.XPath);
      string Expression = Pyro.DbManager.Tools.StringSupport.EscapePostgreSQL(SearchParam.Expression);
      string IsIndexed = Pyro.DbManager.Tools.StringSupport.GetBoolToByteString(SearchParam.IsIndexed);
      string Status = Convert.ToInt32(SearchParam.Status).ToString();
      string LastUpdated = Pyro.DbManager.Tools.StringSupport.GetPostgreSQLDateTimeOffSet(SearchParam.LastUpdated);
      string SearchParameterResourceId = SearchParam.SearchParameterResourceId;
      string SearchParameterResourceVersion = SearchParam.SearchParameterResourceVersion;

      string Query = $"INSERT INTO public.\"_SearchParam\"(\"Resource\", \"Name\", \"Url\", \"Description\", \"Type\", \"XPath\", \"Expression\", \"IsIndexed\", \"Status\", \"LastUpdated\") " +
                     $"VALUES('{Resource}', '{Name}', '{Url}', '{Description}', '{Type}', '{XPath}', '{Expression}', '{IsIndexed}', '{Status}', '{LastUpdated}');";


      return Query;
    }

    private string GenerateMicrosoftSQLServerScriptForTargetResource(SearchParam SearchParam)
    {
      StringBuilder sb = new StringBuilder();
      if (SearchParam.TargetResourceTypeList.Count > 0)
      {
        StringBuilder Subsb = new StringBuilder();
        foreach (var Res in SearchParam.TargetResourceTypeList)
        {
          string SearchParamResourceName = SearchParam.Resource;
          string TargetResourceInt = Convert.ToInt32(Res.ResourceType).ToString();
          string Name = SearchParam.Name;
          
          string Query =
            "INSERT INTO [dbo].[_SParamResource]([ServiceSearchParameterId], [ResourceType]) " +
            "VALUES ( " +
               $"(SELECT Id FROM [dbo].[_SearchParam] WHERE [Resource] = '{SearchParamResourceName}' and [Name] = '{Name}'), " +
               $"'{TargetResourceInt}' )";

          sb.AppendLine(Query);
        }
      }
      return sb.ToString();
    }

    private string GeneratePostgreSQLScriptForTargetResource(SearchParam SearchParam)
    {
      StringBuilder sb = new StringBuilder();
      if (SearchParam.TargetResourceTypeList.Count > 0)
      {
        StringBuilder Subsb = new StringBuilder();
        foreach (var Res in SearchParam.TargetResourceTypeList)
        {
          string SearchParamResourceName = SearchParam.Resource;
          string TargetResourceInt = Convert.ToInt32(Res.ResourceType).ToString();
          string Name = SearchParam.Name;
          
          string Query =
            "INSERT INTO public.\"_SParamResource\"(" +
            "\"ServiceSearchParameterId\", \"ResourceType\") " +
            "SELECT " +
               "sp.\"Id\", " +
               $"'{TargetResourceInt}' " +
            "FROM " +
            "public.\"_SearchParam\" sp " +
            "WHERE " +
             $"sp.\"Resource\" = '{SearchParamResourceName}' and sp.\"Name\" = '{Name}'; ";

          sb.AppendLine(Query);
        }
      }      
      return sb.ToString();
    }


    private IList<SearchParam> GetServiceSearchParameterList()
    {
      IList<DtoServiceSearchParameter> ServiceSearchParameterList = ServiceSearchParameterFactory.FhirAPISearchParameters();
      var ReturnList = new List<SearchParam>();
      var LastUpdated = DateTimeOffset.Now;
      foreach (var SearchParameter in ServiceSearchParameterList)
      {
        var ServiceSearchParameter = new SearchParam()
        {
          Name = SearchParameter.Name,
          Description = SearchParameter.Description,
          Expression = SearchParameter.Expression,
          Resource = SearchParameter.Resource,
          Type = SearchParameter.Type,
          Url = SearchParameter.Url,
          XPath = SearchParameter.XPath,
          IsIndexed = true,
          LastUpdated = LastUpdated,
          Status = PublicationStatus.Active
        };
        if (SearchParameter.TargetResourceTypeList != null && SearchParameter.TargetResourceTypeList.Count > 0)
        {
          foreach (var ResourceTypeTarget in SearchParameter.TargetResourceTypeList)
            ServiceSearchParameter.TargetResourceTypeList.Add(new SParamResource() { ResourceType = ResourceTypeTarget.ResourceType });
        }
        ReturnList.Add(ServiceSearchParameter);
      }
      return ReturnList;
    }


  }
}
