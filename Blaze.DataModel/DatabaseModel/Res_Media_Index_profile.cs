using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Media_Index_profile : UriIndex
  {
    public int Res_Media_Index_profileID {get; set;}
    public virtual Res_Media Res_Media { get; set; }
   
    public Res_Media_Index_profile()
    {
    }
  }
}

