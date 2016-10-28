using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_MedicationDispense_Index_responsibleparty : ReferenceIndex
  {
    public int Res_MedicationDispense_Index_responsiblepartyID {get; set;}
    public virtual Res_MedicationDispense Res_MedicationDispense { get; set; }
   
    public Res_MedicationDispense_Index_responsibleparty()
    {
    }
  }
}

