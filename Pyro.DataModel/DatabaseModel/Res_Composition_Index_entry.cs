using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Composition_Index_entry : ReferenceIndex
  {
    public int Res_Composition_Index_entryID {get; set;}
    public virtual Res_Composition Res_Composition { get; set; }
   
    public Res_Composition_Index_entry()
    {
    }
  }
}

