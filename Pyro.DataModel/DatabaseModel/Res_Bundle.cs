using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Bundle : ResourceIndexBase
  {
    public int Res_BundleID {get; set;}
    public string composition_VersionId {get; set;}
    public string composition_FhirId {get; set;}
    public string composition_Type {get; set;}
    public virtual ServiceRootURL_Store composition_Url { get; set; }
    public int? composition_ServiceRootURL_StoreID { get; set; }
    public string message_VersionId {get; set;}
    public string message_FhirId {get; set;}
    public string message_Type {get; set;}
    public virtual ServiceRootURL_Store message_Url { get; set; }
    public int? message_ServiceRootURL_StoreID { get; set; }
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Bundle_History> Res_Bundle_History_List { get; set; }
    public ICollection<Res_Bundle_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Bundle_Index__security> _security_List { get; set; }
    public ICollection<Res_Bundle_Index__tag> _tag_List { get; set; }
   
    public Res_Bundle()
    {
      this._profile_List = new HashSet<Res_Bundle_Index__profile>();
      this._security_List = new HashSet<Res_Bundle_Index__security>();
      this._tag_List = new HashSet<Res_Bundle_Index__tag>();
      this.Res_Bundle_History_List = new HashSet<Res_Bundle_History>();
    }
  }
}

