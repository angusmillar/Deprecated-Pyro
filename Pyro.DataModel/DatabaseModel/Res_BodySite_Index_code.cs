using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_BodySite_Index_code : TokenIndex
  {
    public int Res_BodySite_Index_codeID {get; set;}
    public virtual Res_BodySite Res_BodySite { get; set; }
   
    public Res_BodySite_Index_code()
    {
    }
  }
}

