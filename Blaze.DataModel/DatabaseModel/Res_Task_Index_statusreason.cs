using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Task_Index_statusreason : TokenIndex
  {
    public int Res_Task_Index_statusreasonID {get; set;}
    public virtual Res_Task Res_Task { get; set; }
   
    public Res_Task_Index_statusreason()
    {
    }
  }
}

