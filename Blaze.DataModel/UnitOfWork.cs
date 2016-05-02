using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Blaze.Common.Interfaces.Repositories;
using Blaze.DataModel.Repository;

namespace Blaze.DataModel
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private Blaze.DataModel.DatabaseModel.DatabaseContext _context = null;

    private ResourceRepository _ResourceRepository;
    private PatientRepository _PatientRepository;
    private CommonRepository _CommonRepository;    


    public UnitOfWork()
    {
      _context = new Blaze.DataModel.DatabaseModel.DatabaseContext();
    }


    public IResourceRepository ResourceRepository
    {
      get
      {
        if (this._ResourceRepository == null)
          this._ResourceRepository = new ResourceRepository(_context);
        return _ResourceRepository;
      }
    }

    public IPatientRepository PatientRepository
    {
      get
      {
        if (this._PatientRepository == null)
          this._PatientRepository = new PatientRepository(_context);
        return _PatientRepository;
      }
    }

    public ICommonRepository CommonRepository
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
