using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DeviceComponent : ResourceIndexBase
  {
    public int Res_DeviceComponentID {get; set;}
    public string parent_VersionId {get; set;}
    public string parent_FhirId {get; set;}
    public string parent_Type {get; set;}
    public virtual Blaze_RootUrlStore parent_Url { get; set; }
    public int? parent_Url_Blaze_RootUrlStoreID { get; set; }
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Blaze_RootUrlStore source_Url { get; set; }
    public int? source_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_DeviceComponent_History> Res_DeviceComponent_History_List { get; set; }
    public ICollection<Res_DeviceComponent_Index_type> type_List { get; set; }
    public ICollection<Res_DeviceComponent_Index_profile> profile_List { get; set; }
    public ICollection<Res_DeviceComponent_Index_security> security_List { get; set; }
    public ICollection<Res_DeviceComponent_Index_tag> tag_List { get; set; }
   
    public Res_DeviceComponent()
    {
      this.type_List = new HashSet<Res_DeviceComponent_Index_type>();
      this.profile_List = new HashSet<Res_DeviceComponent_Index_profile>();
      this.security_List = new HashSet<Res_DeviceComponent_Index_security>();
      this.tag_List = new HashSet<Res_DeviceComponent_Index_tag>();
      this.Res_DeviceComponent_History_List = new HashSet<Res_DeviceComponent_History>();
    }
  }
}

