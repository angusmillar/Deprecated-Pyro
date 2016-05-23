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
    public string parent_FhirId {get; set;}
    public string parent_Type {get; set;}
    public virtual Blaze_RootUrlStore parent_Url { get; set; }
    public int? parent_Url_Blaze_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Blaze_RootUrlStore source_Url { get; set; }
    public int? source_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_DeviceComponent_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_DeviceComponent_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_DeviceComponent_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_DeviceComponent_History> Res_DeviceComponent_History_List { get; set; }
    public ICollection<Res_DeviceComponent_Index_type> type_List { get; set; }
   
    public Res_DeviceComponent()
    {
      this.type_List = new HashSet<Res_DeviceComponent_Index_type>();
      this.meta_tag_List = new HashSet<Res_DeviceComponent_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_DeviceComponent_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_DeviceComponent_Index_meta_profile>();
      this.Res_DeviceComponent_History_List = new HashSet<Res_DeviceComponent_History>();
    }
  }
}

