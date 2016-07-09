using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Composition_Index_period : DatePeriodIndex
  {
    public int Res_Composition_Index_periodID {get; set;}
    public virtual Res_Composition Res_Composition { get; set; }
   
    public Res_Composition_Index_period()
    {
    }
  }
}

