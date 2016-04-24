using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_NutritionOrder_Index_oraldiet
  {
    public int Res_NutritionOrder_Index_oraldietID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_NutritionOrder Res_NutritionOrder { get; set; }
   
    public Res_NutritionOrder_Index_oraldiet()
    {
    }
  }
}

