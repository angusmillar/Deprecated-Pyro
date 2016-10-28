using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;
using System.Data.SqlClient;
using Hl7.Fhir.Model;
//using Pyro.DataModel.Repository;

namespace Pyro.Engine.CustomException
{
  public static class SqlExceptionSupport
  {
    public static DtoPyroException GenerateDtoPyroException(SqlException SqlException, bool DebuggerAttached = false)
    {      
      var OpOutCome = new OperationOutcome();
      OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
      var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
      OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
      OpOutComeIssueComp.Code = ResolveIssueType(SqlException.Number);
      if (DebuggerAttached)
        OpOutComeIssueComp.Diagnostics = SqlException.Message;
      else
        OpOutComeIssueComp.Diagnostics = ResolveDiagnosticsText(SqlException.Number);
      OpOutCome.Issue.Add(OpOutComeIssueComp);
      return new DtoPyroException(ResolveHttpStatusCode(SqlException.Number), OpOutCome, SqlException.Message, SqlException);
    }

    private static string ResolveDiagnosticsText(int SqlErrorNumber)
    {
      switch (SqlErrorNumber)
      {
        case -2:
          return "The SQL data base timed out while executing the request.";
        default:
          return "There has been an SQL server error.";
      }
    }

    private static OperationOutcome.IssueType? ResolveIssueType(int SqlErrorNumber)
    {
      switch (SqlErrorNumber)
      {
        case -2:
          return OperationOutcome.IssueType.Timeout;
        default:
             return OperationOutcome.IssueType.Exception;
      }
    }

    private static System.Net.HttpStatusCode ResolveHttpStatusCode(int SqlErrorNumber)
    {
      switch (SqlErrorNumber)
      {
        case -2:
          return System.Net.HttpStatusCode.RequestTimeout;
        default:
          return System.Net.HttpStatusCode.InternalServerError;
      }
    }
  }
}
