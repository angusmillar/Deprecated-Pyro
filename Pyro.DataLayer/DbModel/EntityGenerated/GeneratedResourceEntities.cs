using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.EntityBase;

//To be generated

namespace Pyro.DataLayer.DbModel.EntityGenerated
{
  public class PatientRes : ResourceCurrentBase<PatientRes, PatientResIndex> { }  
  public class PatientResIndex : ResourceIndexBase
  {
    public virtual PatientRes Patient { get; set; }
    public PatientResIndex() { }
  }

  public class ObservationRes : ResourceCurrentBase<ObservationRes, ObservationResIndex> { }  
  public class ObservationResIndex : ResourceIndexBase
  {
    public virtual ObservationRes Observation { get; set; }
    public ObservationResIndex() { }
  }
}
