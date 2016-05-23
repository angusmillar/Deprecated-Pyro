using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DocumentReference_Index_facility : TokenIndex
  {
    public int Res_DocumentReference_Index_facilityID {get; set;}
    public virtual Res_DocumentReference Res_DocumentReference { get; set; }
   
    public Res_DocumentReference_Index_facility()
    {
    }
  }
}

