using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Provenance_Index_agent : ReferenceIndex
  {
    public int Res_Provenance_Index_agentID {get; set;}
    public virtual Res_Provenance Res_Provenance { get; set; }
   
    public Res_Provenance_Index_agent()
    {
    }
  }
}

