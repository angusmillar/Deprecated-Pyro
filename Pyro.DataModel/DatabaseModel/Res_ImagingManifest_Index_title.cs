using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_ImagingManifest_Index_title : TokenIndex
  {
    public int Res_ImagingManifest_Index_titleID {get; set;}
    public virtual Res_ImagingManifest Res_ImagingManifest { get; set; }
   
    public Res_ImagingManifest_Index_title()
    {
    }
  }
}

