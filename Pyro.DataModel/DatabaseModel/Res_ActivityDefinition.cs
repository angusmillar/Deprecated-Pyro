using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ActivityDefinition : ResourceIndexBase
  {
    public int Res_ActivityDefinitionID {get; set;}
    public string description_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string title_String {get; set;}
    public string version_String {get; set;}
    public ICollection<Res_ActivityDefinition_History> Res_ActivityDefinition_History_List { get; set; }
    public ICollection<Res_ActivityDefinition_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_ActivityDefinition_Index_topic> topic_List { get; set; }
    public ICollection<Res_ActivityDefinition_Index__profile> _profile_List { get; set; }
    public ICollection<Res_ActivityDefinition_Index__security> _security_List { get; set; }
    public ICollection<Res_ActivityDefinition_Index__tag> _tag_List { get; set; }
   
    public Res_ActivityDefinition()
    {
      this.identifier_List = new HashSet<Res_ActivityDefinition_Index_identifier>();
      this.topic_List = new HashSet<Res_ActivityDefinition_Index_topic>();
      this._profile_List = new HashSet<Res_ActivityDefinition_Index__profile>();
      this._security_List = new HashSet<Res_ActivityDefinition_Index__security>();
      this._tag_List = new HashSet<Res_ActivityDefinition_Index__tag>();
      this.Res_ActivityDefinition_History_List = new HashSet<Res_ActivityDefinition_History>();
    }
  }
}

