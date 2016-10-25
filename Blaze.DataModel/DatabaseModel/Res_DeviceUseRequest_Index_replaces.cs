using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DeviceUseRequest_Index_replaces : ReferenceIndex
  {
    public int Res_DeviceUseRequest_Index_replacesID {get; set;}
    public virtual Res_DeviceUseRequest Res_DeviceUseRequest { get; set; }
   
    public Res_DeviceUseRequest_Index_replaces()
    {
    }
  }
}

