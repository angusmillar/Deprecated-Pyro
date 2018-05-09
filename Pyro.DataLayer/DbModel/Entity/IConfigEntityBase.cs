using System;

namespace Pyro.DataLayer.DbModel.Entity
{
  public interface IConfigEntityBase
  {
    DateTimeOffset CreatedDate { get; set; }
    string CreatedUser { get; set; }
    DateTimeOffset LastUpdated { get; set; }
    string LastUpdatedUser { get; set; }
  }
}