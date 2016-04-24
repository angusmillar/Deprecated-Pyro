using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Account
  {
    public int Res_AccountID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public decimal? balance_Quantity {get; set;}
    public string balance_System {get; set;}
    public string balance_Code {get; set;}
    public string name_String {get; set;}
    public string owner_FhirId {get; set;}
    public string owner_Type {get; set;}
    public virtual Aux_RootUrlStore owner_Aux_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public DateTimeOffset? period_DateTimeOffset {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Aux_RootUrlStore subject_Aux_RootUrlStoreID { get; set; }
    public ICollection<Res_Account_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Account_Index_type> type_List { get; set; }
   
    public Res_Account()
    {
      this.identifier_List = new HashSet<Res_Account_Index_identifier>();
      this.type_List = new HashSet<Res_Account_Index_type>();
    }
  }
}

