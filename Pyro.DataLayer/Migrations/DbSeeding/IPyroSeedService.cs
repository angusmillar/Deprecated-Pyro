namespace Pyro.DataLayer.Migrations.DbSeeding
{
  public interface IPyroSeedService
  {
    string ServiceName { get; }
    bool DoesSeedNeedToRun();
    void Seed();
  }
}