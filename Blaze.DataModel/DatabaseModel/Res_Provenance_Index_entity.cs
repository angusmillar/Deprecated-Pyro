using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Provenance_Index_entity
  {
    public int Res_Provenance_Index_entityID {get; set;}
    public string Uri {get; set;}
    public virtual Res_Provenance Res_Provenance { get; set; }
   
    public Res_Provenance_Index_entity()
    {
    }
  }
}

