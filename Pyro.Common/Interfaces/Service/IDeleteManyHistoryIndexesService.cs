namespace Pyro.Common.Interfaces.Service
{
  public interface IDeleteHistoryIndexesService
  {
    IResourceServiceOutcome DeleteMany();
    IResourceServiceOutcome DeleteSingle();
  }
}