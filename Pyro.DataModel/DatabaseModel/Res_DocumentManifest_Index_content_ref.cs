using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_DocumentManifest_Index_content_ref : ReferenceIndex
  {
    public int Res_DocumentManifest_Index_content_refID {get; set;}
    public virtual Res_DocumentManifest Res_DocumentManifest { get; set; }
   
    public Res_DocumentManifest_Index_content_ref()
    {
    }
  }
}

