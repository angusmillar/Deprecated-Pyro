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
    public ICollection<Res_ModuleDefinition_Index_profile> profile_List { get; set; }
    public ICollection<Res_ModuleDefinition_Index_security> security_List { get; set; }
    public ICollection<Res_ModuleDefinition_Index_tag> tag_List { get; set; }
   
    public Res_ModuleDefinition()
    {
      this.profile_List = new HashSet<Res_ModuleDefinition_Index_profile>();
      this.security_List = new HashSet<Res_ModuleDefinition_Index_security>();
      this.tag_List = new HashSet<Res_ModuleDefinition_Index_tag>();
      this.Res_ModuleDefinition_History_List = new HashSet<Res_ModuleDefinition_History>();
    }
  }
}

