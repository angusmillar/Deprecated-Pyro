using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MessageHeader_Index_destination_uri
  {
    public int Res_MessageHeader_Index_destination_uriID {get; set;}
    public string Uri {get; set;}
    public virtual Res_MessageHeader Res_MessageHeader { get; set; }
   
    public Res_MessageHeader_Index_destination_uri()
    {
    }
  }
}

