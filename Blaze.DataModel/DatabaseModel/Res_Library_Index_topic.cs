using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Library_Index_topic
  {
    public int Res_Library_Index_topicID {get; set;}
    public string Code {get; set;}
    public string System {get; set;}
    public virtual Res_Library Res_Library { get; set; }
   
    public Res_Library_Index_topic()
    {
    }
  }
}

