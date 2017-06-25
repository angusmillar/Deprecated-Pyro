namespace Pyro.DataLayer.Migrations.DbSeeding
{
  public interface IPyroSeedService
  {
    /// <summary>
    /// A human name for the Seed service for error reporting
    /// </summary>
    string ServiceName { get; }

    /// <summary>
    /// Returns True if the Seed method need to run and false if it is not required.
    /// This is needed as Migrations will run the seeding process or all migrations 
    /// </summary>
    /// <returns>True if Seed() method is required to run</returns>
    bool DoesSeedNeedToRun();

    /// <summary>
    /// Run this database Seed process
    /// </summary>
    void Seed();
  }
}