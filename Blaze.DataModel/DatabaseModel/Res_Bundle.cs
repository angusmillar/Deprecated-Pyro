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
    public ICollection<Res_Bundle_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_Bundle_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_Bundle_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_Bundle_History> Res_Bundle_History_List { get; set; }
    public ICollection<Res_Bundle_Index_composition> composition_List { get; set; }
    public ICollection<Res_Bundle_Index_message> message_List { get; set; }
   
    public Res_Bundle()
    {
      this.composition_List = new HashSet<Res_Bundle_Index_composition>();
      this.message_List = new HashSet<Res_Bundle_Index_message>();
      this.meta_tag_List = new HashSet<Res_Bundle_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_Bundle_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_Bundle_Index_meta_profile>();
      this.Res_Bundle_History_List = new HashSet<Res_Bundle_History>();
    }
  }
}

