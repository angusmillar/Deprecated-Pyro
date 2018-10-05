using System;

namespace Pyro.DataLayer.DbModel.Entity
{
  public interface IConfigEntityBase
  {
    DateTime CreatedDate { get; set; }
    string CreatedUser { get; set; }
    DateTime LastUpdated { get; set; }
    string LastUpdatedUser { get; set; }
  }
}