using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_List_Index_empty_reason
  {
    public int Res_List_Index_empty_reasonID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_List Res_List { get; set; }
   
    public Res_List_Index_empty_reason()
    {
    }
  }
}

