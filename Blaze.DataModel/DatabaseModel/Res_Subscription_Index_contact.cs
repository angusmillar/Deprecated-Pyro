using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Subscription_Index_contact
  {
    public int Res_Subscription_Index_contactID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Subscription Res_Subscription { get; set; }
   
    public Res_Subscription_Index_contact()
    {
    }
  }
}

