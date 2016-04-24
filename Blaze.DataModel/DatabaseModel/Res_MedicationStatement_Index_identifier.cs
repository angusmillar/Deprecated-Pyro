using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MedicationStatement_Index_identifier
  {
    public int Res_MedicationStatement_Index_identifierID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_MedicationStatement Res_MedicationStatement { get; set; }
   
    public Res_MedicationStatement_Index_identifier()
    {
    }
  }
}

