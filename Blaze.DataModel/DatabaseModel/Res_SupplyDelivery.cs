using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_SupplyDelivery : ResourceIndexBase
  {
    public int Res_SupplyDeliveryID {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string supplier_FhirId {get; set;}
    public string supplier_Type {get; set;}
    public virtual Blaze_RootUrlStore supplier_Url { get; set; }
    public int? supplier_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_SupplyDelivery_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_SupplyDelivery_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_SupplyDelivery_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_SupplyDelivery_History> Res_SupplyDelivery_History_List { get; set; }
    public ICollection<Res_SupplyDelivery_Index_receiver> receiver_List { get; set; }
   
    public Res_SupplyDelivery()
    {
      this.receiver_List = new HashSet<Res_SupplyDelivery_Index_receiver>();
      this.meta_tag_List = new HashSet<Res_SupplyDelivery_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_SupplyDelivery_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_SupplyDelivery_Index_meta_profile>();
      this.Res_SupplyDelivery_History_List = new HashSet<Res_SupplyDelivery_History>();
    }
  }
}

