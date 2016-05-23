using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_List_History : ResourceIndexBase
  {
    public int Res_List_HistoryID {get; set;}
    public virtual Res_List Res_List { get; set; }
   
    public Res_List_History()
    {
    }
  }
}

