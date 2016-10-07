using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ModuleDefinition : ResourceIndexBase
  {
    public int Res_ModuleDefinitionID {get; set;}
    public ICollection<Res_ModuleDefinition_History> Res_ModuleDefinition_History_List { get; set; }
    public ICollection<Res_ModuleDefinition_Index__profile> _profile_List { get; set; }
    public ICollection<Res_ModuleDefinition_Index__security> _security_List { get; set; }
    public ICollection<Res_ModuleDefinition_Index__tag> _tag_List { get; set; }
   
    public Res_ModuleDefinition()
    {
      this._profile_List = new HashSet<Res_ModuleDefinition_Index__profile>();
      this._security_List = new HashSet<Res_ModuleDefinition_Index__security>();
      this._tag_List = new HashSet<Res_ModuleDefinition_Index__tag>();
      this.Res_ModuleDefinition_History_List = new HashSet<Res_ModuleDefinition_History>();
    }
  }
}

