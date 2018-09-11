namespace Pyro.Common.Interfaces.Repositories
{
  public interface IMigrationHistoryRepository
  {
    bool CheckMigrationsPerformed();
  }
}