using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImagingExcerpt_Index_title
  {
    public int Res_ImagingExcerpt_Index_titleID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_ImagingExcerpt Res_ImagingExcerpt { get; set; }
   
    public Res_ImagingExcerpt_Index_title()
    {
    }
  }
}

