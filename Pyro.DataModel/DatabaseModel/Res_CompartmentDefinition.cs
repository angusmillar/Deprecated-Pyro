using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_CompartmentDefinition : ResourceIndexBase
  {
    public int Res_CompartmentDefinitionID {get; set;}
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string name_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string url_Uri {get; set;}
    public ICollection<Res_CompartmentDefinition_History> Res_CompartmentDefinition_History_List { get; set; }
    public ICollection<Res_CompartmentDefinition_Index_resource> resource_List { get; set; }
    public ICollection<Res_CompartmentDefinition_Index__profile> _profile_List { get; set; }
    public ICollection<Res_CompartmentDefinition_Index__security> _security_List { get; set; }
    public ICollection<Res_CompartmentDefinition_Index__tag> _tag_List { get; set; }
   
    public Res_CompartmentDefinition()
    {
      this.resource_List = new HashSet<Res_CompartmentDefinition_Index_resource>();
      this._profile_List = new HashSet<Res_CompartmentDefinition_Index__profile>();
      this._security_List = new HashSet<Res_CompartmentDefinition_Index__security>();
      this._tag_List = new HashSet<Res_CompartmentDefinition_Index__tag>();
      this.Res_CompartmentDefinition_History_List = new HashSet<Res_CompartmentDefinition_History>();
    }
  }
}

