using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Dip.Interfaces;

namespace DataModel
{
  public class UnitOfWork : Dip.Interfaces.IUnitOfWork, IDisposable
  {
    private BlazeDbContext _context = null;

    private Repository.PatientRepository _PatientRepository;

    public UnitOfWork()
    {
      _context = new BlazeDbContext();
    }

    public Dip.Interfaces.IPatientRepository PatientRepository
    {
      get
      {
        if (this._PatientRepository == null)
          this._PatientRepository = new Repository.PatientRepository(_context);
        return _PatientRepository;
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
