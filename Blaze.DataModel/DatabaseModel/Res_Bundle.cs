using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Bundle : ResourceIndexBase
  {
    public int Res_BundleID {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Bundle_History> Res_Bundle_History_List { get; set; }
    public ICollection<Res_Bundle_Index_composition> composition_List { get; set; }
    public ICollection<Res_Bundle_Index_message> message_List { get; set; }
    public ICollection<Res_Bundle_Index_profile> profile_List { get; set; }
    public ICollection<Res_Bundle_Index_security> security_List { get; set; }
    public ICollection<Res_Bundle_Index_tag> tag_List { get; set; }
   
    public Res_Bundle()
    {
      this.composition_List = new HashSet<Res_Bundle_Index_composition>();
      this.message_List = new HashSet<Res_Bundle_Index_message>();
      this.profile_List = new HashSet<Res_Bundle_Index_profile>();
      this.security_List = new HashSet<Res_Bundle_Index_security>();
      this.tag_List = new HashSet<Res_Bundle_Index_tag>();
      this.Res_Bundle_History_List = new HashSet<Res_Bundle_History>();
    }
  }
}

