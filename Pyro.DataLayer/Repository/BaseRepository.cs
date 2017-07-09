using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.Repositories;
using Pyro.DataLayer.DbModel.DatabaseContext;

namespace Pyro.DataLayer.Repository
{
  public class BaseRepository : IBaseRepository
  {
    internal IPyroDbContext IPyroDbContext = null;

    public BaseRepository(IPyroDbContext IPyroDbContext)
    {
      this.IPyroDbContext = IPyroDbContext;
    }

    protected int _NumberOfRecordsPerPage = 10;
    protected int _MaxNumberOfRecordsPerPage = 100;

    /// <summary>
    /// Save method.
    /// </summary>
    public void Save()
    {
      try
      {
        IPyroDbContext.SaveChanges();
      }
      catch (DbEntityValidationException e)
      {
        var outputLines = new StringBuilder();
        foreach (var eve in e.EntityValidationErrors)
        {
          outputLines.AppendLine(string.Format(
              "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
              eve.Entry.Entity.GetType().Name, eve.Entry.State));
          foreach (var ve in eve.ValidationErrors)
          {
            outputLines.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
          }
        }
        //System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

        var OpOutCome = new OperationOutcome();
        OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = outputLines.ToString();
        OpOutCome.Issue.Add(OpOutComeIssueComp);
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutCome, outputLines.ToString(), e);
      }
      catch (DbUpdateException Exec)
      {
        if (Exec.InnerException != null && Exec.InnerException.InnerException != null &&
        Exec.InnerException.InnerException is System.Data.SqlClient.SqlException)
        {
          throw Exec.InnerException.InnerException;
        }
        var OpOutCome = new OperationOutcome();
        OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = Exec.InnerException.InnerException.ToString();
        OpOutCome.Issue.Add(OpOutComeIssueComp);
        throw new DtoPyroException(System.Net.HttpStatusCode.InternalServerError, OpOutCome, Exec.InnerException.InnerException.Message, Exec);
      }
    }
  }
}
