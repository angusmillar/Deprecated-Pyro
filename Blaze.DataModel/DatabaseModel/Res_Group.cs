using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Group : ResourceIndexBase
  {
    public int Res_GroupID {get; set;}
    public string actual_Code {get; set;}
    public string actual_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Group_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_Group_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_Group_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_Group_History> Res_Group_History_List { get; set; }
    public ICollection<Res_Group_Index_characteristic> characteristic_List { get; set; }
    public ICollection<Res_Group_Index_code> code_List { get; set; }
    public ICollection<Res_Group_Index_exclude> exclude_List { get; set; }
    public ICollection<Res_Group_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Group_Index_member> member_List { get; set; }
    public ICollection<Res_Group_Index_value> value_List { get; set; }
   
    public Res_Group()
    {
      this.characteristic_List = new HashSet<Res_Group_Index_characteristic>();
      this.code_List = new HashSet<Res_Group_Index_code>();
      this.exclude_List = new HashSet<Res_Group_Index_exclude>();
      this.identifier_List = new HashSet<Res_Group_Index_identifier>();
      this.member_List = new HashSet<Res_Group_Index_member>();
      this.value_List = new HashSet<Res_Group_Index_value>();
      this.meta_tag_List = new HashSet<Res_Group_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_Group_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_Group_Index_meta_profile>();
      this.Res_Group_History_List = new HashSet<Res_Group_History>();
    }
  }
}

