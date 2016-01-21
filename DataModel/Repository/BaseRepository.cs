using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace DataModel.Repository 
{
  public class BaseRepository : Dip.Interfaces.IBaseRepository
  {
    internal BlazeDbContext _Context = null;
    
    /// <summary>
    /// Save method.
    /// </summary>
    public void Save()
    {
      try
      {
        _Context.SaveChanges();
      }
      catch (DbEntityValidationException e)
      {

        var outputLines = new List<string>();
        foreach (var eve in e.EntityValidationErrors)
        {
          outputLines.Add(string.Format(
              "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
              eve.Entry.Entity.GetType().Name, eve.Entry.State));
          foreach (var ve in eve.ValidationErrors)
          {
            outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
          }
        }
        System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

        throw e;
      }
      catch (Exception Exec)
      {
        string test = Exec.Message;
      }

    }

  }
}
