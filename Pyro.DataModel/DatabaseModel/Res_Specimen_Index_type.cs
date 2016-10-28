using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Specimen_Index_type : TokenIndex
  {
    public int Res_Specimen_Index_typeID {get; set;}
    public virtual Res_Specimen Res_Specimen { get; set; }
   
    public Res_Specimen_Index_type()
    {
    }
  }
}

