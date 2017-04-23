﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Pyro.Common.Interfaces.Repositories;
using Pyro.DataLayer.Repository;
using Pyro.DataLayer.DbModel.EntityGenerated;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.DbModel.UnitOfWork
{  
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private bool _Transactional = false;
    private System.Data.Entity.DbContextTransaction _Trans;

    public void BeginTransaction()
    {
      try
      {
        _Trans = _context.Database.BeginTransaction();
      }
      catch (Exception Exec)
      {
        var Test = Exec.Message;
      }
      _Transactional = true;
    }
    public void CommitTransaction()
    {
      try
      {
        _Trans.Commit();
      }
      catch
      {
        _Trans.Rollback();
        throw new NotImplementedException();

      }
      finally
      {
        _Trans.Dispose();
        _Transactional = false;
      }
    }
    public void RollbackTransaction()
    {
      try
      {
        _Trans.Rollback();
      }
      finally
      {
        _Trans.Dispose();
        _Transactional = false;
      }
    }
    public bool IsTransactional
    {
      get
      {
        return _Transactional;
      }
    }

    private Pyro.DataLayer.DbModel.DatabaseContext.PyroDbContext _context = null;

    private CommonRepository _CommonRepository;    
    private CommonResourceRepository<PatientRes, PatientResIndex> _PatientRepository;
    private CommonResourceRepository<ObservationRes, ObservationResIndex> _ObservationRepository;

    
    public UnitOfWork()
    {
      _context = new Pyro.DataLayer.DbModel.DatabaseContext.PyroDbContext();
    }

    public IDtoCommonRepository CommonRepository
    {
      get
      {
        if (this._CommonRepository == null)
          this._CommonRepository = new CommonRepository(_context);
        return _CommonRepository;
      }
    }
    
    public IResourceRepository PatientRepository
    {
      get
      {
        if (this._PatientRepository == null)
          this._PatientRepository = new CommonResourceRepository<PatientRes, PatientResIndex>(_context, FHIRAllTypes.Patient);
        return _PatientRepository;
      }
    }
    public IResourceRepository ObservationRepository
    {
      get
      {
        if (this._ObservationRepository == null)
          this._ObservationRepository = new CommonResourceRepository<ObservationRes, ObservationResIndex>(_context, FHIRAllTypes.Observation);
        return _ObservationRepository;
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
    #endregion

  }
}
