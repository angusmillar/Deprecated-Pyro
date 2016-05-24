using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Parameters : ResourceIndexBase
  {
    public int Res_ParametersID {get; set;}
    public ICollection<Res_Parameters_History> Res_Parameters_History_List { get; set; }
    public ICollection<Res_Parameters_Index_profile> profile_List { get; set; }
    public ICollection<Res_Parameters_Index_security> security_List { get; set; }
    public ICollection<Res_Parameters_Index_tag> tag_List { get; set; }
   
    public Res_Parameters()
    {
      this.profile_List = new HashSet<Res_Parameters_Index_profile>();
      this.security_List = new HashSet<Res_Parameters_Index_security>();
      this.tag_List = new HashSet<Res_Parameters_Index_tag>();
      this.Res_Parameters_History_List = new HashSet<Res_Parameters_History>();
    }
  }
}

