using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_TestScript : ResourceIndexBase
  {
    public int Res_TestScriptID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string description_String {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string url_Uri {get; set;}
    public ICollection<Res_TestScript_History> Res_TestScript_History_List { get; set; }
    public ICollection<Res_TestScript_Index_testscript_capability> testscript_capability_List { get; set; }
    public ICollection<Res_TestScript_Index_use_context> use_context_List { get; set; }
    public ICollection<Res_TestScript_Index__profile> _profile_List { get; set; }
    public ICollection<Res_TestScript_Index__security> _security_List { get; set; }
    public ICollection<Res_TestScript_Index__tag> _tag_List { get; set; }
   
    public Res_TestScript()
    {
      this.testscript_capability_List = new HashSet<Res_TestScript_Index_testscript_capability>();
      this.use_context_List = new HashSet<Res_TestScript_Index_use_context>();
      this._profile_List = new HashSet<Res_TestScript_Index__profile>();
      this._security_List = new HashSet<Res_TestScript_Index__security>();
      this._tag_List = new HashSet<Res_TestScript_Index__tag>();
      this.Res_TestScript_History_List = new HashSet<Res_TestScript_History>();
    }
  }
}

