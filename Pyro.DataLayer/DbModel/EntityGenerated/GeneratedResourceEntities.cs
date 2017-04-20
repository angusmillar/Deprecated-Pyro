using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.EntityBase;

namespace Pyro.DataLayer.DbModel.EntityGenerated
{
  public class PatientRes : ResourceCurrentBase<PatientRes, PatientResHistory, PatientResIndex> { }
  public class PatientResHistory : ResourceHistoryBase<PatientRes> { }
  public class PatientResIndex : ResourceIndexBase
  {
    public virtual PatientRes Patient { get; set; }
    public PatientResIndex() { }
  }

  public class ObservationRes : ResourceCurrentBase<ObservationRes, ObservationResHistory, ObservationResIndex> { }
  public class ObservationResHistory : ResourceHistoryBase<ObservationRes> { }
  public class ObservationResIndex : ResourceIndexBase
  {
    public virtual ObservationRes Observation { get; set; }
    public ObservationResIndex() { }
  }
}
