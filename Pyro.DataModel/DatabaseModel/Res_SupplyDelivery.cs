using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_SupplyDelivery : ResourceIndexBase
  {
    public int Res_SupplyDeliveryID {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string supplier_VersionId {get; set;}
    public string supplier_FhirId {get; set;}
    public string supplier_Type {get; set;}
    public virtual ServiceRootURL_Store supplier_Url { get; set; }
    public int? supplier_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_SupplyDelivery_History> Res_SupplyDelivery_History_List { get; set; }
    public ICollection<Res_SupplyDelivery_Index_receiver> receiver_List { get; set; }
    public ICollection<Res_SupplyDelivery_Index__profile> _profile_List { get; set; }
    public ICollection<Res_SupplyDelivery_Index__security> _security_List { get; set; }
    public ICollection<Res_SupplyDelivery_Index__tag> _tag_List { get; set; }
   
    public Res_SupplyDelivery()
    {
      this.receiver_List = new HashSet<Res_SupplyDelivery_Index_receiver>();
      this._profile_List = new HashSet<Res_SupplyDelivery_Index__profile>();
      this._security_List = new HashSet<Res_SupplyDelivery_Index__security>();
      this._tag_List = new HashSet<Res_SupplyDelivery_Index__tag>();
      this.Res_SupplyDelivery_History_List = new HashSet<Res_SupplyDelivery_History>();
    }
  }
}

