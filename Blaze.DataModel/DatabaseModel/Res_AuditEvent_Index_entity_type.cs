using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_AuditEvent_Index_entity_type
  {
    public int Res_AuditEvent_Index_entity_typeID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_AuditEvent Res_AuditEvent { get; set; }
   
    public Res_AuditEvent_Index_entity_type()
    {
    }
  }
}

