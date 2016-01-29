using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Hl7.Fhir.Model;
using BusinessEntities;

namespace DataModel.Repository 
{
  public class BaseRepository : Dip.Interfaces.IBaseRepository
  {
    internal BlazeDbContext _Context = null;

    public bool IsCurrentResourceDeleted(string FhirResourceId)
    {
      //if (_Context.Resource.Any(x => x.PatientResource.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == true))
      if (_Context.Resource.Any(x => x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == true))
        return true;
      else
        return false;
    }

    public int LastDeletedResourceVersion(string FhirResourceId)
    {
      return _Context.Resource.SingleOrDefault(x => x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == true).Version;
    }

    public bool ResourceExists(string FhirResourceId)
    {
      //if (_Context.PatientResource.Any(x => x.FhirResourceId == FhirResourceId))
      if (_Context.ResourceIdentity.Any(x => x.FhirResourceId == FhirResourceId))
        return true;
      else
        return false;
    }

    /// <summary>
    /// Save method.
    /// </summary>
    public void Save()
    {
      try
      {
        _Context.SaveChanges();
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
        throw new DtoBlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutCome, outputLines.ToString(), e);
      }
      catch (DbUpdateException Exec)
      {

        var OpOutCome = new OperationOutcome();
        OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
        var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
        OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
        OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
        OpOutComeIssueComp.Diagnostics = Exec.ToString();
        OpOutCome.Issue.Add(OpOutComeIssueComp);
        throw new DtoBlazeException(System.Net.HttpStatusCode.InternalServerError, OpOutCome, Exec.Message, Exec);
      }

    }

  }
}
