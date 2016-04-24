using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Order
  {
    public int Res_OrderID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Aux_RootUrlStore source_Aux_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Aux_RootUrlStore subject_Aux_RootUrlStoreID { get; set; }
    public string target_FhirId {get; set;}
    public string target_Type {get; set;}
    public virtual Aux_RootUrlStore target_Aux_RootUrlStoreID { get; set; }
    public ICollection<Res_Order_Index_detail> detail_List { get; set; }
    public ICollection<Res_Order_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Order_Index_when> when_List { get; set; }
    public ICollection<Res_Order_Index_when_code> when_code_List { get; set; }
   
    public Res_Order()
    {
      this.detail_List = new HashSet<Res_Order_Index_detail>();
      this.identifier_List = new HashSet<Res_Order_Index_identifier>();
      this.when_List = new HashSet<Res_Order_Index_when>();
      this.when_code_List = new HashSet<Res_Order_Index_when_code>();
    }
  }
}

