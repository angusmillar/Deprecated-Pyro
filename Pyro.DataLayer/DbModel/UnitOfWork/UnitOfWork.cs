using Hl7.Fhir.Model;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Interfaces.Repositories;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.DataLayer.Repository;
using System;
using System.Data.Entity;

namespace Pyro.DataLayer.DbModel.UnitOfWork
{
  public partial class UnitOfWork : IUnitOfWork, IDisposable
  {
    private IPyroDbContext _context = null;
    private IResourceRepositoryFactory IResourceRepositoryFactory;

    public UnitOfWork(IPyroDbContext PyroDbContext, IResourceRepositoryFactory IResourceRepositoryFactory)
    {
      _context = PyroDbContext;
      this.IResourceRepositoryFactory = IResourceRepositoryFactory;
    }

    public DbContextTransaction BeginTransaction()
    {
      try
      {
        return _context.BeginTransaction();
      }
      catch (Exception Exec)
      {
        string Message = Exec.Message;
        throw new Pyro.Common.BusinessEntities.Dto.DtoPyroException(System.Net.HttpStatusCode.InternalServerError,
          Pyro.Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Message), Message);
      }
    }

    private CommonRepository _CommonRepository;

    public IDtoCommonRepository CommonRepository
    {
      get
      {
        if (this._CommonRepository == null)
          this._CommonRepository = new CommonRepository(_context);
        return _CommonRepository;
      }
    }

    #region Implementing IDiosposable...

    #region private dispose variable declaration...
    private bool disposed = false;
    #endregion

    /// <summary>
    /// Protected Virtual Dispose method
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this.disposed = true;
    }

    /// <summary>
    /// Dispose method
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    ~UnitOfWork() // the finalizer
    {
      Dispose(false);
    }
    #endregion

  }
}

