using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.DtoEntity;
using System.Data.SqlClient;
using Hl7.Fhir.Model;

namespace Pyro.Common.Exceptions
{
  public static class SqlExceptionSupport
  {
    public static PyroException GenerateDtoPyroException(SqlException SqlException, bool DebuggerAttached = false)
    {
      OperationOutcome OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, ResolveIssueType(SqlException.Number), "SQL Exception has occurred, see diagnostics for exception message.");
      if (DebuggerAttached)
        OpOutCome.Issue[0].Diagnostics = SqlException.Message;
      else
        OpOutCome.Issue[0].Diagnostics = ResolveDiagnosticsText(SqlException.Number);
      return new PyroException(ResolveHttpStatusCode(SqlException.Number), OpOutCome, SqlException.Message, SqlException);
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
