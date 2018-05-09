using Pyro.DataLayer.DbModel.EntityBase;
using System;

namespace Pyro.DataLayer.DbModel.Entity
{
  public partial class _FhirRelease : ConfigEntityBase, IConfigEntityBase, IModelBase
  {    
    public string FhirVersion { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
  }
}
