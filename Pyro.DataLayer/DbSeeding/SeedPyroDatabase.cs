//using System;
//using System.Collections.Generic;
//using Pyro.DataLayer.DbModel.DatabaseContext;

//namespace Pyro.DataLayer.DbSeeding
//{
//  public class SeedPyroDatabase
//  {
//    private PyroDbContext _Context;
//    private List<IPyroSeedService> SeedServiceList;
//    public SeedPyroDatabase(PyroDbContext Context)
//    {
//      _Context = Context;
//      SeedServiceList = new List<IPyroSeedService>();
//      SeedServiceList.Add(new PyroSeedServiceSearchParameters(_Context));
//      SeedServiceList.Add(new SeedServiceFhirReleaseSTU301(_Context));      
//    }

//    public void Seed()
//    {
//      foreach (var SeedService in SeedServiceList)
//      {
//        //Console.WriteLine($"Checking Seed Service: {SeedService.ServiceName}");
//        try
//        {
//          if (SeedService.DoesSeedNeedToRun())
//          {
//            Console.WriteLine($"Seed Service: {SeedService.ServiceName} Running.");
//            SeedService.Seed();
//            Console.WriteLine($"Seed Service: {SeedService.ServiceName} Completed.");
//          }
//        }
//        catch (Exception Exec)
//        {
//          throw new Exception($"The Pyro database seed service named {SeedService.ServiceName} has encountered a problem. Seed inner exception for more detail. ", Exec);
//        }
//      }
//    }
//  }
//}
