using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImagingObjectSelection_Index__profile : UriIndex
  {
    public int Res_ImagingObjectSelection_Index__profileID {get; set;}
    public virtual Res_ImagingObjectSelection Res_ImagingObjectSelection { get; set; }
   
    public Res_ImagingObjectSelection_Index__profile()
    {
    }
  }
}

