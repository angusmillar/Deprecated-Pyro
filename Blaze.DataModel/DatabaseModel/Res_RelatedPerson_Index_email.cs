using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_RelatedPerson_Index_email
  {
    public int Res_RelatedPerson_Index_emailID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_RelatedPerson Res_RelatedPerson { get; set; }
   
    public Res_RelatedPerson_Index_email()
    {
    }
  }
}

