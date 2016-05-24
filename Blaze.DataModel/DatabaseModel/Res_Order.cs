using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Order : ResourceIndexBase
  {
    public int Res_OrderID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Blaze_RootUrlStore source_Url { get; set; }
    public int? source_Url_Blaze_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public string target_FhirId {get; set;}
    public string target_Type {get; set;}
    public virtual Blaze_RootUrlStore target_Url { get; set; }
    public int? target_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Order_History> Res_Order_History_List { get; set; }
    public ICollection<Res_Order_Index_detail> detail_List { get; set; }
    public ICollection<Res_Order_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Order_Index_when> when_List { get; set; }
    public ICollection<Res_Order_Index_when_code> when_code_List { get; set; }
    public ICollection<Res_Order_Index_profile> profile_List { get; set; }
    public ICollection<Res_Order_Index_security> security_List { get; set; }
    public ICollection<Res_Order_Index_tag> tag_List { get; set; }
   
    public Res_Order()
    {
      this.detail_List = new HashSet<Res_Order_Index_detail>();
      this.identifier_List = new HashSet<Res_Order_Index_identifier>();
      this.when_List = new HashSet<Res_Order_Index_when>();
      this.when_code_List = new HashSet<Res_Order_Index_when_code>();
      this.profile_List = new HashSet<Res_Order_Index_profile>();
      this.security_List = new HashSet<Res_Order_Index_security>();
      this.tag_List = new HashSet<Res_Order_Index_tag>();
      this.Res_Order_History_List = new HashSet<Res_Order_History>();
    }
  }
}

