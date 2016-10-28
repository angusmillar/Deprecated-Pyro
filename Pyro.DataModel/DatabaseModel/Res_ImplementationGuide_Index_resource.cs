using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ImplementationGuide_Index_resource : ReferenceIndex
  {
    public int Res_ImplementationGuide_Index_resourceID {get; set;}
    public virtual Res_ImplementationGuide Res_ImplementationGuide { get; set; }
   
    public Res_ImplementationGuide_Index_resource()
    {
    }
  }
}

