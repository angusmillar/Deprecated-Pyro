using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DeviceUseStatement_Index_tag : TokenIndex
  {
    public int Res_DeviceUseStatement_Index_tagID {get; set;}
    public virtual Res_DeviceUseStatement Res_DeviceUseStatement { get; set; }
   
    public Res_DeviceUseStatement_Index_tag()
    {
    }
  }
}

