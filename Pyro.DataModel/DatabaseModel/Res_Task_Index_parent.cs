using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Task_Index_parent : ReferenceIndex
  {
    public int Res_Task_Index_parentID {get; set;}
    public virtual Res_Task Res_Task { get; set; }
   
    public Res_Task_Index_parent()
    {
    }
  }
}

