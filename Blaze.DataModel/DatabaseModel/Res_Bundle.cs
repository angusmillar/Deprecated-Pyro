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
    public ICollection<Res_Bundle_Index_profile> profile_List { get; set; }
    public ICollection<Res_Bundle_Index_security> security_List { get; set; }
    public ICollection<Res_Bundle_Index_tag> tag_List { get; set; }
   
    public Res_Bundle()
    {
      this.profile_List = new HashSet<Res_Bundle_Index_profile>();
      this.security_List = new HashSet<Res_Bundle_Index_security>();
      this.tag_List = new HashSet<Res_Bundle_Index_tag>();
      this.Res_Bundle_History_List = new HashSet<Res_Bundle_History>();
    }
  }
}

