using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Dip.Interfaces.Repositories;

namespace DataModel
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private BlazeDbContext _context = null;

    private Repository.ResourceRepository _ResourceRepository;
    private Repository.PatientRepository _PatientRepository;
    private Repository.ValueSetRepository _ValueSetRepository;
    private Repository.ConceptMapRepository _ConceptMapRepository;

    public UnitOfWork()
    {
      _context = new BlazeDbContext();
    }

    public IResourceRepository ResourceRepository
    {
      get
      {
        if (this._ResourceRepository == null)
          this._ResourceRepository = new Repository.ResourceRepository(_context);
        return _ResourceRepository;
      }
    }
    public IPatientRepository PatientRepository
    {
      get
      {
        if (this._PatientRepository == null)
          this._PatientRepository = new Repository.PatientRepository(_context);
        return _PatientRepository;
      }
    }
    public IValueSetRepository ValueSetRepository
    {
      get
      {
        if (this._ValueSetRepository == null)
          this._ValueSetRepository = new Repository.ValueSetRepository(_context);
        return _ValueSetRepository;
      }
    }
    public IConceptMapRepository ConceptMapRepository
        {
      get
      {
        if (this._ConceptMapRepository == null)
          this._ConceptMapRepository = new Repository.ConceptMapRepository(_context);
        return _ConceptMapRepository;
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
          Debug.WriteLine("UnitOfWork is being disposed");
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
    #endregion

  }
}
