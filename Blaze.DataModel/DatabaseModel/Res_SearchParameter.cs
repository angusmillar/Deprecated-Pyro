using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_SearchParameter : ResourceIndexBase
  {
    public int Res_SearchParameterID {get; set;}
    public string base_Code {get; set;}
    public string base_System {get; set;}
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public string description_String {get; set;}
    public string name_String {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public string url_Uri {get; set;}
    public ICollection<Res_SearchParameter_History> Res_SearchParameter_History_List { get; set; }
    public ICollection<Res_SearchParameter_Index_context> context_List { get; set; }
    public ICollection<Res_SearchParameter_Index_target> target_List { get; set; }
    public ICollection<Res_SearchParameter_Index__profile> _profile_List { get; set; }
    public ICollection<Res_SearchParameter_Index__security> _security_List { get; set; }
    public ICollection<Res_SearchParameter_Index__tag> _tag_List { get; set; }
   
    public Res_SearchParameter()
    {
      this.context_List = new HashSet<Res_SearchParameter_Index_context>();
      this.target_List = new HashSet<Res_SearchParameter_Index_target>();
      this._profile_List = new HashSet<Res_SearchParameter_Index__profile>();
      this._security_List = new HashSet<Res_SearchParameter_Index__security>();
      this._tag_List = new HashSet<Res_SearchParameter_Index__tag>();
      this.Res_SearchParameter_History_List = new HashSet<Res_SearchParameter_History>();
    }
  }
}

