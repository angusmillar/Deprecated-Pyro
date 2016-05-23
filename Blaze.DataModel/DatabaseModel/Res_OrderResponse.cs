using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OrderResponse : ResourceIndexBase
  {
    public int Res_OrderResponseID {get; set;}
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string request_FhirId {get; set;}
    public string request_Type {get; set;}
    public virtual Blaze_RootUrlStore request_Url { get; set; }
    public int? request_Url_Blaze_RootUrlStoreID { get; set; }
    public string who_FhirId {get; set;}
    public string who_Type {get; set;}
    public virtual Blaze_RootUrlStore who_Url { get; set; }
    public int? who_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_OrderResponse_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_OrderResponse_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_OrderResponse_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_OrderResponse_History> Res_OrderResponse_History_List { get; set; }
    public ICollection<Res_OrderResponse_Index_fulfillment> fulfillment_List { get; set; }
    public ICollection<Res_OrderResponse_Index_identifier> identifier_List { get; set; }
   
    public Res_OrderResponse()
    {
      this.fulfillment_List = new HashSet<Res_OrderResponse_Index_fulfillment>();
      this.identifier_List = new HashSet<Res_OrderResponse_Index_identifier>();
      this.meta_tag_List = new HashSet<Res_OrderResponse_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_OrderResponse_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_OrderResponse_Index_meta_profile>();
      this.Res_OrderResponse_History_List = new HashSet<Res_OrderResponse_History>();
    }
  }
}

