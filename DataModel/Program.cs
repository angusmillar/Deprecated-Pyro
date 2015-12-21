using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
  class Program
  {
    static void Main(string[] args)
    {
      using(var oDB = new BlazeDbContext())
      {
        try
        {
          oDB.Database.Create();
          Console.WriteLine("Database created successfully.");
          Console.ReadKey();
        }
        catch (Exception Exec)
        {
          Console.WriteLine(Exec.Message);
          Console.ReadKey();
        }

        Model.PatientResource oPatRes = new Model.PatientResource();
        

      }

    }
  }
}
